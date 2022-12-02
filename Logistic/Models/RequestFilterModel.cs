namespace Logistic.Models
{
    public class RequestFilterModel
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public short UserId { get; set; }
        public short AreaId { get; set; }
        public bool IsMore { get; set; }

    }
}
