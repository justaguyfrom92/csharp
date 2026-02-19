namespace RegularDashboard.Models;

public class DashboardViewModel
{
    public IReadOnlyList<StatCard> StatCards { get; set; } = [];
}

public record StatCard(string Label, string Value, string Delta, bool IsPositive);
