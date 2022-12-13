using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Menu:BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitInPrice { get; set; }
        public List<Product> Recipe { get; set; }
        public MenuCategory MenuCategory { get; set; }
        public int? MenuCategoryId { get; set; }
    }
}
