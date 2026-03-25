namespace ERPSystem.Models
{
    public class PO
    {
        public int OrderID { get; set; }
        public string? PONo { get; set; }
        public string? Customerid { get; set; }
        public int qty { get; set; }
        public string? productid { get; set; }
        public string? Description { get; set; }
        public string? LicenceType { get; set; }
        public string? Saletype { get; set; }
        public string? Salesperson { get; set; }
        public int WarrantyYEAR { get; set; }
        public string? Attachment { get; set; }
    }
}