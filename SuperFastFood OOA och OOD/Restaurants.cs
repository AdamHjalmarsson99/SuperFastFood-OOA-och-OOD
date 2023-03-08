using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFastFood_OOA_och_OOD
{
    internal class Restaurants
    {
        public string Restauranger { get; set; }

        public static List <Restaurants> rest = new List <Restaurants> ();

        public Restaurants(string Restauranger)
        {
            this.Restauranger = Restauranger;
        }
    }
}
