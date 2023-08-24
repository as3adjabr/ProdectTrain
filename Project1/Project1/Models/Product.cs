using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public float price { get; set; }

        public float cost { get; set; }
    }
}
