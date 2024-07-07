using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocStation.Data.Models
{
    public class ModelsDBContecx : DbContext
    {
        public DbSet<HDepartments> HDepartments { get; set; }
        public DbSet<HPositions> HPositions { get; set; }
        public DbSet<HSubsidiaries> HSubsidiaries { get; set; }

        public ModelsDBContecx(DbContextOptions<ModelsDBContecx> options) : base(options)
        {
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
