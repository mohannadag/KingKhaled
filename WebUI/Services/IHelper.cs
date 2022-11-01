namespace WebUI.Services
{
    public interface IHelper
    {
        Dictionary<string, string> HandleErrors(HttpResponseMessage response);
    }
}