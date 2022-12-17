using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        public Guid Token { get; set; }

        [Column(TypeName ="bit")]
        public bool disabled { get; set; }

        [Column(TypeName ="int")]
        public int pib { get; set; }

    }
}
