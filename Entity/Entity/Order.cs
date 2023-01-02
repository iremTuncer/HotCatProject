using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Order:BaseEntity
    {
        public int TableNo { get; set; }
        public decimal TotalPrice { get; set; }
        public List<SelectedMenu> MenuList { get; set; }
        public bool IsPaid { get; set; }

    }

    public class SelectedMenu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitInPrice { get; set; }
        public int piece { get; set; }

        public Order Order { get; set; }

    }

}
