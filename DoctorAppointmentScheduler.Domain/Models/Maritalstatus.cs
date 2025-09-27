using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.Domain.Models;

[Table("maritalstatus", Schema = "master")]
public partial class Maritalstatus
{
    [Key]
    [Column("maritalstatusid")]
    public Guid Maritalstatusid { get; set; }

    [Column("maritalstatus")]
    [StringLength(50)]
    public string Maritalstatus1 { get; set; } = null!;

    [Column("isdeleted")]
    public bool? Isdeleted { get; set; }
}
