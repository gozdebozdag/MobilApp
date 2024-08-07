using Microsoft.AspNetCore.Mvc;
using MobilApp.API.Services;
using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;

namespace MobilApp.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
    public class GroupController : ControllerBase
     {
        private readonly MobilAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public GroupController(MobilAppDbContext context, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var groups = _unitOfWork.Group.GetAll();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var groups = _unitOfWork.Group.GetById(id);
            if (groups == null)
            {
                return NotFound();
            }
            return Ok(groups);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Groups group)
        {
            if (group == null)
            {
                return BadRequest();
            }
            _unitOfWork.Group.Add(group);
            _unitOfWork.Save();
            return Ok(new { message = "Group added successfully" });
        }

        [HttpPut]
        public IActionResult Update([FromBody] Groups group)
        {
            if (group == null)
            {
                return BadRequest();
            }
            var groups = _unitOfWork.Group.GetById(group.GroupId);
            groups.GroupName = group.GroupName;
            _unitOfWork.Save();
            return Ok(new { message = "Group updated successfully" });
        }
    }
}
