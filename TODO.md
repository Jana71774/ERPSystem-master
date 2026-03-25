# ERPSystem Error Fixes - Progress Tracker

## Remaining Steps:
- [x] 1. Fix ERPSystem.csproj (TargetFramework to net8.0, add EF Core packages)
- [x] 2. Fix Program.cs (add using, AddDbContext registration)
- [x] 3. Fix Razor @model typos/mismatches in all affected views (Customer/Edit, ItemData/Create+Edit, BOM/GRN/PO/Inventory/Product/Salesperson/ItemMaster/Spec/TransSpec Index/Create/Edit)
- [ ] 4. Run `dotnet restore &amp;&amp; dotnet build` (verify 0 errors)
- [ ] 5. Run `dotnet ef migrations add InitialCreate --startup-project .` (optional if needed)
- [ ] 6. `dotnet run` and test pages
