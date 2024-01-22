using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationContext _db;
        public ApplicationUserRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationUser obj)
        {
            _db.ApplicationUsers.Update(obj);
        }


    }
}
