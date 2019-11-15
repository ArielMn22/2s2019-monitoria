using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domains;
using backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace senai_2s2019_CodeXP_Gufos.Controllers
{
    /// <summary>
    /// Classe responsável pelo controle de endpoints, chamada dos métodos e autorização da aplicação
    /// Definimos a rota do controller, que é um controller de API e que o resultado das requisições é em formato JSON
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoriasController : ControllerBase
    {
        // Cria uma instância para chamada de métodos do repositório
        CategoriaRepository _repositorio = new CategoriaRepository();

        // GET: api/Categorias
        /// <summary>
        /// Lista todas as categorias
        /// </summary>
        /// <returns>Retorna uma lista de categorias</returns>
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            // Define uma lista de categorias chamada categorias
            // Faz a chamada do método no repositório para listar todas as categorias
            // Atribui o retorno do método ao objeto categorias
            List<Categoria> categorias = await _repositorio.Listar();

            // Se a lista de categorias for nula, retorna 404 - NotFound
            if (categorias == null)
            {
                return NotFound(new { mensagem = "Nenhuma categoria encontrada" });
            }

            // Retorna a lista de categorias
            return categorias;
        }

        // GET: api/Categorias/1
        /// <summary>
        /// Busca uma categoria através do seu ID
        /// </summary>
        /// <param name="id">Identificador único da categoria</param>
        /// <returns>Retorna uma categoria buscada</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetByID(int id)
        {
            // Define um objeto do tipo Categoria chamado categoria
            // Faz a chamada do método no repositório para buscar uma categoria passando como parâmetro seu ID
            // Este ID é recebido pela url da requisição
            Categoria categoria = await _repositorio.BuscarPorID(id);

            // Caso a categoria seja nula, retorna uma mensagem personalizada
            if (categoria == null)
            {
                return NotFound(new { mensagem = "Nenhuma categoria encontrada para o ID informado" });
            }

            // Retorna uma categoria buscada
            return categoria;
        }

        // POST: api/Categorias
        /// <summary>
        /// Cadastra uma nova categoria
        /// </summary>
        /// <param name="categoria">Nome da categoria que será cadastrada</param>
        /// <returns>Retorna a categoria que foi cadastrada</returns>
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            // Tenta chamar o método do repositório e cadastrar uma categoria
            try
            {
                // Espera o retorno do método
                await _repositorio.Salvar(categoria);
            }
            // Caso não seja cadastrada, retorna o erro
            catch (System.Exception)
            {
                throw;
            }

            // Retorna a categoria cadastrada
            return categoria;
        }

        // PUT: api/Categorias/4
        /// <summary>
        /// Atualiza os dados de uma categoria cadastrada
        /// </summary>
        /// <param name="id">Identificador único da categoria que será atualizada</param>
        /// <param name="categoria">Objeto categoria com os dados que serão atualizados</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Categoria categoria)
        {
            // Se o ID do objeto não existir, retorna erro 400 - BadRequest com uma mensagem personalizada
            if (id != categoria.CategoriaId)
            {
                return BadRequest(new { mensagem = "Inconsistência nos IDs informados" });
            }
            //Tenta chamar o método do repositório e alterar uma categoria
            try
            {
                await _repositorio.Alterar(categoria);
            }
            // Caso não seja possível, tenta buscar uma categoria que corresponda ao ID informado
            catch (System.Exception)
            {
                Categoria categoria_valida = await _repositorio.BuscarPorID(id);

                // Caso não encontre, retorna 404 - NotFound com uma mensagem personalizada
                if (categoria_valida == null)
                {
                    return NotFound(new { mensagem = "Nenhuma categoria encontrada para o ID informado" });
                }
                // Caso encontre mas ocorra um erro no cadastro, retorna o erro
                else
                {
                    throw;
                }
            }

            // NoContent retorna 204 - Sem conteúdo
            return NoContent();
        }

        // DELETE: api/Categorias/4
        /// <summary>
        /// Deleta uma categoria cadastrada buscando através do seu ID
        /// </summary>
        /// <param name="id">Identificador único da categoria que será deletada</param>
        /// <returns>Retorna os dados da categoria que foi deletada</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            // Busca uma categoria cadastrada através do ID informado
            Categoria categoria_deletada = await _repositorio.BuscarPorID(id);

            // Caso a categoria não seja encontrada, retorna 404 - NotFound com uma mensagem personalizada
            if (categoria_deletada == null)
            {
                return NotFound(new { mensagem = "Nenhuma categoria encontrada para o ID informado" });
            }

            // Espera o retorno do método que deleta uma categoria
            await _repositorio.Excluir(categoria_deletada);

            // Retorna os dados da categoria deletada
            return categoria_deletada;
        }

        // GET: api/Categorias/FiltrarPorNome
        /// <summary>
        /// Filtra as categorias através do nome
        /// </summary>
        /// <param name="filtro">Filtro que será aplicado na busca</param>
        /// <returns>Retorna uma lista de categorias filtradas</returns>
        [HttpGet("FiltrarPorNome")]
        public ActionResult<List<Categoria>> GetFiltrar([FromBody]string filtro)
        {
            // Busca uma lista de categorias passando o filtro como parâmetro
            List<Categoria> categorias_filtradas = _repositorio.FiltrarPorNome(filtro);

            // Retorna uma lista de categorias com o filtro aplicado
            return categorias_filtradas;
        }

        // GET: api/Categorias/Ordenar
        /// <summary>
        /// Ordena uma lista de categorias
        /// </summary>
        /// <returns>Retorna uma lista de categorias ordenada</returns>
        [HttpGet("Ordenar")]
        public ActionResult<List<Categoria>> GetOrdenar()
        {
            // Busca uma lista de categorias ordenadas
            List<Categoria> categorias_ordenadas = _repositorio.Ordenar();

            // Retorna a lista
            return categorias_ordenadas;
        }
    }
}