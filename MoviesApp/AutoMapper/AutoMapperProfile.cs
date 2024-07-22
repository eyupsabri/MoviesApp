using AutoMapper;
using Entities;
using Entities.DTOs;
using MoviesAppUser.Models;

namespace MoviesAppUser.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.MovieCategories, opt => opt.MapFrom(src => src.MovieCategories.Select(mc => mc.Category.MovieCategory.ToString())));
            CreateMap<Category, CategoryDTO>();
            CreateMap<MovieCategory, MovieCategoryDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<MovieReview, MovieReviewDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.UserNickName, opt => opt.MapFrom(src => src.User.NickName));
            CreateMap<Movie, MovieDetailedDTO>()
                .ForMember(dest => dest.MovieCategories, opt => opt.MapFrom(src => src.MovieCategories.Select(mc => mc.Category.MovieCategory.ToString())));
            CreateMap<MovieReviewModel, MovieReview>();
            CreateMap<MovieAddDTO, Movie>().AfterMap((src, dest, context) =>
            {
                dest.MovieCategories = (ICollection<MovieCategory>)context.Items["MovieCategories"];
            });
            CreateMap<UserRegisterModel, User>();
        }
    }
}
