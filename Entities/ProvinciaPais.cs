using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.api.paises.Entities {
    public class ProvinciaPais {
        public virtual Provincia Provincia { get; set; }
        public virtual Pais Pais { get; set; }
    }
}