using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Autores = new HashSet<Autores>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Autores> Autores { get; set; }
    }
}
