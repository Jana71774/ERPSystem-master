using ERPSystem.Services;
using ERPSystem.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))));

// 🔹 Register DALs
builder.Services.AddScoped<LoginDAL>();
builder.Services.AddScoped<CustomerDAL>();
builder.Services.AddScoped<ProductDAL>();
builder.Services.AddScoped<PODAL>();
builder.Services.AddScoped<InventoryDAL>();
builder.Services.AddScoped<GRNDAL>();
builder.Services.AddScoped<SalespersonDAL>();
builder.Services.AddScoped<ItemMasterDAL>();
builder.Services.AddScoped<ItemDataDAL>();
builder.Services.AddScoped<BOMDAL>();
builder.Services.AddScoped<SpecDAL>();
builder.Services.AddScoped<TransSpecDataDAL>();
builder.Services.AddScoped<DashboardDAL>();

// 🔹 Register Services
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<POService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<GRNService>();
builder.Services.AddScoped<SalespersonService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<BOMService>();
builder.Services.AddScoped<SpecService>();
builder.Services.AddScoped<TransSpecService>();
builder.Services.AddScoped<ItemMasterService>();
builder.Services.AddScoped<ItemDataService>();
builder.Services.AddScoped<ItemMasterService>();

 // if you have one

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();