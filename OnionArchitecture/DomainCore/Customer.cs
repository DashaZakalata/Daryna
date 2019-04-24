using DomainCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    [Table("dbo.Customers")]
    public class Customer : IEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string DeliveryAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
