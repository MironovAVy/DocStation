using Microsoft.EntityFrameworkCore;

namespace DocStation.Data.Models
{
	public class ModelsDBContecx : DbContext
	{

		public DbSet<HDepartments> HDepartments { get; set; }
		public DbSet<HPositions> HPositions { get; set; }
		public DbSet<HSubsidiaries> HSubsidiaries { get; set; }
		public DbSet<TUsers> Users { get; set; }

		//To add migrations only from Nuget package manager
		public ModelsDBContecx()
		{

		}
		//From Api & Migrator
		public ModelsDBContecx(DbContextOptions<ModelsDBContecx> options) : base(options)
		{
		}

		//To add migrations only from Nuget package manager
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TUsers>().HasIndex(u => u.UserName).IsUnique();
			modelBuilder.Entity<TUsers>().HasIndex(u => u.Email).IsUnique();
			modelBuilder.Entity<HSubsidiaries>()
				.HasOne(s => s.Department)
				.WithMany(d => d.HSubsidiaries);				
			base.OnModelCreating(modelBuilder);
		}

	}
}
