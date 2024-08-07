using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilApp.DataAccess.Implementation
{
    public class WishlistRepository:GenericRepository<Wishlist>,IWishlistRepository
    {
        public WishlistRepository(MobilAppDbContext carcontext) : base(carcontext)
        {

        }
    }
}
