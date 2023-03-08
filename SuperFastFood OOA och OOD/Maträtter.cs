using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFastFood_OOA_och_OOD
{
    internal class Maträtter
    {
        public string Dish {get; set;}

        public string Price { get; set;}

        public static List <Maträtter> GetMaträtter = new List<Maträtter>();

        public Maträtter(string Dish, string Price)
        {
            this.Dish = Dish;
            this.Price = Price;
        }
    }
}
