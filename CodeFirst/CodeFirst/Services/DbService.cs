using CodeFirst.Data;
using CodeFirst.DTOs;
using CodeFirst.Models;

namespace CodeFirst.Services;

public class DbService : IDbService
{
    public HospitalContext Context;

    public DbService(HospitalContext context)
    {
        Context = context;
    }

    public async Task<Patient?> DoesPatientExist(int id)
    {
        return await Context.Patients.FindAsync(id);
    }

    public async Task DoesMedicamentExist(List<HelpDTO> medicaments)
    {
        foreach(HelpDTO medicament in medicaments)
        {
            if (await Context.Medicaments.FindAsync(medicament.IdMedicament) == null)
            {
                throw new Exception();
            }
        }
    }
}