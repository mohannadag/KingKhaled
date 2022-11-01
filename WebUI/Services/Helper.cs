using Newtonsoft.Json;
using System.Net;
using WebUI.Models;

namespace WebUI.Services
{
    public class Helper : IHelper
    {
        public Dictionary<string, string> HandleErrors(HttpResponseMessage response)
        {
            Dictionary<string, string> errorsMap = new Dictionary<string, string>();
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ErrorResponse errors = JsonConvert.DeserializeObject<ErrorResponse>(response.Content.ReadAsStringAsync().Result);
                string error = "";
                if (errors.Errors == null || errors.Errors.Count == 0)
                {
                    if (string.IsNullOrEmpty(errors.Message))
                        error = response.Content.ReadAsStringAsync().Result;
                    else
                        error = errors.Message;
                }
                else
                {
                    foreach (var item in errors.Errors)
                    {
                        error += item + "\n";
                    }
                }

                errorsMap.Add("error", error);
                return errorsMap;

            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                errorsMap.Add("view", "NotFound");
                return errorsMap;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                errorsMap.Add("view", "NotAuthorized");
                return errorsMap;
            }
            else
            {
                errorsMap.Add("view", "Error");
                return errorsMap;
            }
        }
    }
}
