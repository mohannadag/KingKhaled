using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebUI.Models.HR.Banks;
using WebUI.Services;

namespace WebUI.Controllers.HR
{
    public class BankController : Controller
    {
        private readonly ILogger<BankController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        private readonly string _apiUrl = "";

        public BankController(ILogger<BankController> logger, IConfiguration configuration, IHelper helper)
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
                List<Bank> bank = new();

                var endpoint = _apiUrl + "API/bank/getall";
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    bank = JsonConvert.DeserializeObject<List<Bank>>(response.Content.ReadAsStringAsync().Result);
                    return View(bank);
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bank model)
        {
            try
            {
                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/bank";
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
                Bank bank = new();
                HttpClient client = new HttpClient();

                var endpoint = _apiUrl + "API/bank/getbyid/" + id;
                HttpResponseMessage response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    bank = JsonConvert.DeserializeObject<Bank>(response.Content.ReadAsStringAsync().Result);
                    return View(bank);
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
        public async Task<IActionResult> Edit(Bank model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                HttpClient client = new HttpClient();

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endpoint = _apiUrl + "API/bank/" + model.Id;
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
