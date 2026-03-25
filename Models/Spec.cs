using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPSystem.Models
{
    [Table("tblSpec")]
    public class Spec
    {
        public string ItemCode { get; set; } = null!; 
        public string SpecId { get; set; } = null!;

        public string? ItemName { get; set; }
        public string? SpecData { get; set; }
        public string? SpecValue { get; set; }
    }
}