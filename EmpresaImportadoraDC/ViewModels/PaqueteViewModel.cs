using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.ViewModels
{
    public class PaqueteViewModel
    {
        [Required]
        public string Codigo { get; set; }

        public int ClienteId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Estado { get; set; }

        public int NoGuiaUSA { get; set; }
        [Required(ErrorMessage = "La transportadora es obligatoria")]
        [Column(TypeName = "nvarchar(50)")]
        public string TransportadoraUSA { get; set; }
        [Required(ErrorMessage = "El tipo de mercancía es obligatorio")]
        [Column(TypeName = "nvarchar(50)")]
        public string TipoMercancia { get; set; }

        public IFormFile Imagen { get; set; }

        public string RutaImagen { get; set; }

        public int NoGuiaCO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string TransportadoraCO { get; set; }

        public long ValorTotal { get; set; }
    }
}
