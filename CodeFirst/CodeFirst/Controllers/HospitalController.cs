using System.Transactions;
using CodeFirst.Data;
using CodeFirst.DTOs;
using CodeFirst.Models;
using CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Controllers;

[ApiController]
public class HospitalController : ControllerBase
{
    public IDbService Service;
    public HospitalContext Context;

    public HospitalController(IDbService service, HospitalContext context)
    {
        Service = service;
        Context = context;
    }

    [HttpPost]
    [Route("prescription")]
    public async Task<IActionResult> AddPrescription(PresciptionDTO presciptionDto)
    {
        var patient = await Service.DoesPatientExist(presciptionDto.Patient.IdPatient);

        try
        {
            await Service.DoesMedicamentExist(presciptionDto.Medicaments);
        }
        catch (Exception e)
        {
            return NotFound("Medicament doesn't exist");
        }

        if (presciptionDto.Medicaments.Count > 10)
        {
            return NotFound("Prescription has more than 10 medicament");
        }

        if (presciptionDto.DueDate < presciptionDto.Date)
        {
            return NotFound("Problem with date");
        }

        using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            var p = Context.Prescriptions.Add(
                new Prescription()
                {
                    Date = presciptionDto.Date,
                    DueDate = presciptionDto.DueDate,
                    IdDoctor = 1, // to nie powinno tak byc ale zadanie nic nie mowi o doktorze
                    IdPatient = presciptionDto.Patient.IdPatient
                }
            );
            await Context.SaveChangesAsync();

            foreach (var medicament in presciptionDto.Medicaments)
            {
                Context.PrescriptionMedicaments.Add(
                    new PrescriptionMedicament()
                    {
                        IdMedicament = medicament.IdMedicament,
                        IdPrescription = p.Entity.IdPrescription,
                        Details = medicament.Description,
                        Dose = medicament.Dose
                    }
                );
            }

            if (patient == null)
            {
                Context.Patients.Add(
                    new Patient()
                    {
                        BirthDate = presciptionDto.Patient.BirthDate,
                        FirstName = presciptionDto.Patient.FirstName,
                        LastName = presciptionDto.Patient.LastName,
                        IdPatient = presciptionDto.Patient.IdPatient
                    }
                );
            }

            await Context.SaveChangesAsync();
            scope.Complete();
        }

        return Ok("Prescription added");
    }

    
    [HttpGet]
    [Route("patient/{id:int}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var patient = await Context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.IdMedicamentNavigation)
            .FirstOrDefaultAsync(p => p.IdPatient == id);

        if (patient == null)
        {
            return NotFound("Patient doesn't exist");
        }

        var patientDto = new 
        {
            patient.IdPatient,
            patient.FirstName,
            patient.LastName,
            patient.BirthDate,
            Prescriptions = patient.Prescriptions.Select(p => new 
            {
                p.IdPrescription,
                p.Date,
                p.DueDate,
                PrescriptionMedicaments = p.PrescriptionMedicaments.Select(pm => new 
                {
                    pm.IdMedicament,
                    pm.Dose,
                    pm.Details
                }).ToList()
            }).ToList()
        };

        return Ok(patientDto);
    }
}