using AutoMapper;
using CleanArch.MVC.Application.DTOs;
using CleanArch.MVC.Application.Products.Commands;

namespace CleanArch.MVC.Application.Mappings
{
    public class DtoToCommands : Profile
    {
        public DtoToCommands()
        {
            CreateMap<ProductDTO,ProductCreateCommand>();
            CreateMap<ProductDTO,ProductUpdateCommand>();
            CreateMap<ProductDTO,ProductRemoveCommand>();
        }
    }
}