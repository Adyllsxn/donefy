namespace Donefy.Src.Core.Application.Interfaces.Facades;
public interface ICategoryFacade : ICategoryCommandFacade, ICategoryQueryFacade { }
public interface ICategoryCommandFacade
{
    Task<CommandResult<bool>> Create(CreateCategoryCommand command, CancellationToken token);
    Task<CommandResult<bool>> Update(UpdateCategoryCommand command, CancellationToken token);
    Task<CommandResult<bool>> Delete(DeleteCategoryCommand command, CancellationToken token);
}

public interface ICategoryQueryFacade
{
    Task<PagedList<List<GetAllCategoriesResponse>>> GetAll(GetAllCategoriesQuery query, CancellationToken token);
    Task<QueryResult<GetCategoryByIdResponse>> GetById(GetCategoryByIdQuery query, CancellationToken token);
}