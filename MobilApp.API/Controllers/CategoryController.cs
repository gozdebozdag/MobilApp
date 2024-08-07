using Microsoft.AspNetCore.Mvc;
using MobilApp.API.Services;
using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;

namespace MobilApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MobilAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(MobilAppDbContext context, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _unitOfWork.Category.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categories = _unitOfWork.Category.GetById(id);
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Categories category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
            return Ok(new { message = "Category added successfully" });
        }

        [HttpPut]
        public IActionResult Update([FromBody] Categories category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            var categories = _unitOfWork.Category.GetById(category.CategoryId);
            categories.Category = category.Category;
            _unitOfWork.Save();
            return Ok(new { message = "Category updated successfully" });
        }
    }
}
