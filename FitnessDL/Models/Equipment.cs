using System;
using System.Collections.Generic;

namespace FitnessDL.Models;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string DeviceType { get; set; } = null!;

    public bool IsInMaintenance { get; set; }

    public virtual ICollection<ReservationDetail> ReservationDetails { get; set; } = new List<ReservationDetail>();
}
