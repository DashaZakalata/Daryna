using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainCore;
using DomainServices.Repositories;

namespace ApplicationServices
{
    public class GoodBO : IGoodBO
    {
        IGoodRepository repository;
        public GoodBO(IGoodRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Good> GetGoods()
        {
            return repository.GetAll();
        }
    }
}
