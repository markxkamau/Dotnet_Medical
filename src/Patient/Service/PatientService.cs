using MedicalTrack.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Patient.Service;

using System;
using MedicalTrack.src.Patient.Dtos;
using MedicalTrack.src.Patient.Model;

public class PatientService
{
    private readonly MedicalContext _context;

    public PatientService(MedicalContext context)
    {
        _context = context;
    }

    public ActionResult<List<Patient>> GetAllPatients()
    {
        return _context.Patients.ToList();
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

    internal Patient? GetPatientById(int id)
    {
        var patient = _context.Patients.SingleOrDefault(p => p.PatientId == id);
        return patient;
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
}