using MedicalTrack.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Schedule.Service;

using MedicalTrack.src.Schedule.Dtos;
using MedicalTrack.src.Drug.Model;
using MedicalTrack.src.Schedule.Model;
using MedicalTrack.src.Drug.Dto;
using MedicalTrack.src.Patient.Dtos;
using System;
using Microsoft.EntityFrameworkCore;

public class ScheduleService
{
    private readonly MedicalContext _context;

    public ScheduleService(MedicalContext context)
    {
        _context = context;
    }

    internal bool CheckSchedule(CreateScheduleDto createScheduleDto)
    {
        var drug = createScheduleDto.ScheduleDrugId;
        var patient = createScheduleDto.SchedulePatientId;
        if (_context.Schedules.Any(p => p.ScheduleDrugId == drug) && _context.Schedules.Any(p => p.SchedulePatientId == patient))
        {
            return false;
        }
        return true;
    }

    internal ScheduleDto AddNewSchedule(CreateScheduleDto createScheduleDto)
    {
        var patient = _context.Patients.Single(p => p.PatientId == createScheduleDto.SchedulePatientId);
        var drug = _context.Drugs.Single(p => p.DrugId == createScheduleDto.ScheduleDrugId);
        var scheduleDto = new ScheduleDto
        {
            ScheduleId = new int(),
            Intakes = createScheduleDto.Intakes,
            ScheduleDrugId = createScheduleDto.ScheduleDrugId,
            ScheduleTime = createScheduleDto.ScheduleTime,
            SchedulePatientId = createScheduleDto.SchedulePatientId
        };

        var schedule = new Schedule
        {
            ScheduleId = scheduleDto.ScheduleId,
            Intakes = scheduleDto.Intakes,
            ScheduleTime = scheduleDto.ScheduleTime,
            ScheduleDrug = drug,
            ScheduleDrugId = scheduleDto.ScheduleDrugId,
            SchedulePatientId = scheduleDto.SchedulePatientId,
            SchedulePatient = patient
        };
        _context.Schedules.Add(schedule);
        _context.SaveChanges();


        return scheduleDto;
    }

    internal ActionResult<List<ScheduleDto>> GetAllSchedules()
    {
        List<ScheduleDto> scheduleDtos = new List<ScheduleDto>();
        var schedules = _context.Schedules
        .ToList();
        foreach (var schedule in schedules)
        {
            var scheduleDto = new ScheduleDto
            {
                ScheduleId = schedule.ScheduleId,
                ScheduleTime = schedule.ScheduleTime,
                Intakes = schedule.Intakes,
                SchedulePatientId = schedule.SchedulePatientId,
                ScheduleDrugId = schedule.ScheduleDrugId,

            };
            scheduleDtos.Add(scheduleDto);
        }
        return scheduleDtos;
    }

    internal ActionResult<ScheduleDto> GetAllSchedules(int id)
    {
        var check = _context.Schedules.Any(p => p.ScheduleId == id);
        if (!check)
        {
            return new ScheduleDto();
        }
        var schedule = _context.Schedules.Single(p => p.ScheduleId == id);

        return new ScheduleDto
        {
            ScheduleId = schedule.ScheduleId,
            Intakes = schedule.Intakes,
            ScheduleDrugId = schedule.ScheduleDrugId,
            SchedulePatientId = schedule.SchedulePatientId,
            ScheduleTime = schedule.ScheduleTime
        };
    }


    internal ActionResult<List<ScheduleDto>> GetScheduleFromPatient(int id)
    {
        List<ScheduleDto> scheduleDtos = new List<ScheduleDto>();
        var check = _context.Schedules.Any(p => p.SchedulePatientId == id);
        if (!check)
        {
            return new List<ScheduleDto>();
        }
        var schedule = _context.Schedules.Where(p => p.SchedulePatientId == id);

        foreach (var item in schedule)
        {

            scheduleDtos.Add(new ScheduleDto
            {
                ScheduleId = item.ScheduleId,
                Intakes = item.Intakes,
                ScheduleDrugId = item.ScheduleDrugId,
                SchedulePatientId = item.SchedulePatientId,
                ScheduleTime = item.ScheduleTime
            });
        }
        return scheduleDtos;
    }

    internal bool CheckPatient(int schedulePatientId, int scheduleDrugId)
    {
        if (_context.Patients.Any(p => p.PatientId == schedulePatientId) &&
         _context.Drugs.Any(d => d.DrugId == scheduleDrugId))
        {
            return true;
        }
        return false;
    }

    internal void DeleteSchedule(int id)
    {
        var schedule = _context.Schedules.Single(s => s.ScheduleId == id);
        _context.Schedules.Remove(schedule);
        _context.SaveChanges();
    }

    internal bool CheckSchedule(int id)
    {
        var schedule = _context.Schedules.Any(s => s.ScheduleId ==id);
        return schedule;

    }
}