using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.Domain.Models;

[Table("title", Schema = "master")]
public partial class Title
{
    [Key]
    [Column("titleid")]
    public Guid Titleid { get; set; }

    [Column("titlename")]
    [StringLength(50)]
    public string Titlename { get; set; } = null!;

    [Column("isdeleted")]
    public bool? Isdeleted { get; set; }
}
