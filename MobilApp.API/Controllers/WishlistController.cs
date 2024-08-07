using Microsoft.AspNetCore.Mvc;
using MobilApp.API.Services;
using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;

namespace MobilApp.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
    public class WishlistController : ControllerBase
     {
        private readonly MobilAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public WishlistController(MobilAppDbContext context, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var wishlists = _unitOfWork.Wishlist.GetAll();
            return Ok(wishlists);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var wishlist = _unitOfWork.Wishlist.GetById(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            return Ok(wishlist);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Wishlist wishlist)
        {
            if (wishlist == null)
            {
                return BadRequest();
            }
            _unitOfWork.Wishlist.Add(wishlist);
            _unitOfWork.Save();
            return Ok(new { message = "Wishlist added successfully" });
        }

        [HttpPut]
        public IActionResult Update([FromBody] Wishlist wishlist)
        {
            if (wishlist == null)
            {
                return BadRequest();
            }
            var wishlists = _unitOfWork.Wishlist.GetById(wishlist.WishlistId);
            wishlists.WishlistId = wishlist.WishlistId;
            _unitOfWork.Save();
            return Ok(new { message = "Wishlist updated successfully" });
        }
    }
}
