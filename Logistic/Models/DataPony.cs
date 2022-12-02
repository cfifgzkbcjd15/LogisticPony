using System;
using System.Collections.Generic;

namespace Logistic.Models;

public partial class DataPony
{
    public short CategoryWork { get; set; }

    public short AreaId { get; set; }

    public short SubareaId { get; set; }

    public Guid RouteId { get; set; }

    public Guid PointId { get; set; }

    public short UserId { get; set; }

    public short OrderNum { get; set; }

    public Guid Id { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitde { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime Date { get; set; }
}
