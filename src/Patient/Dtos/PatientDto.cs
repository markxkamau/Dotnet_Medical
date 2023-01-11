namespace MedicalTrack.src.Patient.Dtos;

using MedicalTrack.src.Schedule.Model;
using MedicalTrack.src.Test.Model;

public record PatientDto
{
    public int PatientId { get; set; }

    public Dictionary<string, string> PatientName { get; set; } = new Dictionary<string, string>();

    public int PatientAge { get; set; }

    public string PatientCondition { get; set; } = string.Empty;

    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();

    public virtual ICollection<Test> Tests { get; } = new List<Test>();
    
}