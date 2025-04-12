using System;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace RentoFull.Models
{
    public class CarsDB : DbContext
    {
      
        public CarsDB()
            : base("name=CarsDB")
        {
        }
        public DbSet<Car> Cars { get; set; }
    }

    
}