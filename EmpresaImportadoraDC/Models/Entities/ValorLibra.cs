using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Entities
{
    public class ValorLibra
    {
        [Key]
        public int ValorLibraId { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        public int ValorLi { get; set; }
    }
}
