using InciCreator.Exceptions;
using InciCreator.Models.DataTransferObjects;
using InciCreator.Services;
using Microsoft.AspNetCore.Mvc;

namespace InciCreator.Controllers;

[ApiController]
[Route("api")]
public class ApplicationController(IApplicationService applicationService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] CreationRequest creationRequest)
    {
        try
        {
            await applicationService.CreateRecords(creationRequest);

            return this.Ok();
        }
        catch (AccountNotFoundException e)
        {
            return this.NotFound(e.Message);
        }
        catch (Exception)
        {
            return this.StatusCode(500, "Unexpected error occured.");
        }
    }
}
