using Microsoft.AspNetCore.Mvc;
using RegularDashboard.Models;

namespace RegularDashboard.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var vm = new DashboardViewModel
        {
            SectionVisible = true,

            StatCards =
            [
                new("Total Users",      "12,840", "↑ 4.2% this week",  true),
                new("Revenue",          "$84.3k",  "↑ 11% this month",  true),
                new("Active Sessions",  "342",     "↓ 2% vs yesterday", false),
                new("Uptime",           "99.9%",   "All systems go",    true),
            ],

            WeeklyTraffic =
            [
                new("Mon", 62), new("Tue", 48), new("Wed", 75),
                new("Thu", 91), new("Fri", 83), new("Sat", 57), new("Sun", 69),
            ],

            RecentActivity =
            [
                new("#22c55e", "User <strong>alice@co.io</strong> signed up",          "2m ago"),
                new("#7c3aed", "Deployment <strong>v2.4.1</strong> succeeded",          "17m ago"),
                new("#f59e0b", "Alert: CPU spike on <strong>node-03</strong>",          "34m ago"),
                new("#3b82f6", "Backup completed successfully",                         "1h ago"),
                new("#ef4444", "Payment failed for <strong>order #8812</strong>",       "2h ago"),
            ],
        };

        return View(vm);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View();
}
