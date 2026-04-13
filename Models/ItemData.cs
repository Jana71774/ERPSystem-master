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

    [Column("itemdata")]
<<<<<<< HEAD
    public string? ItemDataValue { get; set; } 
=======
    public string? ItemDataValue { get; set; }
>>>>>>> 2e17255de0e76bfeb232eb5aa76ea0b362eb7a20

    public string? SpecID { get; set; }
    public string? SpecData { get; set; }

    [ForeignKey("ItemCode")]
    public ItemMaster? ItemMaster { get; set; }
}
}