
using Microsoft.AspNetCore.Mvc;
using MedicalTrack.src.Schedule.Service;


namespace MedicalTrack.src.Schedule.Controller;

using MedicalTrack.src.Schedule.Dtos;


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
    public ActionResult<List<ScheduleDto>> GetAllSchedules()
    {
        return _service.GetAllSchedules();
    }

    [HttpGet("schedule/{id}")]
    public ActionResult<ScheduleDto> GetScheduleById(int id)
    {
        return _service.GetAllSchedules(id);
    }

    [HttpGet("schedule/patient/{id}")]
    public ActionResult<ScheduleDto> GetScheduleFromPatientId(int Id)
    {
        return _service.GetScheduleFromPatient(Id);
    }

    [HttpPost("schedule")]
    public ActionResult<ScheduleDto> CreateNewSchedule(CreateScheduleDto createScheduleDto)
    {
        // Check if schedule exists
        bool check =_service.CheckSchedule(createScheduleDto);
        if (!check)
        {
            return BadRequest("Schedule for Patient already exists under the drug stated");
            
        }
        // Create new schedule
        var schedule = _service.CreateNewSchedule(createScheduleDto);
        return Ok(schedule);

    }

}