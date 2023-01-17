namespace MedicalTrack.src.Schedule.Dtos;

public record CreateScheduleDto
{
    public int? ScheduleDay { get; set; }

    public TimeOnly ScheduleTime { get; set; }

    public bool[]? ScheduleConfirm { get; set; }

    public int SchedulePatientId { get; set; }

    public int ScheduleDrugId { get; set; }

}