namespace Donefy.Src.Presentation.Controllers.Identity;
[ApiController]
[Route(EndpointRouteConstants.Route)]
public class PasswordController : ControllerBase
{
    #region Forgot
    [HttpPost]
    [Route(EndpointNamesConstants.Identity.Password.Forgot)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.Password.Forgot)]
    public IActionResult Forgot()
    {   
        return Ok();
    }
    #endregion

    #region Reset
    [HttpPost]
    [Route(EndpointNamesConstants.Identity.Password.Reset)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.Password.Reset)]
    public IActionResult Reset()
    {   
        return Ok();
    }
    #endregion

    #region Change
    [HttpPost]
    [Route(EndpointNamesConstants.Identity.Password.Change)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.Password.Change)]
    public IActionResult Change()
    {   
        return Ok();
    }
    #endregion
}
