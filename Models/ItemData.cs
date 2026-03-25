using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ERPSystem.Models
{
public class ItemData
{
    [Key]
    public string ItemCode { get; set; } = null!;

    [Required]
    public string ItemName { get; set; } = null!;

    public string? ItemDataValue { get; set; } // renamed from "itemdata" to avoid conflict

    public string? SpecID { get; set; }
    public string? SpecData { get; set; }

    [ForeignKey("ItemCode")]
    public ItemMaster? ItemMaster { get; set; }
}
}