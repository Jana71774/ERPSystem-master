using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ERPSystem.Models
{
public class BOM
{
    [Key]
    public int BOMID { get; set; }

    public string? ProductID { get; set; }
    public string? ModelNo { get; set; }
    public string? Description { get; set; }
    public string? ItemCode { get; set; }
    public string? ItemName { get; set; }
    public int Qty { get; set; }

    [ForeignKey("ProductID")]
    public Product? Product { get; set; }

    [ForeignKey("ItemCode")]
    public ItemMaster? ItemMaster { get; set; }
}
}