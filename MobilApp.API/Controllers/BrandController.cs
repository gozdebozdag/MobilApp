using Microsoft.AspNetCore.Mvc;
using MobilApp.API.Services;
using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;

namespace MobilApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly MobilAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public BrandController( MobilAppDbContext context, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brands = _unitOfWork.Brand.GetAll();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var brands = _unitOfWork.Brand.GetById(id);
            if (brands == null)
            {
                return NotFound();
            }
            return Ok(brands);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Brands brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }
            _unitOfWork.Brand.Add(brand);
            _unitOfWork.Save();
            return Ok(new { message = "Brand added successfully" });
        }

        [HttpPut]
        public IActionResult Update([FromBody] Brands brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }
            var brands = _unitOfWork.Brand.GetById(brand.BrandId);
            brands.Brand = brand.Brand;
            _unitOfWork.Save();
            return Ok(new { message = "Brand updated successfully" });
        }
    }
}
