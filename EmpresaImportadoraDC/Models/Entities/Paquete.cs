using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Código")]        
        public string Codigo { get; set; }

        [DisplayName("Peso en libras")]
        [Required(ErrorMessage = "El peso es obligatorio")]
        public int PesoLibras { get; set; }
        [DisplayName("Cliente y casillero")]       
        public int ClienteId { get; set; }
        [DisplayName("Estado")]
        public int EstadoId { get; set; }
        [Required(ErrorMessage = "El número de guia es obligatoria")]
        public int NoGuiaUSA { get; set; }
        [Required(ErrorMessage = "La transportadora es obligatoria")]
        [Column(TypeName = "nvarchar(50)")]

        public string TransportadoraUSA { get; set; }
        [DisplayName("Tipo de mercancía")]
        public int MercanciaId { get; set; }

        public string RutaImagen { get; set; }

        [DisplayName("Número de guía Colombia")]
        public int NoGuiaCO { get; set; }

        [DisplayName("Transportadora Colombia")]
        [Column(TypeName = "nvarchar(50)")]
        public string TransportadoraCO { get; set; }
        [DisplayName("Valor total")]
        public long ValorTotal { get; set; }
        
        public virtual Mercancia Mercancia { get; set; }
        public virtual Cliente Cliente { get; set;}
        public virtual Estado Estado { get; set; }
    }
}
