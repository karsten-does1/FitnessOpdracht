using System;
using System.Collections.Generic;

namespace FitnessDL.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public DateOnly Date { get; set; }

    public int MemberId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<ReservationDetail> ReservationDetails { get; set; } = new List<ReservationDetail>();
}
