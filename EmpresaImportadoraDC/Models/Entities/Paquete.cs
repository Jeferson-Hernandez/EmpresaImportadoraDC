using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaImportadoraDC.Models.Entities
{
    public class Paquete
    {
        [Key]
        public int PaqueteId { get; set; }
        [Required]
        public string Codigo { get; set; }
        [ForeignKey("Cliente")]
        [Required (ErrorMessage = "El número de casillero es obligatorio")]        
        public int NumeroCasillero { get; set; }
        
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

        public int NoGuiaCO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string TransportadoraCO { get; set; }
        
        public long ValorTotal { get; set; }
        [ForeignKey("NombreCliente")]
        public virtual Cliente Cliente{ get; set;}
    }
}
