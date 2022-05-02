namespace ControlePenal.Models
{
    public class ResponseModel
    {
        public enum StatusEnum { Sucess, Error, NotFound }
        public string Message { get; set; }

        public StatusEnum Status { get; set; }
    }
}
