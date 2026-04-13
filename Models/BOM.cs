using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ERPSystem.Models
{
public class BOM
{
    [Key]
    public int BOMID { get; set; }

    [Required(ErrorMessage = "Product ID is required")]
    public string ProductID { get; set; } = null!;

    [Required(ErrorMessage = "Model No is required")]
    public string ModelNo { get; set; } = null!;

    public string? Description { get; set; }

    [Required(ErrorMessage = "Item Code is required")]
    public string ItemCode { get; set; } = null!;

    [Required(ErrorMessage = "Item Name is required")]
    public string ItemName { get; set; } = null!;

    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Qty { get; set; }

    [ForeignKey("ProductID")]
    public Product? Product { get; set; }

    [ForeignKey("ItemCode")]
    public ItemMaster? ItemMaster { get; set; }
}
}