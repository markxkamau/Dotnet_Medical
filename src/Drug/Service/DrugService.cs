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