using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Entities
{
    public class Mercancia
    {
        [Key]
        public int IdMercancia { get; set; }
        public string TipoMercancia { get; set; }
    }
}
