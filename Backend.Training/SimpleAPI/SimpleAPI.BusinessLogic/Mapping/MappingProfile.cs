using AutoMapper;
using SimpleAPI.DataAccessLayer.Models;
using SimpleAPI.BusinessLogicLayer.ViewModels;

namespace SimpleAPI.BusinessLogicLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SecretModel, ViewSecretModel>()
                .ForMember(x => x.ExpirationDate, o => o.MapFrom(src => ((DateTime?)src.ExpirationDate).ToString()))
                .ForMember(x => x.CreationTime, o => o.MapFrom(src => ((DateTime?)src.CreationTime).ToString()))
                .ForMember(x => x.LastModificationTime, o => o.MapFrom(src => ((DateTime?)src.LastModificationTime).ToString()))
                .ForMember(x => x.Title, o => o.MapFrom(src => src.Title))
                .ForMember(x => x.SecretName, o => o.MapFrom(src => src.SecretName))
                .ForMember(x => x.SecretValue, o => o.MapFrom(src => src.SecretValue))
                .ForMember(x => x.URL, o => o.MapFrom(src => src.URL))
                .ForMember(x => x.Description, o => o.MapFrom(src => src.Description))
                .ForMember(x => x.CategoryId, o => o.MapFrom(src => src.CategoryId));

            CreateMap<ViewSecretModel, SecretModel>()
                .ForMember(x => x.ExpirationDate, o => o.MapFrom(src => DateTime.Parse(src.ExpirationDate)))
                .ForMember(x => x.CreationTime, o => o.MapFrom(src => DateTime.Parse(src.CreationTime)))
                .ForMember(x => x.LastModificationTime, o => o.MapFrom(src => DateTime.Parse(src.LastModificationTime)))
                .ForMember(x => x.Title, o => o.MapFrom(src => src.Title))
                .ForMember(x => x.SecretName, o => o.MapFrom(src => src.SecretName))
                .ForMember(x => x.SecretValue, o => o.MapFrom(src => src.SecretValue))
                .ForMember(x => x.URL, o => o.MapFrom(src => src.URL))
                .ForMember(x => x.Description, o => o.MapFrom(src => src.Description))
                .ForMember(x => x.CategoryId, o => o.MapFrom(src => src.CategoryId))
                .ForMember(x => x.Id, o => o.MapFrom(src => src.Id));
            CreateMap<CategoryModel, ViewCategoryModel>()
                .ForMember(x => x.CategoryName, o => o.MapFrom(src => src.CategoryName));
            CreateMap<ViewCategoryModel, CategoryModel>()
                .ForMember(x => x.CategoryName, o => o.MapFrom(src => src.CategoryName));
        }
    }
}