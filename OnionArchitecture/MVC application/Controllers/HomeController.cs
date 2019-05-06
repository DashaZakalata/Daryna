using DAL;
using DomainCore;
using DomainServices.Repositories;
using MVC_application.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_application.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Good> repo;
        IEnumerable<Good> goods;

        public HomeController()
        {
            repo = new GoodRepository();
            goods = repo.GetAll();
        }
        public ActionResult Index(int page = 1)
        {
            var model = new GoodsModel()
            {
                Goods = GetGoodsForPage(page),
                PageInfo = GetInfo(page)
            };

            return View(model);
        }

        private IEnumerable<Good> GetGoodsForPage(int page, int pageSize = 2)
        {
            return goods.Skip((page - 1) * pageSize).Take(pageSize);
        }

        private PageInfo GetInfo(int page, int pageSize = 2)
        {
            return new PageInfo()
            {
                CurrentNumber = page,
                TotalQuantity = goods.Count<Good>(),
                PageSize = pageSize,
                PagesCount = (int)Math.Ceiling((decimal)goods.Count<Good>() / pageSize)
            };
        }
    }
}