using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocStation.Data.Models
{

    public class TUsersSubsidiaryPositions : ITables
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string UserId;
        public string SubsidiaryId;
        public int PositionId;

    }
}
