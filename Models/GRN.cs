namespace ERPSystem.Models
{
    public class GRN
    {
        public int GRNID { get; set; }
        public DateTime GRNDate { get; set; }
        public string? ItemCode { get; set; }
        public decimal Qty { get; set; }
        public string? BatchCode { get; set; }
        public string? LoginID { get; set; }
        public string? VendorName { get; set; }
        public decimal ValueQty { get; set; }
    }
}