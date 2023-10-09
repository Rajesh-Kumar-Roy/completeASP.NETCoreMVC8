using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _db;
        public CategoryRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
      
        
    }
}
