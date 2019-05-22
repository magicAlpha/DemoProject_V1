    namespace NUnitFramework.Utils
{
    public static class Const
    {
        // Config Files 
        public const string ConfigFileName = "appsettings.json";

        public const string TestDataFileName = "sharedsettings.json";

        public const string LogFileName = "log4net.config";

        public const string Headless = "headless";

        public const string FireFoxHeadless = "-headless";

        public const string LinuxHeadless = "--headless";

        public const string ScreenshotUnderScore = "_";

        public const string ScreenshotImageFormat = ".png";

        public const string Backslash = "/";

        //Web drivers path

        //Linux
        public const string ChromeLinuxPath = @"Drivers\Linux\Chrome\";
        public const string FirefoxLinuxPath = @"Drivers\Linux\Firefox\";
        public const string IELinuxPath = @"Drivers\Linux\IE\";

        //Windows
        public const string ChromeWindowPath = @"Drivers\Windows\Chrome\";
        public const string FirefoxWindowPath = @"Drivers\Windows\Firefox\";
        public const string IEWindowPath = @"Drivers\Windows\IE\";

        // APIs related 
        public const int HTTP_RESPONSE_CODE_200 = 200; // OK --> The request was successfully completed.  
        public const int HTTP_RESPONSE_CODE_201 = 201; // Created --> A new resource was successfully created.
        public const int HTTP_RESPONSE_CODE_400 = 400; //Bad Request --> The request was invalid.
        public const int HTTP_RESPONSE_CODE_202 = 202; //Accepted --> The request has been accepted for processing, but the processing has not been completed.
        public const int HTTP_RESPONSE_CODE_204 = 204; // No Content --> The server has fulfilled the request but does not need to return an entity-body, and might want to return updated metainformation. 
        public const int HTTP_RESPONSE_CODE_203 = 203; // Non-Authoritative Information --> 
        public const int HTTP_RESPONSE_CODE_401 = 401; // Unauthorized --> The request requires user authentication

        public const string HTTP_RESPONSE_STATUS_OK = "OK";
        public const string HTTP_RESPONSE_STATUS_Created = "Created";
        public const string HTTP_RESPONSE_STATUS_Bad_Request = "Bad Request";
        public const string HeaderParameterAccept = "Accept";
        public const string HeaderParameterContentType = "application/json";
        public const string PutAPIResponse = "last night i dreamt of san pandro";

    }
}
