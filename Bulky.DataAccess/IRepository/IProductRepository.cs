using Bulky.Models;

namespace Bulky.DataAccess.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
