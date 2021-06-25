using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fromend.Models
{
    public class Archivodata
    {
        [Required(ErrorMessage = "archivo es requerido")]
        public string file { get; set; }


    }
}
