using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationContext _db;
        public CompanyRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            _db.Companies.Update(company);
        }
    }
}
