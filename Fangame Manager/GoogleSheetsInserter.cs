using Google.Apis.Auth.OAuth2;
using Google.Apis.Script.v1;
using Google.Apis.Script.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Fangame_Manager
{
    class GoogleSheetsInserter
    {
        static string[] Scopes = { "https://www.googleapis.com/auth/drive", "https://www.googleapis.com/auth/spreadsheets", "https://www.googleapis.com/auth/userinfo.email" };
        static string ApplicationName = "Fangame Manager";

        public static bool run(
          string scTime,
          int scDeaths,
          int scRating,
          string scGamename,
          string scSheetName,
          int scRowToStart,
          int scColumnToStart,
          string scDateCompleted)
        {
            UserCredential credential;


            string credPath = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);
            credPath = Path.Combine(credPath, ".credentials" + Path.DirectorySeparatorChar + "FangameManager Google Credentials");

            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = "google_dev_account_id", // From your own account
                    ClientSecret = "google_dev_account_secret" // From your own account
                },
                Scopes,
                Environment.UserName,
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
            
            var service = new ScriptService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Create an execution request object.
            ExecutionRequest request = new ExecutionRequest();
            request.Function = "insertData";

            List<object> reqParams = new List<object>();
            string time = scTime;
            int deaths = scDeaths;
            int rating = scRating;
            string gamename = scGamename;
            string sheetName = scSheetName;
            int rowToStart = scRowToStart;
            int columnToStart = scColumnToStart;
            string dateCompleted = scDateCompleted;

            /*
             * Google script variables. ^*_? is a separating character
            var gamename = res[0];
            var spreadsheetName = res[1];
            var rowToStart = res[2];
            var columnToStart = res[3];
            var date = res[4];
            var rating = res[5];
            var time = res[6];
            var deaths = res[7];
            */

            reqParams.Add($"{gamename}^*_?{sheetName}^*_?{rowToStart}^*_?{columnToStart}^*_?{dateCompleted}^*_?{rating}^*_?{time}^*_?{deaths}");
            request.Parameters = reqParams;

            ScriptsResource.RunRequest runReq =
                    service.Scripts.Run(request, "Google_script_id"); // From your own account

            try
            {
                // Make the API request.
                Operation op = runReq.Execute();

                if (op.Error != null)
                {
                    // The API executed, but the script returned an error.

                    // Extract the first (and only) set of error details
                    // as a IDictionary. The values of this dictionary are
                    // the script's 'errorMessage' and 'errorType', and an
                    // array of stack trace elements. Casting the array as
                    // a JSON JArray allows the trace elements to be accessed
                    // directly.
                    IDictionary<string, object> error = op.Error.Details[0];
                    Console.WriteLine(
                            "Script error message: {0}", error["errorMessage"]);
                    if (error["scriptStackTraceElements"] != null)
                    {
                        // There may not be a stacktrace if the script didn't
                        // start executing.
                        Console.WriteLine("Script error stacktrace:");
                        Newtonsoft.Json.Linq.JArray st =
                            (Newtonsoft.Json.Linq.JArray)error["scriptStackTraceElements"];
                        foreach (var trace in st)
                        {
                            Console.WriteLine(
                                    "\t{0}: {1}",
                                    trace["function"],
                                    trace["lineNumber"]);
                        }
                    }
                    return false;
                }
                else
                {
                    // The result provided by the API needs to be cast into
                    // the correct type, based upon what types the Apps
                    // Script function returns. Here, the function returns
                    // an Apps Script Object with String keys and values.
                    // It is most convenient to cast the return value as a JSON
                    // JObject (folderSet).

                    bool success =
                            (bool)op.Response["result"];
                    if (success)
                    {
                        Console.WriteLine("Insert succesfull");
                    }
                    else
                    {
                        Console.WriteLine("Insert not succesfull");
                    }
                    return success;
                }
            }
            catch (Google.GoogleApiException e)
            {
                // The API encountered a problem before the script
                // started executing.
                Console.WriteLine("Error calling API:\n{0}", e);
                return false;
            }
        }
    }
}
