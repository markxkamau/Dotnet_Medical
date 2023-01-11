
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Test.Controller;
using MedicalTrack.src.Test.Model;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly TestController _service;

    public TestController(TestController service)
    {
        _service = service;
    }
    [HttpGet("tests")]
    public ActionResult<List<Test>> GetAllTests()
    {
        return _service.GetAllTests();
    }

}