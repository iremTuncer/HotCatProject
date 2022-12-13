using DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    public class EmployeeDto:BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salery { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Role { get; set; }
    }
}
