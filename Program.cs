using ERPSystem.Services;
using ERPSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Licensing;
using Syncfusion.EJ2;

var builder = WebApplication.CreateBuilder(args);

// Register Syncfusion License
SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JGaF1cXmhKYVJxWmFZfVhgd19FaVZTQWYuP1ZhSXxVdkZiWX9dc31XQ2dYWUB9XEA=");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JGaF1cXmhKYVJxWmFZfVhgd19FaVZTQWYuP1ZhSXxVdkZiWX9dc31XQ2dYWUB9XEA=");

// MVC
builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

// Syncfusion

builder.Services.AddSyncfusionSmartComponents();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    ));

// DAL Registration
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

// Services
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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();