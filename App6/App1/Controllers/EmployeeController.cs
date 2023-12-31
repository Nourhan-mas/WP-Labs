using App1.Models;
using App1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App1.Models;

namespace App1.Controllers
{
	public class EmployeeController : Controller
	{
		/*		private readonly EmployeeContext _context;
		*/
		public EmployeeController()
		{


		}

		public async Task<IActionResult> Index()
		{
			ViewBag.Layout = "_Lab2Layout";
			using var context = new EmployeeContext();
			var employees = context.Employees.Include(e => e.Company);
			return View(await employees.ToListAsync());
		}
		public IActionResult Details(int id = 1)
		{
			ViewBag.Layout = "_Lab2Layout";
			using var context = new EmployeeContext();
			var employees = context.Employees.FirstOrDefault(m => m.Id == id);
			return View(employees);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{

			using var context = new EmployeeContext();
			var employee = context.Employees.FirstOrDefault(m => m.Id == id);
			return View(employee);

		}
		[HttpPost("[controller]/[action]/{id}")]
		public IActionResult Edit(int id, Employee updatedEmployee)
		{

			if (ModelState.IsValid)
			{
				using var context = new EmployeeContext();
				context.Employees.Update(updatedEmployee);
				context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			ModelState.AddModelError("", "Something went wrong");
			return View(updatedEmployee);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Employee employee)
		{

			if (ModelState.IsValid)
			{
				using var context = new EmployeeContext();
				var addedMovie = context.Entry(employee);
				addedMovie.State = EntityState.Added;
				context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			ModelState.AddModelError("", "Something went wrong");
			return View(employee);
		}
		public IActionResult SalaryDetails()
		{
			ViewBag.Layout = "_Lab2Layout";
			using var context = new EmployeeContext();
			var employeeSalaryList = context.Employees
		   .Include(e => e.Company)
		   .Include(e => e.SalaryInfo)
		   .Select(e => new EmployeeSalaryDto
		   {
			   Id = e.Id,
			   FullName = $"{e.Name} {e.Surname}",
			   CompanyName = e.Company.Name,
			   NetSalary = e.SalaryInfo.Net,
			   GrossSalary = e.SalaryInfo.Gross
		   })
		   .ToList();

			return View(employeeSalaryList);
		}
	}
}
