using App1.Data;
using App1.Models;
using Microsoft.AspNetCore.Mvc;

namespace App1.Controllers
{
	public class CompanyController : Controller
	{
		public CompanyController()
		{
		}
		public IActionResult Index()
		{
			ViewBag.Layout = "_Lab2Layout";
			using var context = new EmployeeContext();
			var companyDetailsList = context.Companies
				.Select(c => new CompanyDetailsDto
				{
					Id = c.Id,
					Name = c.Name,
					FullAddress = $"{c.City}, {c.Country}",
					NumberOfEmployees = c.Employees.Count()
				})
				.ToList();
			return View(companyDetailsList);
		}
	}
}
