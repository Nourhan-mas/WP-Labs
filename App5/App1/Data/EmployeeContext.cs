using App1.Models;
using Microsoft.EntityFrameworkCore;

namespace App1.Data
{
	public class EmployeeContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<SalaryInfo> SalaryInfos { get; set; }

		public EmployeeContext() { }
		public EmployeeContext(DbContextOptions<EmployeeContext> options)
		: base(options)
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=EmployeeDB;Integrated Security=True;Trusted_Connection=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

				entity.Property(e => e.Surname).IsRequired().HasMaxLength(50);

				entity.Property(e => e.Position).IsRequired().HasMaxLength(100);

				entity.HasOne(e => e.SalaryInfo)
				   .WithOne(si => si.Employee)
				   .HasForeignKey<SalaryInfo>(si => si.EmployeeId);

			});

			modelBuilder.Entity<Company>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

				entity.Property(e => e.City).IsRequired().HasMaxLength(50);

				entity.Property(e => e.Country).IsRequired().HasMaxLength(60);

				entity.Property(e => e.ZipCode).IsRequired().HasMaxLength(5).IsFixedLength();

				entity.HasMany(c => c.Employees)
					   .WithOne(e => e.Company)
					   .HasForeignKey(e => e.CompanyId);
			});



			modelBuilder.Entity<Company>().HasData(
			new Company { Id = 1, Name = "TechCorp Solutions", ZipCode = 10001, City = "New York", Country = "USA" },
			new Company { Id = 2, Name = "GlobalWidgets Inc", ZipCode = 90210, City = "Beverly Hills", Country = "USA" },
			new Company { Id = 3, Name = "InnovateSoft Ltd", ZipCode = 58643, City = "London", Country = "UK" },
			new Company { Id = 4, Name = "NexGen Innovations", ZipCode = 75001, City = "Paris", Country = "France" },
			new Company { Id = 5, Name = "BrightFutures Corp", ZipCode = 10178, City = "Berlin", Country = "Germany" }
);

			// Seed initial data
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				Id = 1,
				Name = "Martin",
				Surname = "Simpson",
				BirthDate = new DateTime(1992, 12, 3),
				Position = "Marketing Expert",
				Image = "/images/Martin.jpg"
			},
			new Employee
			{
				Id = 2,
				Name = "Jacob",
				Surname = "Hawk",
				BirthDate = new DateTime(1995, 10, 2),
				Position = "Manager",
				Image = "/images/Jacob.jpg"
			},
			new Employee
			{
				Id = 3,
				Name = "Elizabeth",
				Surname = "Geil",
				BirthDate = new DateTime(2000, 1, 7),
				Position = "Software Engineer",
				Image = "/images/Elizabeth.jpg"
			},
			new Employee
			{
				Id = 4,
				Name = "Kate",
				Surname = "Metain",
				BirthDate = new DateTime(1997, 2, 13),
				Position = "Admin",
				Image = "/images/Kate.jpg"
			},
			new Employee
			{
				Id = 5,
				Name = "Michael",
				Surname = "Cook",
				BirthDate = new DateTime(1990, 12, 25),
				Position = "Marketing expert",
				Image = "/images/Michael.jpg"
			},
			new Employee
			{
				Id = 6,
				Name = "John",
				Surname = "Snow",
				BirthDate = new DateTime(2001, 7, 15),
				Position = "Software Engineer",
				Image = "/images/John.jpg"
			},
			new Employee
			{
				Id = 7,
				Name = "Nina",
				Surname = "Soprano",
				BirthDate = new DateTime(1999, 9, 30),
				Position = "Software Engineer",
				Image = "/images/Nina.jpg"
			},
			new Employee
			{
				Id = 8,
				Name = "Tina",
				Surname = "Fins",
				BirthDate = new DateTime(2000, 5, 14),
				Position = "Team Leader",
				Image = "/images/Tina.jpg"
			});
		}
	}
}
