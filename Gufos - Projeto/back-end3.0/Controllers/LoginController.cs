using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.Domains;
using backend.Repositories;
using backend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepository _repositorio = new UsuarioRepository();

        // Define uma variável para percorrer os métodos com as configurações obtidas no appsettings.json
        private IConfiguration _config;

        // Define um método construtor para poder acessar as configurações acima
        public LoginController(IConfiguration config){
            _config = config;
        }

        // Faz a chamada do método para validar o usuário na aplicação
        private Usuario ValidaUsuario(LoginViewModel login){
            
            Usuario usuarioLogado = _repositorio.RealizarLogin(login.Email, login.Senha);

            return usuarioLogado;
        }

        // Gera o token
        private string GerarToken(Usuario userInfo){
            
            // Define a criptografia do token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            // Define as Claims (dados da sessão)
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.NameId, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userInfo.TipoUsuario.Titulo.ToString()),
                new Claim("permissao", userInfo.TipoUsuario.Titulo.ToString())
            };

            // Configura o token e seu tempo de vida
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials : credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Usa a anotação abaixo para ignorar a autenticação neste método
        /// <summary>
        /// Realiza login no sistema
        /// </summary>
        /// <param name="login">Email e Senha para realizar login</param>
        /// <returns>Retorna um token com os dados do usuário logado</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginViewModel login){
            
            // IActionResult response = Unauthorized();

            var user = ValidaUsuario(login);

            if (user == null)
            {
                return NotFound(new { mensagem = "Usuário ou senha inválidos!" });
            }

            var tokenString = GerarToken(user);

            return Ok(new { token = tokenString });
        }
    }
}