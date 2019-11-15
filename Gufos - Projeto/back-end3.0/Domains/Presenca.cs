using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domains
{
    public partial class Presenca
    {
        [Key]
        [Column("Presenca_id")]
        public int PresencaId { get; set; }
        [Column("Evento_id")]
        public int? EventoId { get; set; }
        [Column("Usuario_id")]
        public int? UsuarioId { get; set; }
        [Required]
        [StringLength(255)]
        public string Status { get; set; }

        [ForeignKey(nameof(EventoId))]
        [InverseProperty("Presenca")]
        public virtual Evento Evento { get; set; }
        [ForeignKey(nameof(UsuarioId))]
        [InverseProperty("Presenca")]
        public virtual Usuario Usuario { get; set; }
    }
}
