using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Dominio.DTO;
using MinimalApi.Dominio.Entidade;

namespace MinimalApi.Dominio.Interfaces
{
    public interface IAdministradorServicos
    {
        Administrador? Login(LoginDTO loginDTO);

        Administrador? Incluir(Administrador administrador);

        Administrador? BuscaPorId(int id);
        List<Administrador> Todos(int? pagina );
    }
}