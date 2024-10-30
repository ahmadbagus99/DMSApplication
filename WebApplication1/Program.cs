using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/"); // Mengautorisasi semua halaman dalam folder
});

// Menambahkan konteks database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

// Menambahkan identitas pengguna
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Tambahkan UseAuthentication di sini
app.UseAuthentication();
app.UseAuthorization();

// Mengatur redirect ke halaman Login ketika aplikasi dimulai
app.MapGet("/", async context =>
{
    context.Response.Redirect("/Main/Index");
});

app.MapRazorPages();

app.Run();
