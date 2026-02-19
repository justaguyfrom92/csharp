using RegularDashboard.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

// Blazor Server enables @onclick C# methods in components
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<DashboardHub>("/dashboardHub");

app.MapRazorComponents<RegularDashboard.Components.App>()
   .AddInteractiveServerRenderMode();

app.Run();
