namespace Donefy.Src.Core.Application.UseCases.Tasks.Queries.GetAll;
public class GetAllTasksQuery : PagedRequest, IQuery<PagedList<List<GetAllTasksResponse>>>;