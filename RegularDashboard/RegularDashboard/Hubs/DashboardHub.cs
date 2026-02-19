using Microsoft.AspNetCore.SignalR;

namespace RegularDashboard.Hubs;

public class DashboardHub : Hub
{
    private static bool _sectionVisible = true;

    public async Task ToggleSection()
    {
        _sectionVisible = !_sectionVisible;
        await Clients.All.SendAsync("ReceiveSectionState", _sectionVisible);
    }

    public override async Task OnConnectedAsync()
    {
        // Sync new client to current server state
        await Clients.Caller.SendAsync("ReceiveSectionState", _sectionVisible);
        await base.OnConnectedAsync();
    }
}
