using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public float Price { get; set; }

        public float Cost { get; set; }
    }
}
