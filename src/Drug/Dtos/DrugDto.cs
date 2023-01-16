namespace MedicalTrack.src.Drug.Dto;

using MedicalTrack.src.Schedule.Dtos;
public record DrugDto
{
    public int DrugId { get; set; }
    public Dictionary<string, string>? DrugInfo { get; set; }

    public int DrugCount { get; set; }

    public Dictionary<string, string>? DrugPurpose { get; set; }

    public virtual ICollection<ScheduleDto> Schedules { get; } = new List<ScheduleDto>();

}