using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains;

namespace backend.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Retorna uma lista com os tipos de usuário</returns>
        Task<List<TipoUsuario>> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do seu id
        /// </summary>
        /// <param name="id">Identificador específico do tipo de usuário</param>
        /// <returns>Retorna um tipo de usuário buscado</returns>
        Task<TipoUsuario> BuscarPorID(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Objeto tipo usuário com os dados que serão cadastrados</param>
        /// <returns>Retorna um tipo usuário cadastrado</returns>
        Task<TipoUsuario> Salvar(TipoUsuario tipoUsuario);
        
        /// <summary>
        /// Altera um tipo usuário existente
        /// </summary>
        /// <param name="tipoUsuario">Objeto tipo usuário com os dados que serão atualizados</param>
        /// <returns>Retorna um tipo usuário atualizado</returns>
        Task<TipoUsuario> Alterar(TipoUsuario tipoUsuario);

        /// <summary>
        /// Deleta uma tipo usuário existente
        /// </summary>
        /// <param name="tipoUsuario">Objeto tipo usuário com os dados que serão deletados</param>
        /// <returns>Retorna um tipo usuário deletado</returns>
        Task<TipoUsuario> Excluir(TipoUsuario tipoUsuario);

        /// <summary>
        /// Lista todos os tipos de usuário que atendem ao filtro
        /// </summary>
        /// <param name="filtro">Filtro que será aplicado na busca</param>
        /// <returns>Retorna uma lista de tipo usuário filtrados</returns>
        List<TipoUsuario> FiltrarPorNome(string filtro);

        /// <summary>
        /// Lista todos os tipos de usuário de forma ordenada
        /// </summary>
        /// <returns>Retorna uma lista de tipo usuário ordenada</returns>
        List<TipoUsuario> Ordenar();
    }
}