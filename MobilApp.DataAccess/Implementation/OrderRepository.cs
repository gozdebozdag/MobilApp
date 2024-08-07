using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MobilApp.DataAccess.Implementation
{
    public class OrderRepository:GenericRepository<Order>,IOrderRepository 
    {
        public OrderRepository(MobilAppDbContext carcontext) : base(carcontext)
        {

        }
    }
}
