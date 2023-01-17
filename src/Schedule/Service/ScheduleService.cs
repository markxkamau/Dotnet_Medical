using MedicalTrack.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Schedule.Service;

using MedicalTrack.src.Schedule.Dtos;
using MedicalTrack.src.Drug.Model;
using MedicalTrack.src.Schedule.Model;
using MedicalTrack.src.Drug.Dto;
using MedicalTrack.src.Patient.Dtos;
using System;

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

    internal ScheduleDto CreateNewSchedule(CreateScheduleDto createScheduleDto)
    {
        var patient = _context.Patients.Single(p => p.PatientId == createScheduleDto.SchedulePatientId);
        var drug = _context.Drugs.Single(p => p.DrugId == createScheduleDto.ScheduleDrugId);
        var scheduleDto = new ScheduleDto
        {
            ScheduleId = new int(),
            ScheduleConfirm = createScheduleDto.ScheduleConfirm,
            ScheduleDay = createScheduleDto.ScheduleDay,
            ScheduleDrug = new DrugDto{
                DrugId = drug.DrugId,
                DrugCount = drug.DrugCount,
                DrugInfo = drug.DrugInfo,
                DrugPurpose =drug.DrugPurpose
            },
            ScheduleDrugId = createScheduleDto.ScheduleDrugId,
            ScheduleTime = createScheduleDto.ScheduleTime,
            SchedulePatientId = createScheduleDto.SchedulePatientId,
            SchedulePatient = new PatientDto
            {
                PatientAge = patient.PatientAge,
                PatientId = patient.PatientId,
                PatientCondition = patient.PatientCondition,
                PatientEmail = patient.PatientEmail,
                PatientName = patient.PatientName
            }
        };

        var schedule = new Schedule{
            ScheduleId = scheduleDto.ScheduleId,
            ScheduleConfirm = scheduleDto.ScheduleConfirm,
            ScheduleDay = scheduleDto.ScheduleDay,
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
        var schedules = _context.Schedules.ToList();
        foreach (var schedule in schedules)
        {
            var scheduleDto = new ScheduleDto
            {
                ScheduleId = schedule.ScheduleId,
                ScheduleTime = schedule.ScheduleTime,
                ScheduleConfirm = schedule.ScheduleConfirm,
                SchedulePatientId = schedule.SchedulePatientId,
                ScheduleDrugId = schedule.ScheduleDrugId,
                ScheduleDay = schedule.ScheduleDay,
                ScheduleDrug = new DrugDto
                {
                    DrugId = schedule.ScheduleDrug.DrugId,
                    DrugCount = schedule.ScheduleDrug.DrugCount,
                    DrugInfo = schedule.ScheduleDrug.DrugInfo,
                    DrugPurpose = schedule.ScheduleDrug.DrugPurpose
                },
                SchedulePatient = new PatientDto
                {
                    PatientId = schedule.SchedulePatient.PatientId,
                    PatientAge = schedule.SchedulePatient.PatientAge,
                    PatientCondition = schedule.SchedulePatient.PatientCondition,
                    PatientEmail = schedule.SchedulePatient.PatientEmail,
                    PatientName = schedule.SchedulePatient.PatientName
                }

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
            ScheduleConfirm = schedule.ScheduleConfirm,
            ScheduleDay = schedule.ScheduleDay,
            ScheduleDrugId = schedule.ScheduleDrugId,
            SchedulePatientId = schedule.SchedulePatientId,
            ScheduleTime = schedule.ScheduleTime
        };
    }


    internal ActionResult<ScheduleDto> GetScheduleFromPatient(int id)
    {
        var check = _context.Schedules.Any(p => p.SchedulePatientId == id);
        if (!check)
        {
            return new ScheduleDto();
        }
        var schedule = _context.Schedules.Single(p => p.SchedulePatientId == id);

        return new ScheduleDto
        {
            ScheduleId = schedule.ScheduleId,
            ScheduleConfirm = schedule.ScheduleConfirm,
            ScheduleDay = schedule.ScheduleDay,
            ScheduleDrugId = schedule.ScheduleDrugId,
            SchedulePatientId = schedule.SchedulePatientId,
            ScheduleTime = schedule.ScheduleTime
        };
    }
}