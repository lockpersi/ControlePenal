using System;
using System.Collections.Generic;

namespace ControlePenal.Entity.Models
{
    public partial class CriminalCodeContext
    {
        public int IdCriminalCode { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }

        public virtual UserContext CreateUser { get; } = null!;
        public virtual StatusContext Status { get; } = null!;
        public virtual UserContext UpdateUser { get; } = null!;
    }
}
