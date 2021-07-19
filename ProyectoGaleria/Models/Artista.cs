using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGaleria.Models
{
    public class Artista
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Display(Name ="Nombre de la Obra")]
        public string Obra { get; set; }
        [Display(Name = "Tipo de Arte")]
        public string Tipo { get; set; }
        public int Precio { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de la Lanzamiento")]
        public DateTime Fechacreacion { get; set; }
        
        [Display(Name = "Imagen")]
        public byte[] Imagen { get; set; }
        [Display(Name = "Imagen Perfil")]
        public byte[] ImgPerfil { get; set; }


    }
}
