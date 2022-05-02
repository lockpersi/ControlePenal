namespace ControlePenal.Models
{
    public class CriminalCodeModel
    {
        public int IdCriminalCode { get; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public int UpdateUserId { get; set; }

    }
}
