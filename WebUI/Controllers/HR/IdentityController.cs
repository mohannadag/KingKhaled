using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models.HR.Employees;
using WebUI.Models.HR.Identities;
using WebUI.Models.HR.JobVisas;
using WebUI.Services;

namespace WebUI.Controllers.HR
{
    public class IdentityController : Controller
    {
        private readonly ILogger<IdentityController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        private readonly string _apiUrl = "";

        public IdentityController(ILogger<IdentityController> logger, IConfiguration configuration, IHelper helper)
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
                List<Identity> identity = new();

                var endpoint = _apiUrl + "API/identity/getall";
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    identity = JsonConvert.DeserializeObject<List<Identity>>(response.Content.ReadAsStringAsync().Result);
                    return View(identity);
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
                List<JobVisa> jobVisas = new();
                List<Employee> employees = new();

                HttpClient client = new HttpClient();
                var endpoint = _apiUrl + "API/jobvisa/getall";
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    jobVisas = JsonConvert.DeserializeObject<List<JobVisa>>(response.Content.ReadAsStringAsync().Result);
                    var employeesendpoint = _apiUrl + "API/employee/getall";
                    HttpResponseMessage employeesresponse = await client.GetAsync(employeesendpoint);
                    employees = JsonConvert.DeserializeObject<List<Employee>>(employeesresponse.Content.ReadAsStringAsync().Result);

                    Identity model = new Identity
                    {
                        JobVisaList = new SelectList(jobVisas, "Id", "Name"),
                        EmployeeList = new SelectList(employees, "Id", "ArabicName"),
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
        public async Task<IActionResult> Create(Identity model)
        {
            try
            {
                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/identity";
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
                Identity identity = new();
                HttpClient client = new HttpClient();

                var endpoint = _apiUrl + "API/identity/getbyid/" + id;
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    identity = JsonConvert.DeserializeObject<Identity>(response.Content.ReadAsStringAsync().Result);

                    List<JobVisa> jobVisas = new();
                    List<Employee> employees = new();

                    var jobVisasendpoint = _apiUrl + "API/jobvisa/getall";
                    HttpResponseMessage jobVisasresponse = await client.GetAsync(jobVisasendpoint);
                    if (jobVisasresponse.IsSuccessStatusCode)
                    {
                        jobVisas = JsonConvert.DeserializeObject<List<JobVisa>>(jobVisasresponse.Content.ReadAsStringAsync().Result);
                        var employeesendpoint = _apiUrl + "API/employee/getall";
                        HttpResponseMessage employeesresponse = await client.GetAsync(employeesendpoint);
                        employees = JsonConvert.DeserializeObject<List<Employee>>(employeesresponse.Content.ReadAsStringAsync().Result);


                        identity.JobVisaList = new SelectList(jobVisas, "Id", "Name");
                        identity.EmployeeList = new SelectList(employees, "Id", "ArabicName");

                    }

                    return View(identity);
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
        public async Task<IActionResult> Edit(Identity model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/identity/" + model.Id;
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
