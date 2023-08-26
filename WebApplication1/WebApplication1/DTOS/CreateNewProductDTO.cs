using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOS
{
    public class CreateNewProductDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public float Cost { get; set; }
    }
}
