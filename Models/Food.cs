using System;
using System.ComponentModel.DataAnnotations;

namespace newProjectJs.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}