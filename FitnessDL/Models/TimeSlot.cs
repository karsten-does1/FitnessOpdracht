using System;
using System.Collections.Generic;

namespace FitnessDL.Models;

public partial class TimeSlot
{
    public int TimeSlotId { get; set; }

    public int StartTime { get; set; }

    public int EndTime { get; set; }

    public string PartOfDay { get; set; } = null!;

    public virtual ICollection<ReservationDetail> ReservationDetails { get; set; } = new List<ReservationDetail>();
}
