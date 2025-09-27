using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.Domain.Models;

[Table("country", Schema = "master")]
public partial class Country
{
    [Key]
    [Column("countryid")]
    public Guid Countryid { get; set; }

    [Column("countryname")]
    [StringLength(100)]
    public string Countryname { get; set; } = null!;

    [Column("isdeleted")]
    public bool? Isdeleted { get; set; }
}
