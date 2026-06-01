using System.ComponentModel.DataAnnotations;

namespace ZestrApi.Models
{
    public class MenuItem
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, 1000.00)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(30)]
        public string Department { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}