using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocStation.Data.Models
{
	public interface ITables : IEntity
	{

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
