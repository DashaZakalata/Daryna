using DomainCore;
using DomainServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public IEnumerable<OrderItem> GetOrderItems()
        {
            throw new NotImplementedException();
        }
    }
}
