using ControlePenal.Entity.Models;

namespace ControlePenal.Models
{
    public class CriminalResponseModel : ResponseModel
    {
        public List<CriminalCodeContext>? Data { get; set; }
    }
}
