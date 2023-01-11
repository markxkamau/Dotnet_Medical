
using Microsoft.AspNetCore.Mvc;
using MedicalTrack.src.Schedule.Service;


namespace MedicalTrack.src.Schedule.Controller;
using MedicalTrack.src.Schedule.Model;


[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly ScheduleService _service;

    public ScheduleController(ScheduleService service)
    {
        _service = service;
    }

    //GetAll
    
    [HttpGet("schedules")]
    public ActionResult<List<Schedule>> GetAllSchedules()
    {
        return _service.GetAllSchedules();
    }


}