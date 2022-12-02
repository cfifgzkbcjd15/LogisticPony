namespace Logistic.Models
{
    public class Reports
    {
        public short CategoryWork { get; set; }
        public Guid RouteId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid PointId { get; set; }
        public short UserId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitde { get; set; }
    }
}
