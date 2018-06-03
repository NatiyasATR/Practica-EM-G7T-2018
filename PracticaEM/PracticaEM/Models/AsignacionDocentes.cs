using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaEM.Models
{
    public class AsignacionDocentes
    {
        public int Id { get; set; }
        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        public virtual Cursos Curso { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
        public virtual GrupoClase Grupo { get; set; }
   
    }
}