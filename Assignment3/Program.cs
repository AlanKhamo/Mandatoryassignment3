using Assignment3.Data;
using Assignment3.Hub;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
        "Admin", 
        policyBuilder => policyBuilder
            .RequireClaim("Role", "Admin"));
    options.AddPolicy(
		"ReceptionPerm",
        policyBuilder => policyBuilder
            .RequireClaim("Role", "Medabejder"));
    options.AddPolicy(
		"ResturantPerm",
        polictyBuilder => polictyBuilder
            .RequireClaim("Role", "Tjener"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
using (var scope = app.Services.CreateScope())
{
    Console.WriteLine("Scope");
	var serviceProvider = scope.ServiceProvider;
	var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
	if (userManager != null)
	{
        Console.WriteLine("Seeding");
		SeedData.SeedMedarbejder(userManager); // Seeder Medarbejder
		SeedData.SeedTjener(userManager); // Seeder Tjener
        SeedData.SeedAdmin(userManager);
	}
	else
	{
		throw new Exception("Unable to get UserManager!");
	}
}

app.MapHub<KitchenHub>("/KitchenHub");

app.Run();
