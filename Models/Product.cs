using System.ComponentModel.DataAnnotations;
namespace ERPSystem.Models
{
public class Product
{
    [Key]
    public string ProductID { get; set; } = null!;

    public string? ProdName { get; set; }
    public string? ModelNo { get; set; }
    public string? ModelName { get; set; }
    public string? Description { get; set; }
}
}