using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Domains;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        GufosContext _contexto = new GufosContext();
        public async Task<Usuario> Alterar(Usuario usuario)
        {
            _contexto.Entry(usuario).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return usuario;
        }

        public Usuario BuscarPorID(int id)
        {
            Usuario usuarioBuscado = _contexto.Usuario
                .Select(u => new Usuario()
                {
                    UsuarioId = u.UsuarioId,
                    Nome = u.Nome,
                    Email = u.Email,
                    TipoUsuarioId = u.TipoUsuarioId,

                    TipoUsuario = new TipoUsuario()
                    {
                        TipoUsuarioId = u.TipoUsuario.TipoUsuarioId,
                        Titulo = u.TipoUsuario.Titulo,
                    }
                })
                .ToList()
                .Find(u => u.UsuarioId == id) ;
            return usuarioBuscado;
        }

        public async Task<Usuario> Excluir(Usuario usuario)
        {
            _contexto.Usuario.Remove(usuario);
            await _contexto.SaveChangesAsync();
            return usuario;
        }

        public List<Usuario> FiltrarPorNome(string filtro)
        {
            List<Usuario> usuarios = _contexto.Usuario
                .Select(u => new Usuario()
                {
                    UsuarioId = u.UsuarioId,
                    Nome = u.Nome,
                    Email = u.Email,
                    TipoUsuarioId = u.TipoUsuarioId,

                    TipoUsuario = new TipoUsuario()
                    {
                        TipoUsuarioId = u.TipoUsuario.TipoUsuarioId,
                        Titulo = u.TipoUsuario.Titulo,
                    }
                })
                .Where(u => u.Nome.Contains(filtro)).ToList();

            return usuarios;
        }

        public async Task<List<Usuario>> Listar()
        {
            return await _contexto.Usuario
                //.Include("TipoUsuario")
                .Select(u => new Usuario()
                {
                    UsuarioId = u.UsuarioId,
                    Nome = u.Nome,
                    Email = u.Email,
                    TipoUsuarioId = u.TipoUsuarioId,
                    
                    TipoUsuario = new TipoUsuario()
                    {
                        TipoUsuarioId = u.TipoUsuario.TipoUsuarioId,
                        Titulo = u.TipoUsuario.Titulo,
                    }
                })
                .ToListAsync();
        }

        public List<Usuario> Ordenar()
        {
            List <Usuario> usuarios = _contexto.Usuario
                .Select(u => new Usuario()
                {
                    UsuarioId = u.UsuarioId,
                    Nome = u.Nome,
                    Email = u.Email,
                    TipoUsuarioId = u.TipoUsuarioId,

                    TipoUsuario = new TipoUsuario()
                    {
                        TipoUsuarioId = u.TipoUsuario.TipoUsuarioId,
                        Titulo = u.TipoUsuario.Titulo,
                    }
                })
                .OrderByDescending(u => u.Nome).ToList();

            return usuarios;
        }

        public Usuario RealizarLogin(string email, string senha)
        {
            Usuario usuarioLogado = _contexto.Usuario
                .Select(u => new Usuario()
                {
                    UsuarioId = u.UsuarioId,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    TipoUsuarioId = u.TipoUsuarioId,

                    TipoUsuario = new TipoUsuario()
                    {
                        TipoUsuarioId = u.TipoUsuario.TipoUsuarioId,
                        Titulo = u.TipoUsuario.Titulo,
                    }
                })
                .ToList()
                .Find(u => u.Email == email && u.Senha == senha);
            
            return usuarioLogado;
        }

        public async Task<Usuario> Salvar(Usuario usuario)
        {
            await _contexto.AddAsync(usuario);

            await _contexto.SaveChangesAsync();

            return usuario;
        }
    }
}