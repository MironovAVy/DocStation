using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocStation.Data.Models
{
    public class HDepartments : ITables
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public ICollection<HSubsidiaries> HSubsidiaries { get; set; } //лист не используем, используем интефьес с минимальным набора функционала для таблиц наружу 

    }
}
