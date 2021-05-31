using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        public int NumeroCasillero {get; set;}

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [Column (TypeName = "nvarchar(50)")]
        public string NombreCliente {get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [Column ("CorreoElectronico",TypeName = "nvarchar(100)")]
        public string Correo {get; set; }

        [Required(ErrorMessage = "La dirrecion de entrega es obligatoria")]
        [Column (TypeName = "nvarchar(100)")]
        public string DireccionEntrega {get; set; }
    }
}
