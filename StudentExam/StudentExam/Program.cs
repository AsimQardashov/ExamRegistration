using DataAccess;
using DataAccess.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
});

// Repository assignment
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IStudentInterface, StudentRepesitory>();
builder.Services.AddScoped<IExamInterface, ExamRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Lesson}/{action=Index}/{id?}"); 

//app.MapControllerRoute(
//    name: "Update",
//    pattern: "{controller=Lesson}/{action=Update}/{id?}");

app.Run();
