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
    public class PresencasController : ControllerBase
    {
        PresencaRepository _repositorio = new PresencaRepository();

        /// <summary>
        /// Lista todas as presenças
        /// </summary>
        /// <returns>Retorna uma lista de presenças</returns>
        [HttpGet]
        public async Task<ActionResult<List<Presenca>>> Get()
        {
            List<Presenca> presencas = await _repositorio.Listar();

            if (presencas == null)
            {
                return NotFound();
            }

            return presencas;
        }

        /// <summary>
        /// Busca uma presença através do seu ID
        /// </summary>
        /// <param name="id">Identificador único da presença buscada</param>
        /// <returns>Retorna uma presença buscada</returns>
        [HttpGet("{id}")]
        public ActionResult<Presenca> Get(int id)
        {
            Presenca presenca = _repositorio.BuscarPorID(id);

            if (presenca == null)
            {
                return NotFound(new { mensagem = "Nenhuma presença encontrado para o ID informado" });
            }

            return presenca;
        }

        /// <summary>
        /// Cadastra uma nova presença
        /// </summary>
        /// <param name="presenca">Objeto presença que será cadastrado</param>
        /// <returns>Retorna os dados da presença cadastrada</returns>
        [HttpPost]
        public async Task<ActionResult<Presenca>> Post(Presenca presenca)
        {
            try
            {
                await _repositorio.Salvar(presenca);
            }
            catch (System.Exception)
            {
                throw;
            }

            return presenca;
        }

        /// <summary>
        /// Atualiza uma presença cadastrada
        /// </summary>
        /// <param name="id">Identificador único da presença que será atualizada</param>
        /// <param name="presenca">Objeto presença com os dados que serão atualizados</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Presenca presenca)
        {
            // Se o ID do objeto não existir, retorna erro 400 - BadRequest
            if (id != presenca.PresencaId)
            {
                return BadRequest();
            }

            try
            {
                await _repositorio.Alterar(presenca);
            }
            catch (System.Exception)
            {
                // Verifica se o objeto inserido existe no banco
                Presenca presenca_valida = _repositorio.BuscarPorID(id);

                if (presenca_valida == null)
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
        /// Deleta uma presença através do seu ID
        /// </summary>
        /// <param name="id">Identificador único da presença que será deletada</param>
        /// <returns>Retorna os dados da presença deletada</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Presenca>> Delete(int id)
        {
            Presenca presenca_buscada = _repositorio.BuscarPorID(id);

            if (presenca_buscada == null)
            {
                return NotFound(new { mensagem = "Nenhuma presença encontrada para o ID informado" });
            }

            await _repositorio.Excluir(presenca_buscada);

            return presenca_buscada;
        }

        /// <summary>
        /// Filtra as presenças através do nome do usuário
        /// </summary>
        /// <param name="filtro">Filtro que será aplicado na busca</param>
        /// <returns>Retorna uma lista de presenças filtrada</returns>
        [HttpGet("FiltrarPorNome")]
        public ActionResult<List<Presenca>> GetFiltrar([FromBody]string filtro)
        {
            List<Presenca> presencas_filtradas = _repositorio.FiltrarPorNome(filtro);

            return presencas_filtradas;
        }

        /// <summary>
        /// Ordena uma lista de presenças
        /// </summary>
        /// <returns>Retorna uma lista de presenças ordenada</returns>
        [HttpGet("Ordenar")]
        public ActionResult<List<Presenca>> GetOrdenar()
        {

            List<Presenca> presencas_ordenadas = _repositorio.Ordenar();

            return presencas_ordenadas;
        }
    }
}