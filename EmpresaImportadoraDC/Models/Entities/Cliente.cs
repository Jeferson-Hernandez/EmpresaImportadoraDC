using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Número de casillero")]
        [Required]
        public int NumeroCasillero {get; set;}

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [Column (TypeName = "nvarchar(50)")]
        public string NombreCliente {get; set; }

        [DisplayName("Correo electrónico")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [Column ("CorreoElectronico",TypeName = "nvarchar(100)")]
        public string Correo {get; set; }
        [DisplayName("Dirección de entrega")]
        [Required(ErrorMessage = "La dirreción de entrega es obligatoria")]
        [Column (TypeName = "nvarchar(100)")]
        public string DireccionEntrega {get; set; }
    }
}
