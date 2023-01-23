using System.ComponentModel.DataAnnotations;
using MedicalTrack.src.Patient.Dtos;

namespace MedicalTrack.src.Test.Dtos;

public record TestDto
{
    [Key]
     public int TestId { get; set; }

    public int TestResultBp { get; set; }

    public int TestResultSugars { get; set; }

    public int TestResultWeight { get; set; }

    public int TestResultOxygen { get; set; }

    public int TestPatientId { get; set; }

    public DateTime TestDate { get; set; } = DateTime.UtcNow;


}