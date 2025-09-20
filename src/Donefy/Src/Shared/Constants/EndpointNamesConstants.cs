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

    }

    public static class Auth
    {
        public const string Login = "Login";
        public const string Logout = "Logout";    
        public const string Register = "Register";
        public const string CheckAuth = "CheckAuth";
        public const string GetCurrentUser = "GetCurrentUser";
    }

    public static class Password
    {
        public const string ChangePassword = "ChangePassword";     
        public const string RecoverPassword = "RecoverPassword";
    }
}
