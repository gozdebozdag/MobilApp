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
    public class OrderDetailRepository:GenericRepository<OrderDetail>,IOrderDetailRepository 
    {
        public OrderDetailRepository(MobilAppDbContext carcontext) : base(carcontext)
        {

        }
    }
}
