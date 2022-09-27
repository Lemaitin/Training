using Microsoft.AspNetCore.Mvc;
using SimpleAPI.BusinessLogicLayer.Services;
using SimpleAPI.BusinessLogicLayer.ViewModels;

namespace SimpleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICaregoryService _categoryService;

        public CategoriesController(ICaregoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //Get All Categories
        [HttpGet("GetAllCategories")]
        public async Task <IList<ViewCategoryModel>> GetAll()
        {
            return await _categoryService.GetAllCategories();
        }

        //Get Category
        [HttpGet("GetCategory")]
        public async Task<ViewCategoryModel> GetCategory(int id)
        {
            return await _categoryService.GetCategory(id);
        }

        //Add Category
        [HttpPost("AddCategory")]
        public async Task<ViewCategoryModel> AddCategory(ViewCategoryModel viewCategory)
        {
            return await _categoryService.AddCategory(viewCategory);
        }

        //Update Category
        [HttpPut("UpdateCategory")]
        public bool UpdateCategory(ViewCategoryModel viewCategory)
        {
            return _categoryService.UpdateCategory(viewCategory);
        }

        //Delete Category
        [HttpDelete("DeleteCategory")]
        public bool DeleteCategory(int id)
        {
            return _categoryService.DeleteCategory(id);
        }
    }
}