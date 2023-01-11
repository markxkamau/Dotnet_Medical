
using MedicalTrack.src.Drug.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Drug.Controller;

using MedicalTrack.src.Drug.Model;


[ApiController]
[Route("[controller]")]
public class DrugController : ControllerBase
{
    private readonly DrugService _service;

    public DrugController(DrugService service)
    {
        _service = service;
    }

   
    [HttpGet("drugs")]
    public ActionResult<List<Drug>> GetAllDrugs()
    {
        return _service.GetAllDrugs();
    }

}