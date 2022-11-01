using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models.HR.Grades;
using WebUI.Models.HR.JobGroups;
using WebUI.Models.HR.JobLevels;
using WebUI.Models.HR.Jobs;
using WebUI.Models.HR.JobSubGroups;
using WebUI.Services;

namespace WebUI.Controllers.HR
{
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        private readonly string _apiUrl = "";

        public JobController(ILogger<JobController> logger, IConfiguration configuration, IHelper helper)
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
                List<Job> job = new();

                var endpoint = _apiUrl + "API/job/getall";
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    job = JsonConvert.DeserializeObject<List<Job>>(response.Content.ReadAsStringAsync().Result);
                    return View(job);
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
                List<JobSubGroup> jobSubGroups = new();
                List<Grade> grades = new();
                List<JobLevel> jobLevels = new();

                HttpClient client = new HttpClient();
                var endpoint = _apiUrl + "API/jobgroup/getall";
                HttpResponseMessage response = await client.GetAsync(endpoint);
                
                if (response.IsSuccessStatusCode)
                {
                    jobGroups = JsonConvert.DeserializeObject<List<JobGroup>>(response.Content.ReadAsStringAsync().Result);

                    var jobSubGroupsendpoint = _apiUrl + "API/jobsubgroup/getall";
                    var gradesendpoint = _apiUrl + "API/grade/getall";
                    var jobLevelendpoint = _apiUrl + "API/JobLevel/GetAll";
                    HttpResponseMessage jobSubGroupsresponse = await client.GetAsync(jobSubGroupsendpoint);
                    HttpResponseMessage gradesresponse = await client.GetAsync(gradesendpoint);
                    HttpResponseMessage jobLevelresponse = await client.GetAsync(jobLevelendpoint);
                    jobSubGroups = JsonConvert.DeserializeObject<List<JobSubGroup>>(jobSubGroupsresponse.Content.ReadAsStringAsync().Result);
                    grades = JsonConvert.DeserializeObject<List<Grade>>(gradesresponse.Content.ReadAsStringAsync().Result);
                    jobLevels = JsonConvert.DeserializeObject<List<JobLevel>>(jobLevelresponse.Content.ReadAsStringAsync().Result);
                    Job model = new Job
                    {
                        JobGroupList = new SelectList(jobGroups, "Id", "ArabicName"),
                        JobSubGroupList = new SelectList(jobSubGroups, "Id", "ArabicName"),
                        GradeList = new SelectList(grades, "Id", "Name"),
                        JobLevelList = new SelectList(jobLevels, "Id", "Name")
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
        public async Task<IActionResult> Create(Job model)
        {
            try
            {
                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/job";
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
                Job job = new();
                List<JobGroup> jobGroups = new();
                List<JobSubGroup> jobSubGroups = new();
                List<Grade> grades = new();
                List<JobLevel> jobLevels = new();

                HttpClient client = new HttpClient();

                var endpoint = _apiUrl + "API/job/getbyid/" + id;
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    var jobGroupsendpoint = _apiUrl + "API/jobgroup/getall";
                    var jobSubGroupsendpoint = _apiUrl + "API/jobsubgroup/getall";
                    var gradesendpoint = _apiUrl + "API/grade/getall";
                    var jobLevelendpoint = _apiUrl + "API/JobLevel/GetAll";
                    HttpResponseMessage jobSubGroupsresponse = await client.GetAsync(jobSubGroupsendpoint);
                    HttpResponseMessage gradesresponse = await client.GetAsync(gradesendpoint);
                    HttpResponseMessage jobGroupsresponse = await client.GetAsync(jobGroupsendpoint);
                    HttpResponseMessage jobLevelresponse = await client.GetAsync(jobLevelendpoint);
                    jobSubGroups = JsonConvert.DeserializeObject<List<JobSubGroup>>(jobSubGroupsresponse.Content.ReadAsStringAsync().Result);
                    grades = JsonConvert.DeserializeObject<List<Grade>>(gradesresponse.Content.ReadAsStringAsync().Result);
                    jobGroups = JsonConvert.DeserializeObject<List<JobGroup>>(jobGroupsresponse.Content.ReadAsStringAsync().Result);
                    jobLevels = JsonConvert.DeserializeObject<List<JobLevel>>(jobLevelresponse.Content.ReadAsStringAsync().Result);

                    job = JsonConvert.DeserializeObject<Job>(response.Content.ReadAsStringAsync().Result);
                    job.JobGroupList = new SelectList(jobGroups, "Id", "ArabicName");
                    job.JobSubGroupList = new SelectList(jobSubGroups, "Id", "ArabicName");
                    job.GradeList = new SelectList(grades, "Id", "Name");
                    job.JobLevelList = new SelectList(jobLevels, "Id", "Name");
                    return View(job);
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
        public async Task<IActionResult> Edit(Job model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/job/" + model.Id;
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
