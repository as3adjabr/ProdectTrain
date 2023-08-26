using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public float Cost { get; set; }
    }
}
