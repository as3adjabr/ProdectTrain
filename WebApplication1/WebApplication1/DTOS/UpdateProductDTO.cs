﻿namespace WebApplication1.DTOS
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public float Cost { get; set; }
    }
}
