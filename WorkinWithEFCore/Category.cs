using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared
{
    public class Category
    {
        [Required]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        public string? CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}
