using MedicalTrack.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Test.Service;

using System;
using MedicalTrack.src.Test.Dtos;
using MedicalTrack.src.Test.Model;

public class TestService
{
    private readonly MedicalContext _context;

    public TestService(MedicalContext context)
    {
        _context = context;
    }

    internal TestDto AddNewTest(CreateTestDto createTestDto)
    {
        var testDto = new TestDto
        {
            TestId = new int(),
            TestDate = DateTime.UtcNow,
            TestPatientId = createTestDto.TestPatientId,
            TestResultBp = createTestDto.TestResultBp,
            TestResultOxygen = createTestDto.TestResultOxygen,
            TestResultSugars = createTestDto.TestResultSugars,
            TestResultWeight = createTestDto.TestResultWeight
        };
        var test = new Test
        {
            TestId = testDto.TestId,
            TestDate = testDto.TestDate,
            TestPatientId = testDto.TestPatientId,
            TestResultBp = testDto.TestResultBp,
            TestResultOxygen = testDto.TestResultOxygen,
            TestResultSugars = testDto.TestResultSugars,
            TestResultWeight = testDto.TestResultWeight
        };
        _context.Tests.Add(test);
        _context.SaveChanges();

        return testDto;
    }

    internal ActionResult<List<TestDto>> GetAllTests()
    {
        var tests = _context.Tests.ToList();
        var testDtos = new List<TestDto>();
        foreach (var item in tests)
        {
            var testDto = new TestDto
            {
                TestId = item.TestId,
                TestPatientId = item.TestPatientId,
                TestResultBp = item.TestResultBp,
                TestResultOxygen = item.TestResultOxygen,
                TestResultSugars = item.TestResultSugars,
                TestResultWeight = item.TestResultWeight
            };
            testDtos.Add(testDto);
        }
        return testDtos;
    }

    internal ActionResult<TestDto> GetTestById(int id)
    {
        var test = _context.Tests.Single(t => t.TestId == id);
        var testDto = new TestDto
        {
            TestId = test.TestId,
            TestPatientId = test.TestPatientId,
            TestResultBp = test.TestResultBp,
            TestResultOxygen = test.TestResultOxygen,
            TestResultSugars = test.TestResultSugars,
            TestResultWeight = test.TestResultWeight
        };
        return testDto;
    }
}
