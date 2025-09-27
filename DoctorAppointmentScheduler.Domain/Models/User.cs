using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.Domain.Models;

[Table("users")]
[Index("Username", Name = "users_username_key", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("userid")]
    public Guid Userid { get; set; }

    [Column("doctorid")]
    [StringLength(50)]
    public string Doctorid { get; set; } = null!;

    [Column("doctorname")]
    [StringLength(255)]
    public string Doctorname { get; set; } = null!;

    [Column("specializationid")]
    public Guid? Specializationid { get; set; }

    [Column("gender")]
    public int? Gender { get; set; }

    [Column("dateofbirth")]
    public DateOnly? Dateofbirth { get; set; }

    [Column("phonenumber")]
    [StringLength(15)]
    public string Phonenumber { get; set; } = null!;

    [Column("address")]
    [StringLength(255)]
    public string? Address { get; set; }

    [Column("username")]
    [StringLength(100)]
    public string Username { get; set; } = null!;

    [Column("password")]
    public string Password { get; set; } = null!;

    [Column("role")]
    public int Role { get; set; }

    [Column("yearsofexperience")]
    public int? Yearsofexperience { get; set; }

    [Column("qualification")]
    [StringLength(100)]
    public string? Qualification { get; set; }

    [Column("consultationfee")]
    [Precision(10, 2)]
    public decimal? Consultationfee { get; set; }

    [Column("starttime")]
    public TimeOnly? Starttime { get; set; }

    [Column("endtime")]
    public TimeOnly? Endtime { get; set; }
}
