using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models.HR.JobGroups;
using WebUI.Models.HR.JobSubGroups;
using WebUI.Services;

namespace WebUI.Controllers.HR
{
    public class JobSubGroupController : Controller
    {
        private readonly ILogger<JobSubGroupController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        private readonly string _apiUrl = "";

        public JobSubGroupController(ILogger<JobSubGroupController> logger, IConfiguration configuration, IHelper helper)
        {
            _logger = logger;
            _configuration = configuration;
            _helper = helper;
            _apiUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<JobSubGroup> jobSubGroup = new();

                var endpoint = _apiUrl + "API/jobSubGroup/getall";
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    jobSubGroup = JsonConvert.DeserializeObject<List<JobSubGroup>>(response.Content.ReadAsStringAsync().Result);
                    return View(jobSubGroup);
                }
                else
                {
                    var result = _helper.HandleErrors(response);
                    result.TryGetValue("error", out string error);
                    if (error != null)
                    {
                        ViewData["ErrorMessage"] = error;
                        return View("Error");
                    }
                    else
                    {
                        result.TryGetValue("view", out string view);
                        ViewData["ErrorMessage"] = "Server Error";
                        return View(view);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured: {ex}");
                return View("Error");
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                List<JobGroup> jobGroups = new();

                HttpClient client = new HttpClient();
                var endpoint = _apiUrl + "API/jobgroup/getall";
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    jobGroups = JsonConvert.DeserializeObject<List<JobGroup>>(response.Content.ReadAsStringAsync().Result);
                    JobSubGroup model = new JobSubGroup
                    {
                        JobGroupList = new SelectList(jobGroups, "Id", "ArabicName")
                    };
                    return View(model);
                }
                else
                {
                    var result = _helper.HandleErrors(response);
                    result.TryGetValue("error", out string error);
                    if (error != null)
                    {
                        ViewData["ErrorMessage"] = error;
                        return View("Error");
                    }
                    else
                    {
                        result.TryGetValue("view", out string view);
                        ViewData["ErrorMessage"] = "Server Error";
                        return View(view);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured: {ex}");
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobSubGroup model)
        {
            try
            {
                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/jobSubGroup";
                HttpResponseMessage response = await client.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var result = _helper.HandleErrors(response);
                    result.TryGetValue("error", out string error);
                    if (error != null)
                    {
                        ModelState.TryAddModelError("", error);
                        return View(model);
                    }
                    else
                    {
                        result.TryGetValue("view", out string view);
                        ViewData["ErrorMessage"] = "Server Error";
                        return View(view);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured: {ex}");
                return View("Error");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                JobSubGroup jobSubGroup = new();
                List<JobGroup> jobGroups = new();
                HttpClient client = new HttpClient();

                var endpoint = _apiUrl + "API/jobSubGroup/getbyid/" + id;
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    jobSubGroup = JsonConvert.DeserializeObject<JobSubGroup>(response.Content.ReadAsStringAsync().Result);

                    var jobGroupsendpoint = _apiUrl + "API/jobgroup/getall";
                    HttpResponseMessage jobGroupsresponse = await client.GetAsync(jobGroupsendpoint);
                    jobGroups = JsonConvert.DeserializeObject<List<JobGroup>>(jobGroupsresponse.Content.ReadAsStringAsync().Result);
                    jobSubGroup.JobGroupList = new SelectList(jobGroups, "Id", "ArabicName");

                    return View(jobSubGroup);
                }
                else
                {
                    var result = _helper.HandleErrors(response);
                    result.TryGetValue("error", out string error);
                    if (error != null)
                    {
                        ViewData["ErrorMessage"] = error;
                        return View("Error");
                    }
                    else
                    {
                        result.TryGetValue("view", out string view);
                        ViewData["ErrorMessage"] = "Server Error";
                        return View(view);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured: {ex}");
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobSubGroup model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/jobSubGroup/" + model.Id;
                HttpResponseMessage response = await client.PutAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var result = _helper.HandleErrors(response);
                    result.TryGetValue("error", out string error);
                    if (error != null)
                    {
                        ModelState.TryAddModelError("", error);
                        return View(model);
                    }
                    else
                    {
                        result.TryGetValue("view", out string view);
                        ViewData["ErrorMessage"] = "Server Error";
                        return View(view);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured: {ex}");
                return View("Error");
            }
        }
    }
}
