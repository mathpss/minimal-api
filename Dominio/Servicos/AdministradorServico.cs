using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Dominio.DTO;
using MinimalApi.Dominio.Entidade;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.DB;

namespace MinimalApi.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServicos
    {
        private readonly DBContexto _contexto;
        public AdministradorServico(DBContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador? BuscaPorId(int id)
        {
            return _contexto.Administradors.Where(x => x.Id == id).FirstOrDefault();
        }

        public Administrador? Incluir(Administrador administrador)
        {
            _contexto.Administradors.Add(administrador);
            _contexto.SaveChanges();

            return administrador;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradors.Where(x => x.Email == loginDTO.Email && x.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;   
        }

        public List<Administrador> Todos(int? pagina)
        {
            var query = _contexto.Administradors.AsQueryable();

            int itensPorPagina = 10;

            if (pagina != null){
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
}
            return query.ToList();
        }

        
    }
}