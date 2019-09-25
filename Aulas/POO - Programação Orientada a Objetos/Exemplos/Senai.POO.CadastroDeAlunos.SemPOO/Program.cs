﻿using System;

namespace Senai.POO.CadastroDeAlunos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaranda variáveis
            string nome, curso;
            int rg = 0, idade = 0;

            Console.Clear(); // Limpa a tela

            // Lendo nome
            System.Console.WriteLine("Insira seu nome:");
            nome = Console.ReadLine();
            
            // Lendo nome do curso
            System.Console.WriteLine("Insira o nome de seu curso: ");
            curso = Console.ReadLine();
            
            // Lendo RG
            System.Console.WriteLine("Insira seu RG: ");
            rg = int.Parse(Console.ReadLine());
            
            // Lendo idade
            System.Console.WriteLine("Insira sua idade: ");
            idade = int.Parse(Console.ReadLine());

            // Exibindo as informações
            System.Console.WriteLine("Nome: " + nome);
            System.Console.WriteLine("Curso: " + curso);
            System.Console.WriteLine("RG: " + rg);
            System.Console.WriteLine("Idade: " + idade);
        }
    }
}
