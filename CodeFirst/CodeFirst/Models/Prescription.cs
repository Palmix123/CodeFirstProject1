using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models;

[Table("prescription")]
public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public int IdPatient { get; set; }

    [Required]
    public int IdDoctor { get; set; }
    
    [ForeignKey(nameof(IdPatient))] public Patient IdPatientNavigation { get; set; } = null!;

    [ForeignKey(nameof(IdDoctor))] public Doctor IdDoctorNavigation { get; set; } = null!;

    public List<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();
}