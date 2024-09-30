using System.ComponentModel.DataAnnotations;

namespace Exercise02
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        public string? Description { get; set; }
    }
}
