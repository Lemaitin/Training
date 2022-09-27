using SimpleAPI.BusinessLogicLayer.ViewModels;

namespace SimpleAPI.BusinessLogicLayer.Services
{
    public interface ICaregoryService
    {
        Task<IList<ViewCategoryModel>> GetAllCategories();

        Task<ViewCategoryModel> GetCategory(int id);

        Task<ViewCategoryModel> AddCategory(ViewCategoryModel viewCategory);

        bool UpdateCategory(ViewCategoryModel viewCategory);

        bool DeleteCategory(int id);
    }
}
