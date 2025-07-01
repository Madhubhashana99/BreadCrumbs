using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace student_management_system.Models;

[Table("student_details")]
public partial class StudentDetail
{
    [Key]
    [Column("stu_id")]
    public int StuId { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    public string LastName { get; set; } = null!;

    [Column("email")]
    public string Email { get; set; } = null!;

    [Column("phone_number")]
    public int? PhoneNumber { get; set; }

    [Column("birthday")]
    public DateOnly? Birthday { get; set; }

    [Column("gender")]
    public string? Gender { get; set; }
}
