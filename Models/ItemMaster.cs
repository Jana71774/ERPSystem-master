using System;
using System.ComponentModel.DataAnnotations;
namespace ERPSystem.Models
{
public class ItemMaster
{
    [Key]
    public string ItemCode { get; set; } = null!;

    [Required]
    public string ItemName { get; set; } = null!;

    [Required]
    public string ItemType { get; set; } = null!;

    public string? ItemDesc { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
}