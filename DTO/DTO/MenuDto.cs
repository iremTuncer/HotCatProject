using DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    public class MenuDto:BaseDto
    {
        public string Name { get; set; }
        public decimal UnitInPrice { get; set; }
        public List<ProductDto> Recipe { get; set; }
        
        public int? MenuCategoryId { get; set; }
    }
}
