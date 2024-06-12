using CodeFirst.Models;

namespace CodeFirst.DTOs;

public class PresciptionDTO
{
    public AddPatient Patient { get; set; } = null!;

    public List<HelpDTO> Medicaments { get; set; } = new List<HelpDTO>();

    public DateTime Date { get; set; }

    public DateTime DueDate { get; set; }
}