using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains;

namespace backend.Interfaces
{
    /// <summary>
    /// Classe responsável por definir os métodos da Categoria
    /// </summary>
    public interface ICategoriaRepository
    {
        /// <summary>
        /// Lista todas as categorias
        /// </summary>
        /// <returns>Retorna uma lista de categorias</returns>
        Task<List<Categoria>> Listar();
        
        /// <summary>
        /// Busca uma categoria através do seu ID
        /// </summary>
        /// <param name="id">Identificador específico da categoria</param>
        /// <returns>Retorna uma categoria buscada</returns>
        Task<Categoria> BuscarPorID(int id);

        /// <summary>
        /// Cadastra uma nova categoria
        /// </summary>
        /// <param name="categoria">Objeto categoria com os dados que serão cadastrados</param>
        /// <returns>Retorna uma categoria cadastrada</returns>
        Task<Categoria> Salvar(Categoria categoria);
        
        /// <summary>
        /// Altera uma categoria existente
        /// </summary>
        /// <param name="categoria">Objeto categoria com os dados que serão atualizados</param>
        /// <returns>Retorna uma categoria atualizada</returns>
        Task<Categoria> Alterar(Categoria categoria);

        /// <summary>
        /// Deleta uma categoria existente
        /// </summary>
        /// <param name="categoria">Objeto categoria com os dados que serão deletados</param>
        /// <returns>Retorna uma categoria deletada</returns>
        Task<Categoria> Excluir(Categoria categoria);

        /// <summary>
        /// Lista todas as categorias que atendem ao filtro
        /// </summary>
        /// <param name="filtro">Filtro que será aplicado na busca</param>
        /// <returns>Retorna uma lista de categorias filtradas</returns>
        List<Categoria> FiltrarPorNome(string filtro);

        /// <summary>
        /// Lista todas as categorias de forma ordenada
        /// </summary>
        /// <returns>Retorna uma lista de categorias ordenada</returns>
        List<Categoria> Ordenar();
    }
}