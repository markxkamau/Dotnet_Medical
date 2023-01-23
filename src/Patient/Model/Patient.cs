
namespace MedicalTrack.src.Patient.Model;

using MedicalTrack.src.Schedule.Dtos;
using MedicalTrack.src.Schedule.Model;
using MedicalTrack.src.Test.Dtos;
using MedicalTrack.src.Test.Model;
public partial class Patient
{
    public int PatientId { get; set; }

    public Dictionary<string, string> PatientName { get; set; } = new Dictionary<string, string>();
    
    public string PatientEmail { get; set; } = string.Empty;

    public int PatientAge { get; set; }

    public string PatientCondition { get; set; } = string.Empty;

    public virtual ICollection<ScheduleDto> Schedules { get; } = new List<ScheduleDto>();

    public virtual ICollection<TestDto> Tests { get; } = new List<TestDto>();
}
