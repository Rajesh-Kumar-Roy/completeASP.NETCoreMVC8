using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationContext _db;
        public OrderDetailRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }


        public void Update(OrderDetail orderDetail)
        {
            _db.OrderDetails.Update(orderDetail);
        }
    }
}
