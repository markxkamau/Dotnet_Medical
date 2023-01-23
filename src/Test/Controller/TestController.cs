
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Test.Controller;

using MedicalTrack.src.Test.Dtos;
using MedicalTrack.src.Test.Model;
using MedicalTrack.src.Test.Service;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly TestService _service;

    public TestController(TestService service)
    {
        _service = service;
    }
    [HttpGet("tests")]
    public ActionResult<List<TestDto>> GetAllTests()
    {
        return _service.GetAllTests();
    }

    [HttpGet("test/{id}")]
    public ActionResult<TestDto> GetTestById(int id)
    {
        return _service.GetTestById(id);
    }

    [HttpPost("test")]
    public ActionResult<TestDto> AddNewTest(CreateTestDto createTestDto)
    {
        return Ok(_service.AddNewTest(createTestDto));

    }

}