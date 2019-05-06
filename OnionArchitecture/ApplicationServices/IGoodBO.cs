using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public interface IGoodBO
    {
        IEnumerable<Good> GetGoods();
    }
}
