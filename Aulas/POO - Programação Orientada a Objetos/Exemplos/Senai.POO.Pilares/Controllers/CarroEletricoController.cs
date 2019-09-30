using Senai.POO.Pilares.Models;

namespace Senai.POO.Pilares.Controllers
{
    public class CarroEletricoController : CarroController
    {
        /// Instanciando Objeto CarroEletricoModel
        CarroEletricoModel carro = new CarroEletricoModel();
        
        // Estamos declarando o objeto 'motor'
        MotorModel motor = new MotorModel();

        /// <summary>
        /// Declarando método de carregar bateria
        /// </summary>
        /// <param name="carga"></param>
        public void CarregarBateria(float carga)
        {
            if (carro.Bateria < 100){
                carro.Bateria += carga;
            }
        }

        /// <summary>
        /// Retorna o Status da bateria.
        /// </summary>
        /// <returns>float</returns>
        public float StatusBateria()
        {
            return carro.Bateria;
        }
    }
}