namespace MedicalTrack.src.Drug.Dto;

using System.ComponentModel.DataAnnotations;
using MedicalTrack.src.Schedule.Dtos;
public record DrugDto
{
    [Key]
    public int DrugId { get; set; }
    public Dictionary<string, string>? DrugInfo { get; set; }

    public int DrugCount { get; set; }

    public Dictionary<string, string>? DrugPurpose { get; set; }

    public virtual ICollection<ScheduleDto> Schedules { get; } = new List<ScheduleDto>();

}