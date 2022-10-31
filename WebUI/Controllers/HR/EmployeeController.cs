using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebUI.Models.HR.Branches;
using WebUI.Models.HR.Employees;
using WebUI.Models.HR.Grades;
using WebUI.Models.HR.JobVacancies;
using WebUI.Models.HR.Levels;
using WebUI.Models.HR.Nationalities;
using WebUI.Models.HR.Qualifications;
using WebUI.Services;

namespace WebUI.Controllers.HR
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        private readonly string _apiUrl = "";

        public EmployeeController(ILogger<EmployeeController> logger, IConfiguration configuration, IHelper helper)
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
                List<Employee> employees = new();

                var endpoint = _apiUrl + "API/employee/getall";
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    employees = JsonConvert.DeserializeObject<List<Employee>>(response.Content.ReadAsStringAsync().Result);
                    return View(employees);
                    //return View("~/Views/HR/Employee/index.cshtml", employees);
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
                List<JobVacancy> jobVacancies = new();
                List<Branch> branches = new();
                List<Qualification> qualifications = new();
                List<Grade> grades = new();
                List<Level> levels = new();
                List<Nationality> nationalities = new();

                HttpClient client = new HttpClient();
                var jobVacanciesendpoint = _apiUrl + "API/JobVacancy/getall";
                HttpResponseMessage jobVacanciesresponse = await client.GetAsync(jobVacanciesendpoint);

                var branchesendpoint = _apiUrl + "API/Branch/getall";
                HttpResponseMessage branchesresponse = await client.GetAsync(jobVacanciesendpoint);

                var qualificationendpoint = _apiUrl + "API/Qualification/getall";
                HttpResponseMessage qualificationresponse = await client.GetAsync(qualificationendpoint);

                var gradesendpoint = _apiUrl + "API/Grade/getall";
                HttpResponseMessage gradesresponse = await client.GetAsync(gradesendpoint);

                var levelsendpoint = _apiUrl + "API/Level/getall";
                HttpResponseMessage levelsresponse = await client.GetAsync(levelsendpoint);

                var nationalitiesendpoint = _apiUrl + "API/Nationality/getall";
                HttpResponseMessage nationalitiesresponse = await client.GetAsync(nationalitiesendpoint);

                if (jobVacanciesresponse.IsSuccessStatusCode)
                {
                    jobVacancies = JsonConvert.DeserializeObject<List<JobVacancy>>(jobVacanciesresponse.Content.ReadAsStringAsync().Result);
                    branches = JsonConvert.DeserializeObject<List<Branch>>(branchesresponse.Content.ReadAsStringAsync().Result);
                    qualifications = JsonConvert.DeserializeObject<List<Qualification>>(qualificationresponse.Content.ReadAsStringAsync().Result);
                    grades = JsonConvert.DeserializeObject<List<Grade>>(gradesresponse.Content.ReadAsStringAsync().Result);
                    levels = JsonConvert.DeserializeObject<List<Level>>(levelsresponse.Content.ReadAsStringAsync().Result);
                    nationalities = JsonConvert.DeserializeObject<List<Nationality>>(nationalitiesresponse.Content.ReadAsStringAsync().Result);

                    Employee model = new Employee
                    {
                        JobVacancyList = new SelectList(jobVacancies, "Id", "VacantNumber"),
                        BranchList = new SelectList(branches, "Id", "ArabicName"),
                        QualificationList = new SelectList(qualifications, "Id", "Name"),
                        GradeList = new SelectList(grades, "Id", "Name"),
                        LevelList = new SelectList(levels, "Id", "Name"),
                        NationalityList = new SelectList(nationalities, "Id", "ArabicName"),

                    };
                    return View(model);
                }
                else
                {
                    var result = _helper.HandleErrors(jobVacanciesresponse);
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
        public async Task<IActionResult> Create(Employee model)
        {
            try
            {
                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/employee";
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
                Employee employee = new();
                HttpClient client = new HttpClient();

                var endpoint = _apiUrl + "API/employee/getbyid/" + id;
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    employee = JsonConvert.DeserializeObject<Employee>(response.Content.ReadAsStringAsync().Result);
                    List<JobVacancy> jobVacancies = new();
                    List<Branch> branches = new();
                    List<Qualification> qualifications = new();
                    List<Grade> grades = new();
                    List<Level> levels = new();
                    List<Nationality> nationalities = new();

                    var jobVacanciesendpoint = _apiUrl + "API/JobVacancy/getall";
                    HttpResponseMessage jobVacanciesresponse = await client.GetAsync(jobVacanciesendpoint);

                    var branchesendpoint = _apiUrl + "API/Branch/getall";
                    HttpResponseMessage branchesresponse = await client.GetAsync(jobVacanciesendpoint);

                    var qualificationendpoint = _apiUrl + "API/Qualification/getall";
                    HttpResponseMessage qualificationresponse = await client.GetAsync(qualificationendpoint);

                    var gradesendpoint = _apiUrl + "API/Grade/getall";
                    HttpResponseMessage gradesresponse = await client.GetAsync(gradesendpoint);

                    var levelsendpoint = _apiUrl + "API/Level/getall";
                    HttpResponseMessage levelsresponse = await client.GetAsync(levelsendpoint);

                    var nationalitiesendpoint = _apiUrl + "API/Nationality/getall";
                    HttpResponseMessage nationalitiesresponse = await client.GetAsync(nationalitiesendpoint);

                    jobVacancies = JsonConvert.DeserializeObject<List<JobVacancy>>(jobVacanciesresponse.Content.ReadAsStringAsync().Result);
                    branches = JsonConvert.DeserializeObject<List<Branch>>(branchesresponse.Content.ReadAsStringAsync().Result);
                    qualifications = JsonConvert.DeserializeObject<List<Qualification>>(qualificationresponse.Content.ReadAsStringAsync().Result);
                    grades = JsonConvert.DeserializeObject<List<Grade>>(gradesresponse.Content.ReadAsStringAsync().Result);
                    levels = JsonConvert.DeserializeObject<List<Level>>(levelsresponse.Content.ReadAsStringAsync().Result);
                    nationalities = JsonConvert.DeserializeObject<List<Nationality>>(nationalitiesresponse.Content.ReadAsStringAsync().Result);


                    employee.JobVacancyList = new SelectList(jobVacancies, "Id", "VacantNumber");
                    employee.BranchList = new SelectList(branches, "Id", "ArabicName");
                    employee.QualificationList = new SelectList(qualifications, "Id", "Name");
                    employee.GradeList = new SelectList(grades, "Id", "Name");
                    employee.LevelList = new SelectList(levels, "Id", "Name");
                    employee.NationalityList = new SelectList(nationalities, "Id", "ArabicName");

                    return View(employee);
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
        public async Task<IActionResult> Edit(Employee model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/employee/" + model.Id;
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
