using System.ComponentModel.DataAnnotations;
using MedicalTrack.src.Drug.Dto;
using MedicalTrack.src.Patient.Dtos;

namespace MedicalTrack.src.Schedule.Dtos
{
    public record ScheduleDto
    {
        public int? Intakes { get; set; }

        public List<String> ScheduleTime { get; set; } =  new List<string>();

        public int SchedulePatientId { get; set; }

        public int ScheduleDrugId { get; set; }
[Key]
        public int ScheduleId { get; set; }
    }
}