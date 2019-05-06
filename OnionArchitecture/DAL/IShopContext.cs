using DomainCore;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IShopContext: IUnitOfWork
    {
         DbSet<Order> Orders { get; set; }
         DbSet<OrderItem> OrderItems { get; set; }
         DbSet<Customer> Customers { get; set; }
         DbSet<Good> Goods { get; set; }
    }
}
