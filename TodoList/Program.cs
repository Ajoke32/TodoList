using TodoList.Interfaces;
using TodoList.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ITaskRepository, TaskRepository>(serv =>
{
    IConfiguration configuration =  serv.GetRequiredService<IConfiguration>();
    string? connectionString = configuration.GetConnectionString("DefaultConnection");
    if (connectionString == null)
    {
        throw new Exception("Connecion string is not set up");
    }
    return new TaskRepository(connectionString);
});
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>(serv =>
{
    IConfiguration configuration = serv.GetRequiredService<IConfiguration>();
    string? connectionString = configuration.GetConnectionString("DefaultConnection");
    if (connectionString == null)
    {
        throw new Exception("Connecion string is not set up");
    }
    return new CategoryRepository(connectionString);
});

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
    pattern: "{controller=Task}/{action=Tasks}");

app.Run();
