using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains;

namespace backend.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Retorna uma lista de usuarios</returns>
        Task<List<Usuario>> Listar();
        
        /// <summary>
        /// Busca um usuario através do seu ID
        /// </summary>
        /// <param name="id">Identificador específico do usuario</param>
        /// <returns>Retorna um usuario buscado</returns>
        Usuario BuscarPorID(int id);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto usuario com os dados que serão cadastrados</param>
        /// <returns>Retorna um usuario cadastrado</returns>
        Task<Usuario> Salvar(Usuario usuario);
        
        /// <summary>
        /// Altera um usuario existente
        /// </summary>
        /// <param name="usuario">Objeto usuario com os dados que serão atualizados</param>
        /// <returns>Retorna um usuario atualizado</returns>
        Task<Usuario> Alterar(Usuario usuario);

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="usuario">Objeto usuario com os dados que serão deletados</param>
        /// <returns>Retorna um usuario deletado</returns>
        Task<Usuario> Excluir(Usuario usuario);

        /// <summary>
        /// Lista todos os usuarios que atendem ao filtro
        /// </summary>
        /// <param name="filtro">Filtro que será aplicado na busca</param>
        /// <returns>Retorna uma lista de usuarios filtrados</returns>
        List<Usuario> FiltrarPorNome(string filtro);

        /// <summary>
        /// Lista todos os usuarios de forma ordenada
        /// </summary>
        /// <returns>Retorna uma lista de usuarios ordenada</returns>
        List<Usuario> Ordenar();

        /// <summary>
        /// Realiza login de um usuário
        /// </summary>
        /// <param name="email">Email informado pelo usuário</param>
        /// <param name="senha">Senha informada pelo usuário</param>
        /// <returns>Retorna um usuário correspondente</returns>
        Usuario RealizarLogin(string email, string senha);
    }
}