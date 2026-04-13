using ERPSystem.Services;
using ERPSystem.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// 🔹 Session (fixed configuration)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);   // session active for 30 mins
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

// 🔹 MySQL Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    )
);

// ===================== DAL =====================
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

// ===================== SERVICES =====================
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

var app = builder.Build();

// ===================== MIDDLEWARE =====================
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔹 session must be before authorization
app.UseSession();

app.UseAuthorization();

// ===================== ROUTING =====================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();