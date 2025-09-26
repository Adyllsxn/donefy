namespace Donefy.Src.Presentation.Controllers.Identity;
[ApiController]
[Route(EndpointRouteConstants.Route)]
public class AuthController : ControllerBase
{
    #region Login
    [HttpPost]
    [Route(EndpointNamesConstants.Identity.Auth.Login)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.Auth.Login)]
    public IActionResult Login()
    {   
        return Ok();
    }
    #endregion

    #region Logout
    [HttpPost]
    [Route(EndpointNamesConstants.Identity.Auth.Logout)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.Auth.Logout)]
    public IActionResult Logout()
    {   
        return Ok();
    }
    #endregion

    #region Register
    [HttpPost]
    [Route(EndpointNamesConstants.Identity.Auth.Register)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.Auth.Register)]
    public IActionResult Register()
    {   
        return Ok();
    }
    #endregion

    #region RefreshToken
    [HttpPost]
    [Route(EndpointNamesConstants.Identity.Auth.RefreshToken)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.Auth.RefreshToken)]
    public IActionResult RefreshToken()
    {   
        return Ok();
    }
    #endregion

    #region CheckAuth
    [HttpGet]
    [Route(EndpointNamesConstants.Identity.Auth.CheckAuth)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.Auth.CheckAuth)]
    public IActionResult CheckAuth()
    {   
        return Ok();
    }
    #endregion
}
