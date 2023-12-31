using Microsoft.AspNetCore.Mvc;

public class LeftNavigation : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
        var links = new List<LeftNavigationLink>
        {
            new LeftNavigationLink { Controller = "Home", Action = "Index", Title = "Home" },
            new LeftNavigationLink { Controller = "Employee", Action = "Index", Title = "Employees" },
            new LeftNavigationLink { Controller = "Company", Action = "Index", Title = "Companies" },
            new LeftNavigationLink { Action = "Privacy", Title = "Privacy" }
        };
        return View();
        }
    }
public class LeftNavigationLink
{
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Title { get; set; }
}
