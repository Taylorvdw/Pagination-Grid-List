using API.Dto;
using API.Helpers;
using API.Models;
using API.Repository.IRepository;
using API.Repository.Specifications;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper)
        {
            _productTypeRepo = productTypeRepo;
            _productRepo = productRepo;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProdDto>>> GetProducts([FromQuery]ProdSpecParams ProdParams)
        {
            var spec = new ProdWithTypesSpec(ProdParams);
            var countSpec = new ProdCountSpec(ProdParams);
            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProdDto>>(products);

            return Ok(new Pagination<ProdDto>(ProdParams.PageIndex, ProdParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdDto>> GetProduct(int id)
        {
            var spec = new ProdWithTypesSpec(id);
            var prod = await _productRepo.getEntityWithSpec(spec);
            return _mapper.Map<Product, ProdDto>(prod);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }   
    
}
