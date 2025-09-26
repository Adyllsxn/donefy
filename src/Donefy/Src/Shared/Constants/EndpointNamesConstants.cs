namespace Donefy.Src.Shared.Constants;
public class EndpointNamesConstants
{
    public static class Common
    {
        public const string GetById = "GetById";
        public const string GetAll = "GetAll";
        public const string Create = "Create";
        public const string Update = "Update";
        public const string Delete = "Delete";
        public const string GetCurrentUser = "GetCurrentUser";

    }
    public static class System
    {
        public const string Health = "Health";
        public const string Database = "GetAll";
        public const string SystemInformation = "Create";

    }
    public static class Analytics
    {
        public const string Dashboard = "Dashboard";

    }
    public static class Identity
    {
        public static class Auth
        {
            public const string Login = "Login";
            public const string Logout = "Logout";    
            public const string Register = "Register";
            public const string CheckAuth = "CheckAuth";
            public const string RefreshToken = "Refresh-Token";
        }
        public static class Password
        {
            public const string Forgot = "Forgot";     
            public const string Reset = "Reset";
            public const string Change = "Change";
        }
    }
}
