using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.Domain.Models;

public partial class Occupation
{
    public Guid Occupationid { get; set; }

    public string Occupationname { get; set; } = null!;

    public bool? Isdeleted { get; set; }
}
