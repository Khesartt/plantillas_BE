using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Plantilla_S_EF.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        public int id { get; set; }
        
        [Column(TypeName ="varchar(120)")]
        public string name { get; set; }

        [Column(TypeName ="bigint")]
        public long population { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime updatedDate { get; set; }

        [Column(TypeName ="varchar(200)")]
        [JsonIgnore]
        public Guid Token { get; set; }

        [Column(TypeName ="bit")]
        public bool disabled { get; set; }

        [Column(TypeName ="int")]
        public int pib { get; set; }
        public int id_country { get; set; }

        [ForeignKey("id_country")]
        [InverseProperty("cities")]
        [JsonIgnore]
        public virtual Country country { get; set; }

    }
}
