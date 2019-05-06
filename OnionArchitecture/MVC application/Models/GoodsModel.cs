using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_application.Models
{
    public class GoodsModel
    {
        public IEnumerable<Good> Goods { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}