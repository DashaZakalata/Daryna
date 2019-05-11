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

namespace MVC_application.Controllers
{
    public class HomeController : Controller
    {
        IGoodBO goodBO;
        IEnumerable<Good> goods;
        IEnumerable<string> names;
        IEnumerable<string> sortTypes;

        public HomeController(IGoodBO goodBO)
        {
            this.goodBO = goodBO;

            goods = this.goodBO.GetGoods().ToList();

            names = new string[] { "All" }.Union(goods.Select(c => c.Name.ToString()).Distinct());

            sortTypes = new List<string>()
            {
                "From low to high",
                "From high to low"
            };
        }
        public ActionResult Index(string name,
            string sortType, decimal? priceFrom, decimal? priceTo, int page = 1)
        {
            //IEnumerable<Phone> goods = phones.AsEnumerable();
            //if (!string.IsNullOrEmpty(manufacturer) && manufacturer != "All")
            //{
            //    result = result.Where(c => c.Manufacturer == manufacturer);
            //}
            if (!string.IsNullOrEmpty(name) && name != "All")
            {
                goods = goods.Where(c => c.Name == name);
            }
            if (string.IsNullOrEmpty(sortType) || sortType == "From low to high")
            {
                goods = goods.OrderBy(c => c.Price);
            }
            else
            {
                goods = goods.OrderByDescending(c => c.Price);
            }

            if (priceFrom.HasValue && priceTo.HasValue && priceFrom < priceTo)
            {
                goods = goods.Where(c => c.Price >= priceFrom && c.Price <= priceTo);
            }
            var goodsModel = new GoodsModel()
            {
                Goods = GetGoodsForPage(page).ToList(),
                Name = new SelectList(names),
                SortTypes = new SelectList(sortTypes),
                PageInfo = GetInfo(page)
            };

            return View(goodsModel);
        }
        //public ActionResult Index(int page = 1)
        //{
        //    try
        //    {
        //        var model = new GoodsModel()
        //        {
        //            Goods = GetGoodsForPage(page),
        //            PageInfo = GetInfo(page)
        //        };
        //        return View(model);

        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("InternalServerError", "Errors");
        //    }
        //}

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