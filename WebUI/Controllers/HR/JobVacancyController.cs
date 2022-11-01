using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models.HR.Branches;
using WebUI.Models.HR.Departments;
using WebUI.Models.HR.Jobs;
using WebUI.Models.HR.JobVacancies;
using WebUI.Services;

namespace WebUI.Controllers.HR
{
    public class JobVacancyController : Controller
    {
        private readonly ILogger<JobVacancyController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        private readonly string _apiUrl = "";

        public JobVacancyController(ILogger<JobVacancyController> logger, IConfiguration configuration, IHelper helper)
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
                List<JobVacancy> jobVacancy = new();

                var endpoint = _apiUrl + "API/jobVacancy/getall";
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    jobVacancy = JsonConvert.DeserializeObject<List<JobVacancy>>(response.Content.ReadAsStringAsync().Result);
                    return View(jobVacancy);
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

        public async Task<IActionResult> GetVacancyByBranch(int branchId)
        {
            try
            {
                List<JobVacancy> jobVacancies = new();
                HttpClient client = new HttpClient();

                var endpoint = _apiUrl + "API/JobVacancy/GetAllBy-BranchId/" + branchId;
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    jobVacancies = JsonConvert.DeserializeObject<List<JobVacancy>>(response.Content.ReadAsStringAsync().Result);
                    foreach (var item in jobVacancies)
                    {
                        item.JobName = item.VacantNumber + " / " + item.JobName + " / " + item.JobLevelName;
                    }
                    return Json(new SelectList(jobVacancies, "Id", "JobName"));
                }
                else
                {
                    return Json("");
                }
            }
            catch (Exception ex) { _logger.LogError($"Exception occured: {ex}"); return View("Error"); }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                List<Department> departments = new();
                List<Branch> branches = new();
                List<Job> jobs = new();

                HttpClient client = new HttpClient();
                var endpoint = _apiUrl + "API/department/getall";
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    departments = JsonConvert.DeserializeObject<List<Department>>(response.Content.ReadAsStringAsync().Result);
                    var branchesendpoint = _apiUrl + "API/branch/getall";
                    HttpResponseMessage branchesresponse = await client.GetAsync(branchesendpoint);
                    var jobsendpoint = _apiUrl + "API/job/getall";
                    HttpResponseMessage jobsresponse = await client.GetAsync(jobsendpoint);

                    branches = JsonConvert.DeserializeObject<List<Branch>>(branchesresponse.Content.ReadAsStringAsync().Result);
                    jobs = JsonConvert.DeserializeObject<List<Job>>(jobsresponse.Content.ReadAsStringAsync().Result);
                    JobVacancy model = new JobVacancy
                    {
                        DepartmentsList = new SelectList(departments, "Id", "ArabicName"),
                        BranchList = new SelectList(branches, "Id", "ArabicName"),
                        JobList = new SelectList(jobs, "Id", "ArabicName")
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
        public async Task<IActionResult> Create(JobVacancy model)
        {
            try
            {
                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/jobVacancy";
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
                JobVacancy jobVacancy = new();
                List<Department> departments = new();
                List<Branch> branches = new();
                List<Job> jobs = new();
                HttpClient client = new HttpClient();

                var endpoint = _apiUrl + "API/jobVacancy/getbyid/" + id;
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    jobVacancy = JsonConvert.DeserializeObject<JobVacancy>(response.Content.ReadAsStringAsync().Result);
                    var departmentsendpoint = _apiUrl + "API/department/getall";
                    HttpResponseMessage departmentsresponse = await client.GetAsync(departmentsendpoint);
                    var branchesendpoint = _apiUrl + "API/branch/getall";
                    HttpResponseMessage branchesresponse = await client.GetAsync(branchesendpoint);
                    var jobsendpoint = _apiUrl + "API/job/getall";
                    HttpResponseMessage jobsresponse = await client.GetAsync(jobsendpoint);

                    departments = JsonConvert.DeserializeObject<List<Department>>(departmentsresponse.Content.ReadAsStringAsync().Result);
                    branches = JsonConvert.DeserializeObject<List<Branch>>(branchesresponse.Content.ReadAsStringAsync().Result);
                    jobs = JsonConvert.DeserializeObject<List<Job>>(jobsresponse.Content.ReadAsStringAsync().Result);

                    jobVacancy.DepartmentsList = new SelectList(departments, "Id", "ArabicName");
                    jobVacancy.BranchList = new SelectList(branches, "Id", "ArabicName");
                    jobVacancy.JobList = new SelectList(jobs, "Id", "ArabicName");

                    return View(jobVacancy);
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
        public async Task<IActionResult> Edit(JobVacancy model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/jobVacancy/" + model.Id;
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
