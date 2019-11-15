using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            Presenca = new HashSet<Presenca>();
        }

        [Key]
        [Column("Evento_id")]
        public int EventoId { get; set; }
        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }
        [Column("Categoria_id")]
        public int? CategoriaId { get; set; }
        [Column("Acesso_livre")]
        public bool? AcessoLivre { get; set; }
        [Column("Data_evento", TypeName = "datetime")]
        public DateTime DataEvento { get; set; }
        [Column("Localizacao_id")]
        public int? LocalizacaoId { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        [InverseProperty("Evento")]
        public virtual Categoria Categoria { get; set; }
        [ForeignKey(nameof(LocalizacaoId))]
        [InverseProperty("Evento")]
        public virtual Localizacao Localizacao { get; set; }
        [InverseProperty("Evento")]
        public virtual ICollection<Presenca> Presenca { get; set; }
    }
}
