namespace MobilApp.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository User { get; }
        IProductRepository Product { get; }
        IGroupRepository Group { get; }
        IBrandRepository Brand { get; }
        ICategoryRepository Category { get; }
        ICustomerRepository Customer { get; }
        IOrderRepository Order { get; }
        IOrderDetailRepository OrderDetail { get; }
        IWishlistRepository Wishlist { get; }
        
        int Save();
    }
}
