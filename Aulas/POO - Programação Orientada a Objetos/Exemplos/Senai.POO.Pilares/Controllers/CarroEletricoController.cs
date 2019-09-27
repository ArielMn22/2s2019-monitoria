using Senai.POO.Pilares.Models;

namespace Senai.POO.Pilares.Controllers
{
    public class CarroEletricoController : CarroController
    {
        CarroEletricoModel carro = new CarroEletricoModel();

        public void CarregarBateria(float carga)
        {
            if (carro.Bateria < 100){
                carro.Bateria += carga;
            }
        }

        public float StatusBateria()
        {
            return carro.Bateria;
        }
    }
}