using Entity.Abstract;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public virtual Category CategoryName { get; set; }
        public int? CategoryNameId { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Unit Unit { get; set; } 
        
    }
}
