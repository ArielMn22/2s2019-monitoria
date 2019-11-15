using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Context;
using backend.Domains;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        GufosContext _contexto = new GufosContext();
        public async Task<Localizacao> Alterar(Localizacao localizacao)
        {
            _contexto.Entry(localizacao).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return localizacao;
        }

        public async Task<Localizacao> BuscarPorID(int id)
        {
            return await _contexto.Localizacao.FindAsync(id);
        }

        public async Task<Localizacao> Excluir(Localizacao localizacao)
        {
            _contexto.Localizacao.Remove(localizacao);
            await _contexto.SaveChangesAsync();
            return localizacao;
        }

        public List<Localizacao> FiltrarPorNome(string filtro)
        {
            List<Localizacao> localizacoes = _contexto.Localizacao
                .Where(l => l.RazaoSocial.Contains(filtro)).ToList();

            return localizacoes;
        }

        public async Task<List<Localizacao>> Listar()
        {
            return await _contexto.Localizacao
                .ToListAsync();
        }

        public List<Localizacao> Ordenar()
        {
            List <Localizacao> localizacoes = _contexto.Localizacao
                .OrderByDescending(l => l.RazaoSocial).ToList();

            return localizacoes;
        }

        public async Task<Localizacao> Salvar(Localizacao localizacao)
        {
            await _contexto.AddAsync(localizacao);

            await _contexto.SaveChangesAsync();

            return localizacao;
        }
    }
}