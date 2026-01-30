using Mapster;
using Microsoft.AspNetCore.Identity;
using RMSHOP.DAL.DTO.Request.Review;
using RMSHOP.DAL.DTO.Response;
using RMSHOP.DAL.Models;
using RMSHOP.DAL.Models.review;
using RMSHOP.DAL.Repository.Orders;
using RMSHOP.DAL.Repository.Products;
using RMSHOP.DAL.Repository.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.BLL.Service.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ReviewService(IReviewRepository reviewRepository, UserManager<ApplicationUser> userManager
            , IProductRepository productRepository
            ,IOrderRepository orderRepository)
        {
            _reviewRepository = reviewRepository;
            _userManager = userManager;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public async Task<BaseResponse> AddReviewAsync(string userId, int productId, ReviewRequest request)
        {
            var user= await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                //404
                return new BaseResponse()
                {
                     Success = false,
                     Message="User Not Found"
                };
            }

            if(await _userManager.IsLockedOutAsync(user))
            {
                return new BaseResponse()
                {
                    Success = false,
                    Message = "User is Blocked"
                };
            }
            var product = await _productRepository.FindProductById(productId);
            if (product is null)
            {
                //404
                return new BaseResponse()
                {
                    Success = false,
                    Message = "Product Not Found"
                };
            }

            //حالات الايرور 
            //هل هاد اليوزر كان عامل اوردر لهاد المنتج ووصله ؟
            //هل هاد اليوزر معلق من قبل على هاد المنتج ؟

            if(!await _orderRepository.HasDeleveredOrderForThisUserForThisProduct(userId, productId))
            {
                //400
                return new BaseResponse()
                {
                    Success = false,
                    Message = "You Should buy this product and delevered you then you can add review "
                };
            }
            if(await _reviewRepository.HasUserReviewedProduct(userId, productId))
            {
                //400
                return new BaseResponse()
                {
                    Success = false,
                    Message = "You have already reviewed this product. You cannot submit another review."
                };
            }

            var response = request.Adapt<Review>();
            response.UserId= userId;
            response.ProductId= productId;
            await _reviewRepository.AddReviewAsync(response);
            //200
            return new BaseResponse()
            {
                 Success= true,
                 Message="Review Added Successfully"
            };
        }
    }
}
