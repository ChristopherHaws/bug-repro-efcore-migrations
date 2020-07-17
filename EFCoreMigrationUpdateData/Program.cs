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
				entity.HasKey(x => x.Code).IsClustered();
				entity.Property(x => x.TimeZone).IsRequired().HasDefaultValueSql("('UTC')").HasConversion(x => x.Id, x => TimeZoneInfo.FindSystemTimeZoneById(x));

				entity.HasData(new TestEntity(
					code: "code-1",
					timeZone: TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
				));
			});
		}
	}

	public class TestEntity
	{
		public TestEntity(string code, TimeZoneInfo timeZone)
		{
			Code = code;
			TimeZone = timeZone;
		}

		public string Code { get; set; }
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
