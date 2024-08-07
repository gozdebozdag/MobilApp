using Microsoft.AspNetCore.Mvc;
using MobilApp.API.Services;
using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;

namespace MobilApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;
        private readonly MobilAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(CustomerService service, MobilAppDbContext context, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _service = service;
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _unitOfWork.Customer.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customers = _unitOfWork.Customer.GetById(id);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            _unitOfWork.Customer.Add(customer);
            _unitOfWork.Save();
            return Ok(new { message = "Customer added successfully" });
        }

        [HttpPut]
        public IActionResult Update([FromBody] Customer customer)
        {
            if (customer == null)
            { 
                return BadRequest();
            }
            var customers = _unitOfWork.Customer.GetById(customer.CustomerId);
            customers.FirstName = customer.FirstName;
            customers.LastName = customer.LastName;
            customers.Email = customer.Email;
            customers.PhoneNumber = customer.PhoneNumber;
            customers.IsActive = customer.IsActive;
            _unitOfWork.Save();
            return Ok(new { message = "Customer updated successfully" });
        }
    }
}
