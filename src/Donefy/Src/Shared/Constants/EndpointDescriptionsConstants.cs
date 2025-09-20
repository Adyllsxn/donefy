namespace Donefy.Src.Shared.Constants;
public class EndpointDescriptionsConstants
{
    public static class Category
    {
        public const string GetById = "Get a category by its unique identifier";
        public const string GetAll = "Get all categories with pagination support";
        public const string Create = "Create a new category";
        public const string Update = "Update an existing category";
        public const string Delete = "Delete a category by ID";
    }

    public static class User
    {
        public const string Login = "Authenticate user and return JWT token";
        public const string Logout = "Invalidate user session";
        public const string ChangePassword = "Change user password";
        public const string RecoverPassword = "Recover user password via email";
        public const string Delete = "Delete user account";
        public const string GetAll = "Get all users with pagination";
        public const string GetById = "Get user by ID";
        public const string GetCurrentUser = "Get currently authenticated user data";
        public const string GetByName = "Search users by name";
        public const string CheckAuth = "Validate JWT token and check authentication status";
    }
    public static class Dashboards
    {
        public const string GetAdminDashboardData =
            "Retorna dados agregados e métricas gerais do sistema para o painel administrativo. " +
            "Inclui totais de imóveis, candidaturas e outras estatísticas relevantes.";
    }
}
