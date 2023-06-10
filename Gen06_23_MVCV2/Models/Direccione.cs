using System;
using System.Collections.Generic;

namespace Gen06_23_MVCV2.Models
{
    public partial class Direccione
    {
        public Direccione()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string Cikudad { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
