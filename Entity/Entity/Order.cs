using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Order:BaseEntity
    {
        public int TableNo { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Menu> OrderList { get; set; }
        public bool IsPaid { get; set; }

    }
}
