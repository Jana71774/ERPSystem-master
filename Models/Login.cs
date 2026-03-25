namespace ERPSystem.Models
{
    public class Login
    {
        public string? LoginId { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}