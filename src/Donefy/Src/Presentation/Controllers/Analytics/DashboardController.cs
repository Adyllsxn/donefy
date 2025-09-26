namespace Donefy.Src.Presentation.Controllers.Analytics;
[ApiController]
[Route(EndpointRouteConstants.Route)]
public class DashboardController : ControllerBase
{
    #region GetAll
    [HttpGet]
    [Route(EndpointNamesConstants.Analytics.Dashboard)]
    [EndpointSummary(EndpointDescriptionsConstants.Analytics.Dashboard)]
    public IActionResult Dashboard()
    {   
        return Ok();
    }
    #endregion

}
