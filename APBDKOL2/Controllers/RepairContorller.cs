using APBDKOL2.DTO;
using APBDKOL2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDKOL2.Controllers;

[ApiController]
[Route("[controller]")]
public class RepairContorller : ControllerBase
{
    private readonly IRepairDbService _repairDbService;

    public RepairContorller(IRepairDbService repairDbService)
    {
        _repairDbService = repairDbService;
    }

    [HttpGet("/mechanic/{id}")]
    public async Task<IActionResult> GetMechanic(int id)
    {
        var res = await _repairDbService.GetMechanicAsync(id);
        if(res == null)
        {
            return BadRequest("Error: Nie ma takiego mechanika w bazie");
        }
        return Ok(res);
    }


    [HttpPost("/cars")]
    public async Task<IActionResult> AddCar(CarInsertDTO carInsertDto)
    {
        var res = await _repairDbService.AddCarAsync(carInsertDto);
        if (res != "Ok")
        {
            return BadRequest(res);
        }
        return Ok();
    }

}