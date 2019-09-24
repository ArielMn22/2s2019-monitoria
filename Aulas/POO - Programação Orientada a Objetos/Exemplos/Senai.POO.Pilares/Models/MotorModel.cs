namespace Senai.POO.Pilares.Models
{
    public class MotorModel
    {
        /// <summary>
        /// Quantidade de cavalos, potência
        /// </summary>
        /// <value>int</value>
        public int Cavalos { get; set; }
        
        /// <summary>
        /// Quantidade de cilindros
        /// </summary>
        /// <value>int</value>
        public int Cilindros { get; set; }
        
        /// <summary>
        /// Nome pistão
        /// </summary>
        /// <value>string</value>
        public string Pistao { get; set; }
        
        /// <summary>
        /// Nome da vela de ignição
        /// </summary>
        /// <value>string</value>
        public string VelaIgnicao { get; set; }
        
        /// <summary>
        /// Nome do radiador
        /// </summary>
        /// <value>string</value>
        public string Radiador { get; set; }
    }
}