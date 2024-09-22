using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocStation.Data.Models
{
    public class HSubsidiaries : ITables
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public string Description { get; set; }
     
        public virtual HDepartments Department { get; set; }

        public int DepartmentId { get; set; }  // Связь с департаментом

    
    }
}
