using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.ViewModels
{
    public class ClienteViewModel
    {
        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [Column(TypeName = "nvarchar(50)")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [Column("CorreoElectronico", TypeName = "nvarchar(100)")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La dirrecion de entrega es obligatoria")]
        [Column(TypeName = "nvarchar(100)")]
        public string DireccionEntrega { get; set; }
    }
}
