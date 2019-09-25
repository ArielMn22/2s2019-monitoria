namespace Senai.POO.CadastroDeAlunos.SomenteModel.Models
{
    /// <summary>
    /// Modelo de aluno
    /// </summary>
    public class AlunoModel
    {
        /// <summary>
        /// Nome do aluno
        /// </summary>
        /// <value>string</value>
        public string Nome { get; set; }
        
        /// <summary>
        /// Nome do curso
        /// </summary>
        /// <value>string</value>
        public string Curso { get; set; }
        
        /// <summary>
        /// Rg do aluno
        /// </summary>
        /// <value>int</value>
        public int Rg { get; set; }
        
        /// <summary>
        /// Idade do aluno
        /// </summary>
        /// <value>int</value>
        public int Idade { get; set; }
    }
}