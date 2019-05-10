using ApplicationServices;
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
using System.Data.Entity;

namespace MVC_application.Controllers
{
    public class HomeController : Controller
    {
        IGoodBO goodBO;
        IEnumerable<Good> goods;
        ShopContext context = new ShopContext();

        public HomeController(IGoodBO goodBO)
        {
            this.goodBO = goodBO;

            goods = this.goodBO.GetGoods();
        }
        public ActionResult Index(int page = 1)
        {
            try
            {
                var model = new GoodsModel()
                {
                    Goods = GetGoodsForPage(page),
                    PageInfo = GetInfo(page)
                };
                return View(model);

            }
            catch (Exception)
            {
                return RedirectToAction("InternalServerError", "Errors");
            }

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

        public ActionResult GoodDetails(int id = default(int))
        {
            if (id == 0)
            {
                return RedirectToAction("Index","Home");
            }
            else 
                return View(goods.Single(c => c.Id == id));

        }

        public ActionResult GoodEdit(int id=default(int))
        {
            Good good = goods.Single(c => c.Id == id);
            if (good==null)
            {
                return HttpNotFound();
            }
            return View(good);
        }
        [HttpPost]
        public ActionResult GoodEdit(Good good)
        {
            if (ModelState.IsValid)
            {
                context.Entry(good).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(good);
            
        }
    }
}