using System.Collections.Generic;
using System;

namespace Plantilla_S_EF.Models.respondsModels
{
    public class CountryRespond
    {
        public int id { get; set; }
        public string name { get; set; }
        public long population { get; set; }
        public DateTime updatedDate { get; set; }
        public Guid Token { get; set; }
        public bool disabled { get; set; }
        public int pib { get; set; }
        public List<City> cities { get; set; }
    }
}
