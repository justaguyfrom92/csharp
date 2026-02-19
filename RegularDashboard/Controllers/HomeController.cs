using Microsoft.AspNetCore.Mvc;
using RegularDashboard.Models;

namespace RegularDashboard.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var vm = new DashboardViewModel
        {
            StatCards =
            [
                new("Total Users",     "12,840", "↑ 4.2% this week",  true),
                new("Revenue",         "$84.3k",  "↑ 11% this month",  true),
                new("Active Sessions", "342",     "↓ 2% vs yesterday", false),
                new("Uptime",          "99.9%",   "All systems go",    true),
            ],
        };

        return View(vm);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View();
}
