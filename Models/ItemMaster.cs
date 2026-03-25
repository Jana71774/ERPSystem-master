namespace ERPSystem.Models
{
    public class ItemMaster
    {
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? ItemType { get; set; }
        public string? ItemDesc { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}