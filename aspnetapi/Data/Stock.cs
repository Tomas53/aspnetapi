using System.ComponentModel.DataAnnotations;

namespace aspnetapi.Data
{
    public sealed class Stock //this class is private and cannot be inherited from
    {
        [Key]
        public int StockId { get; set; }

        [Required]
        [MaxLength(100)]
        public string StockName { get; set; }=String.Empty;
        [Required]
        [MaxLength(1000000)]
        public string Country { get; set; } = String.Empty;
        [Required]
        [MaxLength(1000000)]
        public string Price { get; set; } = String.Empty;//""
        [Required]
        [MaxLength(1000000)]
        public string Data { get; set; } = String.Empty;


    }
}
