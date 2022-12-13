using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Employee:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salery { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool ActiveWork { get; set; }
        public Role Role { get; set; }
        public int? RoleId { get; set; }
    }
}
