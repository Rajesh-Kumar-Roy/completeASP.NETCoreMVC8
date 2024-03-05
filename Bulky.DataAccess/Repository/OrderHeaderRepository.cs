using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationContext _db;
        public OrderHeaderRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader orderHeader)
        {
            _db.OrderHeaders.Update(orderHeader);
        }


    }
}
