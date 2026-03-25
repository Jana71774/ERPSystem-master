using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ERPSystem.Models
{
public class GRN
{
    [Key]
    public int GRNID { get; set; }

    public DateTime GRNDate { get; set; }
    public string ItemCode { get; set; } = null!;
    public decimal Qty { get; set; }
    public string? BatchCode { get; set; }
    public string? LoginID { get; set; }
    public string? VendorName { get; set; }
    public decimal? ValueQty { get; set; }

    [ForeignKey("ItemCode")]
    public ItemData? ItemData { get; set; }
}
}