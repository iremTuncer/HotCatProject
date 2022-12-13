using DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    public class ProductDto:BaseDto
    {
        public string ProductName { get; set; }
        public int? CategoryNameId { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Unit { get; set; }
     
    }
}
