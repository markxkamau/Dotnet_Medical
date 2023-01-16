namespace MedicalTrack.src.Drug.Dto;

using MedicalTrack.src.Schedule.Dtos;
public record CreateDrugDto
{
    public string DrugName { get; set; } = string.Empty;
    public string DrugScientificName { get; set; } = string.Empty;
    public float DrugSize { get; set; }
    public string DrugPackaging { get; set; } = string.Empty;
    public int DrugCount { get; set; }
    public string DrugPurpose { get; set; } = string.Empty;

}