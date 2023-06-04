using TodoList.Interfaces;
using TodoList.Repositories;
using TodoList.GraphQL.AppSchema;
using GraphQL;
using TodoList.GraphQL.Mutations;
using TodoList.Utils;
using TodoList.GraphQL.Schemes;
using TodoList.GraphQL.Queries;
using GraphQL.Server.Transports.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
	options.AddPolicy(name:MyAllowSpecificOrigins,c =>
	{
		c.WithOrigins("http://localhost:3000/").AllowAnyHeader().AllowAnyMethod().AllowAnyHeader();
	});
});
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<TaskRepositoryManager>();


builder.Services.AddTransient<ITaskRepository>(serv=>
{
	var repo = serv.GetRequiredService<TaskRepositoryManager>();
	return repo.GetTaskRepository();
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




builder.Services.AddScoped<TaskQuery>();
builder.Services.AddScoped<TaskMutation>();
builder.Services.AddScoped<CategoryQuery>();
builder.Services.AddScoped<CategoryMutation>();

builder.Services.AddGraphQL((options)=>
{
	
	options.AddSchema<TaskSchema>(serviceLifetime:GraphQL.DI.ServiceLifetime.Scoped)
	.AddSchema<CategorySchema>(serviceLifetime:GraphQL.DI.ServiceLifetime.Scoped)
	.AddGraphTypes()
	.AddErrorInfoProvider(e=>e.ExposeExceptionDetails=true)
	.AddSystemTextJson();
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

app.UseGraphQLAltair("/ui/graphql")
	.UseGraphQL();

app.MapGraphQL<TaskSchema>("tasks");
app.MapGraphQL<CategorySchema>("category");
app.UseRouting();
app.UseCors(o =>o.WithOrigins("http://localhost:3000/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Task}/{action=Tasks}");

app.Run();
