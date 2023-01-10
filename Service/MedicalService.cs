using MedicalTrack.Data;
using MedicalTrack.Model;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.Service;

public class MedicalService
{
    private readonly MedicalContext _context;

    public MedicalService(MedicalContext context)
    {
        _context = context;
    }

    public ActionResult<List<Patient>> GetAllPatients()
    {
        return _context.Patients.ToList();
    }

    internal ActionResult<List<Drug>> GetAllDrugs()
    {
        return _context.Drugs.ToList();
    }

    internal ActionResult<List<Schedule>> GetAllSchedules()
    {
        return _context.Schedules.ToList();
    }

    internal ActionResult<List<Test>> GetAllTests()
    {
        return _context.Tests.ToList();
    }
}