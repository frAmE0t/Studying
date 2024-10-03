using System.ComponentModel.DataAnnotations;

namespace Packt.Shared
{
    public class Customer
    {
        [Required]
        [StringLength(5)]
        public string CustomerId { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(15)]
        public string? City { get; set; } = null!;
    }
}
