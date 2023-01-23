namespace MedicalTrack.src.Drug.Dto;

using System.ComponentModel.DataAnnotations;
using MedicalTrack.src.Schedule.Dtos;
public record CreateDrugDto
{
    [Required]
    public string DrugName { get; set; } = string.Empty;
    [Required]
    public string DrugScientificName { get; set; } = string.Empty;
    [Required]
    public float DrugSize { get; set; }
    [Required]
    public string DrugPackaging { get; set; } = string.Empty;
    public int DrugCount { get; set; }
    public string DrugPurpose { get; set; } = string.Empty;

}