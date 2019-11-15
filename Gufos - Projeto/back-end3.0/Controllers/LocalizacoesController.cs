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
    public class LocalizacoesController : ControllerBase
    {
        LocalizacaoRepository _repositorio = new LocalizacaoRepository();

        /// <summary>
        /// Lista todas as localizações
        /// </summary>
        /// <returns>Retorna uma lista de localizações</returns>
        [HttpGet]
        public async Task<ActionResult<List<Localizacao>>> Get()
        {
            List<Localizacao> localizacoes = await _repositorio.Listar();

            if (localizacoes == null)
            {
                return NotFound();
            }

            return localizacoes;
        }

        /// <summary>
        /// Busca uma localização através do seu ID
        /// </summary>
        /// <param name="id">Identificador único da localização que será buscada</param>
        /// <returns>Retorna uma localização buscada</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Localizacao>> Get(int id)
        {
            Localizacao localizacao = await _repositorio.BuscarPorID(id);

            if (localizacao == null)
            {
                return NotFound(new { mensagem = "Nenhuma localização encontrado para o ID informado" });
            }

            return localizacao;
        }

        /// <summary>
        /// Cadastra uma nova localização
        /// </summary>
        /// <param name="localizacao">Objeto localização que será cadastrado</param>
        /// <returns>Retorna os dados da localização cadastrada</returns>
        [HttpPost]
        public async Task<ActionResult<Localizacao>> Post(Localizacao localizacao)
        {
            try
            {
                await _repositorio.Salvar(localizacao);
            }
            catch (System.Exception)
            {
                throw;
            }

            return localizacao;
        }

        /// <summary>
        /// Atualiza uma localização existente
        /// </summary>
        /// <param name="id">Identificador único da localização que será atualizada</param>
        /// <param name="localizacao">Objeto localização com os dados que serão atualizados</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Localizacao localizacao)
        {
            // Se o ID do objeto não existir, retorna erro 400 - BadRequest
            if (id != localizacao.LocalizacaoId)
            {
                return BadRequest();
            }

            try
            {
                await _repositorio.Alterar(localizacao);
            }
            catch (System.Exception)
            {
                // Verifica se o objeto inserido existe no banco
                Localizacao localizacao_valida = await _repositorio.BuscarPorID(id);

                if (localizacao_valida == null)
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
        /// Deleta uma localização através do seu ID
        /// </summary>
        /// <param name="id">Identificador único da localização que será deletada</param>
        /// <returns>Retorna os dados da localização deletada</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Localizacao>> Delete(int id)
        {
            Localizacao localizacao_buscada = await _repositorio.BuscarPorID(id);

            if (localizacao_buscada == null)
            {
                return NotFound(new { mensagem = "Nenhuma localização encontrada para o ID informado" });
            }

            await _repositorio.Excluir(localizacao_buscada);

            return localizacao_buscada;
        }

        /// <summary>
        /// Filtra as localizações através da Razão Social
        /// </summary>
        /// <param name="filtro">Filtro que será aplicado na busca</param>
        /// <returns>Retorna uma lista de localizações filtradas</returns>
        [HttpGet("FiltrarPorNome")]
        public ActionResult<List<Localizacao>> GetFiltrar([FromBody]string filtro)
        {

            List<Localizacao> localizacoes_filtradas = _repositorio.FiltrarPorNome(filtro);

            return localizacoes_filtradas;
        }

        /// <summary>
        /// Ordena uma lista de localizações
        /// </summary>
        /// <returns>Retorna uma lista de localizações ordenada</returns>
        [HttpGet("Ordenar")]
        public ActionResult<List<Localizacao>> GetOrdenar()
        {

            List<Localizacao> localizacoes_ordenadas = _repositorio.Ordenar();

            return localizacoes_ordenadas;
        }
    }
}