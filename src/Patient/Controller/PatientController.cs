
using MedicalTrack.src.Patient.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Patient.Controller;

using MedicalTrack.src.Patient.Model;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly PatientService _service;

    public PatientController(PatientService service)
    {
        _service = service;
    }

    //GetAll
    [HttpGet("patients")]
    public ActionResult<List<Patient>> GetAllPatients()
    {
        return _service.GetAllPatients();
    }
    
    [HttpGet("patient/{id}")]
    public ActionResult<Patient> GetPatientById(int id)
    {
        var patient = _service.GetPatientById(id);
        if (patient is null)
        {
            return NotFound("Patient Doesn't exist");

        }
        return Ok(patient);
    }

}