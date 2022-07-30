using HondaDealership.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HondaDealership.Data_Access
{
    public class ApplicationDBContext : DbContext
    {
        /*
        public DbSet<Car> Make { get; set; }
        public DbSet<Car> CarModel { get; set; }
        public DbSet<Car> Year { get; set; }
        public DbSet<Car> Colour { get; set; }
        public DbSet<Car> Registration { get; set; }
        public DbSet<Car> Price { get; set; }
        */

        public DbSet<Car> Car { get; set; }

        public DbSet<Car> selectedCar { get; set; }

        public DbSet<Car> car { get; set; }

        public DbContext justOneCar { get; set; }

        



        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }
}
