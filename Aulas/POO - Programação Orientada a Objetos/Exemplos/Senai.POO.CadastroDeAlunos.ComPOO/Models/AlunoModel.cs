using System;

namespace Senai.POO.CadastroDeAlunos.Models {
    /// <summary>
    /// Modelo de Aluno.
    /// </summary>
    public class AlunoModel {
        /// <summary>
        /// Nome do aluno.
        /// </summary>
        /// <value>String.</value>
        public string Nome {get; set; }

        /// <summary>
        /// Nome do curso.
        /// </summary>
        /// <value>String.</value>
        public string Curso { get; set; }

        /// <summary>
        /// RG do aluno.
        /// </summary>
        /// <value>int</value>
        public double Rg { get; set; }

        /// <summary>
        /// Idade do aluno.
        /// </summary>
        /// <value>Int.</value>
        public int Idade { get; set; }

        /// <summary>
        /// Exibe as informações do aluno.
        /// </summary>
        public void ExibirAluno () {
            System.Console.WriteLine ("Nome: " + Nome);
            System.Console.WriteLine ("Curso: " + Curso);
            System.Console.WriteLine ("RG: " + Rg);
            System.Console.WriteLine ("Idade: " + Idade);
        }

        /// <summary>
        /// Método ir no banheiro, somente imprime uma string na tela.
        /// </summary>
        public void IrNoBanheiro () {
            System.Console.WriteLine ("=======================================");
            System.Console.WriteLine ("      Deixa eu ir no banheiro AEEE!!");
            System.Console.WriteLine ("=======================================");
        }

        /// <summary>
        /// Cadastrar um aluno
        /// </summary>
        public void CadastrarAluno()
        {
            // Lendo nome
            System.Console.WriteLine("Insira seu nome:");
            Nome = Console.ReadLine();
            
            // Lendo nome do curso
            System.Console.WriteLine("Insira o nome de seu curso: ");
            Curso = Console.ReadLine();
            
            // Lendo RG
            System.Console.WriteLine("Insira seu RG: ");
            Rg = int.Parse(Console.ReadLine());
            
            // Lendo idade
            System.Console.WriteLine("Insira sua idade: ");
            Idade = int.Parse(Console.ReadLine());
        }
    }
}