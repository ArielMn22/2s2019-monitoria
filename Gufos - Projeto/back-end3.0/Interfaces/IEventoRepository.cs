using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains;

namespace backend.Interfaces
{
    public interface IEventoRepository
    {
        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Retorna uma lista de eventos</returns>
        Task<List<Evento>> Listar();
        
        /// <summary>
        /// Busca um evento através do seu ID
        /// </summary>
        /// <param name="id">Identificador específico do evento</param>
        /// <returns>Retorna um evento buscado</returns>
        Evento BuscarPorID(int id);

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="evento">Objeto evento com os dados que serão cadastrados</param>
        /// <returns>Retorna um evento cadastrado</returns>
        Task<Evento> Salvar(Evento evento);
        
        /// <summary>
        /// Altera um evento existente
        /// </summary>
        /// <param name="evento">Objeto evento com os dados que serão atualizados</param>
        /// <returns>Retorna um evento atualizado</returns>
        Task<Evento> Alterar(Evento evento);

        /// <summary>
        /// Deleta um evento existente
        /// </summary>
        /// <param name="evento">Objeto evento com os dados que serão deletados</param>
        /// <returns>Retorna um evento deletado</returns>
        Task<Evento> Excluir(Evento evento);

        /// <summary>
        /// Lista todas os eventos que atendem ao filtro
        /// </summary>
        /// <param name="filtro">Filtro que será aplicado na busca</param>
        /// <returns>Retorna uma lista de eventos filtrados</returns>
        List<Evento> FiltrarPorNome(string filtro);

        /// <summary>
        /// Lista todos os eventos de forma ordenada
        /// </summary>
        /// <returns>Retorna uma lista de eventos ordenada</returns>
        List<Evento> Ordenar();
    }
}