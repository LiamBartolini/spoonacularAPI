using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_version.Models
{
    public class Recipe
    {
        public Result[] results { get; set; }
        public int number { get; set; }
        public int totalResults { get; set; }
    }

    public class Result
    {
        public string title { get; set; }
        public string image { get; set; }
        public Nutrient[] nutrition { get; set; }
    }

    public class Nutrient
    {
        public string name { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
    }
}
