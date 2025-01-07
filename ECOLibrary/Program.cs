using ECOLibrary.BusinessLayer.Concrete;
using ECOLibrary.BusinessLayer.Mapping;
using ECOLibrary.BusinessLayer.Services.BookCopyService;
using ECOLibrary.BusinessLayer.Services.BookService;
using ECOLibrary.BusinessLayer.Services.EmployeeService;
using ECOLibrary.BusinessLayer.Services.LoanService;
using ECOLibrary.BusinessLayer.Services.UserService;
using ECOLibrary.DataAccessLayer.Abstract;
using ECOLibrary.DataAccessLayer.Concrete;
using ECOLibrary.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<Context>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookRepository, EfBookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookCopyRepository, EfBookCopyRepository>();
builder.Services.AddScoped<IBookCopyService, BookCopyService>();
builder.Services.AddScoped<ILoanRepository, EfLoanRepository>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.LogoutPath = "/Login/Logout";
    });
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
