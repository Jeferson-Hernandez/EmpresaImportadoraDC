using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Entities
{
    public class Mercancia
    {
        [Key]
        public int IdMercancia { get; set; }
        [Required(ErrorMessage = "El tipo de mercancía es obligatoria")]
        [Column (TypeName = "nvarchar(50)")]
        public string TipoMercancia { get; set; }
    }
}
