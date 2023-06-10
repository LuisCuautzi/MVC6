using System;
using System.Collections.Generic;

namespace Gen06_23_MVCV2.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Cursos = new HashSet<Curso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int NCursos { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
