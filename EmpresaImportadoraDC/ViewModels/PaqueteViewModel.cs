using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.ViewModels
{
    public class PaqueteViewModel
    {
        public int PaqueteId { get; set; }
        [Required]
        public string Codigo { get; set; }

        [DisplayName("Peso en libras")]
        [Required(ErrorMessage = "El peso es obligatorio")]
        public int PesoLibras { get; set; }

        public int ClienteId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Estado { get; set; }
        [DisplayName("Número de guia USA")]
        public int NoGuiaUSA { get; set; }
        [DisplayName("Transportadora USA")]
        [Required(ErrorMessage = "La transportadora es obligatoria")]
        [Column(TypeName = "nvarchar(50)")]
        public string TransportadoraUSA { get; set; }
        [Required(ErrorMessage = "El tipo de mercancía es obligatorio")]
        [Column(TypeName = "nvarchar(50)")]
        public int MercanciaId { get; set; }

        public IFormFile Imagen { get; set; }

        public string RutaImagen { get; set; }
        [DisplayName("Número de guia CO")]
        public int NoGuiaCO { get; set; }
        [DisplayName("Transportadora CO")]
        [Column(TypeName = "nvarchar(50)")]
        public string TransportadoraCO { get; set; }
        [DisplayName("Valor total")]
        public long ValorTotal { get; set; }
    }
}
