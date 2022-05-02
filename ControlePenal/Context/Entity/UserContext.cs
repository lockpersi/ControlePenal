using System;
using System.Collections.Generic;

namespace ControlePenal.Entity.Models
{
    public partial class UserContext
    {

        public int IdUser { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<CriminalCodeContext> CriminalcodeCreateUsers { get; set; }
        public virtual ICollection<CriminalCodeContext> CriminalcodeUpdateUsers { get; set; }
    }
}
