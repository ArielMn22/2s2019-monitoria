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
    public class TiposUsuarioController : ControllerBase
    {
        TipoUsuarioRepository _repositorio = new TipoUsuarioRepository();

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Retorna uma lista de com os tipos de usuário</returns>
        [HttpGet]
        public async Task<ActionResult<List<TipoUsuario>>> Get()
        {
            List<TipoUsuario> tiposUsuario = await _repositorio.Listar();

            if (tiposUsuario == null)
            {
                return NotFound();
            }

            return tiposUsuario;
        }

        /// <summary>
        /// Busca um tipo de usuário através do seu ID
        /// </summary>
        /// <param name="id">Identificador único do tipo de usuário que será buscado</param>
        /// <returns>Retorna um tipo de usuário buscado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> Get(int id)
        {
            TipoUsuario tipoUsuario = await _repositorio.BuscarPorID(id);

            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return tipoUsuario;
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Objeto tipoUsuario que será cadastrado</param>
        /// <returns>Retorna os dados do tipo usuário que foi cadastrado</returns>
        [HttpPost]
        public async Task<ActionResult<TipoUsuario>> Post(TipoUsuario tipoUsuario)
        {
            try
            {
                await _repositorio.Salvar(tipoUsuario);
            }
            catch (System.Exception)
            {
                throw;
            }

            return tipoUsuario;
        }

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">Identificador único do tipo de usuário que será cadastrado</param>
        /// <param name="tipoUsuario">Objeto tipoUsuario com os dados que serão atualizado</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TipoUsuario tipoUsuario)
        {
            // Se o ID do objeto não existir, retorna erro 400 - BadRequest
            if (id != tipoUsuario.TipoUsuarioId)
            {
                return BadRequest();
            }

            try
            {
                await _repositorio.Alterar(tipoUsuario);
            }
            catch (System.Exception)
            {
                // Verifica se o objeto inserido existe no banco
                TipoUsuario tipoUsuario_valido = await _repositorio.BuscarPorID(id);

                if (tipoUsuario_valido == null)
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
        /// Deleta um tipo de usuário através do seu ID
        /// </summary>
        /// <param name="id">Identificador único do tipo de usuário que será deletado</param>
        /// <returns>Retorna os dados do tipo de usuário deletado</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoUsuario>> Delete(int id)
        {
            TipoUsuario tipoUsuario_buscado = await _repositorio.BuscarPorID(id);

            if (tipoUsuario_buscado == null)
            {
                return NotFound(new { mensagem = "Nenhum tipo usuário encontrado para o ID informado" });
            }

            await _repositorio.Excluir(tipoUsuario_buscado);

            return tipoUsuario_buscado;
        }

        /// <summary>
        /// Filtra os tipos de usuário pelo nome
        /// </summary>
        /// <param name="filtro">Filtro que será aplicado na busca</param>
        /// <returns>Retorna uma lista de tipos de usuário filtrada</returns>
        [HttpGet("FiltrarPorNome")]
        public ActionResult<List<TipoUsuario>> GetFiltrar([FromBody]string filtro)
        {

            List<TipoUsuario> tiposUsuario_filtrados = _repositorio.FiltrarPorNome(filtro);

            return tiposUsuario_filtrados;
        }

        /// <summary>
        /// Ordena uma lista de tipos de usuário
        /// </summary>
        /// <returns>Retorna uma lista de tipos de usuário ordenada</returns>
        [HttpGet("Ordenar")]
        public ActionResult<List<TipoUsuario>> GetOrdenar()
        {

            List<TipoUsuario> tiposUsuario_ordenados = _repositorio.Ordenar();

            return tiposUsuario_ordenados;
        }
    }
}