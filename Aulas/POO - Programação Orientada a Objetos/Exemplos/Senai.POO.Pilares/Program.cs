using System;
using Senai.POO.Pilares.Models;
using Senai.POO.Pilares.Controllers;

namespace Senai.POO.Pilares
{
    class Program
    {
        static void Main(string[] args)
        {
            CarroController carro = new CarroController();
            CarroEletricoController carroEletrico = new CarroEletricoController();

            carro.Ligar();

            carro.Acelerar();
            carro.Freiar();

            carroEletrico.CarregarBateria(15);
            carroEletrico.CarregarBateria(15);
            System.Console.WriteLine(carroEletrico.StatusBateria());
        }
    }
}
