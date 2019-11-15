using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Domains;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        GufosContext _contexto = new GufosContext();
        public async Task<TipoUsuario> Alterar(TipoUsuario tipoUsuario)
        {
            _contexto.Entry(tipoUsuario).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return tipoUsuario;
        }

        public async Task<TipoUsuario> BuscarPorID(int id)
        {
           return await _contexto.TipoUsuario.FindAsync(id);
        }

        public async Task<TipoUsuario> Excluir(TipoUsuario tipoUsuario)
        {
            _contexto.TipoUsuario.Remove(tipoUsuario);
            await _contexto.SaveChangesAsync();
            return tipoUsuario;
        }

        public List<TipoUsuario> FiltrarPorNome(string filtro)
        {
            List<TipoUsuario> tiposUsuario = _contexto.TipoUsuario.Where(t => t.Titulo.Contains(filtro)).ToList();

            return tiposUsuario;
        }

        public async Task<List<TipoUsuario>> Listar()
        {
            return await _contexto.TipoUsuario.ToListAsync();
        }

        public List<TipoUsuario> Ordenar()
        {
            List<TipoUsuario> tiposUsuario = _contexto.TipoUsuario.OrderBy(t => t.Titulo).ToList();

            return tiposUsuario;
        }

        public async Task<TipoUsuario> Salvar(TipoUsuario tipoUsuario)
        {
            await _contexto.AddAsync(tipoUsuario);

            await _contexto.SaveChangesAsync();

            return tipoUsuario;
        }
    }
}