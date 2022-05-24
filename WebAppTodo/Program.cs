using WebAppTodo.Models;
using WebAppTodo.MyServices;
using GraphQL;
using GraphQL.DI;
using GraphQL.Server;
using GraphQL.Types;
using WebAppTodo.GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.MicrosoftDI;
using GraphQL.Server.Ui.Altair;
using GraphQL.Server.Transports.AspNetCore.SystemTextJson;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<TaskActionRepository>();
builder.Services.AddTransient<TaskRepository>();
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<ITaskRepository, TaskActionRepository>();

builder.Services.AddSingleton<TodoSchema>();
builder.Services.AddSingleton<ISchema, TodoSchema>();
builder.Services.AddTransient<TodoSchema>();
builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();



// default setup
builder.Services.AddControllers();

object p = builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TodoList", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLNetExample v1"));
    // add altair UI to development only
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseGraphQL<ISchema>();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=TaskList}/{id?}");

app.Run();
