using System.ComponentModel.DataAnnotations;
namespace ERPSystem.Models
{
public class Salesperson
{
    [Key]
    public string EmpID { get; set; } = null!;

    public string? Name { get; set; }
    public string? Region { get; set; }
    public int Target { get; set; }
}
}