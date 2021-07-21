using AutoMapper;
using Course.Services.Catalog.Dtos.Category;
using Course.Services.Catalog.Dtos.Course;
using Course.Services.Catalog.Dtos.Feature;
using Course.Services.Catalog.Models;

namespace Course.Services.Catalog.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Models.Course, CourseDto>().ReverseMap();
            CreateMap<Models.Course, CourseCreateDto>().ReverseMap();
            CreateMap<Models.Course, CourseUpdateDto>().ReverseMap();

            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
