namespace MedicalTrack.src.Patient.Dtos;

public record CreatePatientDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PatientEmail { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = new DateTime();
    public string PatientCondition { get; set; } = string.Empty;
    public int DrugCount { get; set; }

}