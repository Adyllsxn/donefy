namespace Donefy.Src.Shared.Constants;
public class EndpointDescriptionsConstants
{
    public static class Business
    {
        public static class Category
        {
            public const string GetById = "Get a category by its unique identifier";
            public const string GetAll = "Get all categories with pagination support";
            public const string Create = "Create a new category";
            public const string Update = "Update an existing category";
            public const string Delete = "Delete a category by ID";
        }

        public static class Task
        {
            public const string GetById = "Get a task by its unique identifier";
            public const string GetAll = "Get all tasks with pagination and filtering support";
            public const string Create = "Create a new task";
            public const string Update = "Update an existing task";
            public const string UpdateStatus = "Update task status by ID";
            public const string Delete = "Delete a task by ID";
        }
    }

    public static class Identity
    {
        public static class User
        {
            public const string Delete = "Delete user account permanently";
            public const string Update = "Update user account information";
            public const string GetAll = "Get all users with pagination and search";
            public const string GetById = "Get user by ID";
            public const string GetCurrentUser = "Get currently authenticated user data";
            public const string GetByName = "Search users by name or username";
        }

        public static class Auth
        {
            public const string Login = "Authenticate user and return JWT tokens";
            public const string Logout = "Invalidate user session and logout";
            public const string CheckAuth = "Check current authentication status and token validity";
            public const string RefreshToken = "Refresh expired JWT token using refresh token";
            public const string Register = "Create a new user account";
        }

        public static class Password
        {
            public const string Change = "Change current user's password";
            public const string Reset = "Reset user password using reset token";
            public const string Forgot = "Request password reset email with recovery link";
        }

    }

    public static class System
    {
        public const string Health = "Check application health status and availability";
        public const string Database = "Check database connection status and health";
        public const string SystemInformation = "Get system information, metrics and environment details";
    }

    public static class Analytics
    {
        public const string Dashboard = "Returns aggregated data and system metrics for the admin dashboard";
    }
}