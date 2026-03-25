namespace ERPSystem.Models
{
    public class Inventory
    {
        public int StockID { get; set; }
        public string? ItemCode { get; set; }
        public int AvlQty { get; set; }
        public int MinQty { get; set; }
        public int OrderQty { get; set; }
        public string? Description { get; set; }
        public string? LoginID { get; set; }
        public string? LoginName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}