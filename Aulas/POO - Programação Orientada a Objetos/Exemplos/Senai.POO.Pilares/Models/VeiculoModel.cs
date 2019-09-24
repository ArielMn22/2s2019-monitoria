namespace Senai.POO.Pilares.Models
{
    public class VeiculoModel
    {
        public static string Tipo { get; set; }
        public static void Mover()
        {
            System.Console.WriteLine("Movendo veículo: " + Tipo);
        }
    }
}