using System;
using System.Collections.Generic;

namespace Logistic.Models;

public partial class DataPony
{
    public short CategoryWork { get; set; }

    public short AreaId { get; set; }

    public short SubareaId { get; set; }

    public Guid RouteId { get; set; }

    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;

    public Guid PointId { get; set; }

    public DateTime Date { get; set; }

    public short UserId { get; set; }

    public short OrderNum { get; set; }

    public Guid Id { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitde { get; set; }
}
