using System.ComponentModel.DataAnnotations;

namespace MedicalTrack.src.Schedule.Dtos;

public record CreateScheduleDto
{
    [Required]
    public int Intakes { get; set; }

    public List<string> ScheduleTime { get; set; } = new List<string>();
    [Required]
    public int SchedulePatientId { get; set; }
    [Required]
    public int ScheduleDrugId { get; set; }

}