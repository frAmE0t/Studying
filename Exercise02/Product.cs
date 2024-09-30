using System.ComponentModel.DataAnnotations;

namespace Exercise02
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public bool? Discontinued { get; set; }

        public int? CategoryId { get; set; }
    }
}
