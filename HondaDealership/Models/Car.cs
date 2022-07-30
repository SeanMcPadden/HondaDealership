using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HondaDealership.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string CarModel { get; set; }

        public int Year { get; set; }

        public string Colour { get; set; }

        public string Registration { get; set; }

        public decimal Price { get; set; }
    }
}
