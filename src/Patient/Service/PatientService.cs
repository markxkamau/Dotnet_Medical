using MedicalTrack.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Patient.Service;

using MedicalTrack.src.Patient.Model;

public class PatientService
{
    private readonly MedicalContext _context;

    public PatientService(MedicalContext context)
    {
        _context = context;
    }

    public ActionResult<List<Patient>> GetAllPatients()
    {
        return _context.Patients.ToList();
    }

    internal Patient? GetPatientById(int id)
    {
        var patient = _context.Patients.SingleOrDefault(p => p.PatientId == id);
        return patient;
    }
}