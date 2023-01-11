using MedicalTrack.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Schedule.Service;

using MedicalTrack.src.Schedule.Model;

public class ScheduleService
{
    private readonly MedicalContext _context;

    public ScheduleService(MedicalContext context)
    {
        _context = context;
    }

    internal ActionResult<List<Schedule>> GetAllSchedules()
    {
        return _context.Schedules.ToList();
    }
}