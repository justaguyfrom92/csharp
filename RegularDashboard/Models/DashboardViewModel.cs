namespace RegularDashboard.Models;

public class DashboardViewModel
{
    public bool SectionVisible { get; set; } = true;
    public IReadOnlyList<StatCard> StatCards { get; set; } = [];
    public IReadOnlyList<TrafficBar> WeeklyTraffic { get; set; } = [];
    public IReadOnlyList<ActivityItem> RecentActivity { get; set; } = [];
}

public record StatCard(string Label, string Value, string Delta, bool IsPositive);

public record TrafficBar(string Day, int Value);

public record ActivityItem(string Color, string Description, string TimeAgo);
