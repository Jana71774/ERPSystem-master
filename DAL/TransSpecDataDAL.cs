using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;


namespace ERPSystem.DAL
{
    public class TransSpecDataDAL
    {
        private readonly AppDbContext _context;

        public TransSpecDataDAL(AppDbContext context)
        {
            _context = context;
        }

public async Task<IEnumerable<TransSpecDataModel>> GetAll()
        {
            var transData = await _context.Set<TransSpecDataModel>().ToListAsync();
            var itemMasters = await _context.ItemMaster.ToDictionaryAsync(i => i.ItemCode);
            var specs = await _context.Spec.ToDictionaryAsync(s => new { s.ItemCode, s.SpecId });

            return transData.Select(t => new TransSpecDataModel
            {
                StockID = t.StockID,
                SpecID = t.SpecID,
                Value = t.Value,
                Itemcode = t.Itemcode,
                ItemName = string.IsNullOrEmpty(t.ItemName) ? (itemMasters.TryGetValue(t.Itemcode ?? "", out var item) ? item.ItemName : "") : t.ItemName,
                SpecName = string.IsNullOrEmpty(t.SpecName) ? (specs.TryGetValue(new { ItemCode = t.Itemcode ?? "", SpecId = t.SpecID ?? "" }, out var spec) ? spec.SpecData ?? "" : (t.SpecID ?? "")) : t.SpecName,
            }).ToList();
        }

        public async Task Insert(TransSpecDataModel model)
        {
            await _context.Set<TransSpecDataModel>().AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TransSpecDataModel model)
        {
            _context.Set<TransSpecDataModel>().Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.Set<TransSpecDataModel>().FindAsync(id);

            if (data != null)
            {
                _context.Set<TransSpecDataModel>().Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> GetNextSpecId()
        {
            var specIds = await _context.Set<TransSpecDataModel>()
                .Where(t => t.SpecID != null && t.SpecID.StartsWith("SP"))
                .Select(t => t.SpecID!)
                .ToListAsync();

            string maxSpec = "SP000";
            int maxNum = 0;

            foreach (var specId in specIds)
            {
                if (Regex.IsMatch(specId, @"^SP(\d+)$"))
                {
                    var num = int.Parse(Regex.Match(specId, @"SP(\d+)").Groups[1].Value);
                    if (num > maxNum)
                    {
                        maxNum = num;
                        maxSpec = specId;
                    }
                }
            }

            var nextNum = maxNum + 1;
            return $"SP{nextNum:D3}";
        }
    }
}
