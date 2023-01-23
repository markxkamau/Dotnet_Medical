namespace MedicalTrack.src.Schedule.Model;

using MedicalTrack.src.Patient.Model;
using MedicalTrack.src.Drug.Model;
using MedicalTrack.src.Patient.Dtos;
using MedicalTrack.src.Drug.Dto;

public partial class Schedule
{
    public int? Intakes { get; set; }

    public List<String> ScheduleTime { get; set; } = new List<string>();

    public int SchedulePatientId { get; set; }

    public int ScheduleDrugId { get; set; }

    public int ScheduleId { get; set; }

    public virtual DrugDto ScheduleDrug { get; set; } = null!;

    public virtual PatientDto SchedulePatient { get; set; } = null!;
}
