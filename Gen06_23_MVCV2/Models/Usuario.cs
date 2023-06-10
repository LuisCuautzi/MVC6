using System;
using System.Collections.Generic;

namespace Gen06_23_MVCV2.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int PerfilId { get; set; }
        public int DireccionId { get; set; }
        public DateTime FecNac { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }

        public virtual Direccione Direccion { get; set; }
        public virtual Perfile Perfil { get; set; }
    }
}
