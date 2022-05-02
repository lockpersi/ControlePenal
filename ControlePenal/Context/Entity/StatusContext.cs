using System;
using System.Collections.Generic;

namespace ControlePenal.Entity.Models
{
    public partial class StatusContext
    {

        public int IdStatus { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CriminalCodeContext> Criminalcodes { get; set; }
    }
}
