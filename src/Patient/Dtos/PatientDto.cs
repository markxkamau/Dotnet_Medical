namespace MedicalTrack.src.Patient.Dtos;

using System.ComponentModel.DataAnnotations;
using MedicalTrack.src.Schedule.Dtos;
using MedicalTrack.src.Schedule.Model;
using MedicalTrack.src.Test.Dtos;
using MedicalTrack.src.Test.Model;

public record PatientDto
{
    [Key]
    public int PatientId { get; set; }

    public Dictionary<string, string> PatientName { get; set; } = new Dictionary<string, string>();

    public int PatientAge { get; set; }

    public string PatientEmail { get; set; } = string.Empty;

    public string PatientCondition { get; set; } = string.Empty;

    public virtual ICollection<ScheduleDto> Schedules { get; } = new List<ScheduleDto>();

    public virtual ICollection<TestDto> Tests { get; } = new List<TestDto>();

}