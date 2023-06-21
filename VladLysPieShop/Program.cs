using VladLysPieShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("VladLysPieShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'VladLysPieShopDbContextConnection' not found.");

builder.Services.AddDbContext<VladLysPieShopDbContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<VladLysPieShopDbContext>();

builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession(); 
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<VladLysPieShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:VladLysPieShopDbContextConnection"]);
});

//builder.Services.AddDefaultIdentity<IdentityUser>()
//.AddEntityFrameworkStores<VladLysPieShopDbContext>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();
//app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapBlazorHub();

app.MapFallbackToPage("/app/{*catchall}", "/App/Index");


DbInitializer.Seed(app);

app.Run();
