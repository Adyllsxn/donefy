namespace Donefy.Src.Presentation.Controllers.Identity;
[ApiController]
[Route(EndpointRouteConstants.Route)]
public class UsersController : ControllerBase
{
    #region GetAll
    [HttpGet]
    [Route(EndpointNamesConstants.Common.GetAll)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.User.GetAll)]
    public IActionResult GetAll()
    {   
        return Ok();
    }
    #endregion

    #region GetById
    [HttpGet]
    [Route(EndpointNamesConstants.Common.GetById)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.User.GetById)]
    public IActionResult GetById()
    {   
        return Ok();
    }
    #endregion

    #region Update
    [HttpPut]
    [Route(EndpointNamesConstants.Common.Update)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.User.Update)]
    public IActionResult Update()
    {   
        return Ok();
    }
    #endregion

    #region Forgot
    [HttpDelete]
    [Route(EndpointNamesConstants.Common.Delete)]
    [EndpointSummary(EndpointDescriptionsConstants.Identity.User.Delete)]
    public IActionResult Delete()
    {   
        return Ok();
    }
    #endregion
}
