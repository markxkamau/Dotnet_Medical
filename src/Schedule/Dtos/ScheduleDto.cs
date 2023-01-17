using MedicalTrack.src.Drug.Dto;
using MedicalTrack.src.Patient.Dtos;

namespace MedicalTrack.src.Schedule.Dtos
{
    public record ScheduleDto
    {
        public int? ScheduleDay { get; set; }

        public TimeOnly ScheduleTime { get; set; }

        public bool[]? ScheduleConfirm { get; set; }

        public int SchedulePatientId { get; set; }

        public int ScheduleDrugId { get; set; }

        public int ScheduleId { get; set; }

        public virtual DrugDto ScheduleDrug { get; set; } = null!;

        public virtual PatientDto SchedulePatient { get; set; } = null!;
    }
}