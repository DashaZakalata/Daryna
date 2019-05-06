using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_application.Models
{
    public class PageInfo
    {
        public int TotalQuantity { get; set; }
        public int CurrentNumber { get; set; }
        public int PagesCount { get; set; }
        public int PageSize { get; set; }
    }
}