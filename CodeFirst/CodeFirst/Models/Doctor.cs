﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models;

[Table("doctor")]
public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }

    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string Email { get; set; } = null!;

    public List<Prescription> Prescriptions { get; set; }= new List<Prescription>();
}