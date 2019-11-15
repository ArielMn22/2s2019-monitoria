using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains;

namespace backend.Interfaces
{
    public interface IPresencaRepository
    {
        /// <summary>
        /// Lista todas as presencas
        /// </summary>
        /// <returns>Retorna uma lista de presencas</returns>
        Task<List<Presenca>> Listar();
        
        /// <summary>
        /// Busca uma preenca através do seu ID
        /// </summary>
        /// <param name="id">Identificador específico da presenca</param>
        /// <returns>Retorna uma presenca buscada</returns>
        Presenca BuscarPorID(int id);

        /// <summary>
        /// Cadastra uma nova presenca
        /// </summary>
        /// <param name="presenca">Objeto presenca com os dados que serão cadastrados</param>
        /// <returns>Retorna um presenca cadastrada</returns>
        Task<Presenca> Salvar(Presenca presenca);
        
        /// <summary>
        /// Altera um presenca existente
        /// </summary>
        /// <param name="presenca">Objeto presenca com os dados que serão atualizados</param>
        /// <returns>Retorna um presenca atualizada</returns>
        Task<Presenca> Alterar(Presenca presenca);

        /// <summary>
        /// Deleta uma presenca existente
        /// </summary>
        /// <param name="presenca">Objeto presenca com os dados que serão deletados</param>
        /// <returns>Retorna um presenca deletada</returns>
        Task<Presenca> Excluir(Presenca presenca);

        /// <summary>
        /// Lista todas as presencas que atendem ao filtro
        /// </summary>
        /// <param name="filtro">Filtro que será aplicado na busca</param>
        /// <returns>Retorna uma lista de presencas filtradas</returns>
        List<Presenca> FiltrarPorNome(string filtro);

        /// <summary>
        /// Lista todos os presencas de forma ordenada
        /// </summary>
        /// <returns>Retorna uma lista de presencas ordenada</returns>
        List<Presenca> Ordenar();
    }
}