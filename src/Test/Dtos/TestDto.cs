using MedicalTrack.src.Patient.Dtos;

namespace MedicalTrack.src.Test.Dtos;

public record TestDto
{
    public int TestId { get; set; }

    public int TestResultBp { get; set; }

    public int TestResultSugars { get; set; }

    public int TestResultWeight { get; set; }

    public int TestResultOxygen { get; set; }

    public int TestPatientId { get; set; }

}