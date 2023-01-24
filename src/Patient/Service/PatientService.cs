using MedicalTrack.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Patient.Service;

using System;
using System.Net.Mail;
using MedicalTrack.src.Patient.Dtos;
using MedicalTrack.src.Patient.Model;

public class PatientService
{
    private readonly MedicalContext _context;

    public PatientService(MedicalContext context)
    {
        _context = context;
    }

    public ActionResult<List<PatientDto>> GetAllPatients()
    {
        var patients = _context.Patients.ToList();
        List<PatientDto> patientDtos = new List<PatientDto>();
        foreach (Patient p in patients)
        {
            var patientDto = new PatientDto
            {
                PatientId = p.PatientId,
                PatientAge = p.PatientAge,
                PatientCondition = p.PatientCondition,
                PatientEmail = p.PatientCondition,
                PatientName = p.PatientName
            };
            patientDtos.Add(patientDto);
        }
        return patientDtos;
    }

    internal bool CheckEmailValidity(string patientEmail)
    {
        var valid = true;

        try
        {
            var emailAddress = new MailAddress(patientEmail);
        }
        catch
        {
            valid = false;
        }
        return valid;
    }

    internal PatientDto CreatePatient(CreatePatientDto createPatientDto)
    {
        var name = new Dictionary<string, string>();
        name.Add("First Name", createPatientDto.FirstName);
        name.Add("Last Name", createPatientDto.LastName);

        // issue to convert tht timegap to years
        var years = DateTime.Compare(DateTime.Now, createPatientDto.DateOfBirth);

        var patientDto = new PatientDto
        {
            PatientId = new int(),
            PatientName = name,
            PatientAge = years,
            PatientCondition = createPatientDto.PatientCondition,
            PatientEmail = createPatientDto.PatientEmail
        };

        var patient = new Patient
        {
            PatientId = patientDto.PatientId,
            PatientAge = patientDto.PatientAge,
            PatientCondition = patientDto.PatientCondition,
            PatientEmail = patientDto.PatientEmail,
            PatientName = patientDto.PatientName
        };
        _context.Patients.Add(patient);
        _context.SaveChanges();

        return patientDto;
    }

    internal void DeletePatient(int id)
    {
        var patient = _context.Patients.Single(p => p.PatientId == id);
        _context.Patients.Remove(patient);
        _context.SaveChanges();
    }

    internal PatientDto GetPatientById(int id)
    {
        var patient = _context.Patients.Single(p => p.PatientId == id);
        return new PatientDto
        {
            PatientAge = patient.PatientAge,
            PatientCondition = patient.PatientCondition,
            PatientEmail = patient.PatientEmail,
            PatientId = patient.PatientId,
            PatientName = patient.PatientName
        };
    }

    internal bool SearchPatient(string patientEmail)
    {
        var patient = _context.Patients.SingleOrDefault(p => p.PatientEmail == patientEmail);
        if (patient is null)
        {
            return true;
        }
        return false;
    }

    internal bool SearchPatient(int id)
    {
        var patient = _context.Patients.Any(p => p.PatientId == id);
        if (patient)
        {
            return true;
        }
        return false;
    }
}