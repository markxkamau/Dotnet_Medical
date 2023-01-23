
using MedicalTrack.src.Drug.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTrack.src.Drug.Controller;

using MedicalTrack.src.Drug.Dto;
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
    public ActionResult<List<DrugDto>> GetAllDrugs()
    {
        return Ok(_service.GetAllDrugs());
    }

    [HttpGet("drug/{id}")]
    public ActionResult<DrugDto> GetDrugById(int id)
    {
         bool exist = _service.CheckIfExists(id);
        if (!exist)
        {
            return BadRequest("Drug Id not found");
        }
        return Ok(_service.GetDrugById(id));
    }

    [HttpPost("new_drug")]
    public ActionResult<DrugDto> CreateNewDrug(CreateDrugDto createDrugDto)
    {
        // Check if Drug already exists
        bool exist = _service.CheckIfExists(createDrugDto);
        if (!exist)
        {
            return BadRequest("Drug stated already exists");
        }
        // Push data to the database
        var drugDto = _service.AddDrug(createDrugDto);
        // Display the data
        return Ok(drugDto);

    }



}