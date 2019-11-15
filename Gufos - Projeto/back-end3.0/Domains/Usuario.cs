using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Presenca = new HashSet<Presenca>();
        }

        [Key]
        [Column("Usuario_id")]
        public int UsuarioId { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        [StringLength(255)]        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "A senha deve conter no mínimo 3 caracteres")]
        public string Senha { get; set; }
        [Column("Tipo_usuario_id")]
        public int? TipoUsuarioId { get; set; }

        [ForeignKey(nameof(TipoUsuarioId))]
        [InverseProperty("Usuario")]
        public virtual TipoUsuario TipoUsuario { get; set; }
        [InverseProperty("Usuario")]
        public virtual ICollection<Presenca> Presenca { get; set; }
    }
}
