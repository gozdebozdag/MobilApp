using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilApp.Entities
{
    public class Wishlist
    {
        [Key]
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateAdded { get; set; }
        public User User { get; set; }
        public Products Product { get; set; }

    }
}
