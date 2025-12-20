using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using RMSHOP.BLL.Service.Categories;
using RMSHOP.PL.Resources;

namespace RMSHOP.PL.Areas.User
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public CategoriesController(ICategoryService categoryService , IStringLocalizer<SharedResource> localizer) {
            _categoryService = categoryService;
            _localizer = localizer;
        }

        [HttpGet("")]
        public IActionResult Index() {
            var response = _categoryService.GetAllCategories();
            return Ok(new { message = _localizer["Success"].Value,categories=response});
        }
    }
}
