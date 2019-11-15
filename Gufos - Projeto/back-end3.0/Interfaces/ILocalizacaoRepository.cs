using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains;

namespace backend.Interfaces
{
    public interface ILocalizacaoRepository
    {
        /// <summary>
        /// Lista todas as localizacoes
        /// </summary>
        /// <returns>Retorna uma lista de localizacoes</returns>
        Task<List<Localizacao>> Listar();
        
        /// <summary>
        /// Busca uma localizacao através do seu ID
        /// </summary>
        /// <param name="id">Identificador específico da localizacao</param>
        /// <returns>Retorna uma localizacao buscada</returns>
        Task<Localizacao> BuscarPorID(int id);

        /// <summary>
        /// Cadastra uma nova localizacao
        /// </summary>
        /// <param name="localizacao">Objeto localizacao com os dados que serão cadastrados</param>
        /// <returns>Retorna uma localizacao cadastrada</returns>
        Task<Localizacao> Salvar(Localizacao localizacao);
        
        /// <summary>
        /// Altera uma localizacao existente
        /// </summary>
        /// <param name="localizacao">Objeto localizacao com os dados que serão atualizados</param>
        /// <returns>Retorna uma localizacao atualizada</returns>
        Task<Localizacao> Alterar(Localizacao localizacao);

        /// <summary>
        /// Deleta uma localizacao existente
        /// </summary>
        /// <param name="localizacao">Objeto localizacao com os dados que serão deletados</param>
        /// <returns>Retorna uma localizacao deletada</returns>
        Task<Localizacao> Excluir(Localizacao localizacao);

        /// <summary>
        /// Lista todas as localizacoes que atendem ao filtro
        /// </summary>
        /// <param name="filtro">Filtro que será aplicado na busca</param>
        /// <returns>Retorna uma lista de localizacoes filtradas</returns>
        List<Localizacao> FiltrarPorNome(string filtro);

        /// <summary>
        /// Lista todos as localizacoes de forma ordenada
        /// </summary>
        /// <returns>Retorna uma lista de localizacoes ordenada</returns>
        List<Localizacao> Ordenar();
    }
}