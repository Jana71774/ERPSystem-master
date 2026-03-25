using System;
using System.ComponentModel.DataAnnotations;
namespace ERPSystem.Models
{
public class Login
{
    [Key]
    public string LoginId { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } = null!;

    public string? Role { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
}