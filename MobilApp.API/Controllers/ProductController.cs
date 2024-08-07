using Microsoft.AspNetCore.Mvc;
using MobilApp.API.Services;
using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;

namespace MobilApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MobilAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(MobilAppDbContext context, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _unitOfWork.Product.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var products = _unitOfWork.Product.GetById(id);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Products product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _unitOfWork.Product.Add(product);
            _unitOfWork.Save();
            return Ok(new { message = "Product added successfully" });
        }

        [HttpPut]
        public IActionResult Update([FromBody] Products product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            var products = _unitOfWork.Product.GetById(product.ProductId);
            products.Name = product.Name;
            _unitOfWork.Save();
            return Ok(new { message = "Product updated successfully" });
        }
    }
}
