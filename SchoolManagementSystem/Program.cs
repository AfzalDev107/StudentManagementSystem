using SchoolManagementSystem.DAL.Interfaces;
using SchoolManagementSystem.DAL.Repositories;
using SchoolManagementSystem.Service.Interfaces;
using SchoolManagementSystem.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Register your services and repositories with DI
builder.Services.AddSingleton<IStudentRepository, StudentRepository>(); // Registering the repository
builder.Services.AddSingleton<IStudentService, StudentService>();     // Registering the service

// Add MVC controllers with views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
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
    pattern: "{controller=StudentRegistration}/{action=Register}/{id?}");

app.Run();
