using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ERPSystem.Models
{
public class Inventory
{
    [Key]
    public int StockID { get; set; }
    [Required]
    public string ItemCode { get; set; } = null!; // not nullable
    public int AvlQty { get; set; }
    public int MinQty { get; set; }
    public int OrderQty { get; set; }
    public string? Description { get; set; }
    public string? LoginID { get; set; }
    public string? LoginName { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [NotMapped]
    public ItemData? ItemData { get; set; } // disabled EF navigation to avoid schema issues
}
}