using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using RMSHOP.BLL.Service.Products;
using RMSHOP.BLL.Service.Reviews;
using RMSHOP.DAL.DTO.Request.Review;
using RMSHOP.DAL.DTO.Response;
using RMSHOP.DAL.DTO.Response.Products;
using RMSHOP.PL.Resources;
using System.Security.Claims;

namespace RMSHOP.PL.Areas.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IReviewService _reviewService;

        public ProductsController(IProductService productService ,IStringLocalizer<SharedResource> localizer
            ,IReviewService reviewService)
        {
            _productService = productService;
            _localizer = localizer;
            _reviewService = reviewService;
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetAllProductsByCategoryForUser([FromRoute] int id,[FromQuery] string lang="en")
        {
            var response= await _productService.GetAllProductsByCategoryForUserAsync(id,lang);
            return Ok(new { message = _localizer["Success"].Value, products=response });
        }


        [HttpGet("")]
        public async Task<IActionResult> Index(
            [FromQuery] string lang = "en",
            [FromQuery] string? search=null,
            [FromQuery] int? categoryId=null,
            [FromQuery] decimal? minPrice= null,
            [FromQuery] decimal? maxPrice=null,
            [FromQuery] string? sortBy=null,
            [FromQuery] bool asc=true,
            [FromQuery] int page=1, [FromQuery] int limit=3)
        {
            var response= await _productService.GetAllForUserAsync(lang, search ,page,limit, categoryId,minPrice,maxPrice,sortBy,asc);
            return Ok(new {message= _localizer["Success"].Value ,response });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails([FromRoute] int id,[FromQuery] string lang="en")
        {
            var response= await _productService.GetProductDetailsForUserAsync(id,lang);
            return Ok(new {message = _localizer["Success"].Value, product = response});
        }


        [HttpPost("addReview/product/{productId}")]
        [Authorize]
        public async Task<IActionResult> AddReview([FromRoute] int productId,[FromBody] ReviewRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _reviewService.AddReviewAsync(userId,productId,request);
            if (!response.Success)
            {
                if (response.Message.Contains("Not Found"))
                {
                    //404
                    return NotFound(response);
                }
                else
                {
                    //400
                    return BadRequest(response);
                }
            }
            //200
            return Ok(response);
        }
    }
}
