using ECOLibrary.BusinessLayer.Mapping;
using ECOLibrary.DataAccessLayer.Abstract;
using ECOLibrary.DataAccessLayer.Concrete;
using ECOLibrary.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<Context>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
builder.Services.AddScoped<IBookRepository, EfBookRepository>();
builder.Services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IBookCopyRepository, EfBookCopyRepository>();
builder.Services.AddScoped<ILoanRepository, EfLoanRepository>();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
