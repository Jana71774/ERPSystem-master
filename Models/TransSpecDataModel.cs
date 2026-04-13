using System.ComponentModel.DataAnnotations;

namespace ERPSystem.Models
{
    public class TransSpecDataModel
    {
        [Key]
        public int StockID { get; set; }

        [Required(ErrorMessage = "Spec ID is required")]
        public string SpecID { get; set; } = string.Empty;

        [Required(ErrorMessage = "Value is required")]
        public string Value { get; set; } = string.Empty;

        [Required(ErrorMessage = "Item Code is required")]
        public string Itemcode { get; set; } = string.Empty;

        public string ItemName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Spec Name is required")]
        public string SpecName { get; set; } = string.Empty;
    }
}

