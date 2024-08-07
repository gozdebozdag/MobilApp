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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MobilAppDbContext _carcontext;
        public UnitOfWork(MobilAppDbContext carcontext)
        {
            _carcontext = carcontext;
            User = new UserRepository(_carcontext);
            Product = new ProductRepository(_carcontext);
            Group = new GroupRepository(_carcontext);
            Category = new CategoryRepository(_carcontext);
            Brand = new BrandRepository(_carcontext);
            Customer = new CustomerRepository(_carcontext);
            Order =new OrderRepository(_carcontext);
            OrderDetail = new OrderDetailRepository(_carcontext);
            Wishlist =new WishlistRepository(_carcontext);
        }

        public IUserRepository User { get;private set; }
        public IProductRepository Product { get; private set; }
        public IGroupRepository Group { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IBrandRepository Brand { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IWishlistRepository Wishlist { get; private set; }
        public int Save()
        {
            return _carcontext.SaveChanges();
        }
        public void Dispose()
        {
            _carcontext.Dispose();
        }
    }
}
