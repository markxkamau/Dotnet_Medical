namespace MedicalTrack.src.Schedule.Dtos;

public record CreateScheduleDto
{
    public int? Intakes { get; set; }

    public List<string> ScheduleTime { get; set; } = new List<string>();

    public int SchedulePatientId { get; set; }

    public int ScheduleDrugId { get; set; }

}