using System;
using Senai.POO.Pilares.Models;

namespace Senai.POO.Pilares.Controllers
{
    public class CarroController
    {
        // Declarando objeto do tipo CarroModel
        CarroModel carro = new CarroModel();

        /// <summary>
        /// Acelera o carro se o mesmo estiver ligado
        /// </summary>
        public void Acelerar()
        {
            if (carro.Ligado == true)
            {
                System.Console.WriteLine("Carro acelerando!");
            } else {
                System.Console.WriteLine("O carro não está ligado! Não é possível acelerar!");
            }
        }

        /// <summary>
        /// Freia o carro se o mesmo estiver ligado
        /// </summary>
        public void Freiar()
        {
            if (carro.Ligado == true)
            {
                System.Console.WriteLine("Carro freiando...");
            } else {
                System.Console.WriteLine("O carro não está ligado! Não é possível freiar!");
            }
        }

        /// <summary>
        /// Ligar o carro
        /// </summary>
        public void Ligar()
        {
            carro.Ligado = true;
            System.Console.WriteLine("Ligando carro!");
        }

        /// <summary>
        /// Desligar o carro
        /// </summary>
        public void Desligar()
        {
            carro.Ligado = false;
            System.Console.WriteLine("Desligando carro...");
        }

        /// <summary>
        /// Cadastra o motor do carro
        /// </summary>
        public void CadastrarMotor()
        {
            System.Console.WriteLine("Insira quantos cavalos tem o motor:");
            carro.Motor.Cavalos = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Insira quantos cilindros tem o carro:");
            carro.Motor.Cilindros = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Insira o nome do cilindro do carro:");
            carro.Motor.Pistao = Console.ReadLine();
        }
    }
}