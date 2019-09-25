using System;
using Senai.POO.CadastroDeAlunos.Models;

namespace Senai.POO.CadastroDeAlunos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declarando Objeto
            AlunoModel aluno1 = new AlunoModel(); // Declarando uma nova instância

            // Limpa a tela
            Console.Clear();

            // Cadastra um aluno.
            aluno1.CadastrarAluno();

            // Exibindo as informações
            aluno1.ExibirAluno();

            // Chamando método do objeto 'aluno1'
            aluno1.IrNoBanheiro();
        }
    }
}
