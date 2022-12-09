using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.api.paises.Entities
{
    public class Pais
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual List<Provincia>? Provincias { get; set; }
    }
}