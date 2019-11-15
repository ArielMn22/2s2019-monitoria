using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains;
using backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace senai_2s2019_CodeXP_Gufos.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository _repositorio = new UsuarioRepository();

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns>
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            List<Usuario> usuarios = await _repositorio.Listar();

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        /// <summary>
        /// Busca um usuário através do seu ID
        /// </summary>
        /// <param name="id">Identificador único do usuário que será buscado</param>
        /// <returns>Retorna um usuário buscado</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult<Usuario> Get(int id)
        {
            Usuario usuario = _repositorio.BuscarPorID(id);

            if (usuario == null)
            {
                return NotFound(new { mensagem = "Nenhum usuário encontrado para o ID informado" });
            }

            return usuario;
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto usuario que será cadastrado</param>
        /// <returns>Retorna os dados do usuário cadastrado</returns>
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            try
            {
                await _repositorio.Salvar(usuario);
            }
            catch (System.Exception)
            {
                throw;
            }

            return usuario;
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">Identificador único do usuário que será atualizado</param>
        /// <param name="usuario">Objeto usuário com os dados que serão atualizados</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Usuario usuario)
        {
            // Se o ID do objeto não existir, retorna erro 400 - BadRequest
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            try
            {
                await _repositorio.Alterar(usuario);
            }
            catch (System.Exception)
            {
                // Verifica se o objeto inserido existe no banco
                Usuario usuario_valido = _repositorio.BuscarPorID(id);

                if (usuario_valido == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // NoContent retorna 204 - Sem conteúdo
            return NoContent();
        }

        /// <summary>
        /// Deleta um usuário através do seu ID
        /// </summary>
        /// <param name="id">Identificador único do usuário que será deletado</param>
        /// <returns>Retorna os dados do usuário deletado</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            Usuario usuario_buscado = _repositorio.BuscarPorID(id);

            if (usuario_buscado == null)
            {
                return NotFound(new { mensagem = "Nenhum usuário encontrado para o ID informado" });
            }

            await _repositorio.Excluir(usuario_buscado);

            return usuario_buscado;
        }

        /// <summary>
        /// Filtra os usuário pelo nome
        /// </summary>
        /// <param name="filtro">Filtro que será aplicado na busca</param>
        /// <returns>Retorna uma lista de usuários filtrada</returns>
        [HttpGet("FiltrarPorNome")]
        public ActionResult<List<Usuario>> GetFiltrar([FromBody]string filtro)
        {

            List<Usuario> usuarios_filtrados = _repositorio.FiltrarPorNome(filtro);

            return usuarios_filtrados;
        }

        /// <summary>
        /// Ordena uma lista de usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários ordenada</returns>
        [HttpGet("Ordenar")]
        public ActionResult<List<Usuario>> GetOrdenar()
        {

            List<Usuario> usuarios_ordenados = _repositorio.Ordenar();

            return usuarios_ordenados;
        }
    }
}