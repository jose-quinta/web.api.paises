using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.api.paises.Entities {
    public class PaisProvincias {
        public virtual Pais Pais { get; set; }
        public virtual List<Provincia> Provincias { get; set; }
    }
}