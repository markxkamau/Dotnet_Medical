
using MedicalTrack.src.Patient.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Patient.Controller;

using MedicalTrack.src.Patient.Dtos;
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

    [HttpPost("new_patient")]
    public ActionResult<PatientDto> CreatePatient(CreatePatientDto createPatientDto){
        if(!_service.CheckEmailValidity(createPatientDto.PatientEmail)){
            return BadRequest("Check Emaill, No such account registered");
        }
        bool patientCheck = _service.SearchPatient(createPatientDto.PatientEmail);

        if (!patientCheck)
        {
            return BadRequest("Patient Already exists");            
        }

        var patientDto = _service.CreatePatient(createPatientDto);

        return Ok(patientDto);
    }

}