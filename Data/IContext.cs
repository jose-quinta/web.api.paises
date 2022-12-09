using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.api.paises.Entities;

namespace web.api.paises.Data
{
    public interface IContext
    {
        /* Country action */
        Task<List<Pais>> GetPaises();
        Task<Pais> GetPaisById(int id);
        Task<List<Pais>> PostPais(Pais pais);
        Task<Pais> PutPais(int id, Pais pais);
        Task<Pais> DeletePais(int id);
        /* Province action */
        Task<List<Provincia>> GetProvincias();
        Task<Provincia> GetProvinciaById(int id);
        Task<List<Provincia>> PostProvincia(Provincia provincia);
        Task<Provincia> PutProvincia(int id, Provincia provincia);
        Task<Provincia> DeleteProvincia(int id);
    }
}