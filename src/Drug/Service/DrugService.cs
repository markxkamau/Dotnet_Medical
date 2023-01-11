using MedicalTrack.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Drug.Service;

using MedicalTrack.src.Drug.Model;

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

}