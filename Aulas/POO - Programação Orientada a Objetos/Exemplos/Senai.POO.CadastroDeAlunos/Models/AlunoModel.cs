namespace Senai.POO.CadastroDeAlunos.Models
{
    /// <summary>
    /// Modelo de Aluno.
    /// </summary>
    public class AlunoModel
    {
        /// <summary>
        /// Nome do aluno.
        /// </summary>
        /// <value>String.</value>
        public string Nome {get; set;}

        /// <summary>
        /// Nome do curso.
        /// </summary>
        /// <value>String.</value>
        public string Curso {get; set;}

        /// <summary>
        /// RG do aluno.
        /// </summary>
        /// <value>Int.</value>
        public int Rg { get; set; }

        /// <summary>
        /// Idade do aluno.
        /// </summary>
        /// <value>Int.</value>
        public int Idade {get; set;}
    }
}