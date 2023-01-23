using System.ComponentModel.DataAnnotations;

namespace MedicalTrack.src.Test.Dtos;

public record CreateTestDto
{
    [Required]
    [Range(125, 180)]
    public int TestResultBp { get; set; }
    [Required]
    [Range(0, 230)]
    public int TestResultSugars { get; set; }
    [Required]
    public int TestResultWeight { get; set; }
    [Required]
    [Range(0, 100)]
    public int TestResultOxygen { get; set; }
    [Required]

    public int TestPatientId { get; set; }

}