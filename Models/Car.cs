using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentoFull.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Type CType { get; set; }
        public string CImage { get; set; }
        public float Price { get; set; }
        public bool CAvailable { get; set; }



    }

    public enum Type
    {
        Normal,
        Family,
        Sport
    }

}