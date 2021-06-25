using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fromend.Models
{
    public class personassccdata
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Cedula es requerida")]
        [StringLength(20, ErrorMessage = "Logitud de cedula invalida, logitud maxima 20")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(30, ErrorMessage = "Longitud invalida, logitud maxima 30")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Edad es requerida")]
        [Range(1, 999, ErrorMessage = "Longitud invalida, logitud maxima 3")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "Nacimiento es requerido")]
        public DateTime? Nacimiento { get; set; }
        [Required(ErrorMessage = "genero es requerido")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "Estado es requerido")]
        public string Estado { get; set; }
    }
}
