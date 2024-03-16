using AutoMapper;
using CleanArch.MVC.Application.DTOs;
using CleanArch.MVC.Domain.Entities;

namespace CleanArch.MVC.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<Product,ProductDTO>().ReverseMap();
        }
    }
}