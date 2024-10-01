﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        public string? Description { get; set; }
    }
}
