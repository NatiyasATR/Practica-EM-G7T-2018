using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaEM.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public virtual GrupoClase Grupo { get; set; }
        public string CursoId { get; set; }
        public virtual Cursos Curso { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        
    }
}