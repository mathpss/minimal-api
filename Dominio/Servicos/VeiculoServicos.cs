using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidade;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.DB;

namespace MinimalApi.Dominio.Servicos
{
    public class VeiculoServicos : IVeiculoServicos
    {
        private readonly DBContexto _contexto;
        public VeiculoServicos(DBContexto contexto)
        {
            _contexto = contexto;
        }

        public void Apagar(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }

        public void Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public Veiculo? BuscaPorId(int id)
        {
            return _contexto.Veiculos.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Incluir(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
        {
            var query = _contexto.Veiculos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(x => EF.Functions.Like(x.Nome.ToLower(), $"%{x.Nome.ToLower()}%"));
            }

            int itensPorPagina = 10;

            if (pagina != null){
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
}
            return query.ToList();
        }
    }
}