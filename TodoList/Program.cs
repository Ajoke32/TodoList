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




builder.Services.AddScoped<RootMutation>();
builder.Services.AddScoped<RootQuery>();

builder.Services.AddGraphQL((options)=>
{
	
	options.AddSchema<AppSchema>(serviceLifetime:GraphQL.DI.ServiceLifetime.Scoped)
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


app.UseRouting();
app.UseCors(o =>o.WithOrigins("http://localhost:3000/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Task}/{action=Tasks}");

app.Run();
