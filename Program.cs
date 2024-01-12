using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});
// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Cars");
    options.Conventions.AllowAnonymousToPage("/Cars/Index");
    options.Conventions.AllowAnonymousToPage("/Cars/Details");
    options.Conventions.AuthorizeFolder("/Clients", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Rentals", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Companies");
    options.Conventions.AuthorizeFolder("/Companies/Edit", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Companies/Delete", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Categories");
    options.Conventions.AuthorizeFolder("/Categories/Edit", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Categories/Delete", "AdminPolicy");

});
builder.Services.AddDbContext<RentACarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentACarContext") ?? throw new InvalidOperationException("Connection string 'RentACarContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentACarContext")
    ?? throw new InvalidOperationException("Connection string 'RentACarContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
