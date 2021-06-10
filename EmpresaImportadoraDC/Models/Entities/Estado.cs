using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Entities
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }

        [DisplayName("Estado")]
        [Column(TypeName = "nvarchar(50)")]
        public string TipoEstado { get; set; }
    }
}
