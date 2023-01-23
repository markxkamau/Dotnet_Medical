using System.ComponentModel.DataAnnotations;

namespace MedicalTrack.src.Patient.Dtos;

public record CreatePatientDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    [Required]
    public string PatientEmail { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = new DateTime();
    [Required]
    public string PatientCondition { get; set; } = string.Empty;
    public int DrugCount { get; set; }

}