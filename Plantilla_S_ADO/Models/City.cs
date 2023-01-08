using System.Text.Json.Serialization;
using System;

namespace Plantilla_S_ADO.Models
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public long population { get; set; }
        public DateTime updatedDate { get; set; }
        [JsonIgnore]
        public Guid Token { get; set; }
        public bool disabled { get; set; }
        public int pib { get; set; }
        public int id_country { get; set; }

    }
}
