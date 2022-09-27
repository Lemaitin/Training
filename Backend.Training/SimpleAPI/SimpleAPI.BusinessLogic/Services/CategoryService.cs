using AutoMapper;
using SimpleAPI.BusinessLogicLayer.ViewModels;
using SimpleAPI.DataAccessLayer.Interfaces;
using SimpleAPI.DataAccessLayer.Models;

namespace SimpleAPI.BusinessLogicLayer.Services
{
    public class CategoryService : ICaregoryService
    {
        IUnitOfWork _unitOfWork { get; set; }

        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<IList<ViewCategoryModel>> GetAllCategories()
        {
            var categories = await _unitOfWork.CategoryModels.GetAll();
            var viewCategories = _mapper.Map<IList<ViewCategoryModel>>(categories);
            return viewCategories;
        }

        public async Task<ViewCategoryModel> GetCategory(int id)
        {
            var category = await _unitOfWork.CategoryModels.Get(id);
            var viewCategory = _mapper.Map<ViewCategoryModel>(category);
            return viewCategory;
        }

        public async  Task<ViewCategoryModel> AddCategory(ViewCategoryModel viewCategory)
        {
            try
            {
                var convertedCategory = _mapper.Map<CategoryModel>(viewCategory);
                var addCategory = await _unitOfWork.CategoryModels.Add(convertedCategory);
                viewCategory.CategoryName = addCategory.CategoryName;

                return viewCategory;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateCategory(ViewCategoryModel viewCategory)
        {
            try
            {
                var convertedCategory = _mapper.Map<CategoryModel>(viewCategory);
                _unitOfWork.CategoryModels.Update(convertedCategory);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                _unitOfWork.CategoryModels.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}