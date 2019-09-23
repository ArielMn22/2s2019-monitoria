namespace Senai.POO.Pilares.Models
{
    public class CarroModel : VeiculoModel
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }

        public MotorModel Motor { get; set; }
    }
}