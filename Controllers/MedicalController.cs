using MedicalTrack.Model;
using MedicalTrack.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicalController : ControllerBase
{
    private readonly MedicalService _service;

    public MedicalController(MedicalService service)
    {
        _service = service;
    }

    //GetAll
    [HttpGet("patients")]
    public ActionResult<List<Patient>> GetAllPatients()
    {
        return _service.GetAllPatients();
    }
    [HttpGet("drugs")]
    public ActionResult<List<Drug>> GetAllDrugs()
    {
        return _service.GetAllDrugs();
    }
    [HttpGet("schedules")]
    public ActionResult<List<Schedule>> GetAllSchedules()
    {
        return _service.GetAllSchedules();
    }
    [HttpGet("tests")]
    public ActionResult<List<Test>> GetAllTests()
    {
        return _service.GetAllTests();
    }    

}