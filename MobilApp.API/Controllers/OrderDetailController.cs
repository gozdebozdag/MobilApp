using Microsoft.AspNetCore.Mvc;
using MobilApp.API.Services;
using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;

namespace MobilApp.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
    public class OrderDetailController : ControllerBase
     {
        private readonly MobilAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailController(MobilAppDbContext context, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var details = _unitOfWork.OrderDetail.GetAll();
            return Ok(details);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var details = _unitOfWork.OrderDetail.GetById(id);
            if (details == null)
            {
                return NotFound();
            }
            return Ok(details);
        }

        [HttpPost]
        public IActionResult Add([FromBody] OrderDetail detail)
        {
            if (detail == null)
            {
                return BadRequest();
            }
            _unitOfWork.OrderDetail.Add(detail);
            _unitOfWork.Save();
            return Ok(new { message = "Order Detail added successfully" });
        }

        [HttpPut]
        public IActionResult Update([FromBody] OrderDetail detail)
        {
            if (detail == null)
            {
                return BadRequest();
            }
            var details = _unitOfWork.OrderDetail.GetById(detail.OrderDetailId);
            details.UnitPrice = detail.UnitPrice;
            _unitOfWork.Save();
            return Ok(new { message = "Order Detail updated successfully" });
        }
    }
}
