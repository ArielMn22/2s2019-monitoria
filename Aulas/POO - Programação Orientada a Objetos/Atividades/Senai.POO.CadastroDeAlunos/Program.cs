using System;
using Senai.POO.CadastroDeAlunos.Models;

namespace Senai.POO.CadastroDeAlunos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declarando Objeto
            AlunoModel aluno1 = new AlunoModel();

            Console.Clear(); // Limpa a tela

            // Lendo nome
            System.Console.WriteLine("Insira seu nome:");
            aluno1.Nome = Console.ReadLine();
            
            // Lendo nome do curso
            System.Console.WriteLine("Insira o nome de seu curso: ");
            aluno1.Curso = Console.ReadLine();
            
            // Lendo RG
            System.Console.WriteLine("Insira seu RG: ");
            aluno1.Rg = int.Parse(Console.ReadLine());
            
            // Lendo idade
            System.Console.WriteLine("Insira sua idade: ");
            aluno1.Idade = int.Parse(Console.ReadLine());

            // Exibindo as informações
            System.Console.WriteLine("Nome: " + aluno1.Nome);
            System.Console.WriteLine("Curso: " + aluno1.Curso);
            System.Console.WriteLine("RG: " + aluno1.Rg);
            System.Console.WriteLine("Idade: " + aluno1.Idade);
        }
    }
}
