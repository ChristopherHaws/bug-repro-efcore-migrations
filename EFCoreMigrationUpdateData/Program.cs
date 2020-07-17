using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreMigrationUpdateData
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}

	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<TestEntity> TestEntities { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TestEntity>(entity =>
			{
				entity.Property(x => x.TimeZone).IsRequired().HasDefaultValueSql("('UTC')").HasConversion(x => x.Id, x => TimeZoneInfo.FindSystemTimeZoneById(x));
			});
		}
	}

	public class TestEntity
	{
		public int Id { get; set; }
		public TimeZoneInfo TimeZone { get; set; }
	}

	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=Test; Trusted_Connection=True; MultipleActiveResultSets=true");

			return new ApplicationDbContext(optionsBuilder.Options);
		}
	}
}
