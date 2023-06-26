namespace Blog
{
    public static class Configuration
    {
        // Token - Jwt
        public static string JwtKey { get; set; } = "721979D0-C507-45E1-A145-3285247E3FBD";
        public static string ApiKeyName = "api_key";
        public static string ApiKey = "curso_api_IlTevUM/z0ey3NwCV/unWg==";
        public static SmtpConfiguration Smtp = new();

        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public int Port { get; set; } = 25;
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }

}
