namespace Donefy.Src.Presentation.Controllers.Business;
[ApiController]
[Route(EndpointRouteConstants.Route)]
public class CategoriesController : ControllerBase
{
    #region Dependencies and Constructor
    private readonly ICategoryFacade _facade;
    public CategoriesController(ICategoryFacade facade)
    {
        _facade = facade;
    }
    #endregion

    #region API Endpoints
    
    #region GetAll
    [HttpGet]
    [Route(EndpointNamesConstants.Common.GetAll)]
    [EndpointSummary(EndpointDescriptionsConstants.Category.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesDTO dto, CancellationToken token)
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
