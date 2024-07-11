using Microsoft.EntityFrameworkCore;
using telefonrehber.Data;

var builder = WebApplication.CreateBuilder(args);
<<<<<<< HEAD
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaltConnection")));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();



// Add services to the container
 // Add this line

=======

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaltConnection")));

var app = builder.Build();

>>>>>>> 961afc2caab843f24c758815fd033a436f69f418
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
<<<<<<< HEAD
=======
 
>>>>>>> 961afc2caab843f24c758815fd033a436f69f418
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
<<<<<<< HEAD
app.UseCors();
=======

>>>>>>> 961afc2caab843f24c758815fd033a436f69f418
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
<<<<<<< HEAD
    pattern: "{controller=kisis}/{action=Index}/{id?}");
=======
    pattern: "{controller=Home}/{action=Index}/{id?}");
>>>>>>> 961afc2caab843f24c758815fd033a436f69f418

app.Run();
