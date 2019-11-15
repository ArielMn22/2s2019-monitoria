using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domains
{
    public partial class Eventosview
    {
        [Column("#")]
        public int _ { get; set; }
        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }
        [Column("#Localizacao")]
        public int? Localizacao { get; set; }
        [Column("Data_evento", TypeName = "datetime")]
        public DateTime DataEvento { get; set; }
        [Required]
        [StringLength(255)]
        public string Categoria { get; set; }
    }
}
