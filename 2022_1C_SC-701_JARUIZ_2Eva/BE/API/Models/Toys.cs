using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class Toys
    {
        public int Id { get; set; }
        public int? KidId { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }

        public virtual Kids Kid { get; set; }
    }
}
