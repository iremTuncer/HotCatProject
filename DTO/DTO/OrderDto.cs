using DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    public class OrderDto:BaseDto
    {
        public int TableNo { get; set; }
        public decimal TotalPrice { get; set; }
        public List<MenuDto> MenuList { get; set; }
        public bool IsPaid { get; set; }
    }
}
