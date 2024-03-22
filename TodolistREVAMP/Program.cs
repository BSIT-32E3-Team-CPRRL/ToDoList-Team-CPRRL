using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext and specify the connection string
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("TodoListConnection"), new MySqlServerVersion(new Version(8, 0, 23))));

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
    pattern: "{controller=Todo}/{action=Index}/{id?}");

//delete action
app.MapControllerRoute(
    name: "todo",
    pattern: "Todo/{action=Index}/{id?}");

app.Run();
