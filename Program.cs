using TodoApp.Data;
using TodoApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Ajouter DbContext
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajouter le Repository
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// Configurer MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurer le pipeline
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
    pattern: "{controller=Todo}/{action=Index}/{id?}");

app.Run();
