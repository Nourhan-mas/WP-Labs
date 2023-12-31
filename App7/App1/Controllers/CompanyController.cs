using App1.Data;
using App1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
           var companyDetailsList = (from company in context.Companies
                                     join employee in context.Employees on company.Id equals employee.CompanyId into employees
                                     from emp in employees.DefaultIfEmpty()
                                     select new { Company = company, Employee = emp })
                     .GroupBy(x => x.Company)
                     .Select(g => new CompanyDetailsDto
                     {
                         Id = g.Key.Id,
                         Name = g.Key.Name,
                         FullAddress = $"{g.Key.City}, {g.Key.Country}",
                         NumberOfEmployees = g.Count(x => x.Employee != null)
                     })
                    .ToList();
            return View(companyDetailsList);
		}
	}
}
