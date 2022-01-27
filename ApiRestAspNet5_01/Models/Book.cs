using System;
using System.ComponentModel.DataAnnotations;

namespace ApiRestAspNet5_01.Model
{
    public class Book
    {
        [Required]
        public long Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
