namespace MedicalTrack.src.Patient.Dtos;

public record CreatePatientDto
{
    public string FirstName {get; set;} = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int PatientAge { get; set; }
    public string PatientCondition { get; set; } = string.Empty;
    public int DrugCount { get; set; }
    
}