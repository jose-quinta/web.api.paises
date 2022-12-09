using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.api.paises.Entities;

namespace web.api.paises.Data {
    public class Context : IContext {
        /* Lists */
        public static List<Pais> Paises { get; set; } = new List<Pais>() {
            new Pais() {
                Id = 1,
                Name = "Costa Rica"
            },
            new Pais() {
                Id = 2,
                Name = "Peru"
            }
        };
        public static List<Provincia> Provincias { get; set; } = new List<Provincia>() {
            new Provincia() {
                Id = 1,
                Name = "San Jose",
                IdPais = 1
            },
            new Provincia() {
                Id = 2,
                Name = "Alajuela",
                IdPais = 1
            },
            new Provincia() {
                Id = 3,
                Name = "Bagua",
                IdPais = 2
            },
        };
        /* Country action */
        public async Task<List<Pais>> GetPaises() {
            for(var i = 0; i < Paises.Count(); i++) {
                Paises[i].Provincias = null;
            }
            return Paises;
        }
        public async Task<Pais?> GetPaisById(int id) {
            var response = Paises.FirstOrDefault(x => x.Id == id);
            response!.Provincias = Provincias.Where(x => x.IdPais == id).ToList();
            if(response == null) {
                return null;
            }
            return response;
        }
        public async Task<List<Pais>?> PostPais(Pais pais) {
            if(pais == null) {
                return null;
            }
            Paises.Add(pais);
            for(var i = 0; i < Paises.Count(); i++) {
                Paises[i].Provincias = null;
            }
            return Paises;
        }
        public async Task<Pais?> PutPais(int id, Pais pais) {
            if(id != pais.Id) {
                return null;
            }
            var response = Paises.FirstOrDefault(x => x.Id == id);
            if(response == null) {
                return null;
            }
            response.Name = pais.Name;
            response.Provincias = null;
            return response;
        }
        public async Task<Pais?> DeletePais(int id) {
            var response = Paises.FirstOrDefault(x => x.Id == id);
            if(response == null) {
                return null;
            }
            Paises.Remove(response);
            return response;
        }
        /* Province action */
        public async Task<List<Provincia>?> GetProvincias() {
            for(var i = 0; i < Provincias.Count(); i++) {
                Provincias[i].Pais = null;
            }
            return Provincias;
        }
        public async Task<Provincia?> GetProvinciaById(int id) {
            var response = Provincias.FirstOrDefault(x => x.Id == id);
            response!.Pais = new Pais() {
                Id = Paises.FirstOrDefault(p => p.Id == response.IdPais)!.Id,
                Name = Paises!.FirstOrDefault(p => p.Id == response.IdPais)!.Name,
                Provincias = null
            };
            if(response == null) {
                return null;
            }
            return response;
        }
        public async Task<List<Provincia>?> PostProvincia(Provincia provincia) {
            if(provincia == null) {
                return null;
            }
            Provincias.Add(provincia);
            for(var i = 0; i < Provincias.Count(); i++) {
                Provincias[i].Pais = null;
            }
            return Provincias;
        }
        public async Task<Provincia?> PutProvincia(int id, Provincia provincia) {
            if(id != provincia.Id) {
                return null;
            }
            var response = Provincias.FirstOrDefault(x => x.Id == id);
            if(response == null) {
                return null;
            }
            response.Name = provincia.Name;
            response.IdPais = provincia.IdPais;
            response.Pais = null;
            return response;
        }
        public async Task<Provincia?> DeleteProvincia(int id) {
            var response = Provincias.FirstOrDefault(x => x.Id == id);
            if(response == null) {
                return null;
            }
            Provincias.Remove(response);
            return response;
        }
    }
}