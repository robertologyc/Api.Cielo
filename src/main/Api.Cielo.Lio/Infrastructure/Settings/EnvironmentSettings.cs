namespace Api.Cielo.Lio.Infrastructure.Settings
{
    public class EnvironmentSettings
    {
        public class Production
        {
            public static string RequestUrl = "https://api.cieloecommerce.cielo.com.br/";
            public static string QueryUrl = "https://apiquery.cieloecommerce.cielo.com.br/";
        }

        public class Sandbox
        {
            public static string RequestUrl = "https://apisandbox.cieloecommerce.cielo.com.br";
            public static string QueryUrl = "https://apiquerysandbox.cieloecommerce.cielo.com.br";
        }
    }
}
