using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Data;

public class HospitalContext : DbContext
{
    protected HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient?> Patients { get; set; }

    public virtual DbSet<Medicament> Medicaments { get; set; }
    
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor(){IdDoctor = 1, FirstName = "John", LastName = "Kowalski", Email = "jjj@wp.pl"},
            new Doctor(){IdDoctor = 2, FirstName = "Maciek", LastName = "Jankowski", Email = "mj@wp.pl"}
            );
        
        modelBuilder.Entity<Patient>().HasData(
            new Patient(){IdPatient = 1, FirstName = "Johnathan", LastName = "Matejewski", BirthDate = new DateTime(2007, 5, 23)},
            new Patient(){IdPatient = 2, FirstName = "Natalia", LastName = "Kowalska", BirthDate = new DateTime(2008, 5, 23)}
        );

        modelBuilder.Entity<Medicament>().HasData(
            new Medicament(){IdMedicament = 1, Name = "ABC", Description = "no jakis opis 1", Type = "no jakis type 1"},
            new Medicament(){IdMedicament = 2, Name = "ABCDD", Description = "no jakis opis 2", Type = "no jakis type 2"}
            );
        
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription(){IdPrescription = 1, Date = new DateTime(2008, 7, 20), DueDate = new DateTime(2008, 9, 20), IdPatient = 1, IdDoctor = 2},
            new Prescription(){IdPrescription = 2, Date = new DateTime(2010, 7, 20), DueDate = new DateTime(2010, 10, 22), IdPatient = 2, IdDoctor = 1}
        );

        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament(){IdPrescription = 1, IdMedicament = 1,  Dose = 10, Details = "no jakis details"},
            new PrescriptionMedicament(){IdPrescription = 2, IdMedicament = 2, Dose = 20, Details = "no jakis details 2"},
            new PrescriptionMedicament(){IdPrescription = 2, IdMedicament = 1,  Dose = 5, Details = "no jakis details 3"}

            );
        
        base.OnModelCreating(modelBuilder);
    }
}