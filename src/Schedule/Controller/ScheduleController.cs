
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
    public ActionResult<List<ScheduleDto>> GetScheduleFromPatientId(int id)
    {
        return _service.GetScheduleFromPatient(id);
    }

    [HttpPost("schedule")]
    public ActionResult<ScheduleDto> CreateNewSchedule(CreateScheduleDto createScheduleDto)
    {
        // Check if schedule exists
        bool check = _service.CheckSchedule(createScheduleDto);
        if (!check)
        {
            return BadRequest("Schedule for Patient already exists under the drug stated");

        }
        // Check if patient and drug exist
        bool patientCheck = _service.CheckPatient(createScheduleDto.SchedulePatientId, createScheduleDto.ScheduleDrugId);
        if (!patientCheck)
        {
            return NotFound("Patient or Drug Id not yet declared");
        }
        // Create new schedule
        var schedule = _service.AddNewSchedule(createScheduleDto);
        return Ok(schedule);

    }

    [HttpDelete("schedule/{id}")]
    public IActionResult DeleteSchedule(int id)
    {
        bool schedule = _service.CheckSchedule(id);
        if (!schedule)
        {
            return NotFound("Schedule doesn't exist");
        }
        _service.DeleteSchedule(id);
        return Ok("Schedule Successfully deleted");
    }

}