using MedicalTrack.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Drug.Service;

using System;
using MedicalTrack.src.Drug.Dto;
using MedicalTrack.src.Drug.Model;
using Microsoft.EntityFrameworkCore;

public class DrugService
{
    private readonly MedicalContext _context;

    public DrugService(MedicalContext context)
    {
        _context = context;
    }

    internal DrugDto AddDrug(CreateDrugDto createDrugDto)
    {
        Dictionary<String, String> drugInfo = new Dictionary<string, string>();
        drugInfo.Add("Drug Name", createDrugDto.DrugName);
        drugInfo.Add("Drug Scientific Name", createDrugDto.DrugScientificName);
        drugInfo.Add("Drug Size", createDrugDto.DrugSize.ToString());
        drugInfo.Add("Drug Packaging", createDrugDto.DrugPackaging);

        var drugPurpose = new Dictionary<string, string>();
        drugPurpose.Add("Drug Use", createDrugDto.DrugPurpose);

        var drugDto = new DrugDto
        {
            DrugId = new int(),
            DrugCount = createDrugDto.DrugCount,
            DrugInfo = drugInfo,
            DrugPurpose = drugPurpose
        };

        var drug = new Drug
        {
            DrugId = drugDto.DrugId,
            DrugCount = drugDto.DrugCount,
            DrugInfo = drugDto.DrugInfo,
            DrugPurpose = drugDto.DrugPurpose
        };
        _context.Drugs.Add(drug);
        _context.SaveChanges();
        return drugDto;

    }

    internal bool CheckIfExists(CreateDrugDto createDrugDto)
    {
        Dictionary<String, String> drugInfo = new Dictionary<string, string>();
        drugInfo.Add("Drug Name", createDrugDto.DrugName);
        drugInfo.Add("Drug Scientific Name", createDrugDto.DrugScientificName);
        drugInfo.Add("Drug Size", createDrugDto.DrugSize.ToString());
        drugInfo.Add("Drug Packaging", createDrugDto.DrugPackaging);

        var drug = _context.Drugs.SingleOrDefault(p => p.DrugInfo == drugInfo);
        if (drug is null)
        {
            return true;
        }
        return false;
    }

    internal ActionResult<List<Drug>> GetAllDrugs()
    {
        return _context.Drugs.ToList();
    }

    internal ActionResult<DrugDto> GetDrugById(int id)
    {
        var drug = _context.Drugs.SingleOrDefault(p => p.DrugId == id);

        if (drug is null)
        {
            return new DrugDto();
        }

        var drugDto = new DrugDto
        {
            DrugId = drug.DrugId,
            DrugCount = drug.DrugCount,
            DrugInfo = drug.DrugInfo,
            DrugPurpose = drug.DrugPurpose
        };

        return drugDto;
    }
}