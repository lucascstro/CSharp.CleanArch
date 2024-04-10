using AutoMapper;
using CleanArch.MVC.Application.DTOs;
using CleanArch.MVC.Application.Interfaces;
using CleanArch.MVC.Application.Products.Commands;
using CleanArch.MVC.Application.Products.Queries;
using MediatR;

namespace CleanArch.MVC.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductServices(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(await _mediator.Send(
                new GetProductsQuery() ?? throw new ApplicationException($"Entity could not be loaded")
                ));
        }
        public async Task<ProductDTO> GetById(int id)
        {
            var productQueries = new GetProductByIdQuery(id) ?? throw new ApplicationException();
            return _mapper.Map<ProductDTO>(await _mediator.Send(productQueries));
        }

        public async Task<ProductDTO> GetProductCategory(int id)
        {
            var productQueries = new GetProductByIdQuery(id) ?? throw new ApplicationException();
            return _mapper.Map<ProductDTO>(await _mediator.Send(productQueries));
        }


        public async Task Add(ProductDTO productDTO)
        {
            var productCmd = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCmd);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productCmd = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productCmd);
        }

        public async Task Remove(int id)
        {
            await _mediator.Send(new ProductRemoveCommand(id) ?? throw new ApplicationException());
        }
    }
}