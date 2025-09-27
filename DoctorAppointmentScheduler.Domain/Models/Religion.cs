using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.Domain.Models;

[Table("religion", Schema = "master")]
public partial class Religion
{
    [Key]
    [Column("religionid")]
    public Guid Religionid { get; set; }

    [Column("religionname")]
    [StringLength(100)]
    public string Religionname { get; set; } = null!;

    [Column("isdeleted")]
    public bool? Isdeleted { get; set; }
}
