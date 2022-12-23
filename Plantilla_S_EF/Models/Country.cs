using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Plantilla_S_EF.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "varchar(120)")]
        public string name { get; set; }

        [Column(TypeName = "bigint")]
        public long population { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime updatedDate { get; set; }

        [Column(TypeName = "varchar(200)")]
        [JsonIgnore]
        public Guid Token { get; set; }

        [Column(TypeName = "bit")]
        public bool disabled { get; set; }

        [Column(TypeName = "int")]
        public int pib { get; set; }

        [InverseProperty("country")]
        [JsonIgnore]
        public virtual ICollection<City> cities { get; set; }




    }
}
