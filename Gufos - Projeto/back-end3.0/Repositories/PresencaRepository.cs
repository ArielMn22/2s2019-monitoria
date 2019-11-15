using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Domains;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufosContext _contexto = new GufosContext();
        public async Task<Presenca> Alterar(Presenca presenca)
        {
            _contexto.Entry(presenca).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return presenca;
        }

        public Presenca BuscarPorID(int id)
        {
            Presenca presencaBuscada = _contexto.Presenca
                .Select(p => new Presenca()
                {
                    PresencaId = p.PresencaId,
                    Status = p.Status,

                    Usuario = new Usuario()
                    {
                        UsuarioId = p.Usuario.UsuarioId,
                        Nome = p.Usuario.Nome,
                        Email = p.Usuario.Email,
                        TipoUsuario = p.Usuario.TipoUsuario,
                    },

                    Evento = new Evento()
                    {
                        EventoId = p.Evento.EventoId,
                        Titulo = p.Evento.Titulo,
                        Categoria = p.Evento.Categoria,
                        DataEvento = p.Evento.DataEvento,
                        Localizacao = p.Evento.Localizacao,
                        AcessoLivre = p.Evento.AcessoLivre,
                    }
                })
                .ToList().Find(p => p.PresencaId == id) ;
            return presencaBuscada;
        }

        public async Task<Presenca> Excluir(Presenca presenca)
        {
            _contexto.Presenca.Remove(presenca);
            await _contexto.SaveChangesAsync();
            return presenca;
        }

        public List<Presenca> FiltrarPorNome(string filtro)
        {
            List<Presenca> presencas = _contexto.Presenca
                .Select(p => new Presenca()
                {
                    PresencaId = p.PresencaId,
                    Status = p.Status,

                    Usuario = new Usuario()
                    {
                        UsuarioId = p.Usuario.UsuarioId,
                        Nome = p.Usuario.Nome,
                        Email = p.Usuario.Email,
                        TipoUsuario = p.Usuario.TipoUsuario,
                    },

                    Evento = new Evento()
                    {
                        EventoId = p.Evento.EventoId,
                        Titulo = p.Evento.Titulo,
                        Categoria = p.Evento.Categoria,
                        DataEvento = p.Evento.DataEvento,
                        Localizacao = p.Evento.Localizacao,
                        AcessoLivre = p.Evento.AcessoLivre,
                    }
                })
                .Where(p => p.Usuario.Nome.Contains(filtro)).ToList();

            return presencas;
        }

        public async Task<List<Presenca>> Listar()
        {
            //return _contexto.Presenca
            //    .Include(p => p.Evento)
            //    .Include(p => p.Usuario)
            //    .ToListAsync();

            return await _contexto.Presenca
                .Select(p => new Presenca()
                {
                    PresencaId = p.PresencaId,
                    Status = p.Status,
                    
                    Usuario = new Usuario()
                    {
                        UsuarioId = p.Usuario.UsuarioId,
                        Nome = p.Usuario.Nome,
                        Email = p.Usuario.Email,
                        TipoUsuario = p.Usuario.TipoUsuario,
                    },

                    Evento = new Evento()
                    {
                        EventoId = p.Evento.EventoId,
                        Titulo = p.Evento.Titulo,
                        Categoria = p.Evento.Categoria,
                        DataEvento = p.Evento.DataEvento,
                        Localizacao = p.Evento.Localizacao,
                        AcessoLivre = p.Evento.AcessoLivre,
                    }
                })
                .ToListAsync();
        }

        public List<Presenca> Ordenar()
        {
            List <Presenca> presenca = _contexto.Presenca
                .Select(p => new Presenca()
                {
                    PresencaId = p.PresencaId,
                    Status = p.Status,

                    Usuario = new Usuario()
                    {
                        UsuarioId = p.Usuario.UsuarioId,
                        Nome = p.Usuario.Nome,
                        Email = p.Usuario.Email,
                        TipoUsuario = p.Usuario.TipoUsuario,
                    },

                    Evento = new Evento()
                    {
                        EventoId = p.Evento.EventoId,
                        Titulo = p.Evento.Titulo,
                        Categoria = p.Evento.Categoria,
                        DataEvento = p.Evento.DataEvento,
                        Localizacao = p.Evento.Localizacao,
                        AcessoLivre = p.Evento.AcessoLivre,
                    }
                })
                .OrderByDescending(p => p.Status).ToList();

            return presenca;
        }

        public async Task<Presenca> Salvar(Presenca presenca)
        {
            await _contexto.AddAsync(presenca);

            await _contexto.SaveChangesAsync();

            return presenca;
        }
    }
}