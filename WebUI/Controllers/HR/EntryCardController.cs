using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models.HR.Employees;
using WebUI.Models.HR.EntryCards;
using WebUI.Services;

namespace WebUI.Controllers.HR
{
    public class EntryCardController : Controller
    {
        private readonly ILogger<EntryCardController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        private readonly string _apiUrl = "";

        public EntryCardController(ILogger<EntryCardController> logger, IConfiguration configuration, IHelper helper)
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
                List<EntryCard> entryCard = new();

                var endpoint = _apiUrl + "API/entryCard/getall";
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    entryCard = JsonConvert.DeserializeObject<List<EntryCard>>(response.Content.ReadAsStringAsync().Result);
                    return View(entryCard);
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
                List<Employee> employees = new();

                HttpClient client = new HttpClient();
                var endpoint = _apiUrl + "API/employee/getall";
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    employees = JsonConvert.DeserializeObject<List<Employee>>(response.Content.ReadAsStringAsync().Result);
                    EntryCard model = new EntryCard
                    {
                        EmployeeList = new SelectList(employees, "Id", "ArabicName")
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
        public async Task<IActionResult> Create(EntryCard model)
        {
            try
            {
                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/entryCard";
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
                EntryCard entryCard = new();
                HttpClient client = new HttpClient();

                var endpoint = _apiUrl + "API/entryCard/getbyid/" + id;
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    entryCard = JsonConvert.DeserializeObject<EntryCard>(response.Content.ReadAsStringAsync().Result);

                    var employeeendpoint = _apiUrl + "API/employee/getall";
                    HttpResponseMessage employeeresponse = await client.GetAsync(employeeendpoint);
                    if (employeeresponse.IsSuccessStatusCode)
                    {
                        List<Employee> employees = new();
                        employees = JsonConvert.DeserializeObject<List<Employee>>(response.Content.ReadAsStringAsync().Result);
                        entryCard.EmployeeList = new SelectList(employees, "Id", "ArabicName");
                    }
                    return View(entryCard);
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
        public async Task<IActionResult> Edit(EntryCard model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/entryCard/" + model.Id;
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
