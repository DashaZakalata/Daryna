using DomainCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    [Table("dbo.Goods")]
    public class Good : IEntity
    {
        public Good()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        [DataType(DataType.PhoneNumber)]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фото")]
        public string ImagePath { get; set; }

        [Display(Name = "Производитель")]
        public string Manufacturer { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
