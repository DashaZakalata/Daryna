using DomainCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    [Table("dbo.OrderItems")]
    public class OrderItem : IEntity
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int GoodId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }


        public virtual Good Good { get; set; }

        public virtual Order Order { get; set; }
    }
}
