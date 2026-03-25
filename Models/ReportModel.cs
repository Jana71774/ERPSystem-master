using System;

namespace ERPSystem.Models
{
    public class ReportModel
    {
        public int ReportId { get; set; }
        public string? ReportName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}