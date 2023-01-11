using MedicalTrack.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Test.Service;

using MedicalTrack.src.Test.Model;

public class TestService
{
    private readonly MedicalContext _context;

    public TestService(MedicalContext context)
    {
        _context = context;
    }

    internal ActionResult<List<Test>> GetAllTests()
    {
        return _context.Tests.ToList();
    }
}