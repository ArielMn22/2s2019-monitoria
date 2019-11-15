using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Domains;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        GufosContext _contexto = new GufosContext();
        public async Task<Evento> Alterar(Evento evento)
        {
            _contexto.Entry(evento).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return evento;
        }

        public Evento BuscarPorID(int id)
        {
            Evento eventoBuscado = _contexto.Evento
                .Include("Categoria").ToList().Find(e => e.EventoId == id) ;
            return eventoBuscado;
        }

        public async Task<Evento> Excluir(Evento evento)
        {
            _contexto.Evento.Remove(evento);
            await _contexto.SaveChangesAsync();
            return evento;
        }

        public List<Evento> FiltrarPorNome(string filtro)
        {
            List<Evento> eventos = _contexto.Evento
                .Include("Categoria").Where(e => e.Titulo.Contains(filtro)).ToList();

            return eventos;
        }

        public async Task<List<Evento>> Listar()
        {
            return await _contexto.Evento
                .Include("Categoria").ToListAsync();
        }

        public List<Evento> Ordenar()
        {
            List <Evento> evento = _contexto.Evento
                .Include("Categoria").OrderByDescending(u => u.Titulo).ToList();

            return evento;
        }

        public async Task<Evento> Salvar(Evento evento)
        {
            await _contexto.AddAsync(evento);

            await _contexto.SaveChangesAsync();

            return evento;
        }
    }
}