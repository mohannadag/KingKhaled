using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ControlPanel : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<EmployeeModel> reservationList = new List<EmployeeModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/Employee/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<EmployeeModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }
        #region Employe 

        #endregion

        [HttpGet]
        public async Task<IActionResult> AddNewEmployee()
        {
            List<Reservation> reservationList = new List<Reservation>();
            using (var httpClient = new HttpClient())
            {
                //using (var response = await httpClient.PostAsJsonAsync("https://localhost:44324/api/Reservation"))
                //{
                //    string apiResponse = await response.Content.ReadAsStringAsync();
                //    reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                //}
            }
            return View();
        }
        public IActionResult ResidenceData()
        {
            return View();
        }

        #region Jobs

        [HttpGet]
        public async Task<IActionResult>  Job_Applications()
        {
            //List<JobGroupModel> reservationList = new List<JobGroupModel>();
            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/JobGroup/GetAll"))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        if (apiResponse != null)
            //        {
            //            reservationList = JsonConvert.DeserializeObject<List<JobGroupModel>>(apiResponse);
            //        }

            //    }
            //}
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Job_Group()
        {
            List<JobGroupModel> reservationList = new List<JobGroupModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/JobGroup/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<JobGroupModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }
   

        [HttpGet]
        public async Task<IActionResult> Job_Group_Kind()
        {
            List<JobGroupKindModel> reservationList = new List<JobGroupKindModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/JobSubGroup/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<JobGroupKindModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }

        [HttpGet]
        public async Task<IActionResult> Job()
        {
            List<JobModel> reservationList = new List<JobModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/Job/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<JobModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }
        [HttpGet]
        public async Task<IActionResult> Grade()
        {
            List<GradeModel> reservationList = new List<GradeModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/Grade/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<GradeModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }
        public async Task<IActionResult> Levels()
        {
            List<LevelsModels> reservationList = new List<LevelsModels>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/Level/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<LevelsModels>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }
        public async Task<IActionResult> JobVacancy()
        {
            List<JobVacancyModel> reservationList = new List<JobVacancyModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/JobVacancy/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<JobVacancyModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }
        #endregion

        #region Department Branch
        [HttpGet]
        public async Task<IActionResult> Department()
        {
            List<DepartmentModel> reservationList = new List<DepartmentModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/Department/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<DepartmentModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }
        [HttpGet]
        public async Task<IActionResult> Branch()
        {
            List<BranchModel> reservationList = new List<BranchModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/Branch/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<BranchModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }
        #endregion


        #region Nationality
        public async Task<IActionResult> Nationality()
        {

            List<NationalityModel> reservationList = new List<NationalityModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/Nationality/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<NationalityModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }
        #endregion

        #region Banks
        [HttpGet]
        public async Task<IActionResult> Banks()
        {
            List<BankModel> reservationList = new List<BankModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/Bank/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<BankModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }
        #endregion

        public async Task<IActionResult> Salary()
        {
            List<SalaryModel> reservationList = new List<SalaryModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/Salary/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<SalaryModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }
        public async Task<IActionResult> Qualification()
        {
            List<QualificationModel> reservationList = new List<QualificationModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/Qualification/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<QualificationModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);
        }

        public async Task<IActionResult> JobVisa()
        {
            List<JobVisaModel> reservationList = new List<JobVisaModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/JobVisa/GetAll"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        reservationList = JsonConvert.DeserializeObject<List<JobVisaModel>>(apiResponse);
                    }

                }
            }
            return View(reservationList);

        }

        public async Task<IActionResult> Staff_shifts()
        {
            List<Staff_shiftsModel> reservationList = new List<Staff_shiftsModel>();
            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync("http://192.168.100.154:8080/API/Staff_shifts/GetAll"))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        if (apiResponse != null)
            //        {
            //            reservationList = JsonConvert.DeserializeObject<List<Staff_shiftsModel  >>(apiResponse);
            //        }

            //    }
            //}
            return View(reservationList);
        }
    }
    public class Reservation
    {
        public int statusCode { get; set; }
        public string message { get; set; }
    }
}
