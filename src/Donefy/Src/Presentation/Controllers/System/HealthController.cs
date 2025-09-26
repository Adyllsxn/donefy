namespace Donefy.Src.Presentation.Controllers.System;
[ApiController]
[Route(EndpointRouteConstants.Route)]
public class HealthController : ControllerBase
{
    #region Health
    [HttpGet]
    [Route(EndpointNamesConstants.System.Health)]
    [EndpointSummary(EndpointDescriptionsConstants.System.Health)]
    public IActionResult Health()
    {   
        return Ok();
    }
    #endregion

    #region Database
    [HttpGet]
    [Route(EndpointNamesConstants.System.Database)]
    [EndpointSummary(EndpointDescriptionsConstants.System.Database)]
    public IActionResult Database()
    {   
        return Ok();
    }
    #endregion

    #region System
    [HttpGet]
    [Route(EndpointNamesConstants.System.SystemInformation)]
    [EndpointSummary(EndpointDescriptionsConstants.System.SystemInformation)]
    public IActionResult SystemInformation()
    {   
        return Ok();
    }
    #endregion

}
