namespace Senai.POO.Pilares.Models
{
    public class CarroModel
    {
        /// <summary>
        /// Marca do carro
        /// </summary>
        /// <value>string</value>
        public string Marca { get; set; }
        
        /// <summary>
        /// Modelo do carro
        /// </summary>
        /// <value>string</value>
        public string Modelo { get; set; }
        
        /// <summary>
        /// Cor do carro
        /// </summary>
        /// <value>string</value>
        public string Cor { get; set; }
        
        /// <summary>
        /// Placa do carro
        /// </summary>
        /// <value>string</value>
        public string Placa { get; set; }

        /// <summary>
        /// Objeto do motor do carro
        /// </summary>
        /// <value>MotorModel</value>
        public MotorModel Motor { get; set; }

        /// <summary>
        /// Propriedade que diz se o carro está ligado ou não
        /// </summary>
        /// <value>Se for 'true', o carro está ligado. Se for 'false', o carro está desligado</value>
        public bool Ligado {get; set;}
    }
}