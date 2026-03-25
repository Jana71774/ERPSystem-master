namespace ERPSystem.Models
{
    public class Customer
    {
        public string? CustomerID { get; set; }
        public string? Address { get; set; }
        public string? Region { get; set; }
        public string? Email { get; set; }
        public string? ContactPerson { get; set; }
        public string? PhoneNo { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}