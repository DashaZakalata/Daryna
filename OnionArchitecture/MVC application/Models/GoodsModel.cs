using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_application.Models
{
    public class GoodsModel
    {
        public IEnumerable<Good> Goods { get; set; }

        public SelectList Name { get; set; }

        public SelectList SortTypes { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}