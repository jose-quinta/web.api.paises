using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace web.api.paises.Entities
{
    public class Provincia
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int IdPais { get; set; }
        [ForeignKey("IdPais")]
        public virtual Pais? Pais { get; set; }
    }
}