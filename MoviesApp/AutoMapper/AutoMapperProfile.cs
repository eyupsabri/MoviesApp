using AutoMapper;
using Entities;
using Entities.DTOs;

namespace MoviesAppUser.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieDTO>();
        }
    }
}
