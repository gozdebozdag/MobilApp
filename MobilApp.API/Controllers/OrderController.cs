using Microsoft.AspNetCore.Mvc;
using MobilApp.API.Services;
using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;

namespace MobilApp.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
    public class OrderController : ControllerBase
     {
        private readonly MobilAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(MobilAppDbContext context, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _unitOfWork.Order.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var orders = _unitOfWork.Order.GetById(id);
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            _unitOfWork.Order.Add(order);
            _unitOfWork.Save();
            return Ok(new { message = "Order added successfully" });
        }

        [HttpPut]
        public IActionResult Update([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            var orders = _unitOfWork.Order.GetById(order.OrderId);
            orders.OrderDate = order.OrderDate;
            _unitOfWork.Save();
            return Ok(new { message = "Order updated successfully" });
        }
    }
}
