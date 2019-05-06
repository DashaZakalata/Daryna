using DAL;
using DomainCore;
using DomainServices.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GoodRepository : Repository<Good>, IGoodRepository
    {
        public GoodRepository(IShopContext context) : base(context)
        {

        }
    }
}
