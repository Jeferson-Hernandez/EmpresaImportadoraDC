using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Entities
{

    /// <summary>
    /// Daniel Agudelo Montoya
    /// </summary>
    public class Transportadora
    {
        [Key]
        public int TransportadoraId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Column(TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }

        [DisplayName("País")]
        [Required (ErrorMessage = "El pais es obligatorio")]
        [Column(TypeName = "nvarchar(30)")]
        public string Pais { get; set; }
    }
}
