using Mapster;
using RMSHOP.DAL.DTO.Request.Products;
using RMSHOP.DAL.DTO.Response.Products;
using RMSHOP.DAL.Models;
using RMSHOP.DAL.Repository.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.BLL.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        public ProductService(IProductRepository productRepository, IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }
        public async Task<ProductResponse> CreateProductAsync(ProductRequest request)
        {
            var product = request.Adapt<Product>();
            if(request.MainImage != null)
            {
                var fileName= await _fileService.UploadAsync(request.MainImage);
                product.MainImage = fileName;
            }
            var result= await _productRepository.CreateProductAsync(product);
            return result.Adapt<ProductResponse>();
        }

        public async Task<List<ProductResponse>> GetAllAsync()
        {
             var response= await _productRepository.GetAllAsync();
             return response.Adapt<List<ProductResponse>>();
        }
    }
}
