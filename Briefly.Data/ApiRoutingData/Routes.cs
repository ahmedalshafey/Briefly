namespace SchoolProject.Data.ApiRoutingData
{
    public static class Routes
    {
        public static class AuthRouting
        {
            public const string Register = "Register";
            public const string Login = "Login";
            public const string ConfirmEmail = "ConfirmEmail";
            public const string SendResetPassword = "SendResetPassword";
            public const string ConfirmResetPassword = "ConfirmResetPassword";
            public const string ResetPassword = "ResetPassword"; 
            public const string GenerateRefreshToken = "GenerateRefreshToken"; 
            public const string CheckValidationToken = "CheckValidationToken";
            public const string LoginGoogle = "Login-Google";
        }
        public static class RssRouting
        {
            public const string GetAll = "GetAll";
            public const string GetById = "{id}";
            public const string Create = "Create";
            public const string RssUserSubscribe = "RssUserSubscribe/{rssId}";
            public const string RssUserUnSubscribe = "RssUserUnSubscribe/{rssId}";
            public const string SubscribedRss= "SubscribedRss/All";

        }
    }
}
