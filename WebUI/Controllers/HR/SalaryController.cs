using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models.HR.Grades;
using WebUI.Models.HR.Levels;
using WebUI.Models.HR.Salaries;
using WebUI.Services;

namespace WebUI.Controllers.HR
{
    public class SalaryController : Controller
    {
        private readonly ILogger<SalaryController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        private readonly string _apiUrl = "";

        public SalaryController(ILogger<SalaryController> logger, IConfiguration configuration, IHelper helper)
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
                List<Salary> salary = new();

                var endpoint = _apiUrl + "API/salary/getall";
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    salary = JsonConvert.DeserializeObject<List<Salary>>(response.Content.ReadAsStringAsync().Result);
                    return View(salary);
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
                List<Grade> grades = new();
                List<Level> levels = new();

                HttpClient client = new HttpClient();
                var endpoint = _apiUrl + "API/grade/getall";
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    grades = JsonConvert.DeserializeObject<List<Grade>>(response.Content.ReadAsStringAsync().Result);
                    var levelsendpoint = _apiUrl + "API/level/getall";
                    HttpResponseMessage levelsresponse = await client.GetAsync(levelsendpoint);
                    levels = JsonConvert.DeserializeObject<List<Level>>(levelsresponse.Content.ReadAsStringAsync().Result);

                    Salary model = new Salary
                    {
                        GradeList = new SelectList(grades, "Id", "Name"),
                        LevelList = new SelectList(levels, "Id", "Name"),
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
        public async Task<IActionResult> Create(Salary model)
        {
            try
            {
                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/salary";
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
                Salary salary = new();
                List<Grade> grades = new();
                List<Level> levels = new();
                HttpClient client = new HttpClient();

                var endpoint = _apiUrl + "API/salary/getbyid/" + id;
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    salary = JsonConvert.DeserializeObject<Salary>(response.Content.ReadAsStringAsync().Result);

                    var gradesendpoint = _apiUrl + "API/grade/getall";
                    HttpResponseMessage gradesresponse = await client.GetAsync(gradesendpoint);
                    grades = JsonConvert.DeserializeObject<List<Grade>>(gradesresponse.Content.ReadAsStringAsync().Result);
                    var levelsendpoint = _apiUrl + "API/level/getall";
                    HttpResponseMessage levelsresponse = await client.GetAsync(levelsendpoint);
                    levels = JsonConvert.DeserializeObject<List<Level>>(levelsresponse.Content.ReadAsStringAsync().Result);

                    salary.GradeList = new SelectList(grades, "Id", "Name");
                    salary.LevelList = new SelectList(levels, "Id", "Name");

                    return View(salary);
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
        public async Task<IActionResult> Edit(Salary model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/salary/" + model.Id;
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
