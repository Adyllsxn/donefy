namespace Donefy.Src.Presentation.Controllers.Business;
[ApiController]
[Route(EndpointRouteConstants.Route)]
public class TasksController : ControllerBase
{
    #region Dependencies and Constructor
    private readonly ITaskFacade _facade;
    public TasksController(ITaskFacade facade)
    {
        _facade = facade;
    }
    #endregion

    #region API Endpoints
    
    #region GetAll
    [HttpGet]
    [Route(EndpointNamesConstants.Common.GetAll)]
    [EndpointSummary(EndpointDescriptionsConstants.Business.Task.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllTasksDTO dto, CancellationToken token)
    {
        var result = await _facade.GetAll(dto, token);
        var response = new
        {
            Code = (int)result.Code,
            Message = result.Message,
            Data = result.Data
        };
        if (result.IsSuccess)
            return Ok(response);
        return StatusCode((int)result.Code, response);
    }
    #endregion

    #endregion

}
