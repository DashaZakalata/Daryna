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
    public class ShopContext: DbContext, IUnitOfWork
    {
        public ShopContext() : base ("ShopConnectionString")
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Good> Goods { get; set; }
    }
}
