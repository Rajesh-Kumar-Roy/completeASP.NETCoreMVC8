using Bulky.Models;

namespace Bulky.DataAccess.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
    }
}
