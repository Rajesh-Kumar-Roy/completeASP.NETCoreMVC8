using Bulky.Models;

namespace Bulky.DataAccess.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
