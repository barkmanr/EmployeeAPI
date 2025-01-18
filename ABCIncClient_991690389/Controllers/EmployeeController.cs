using ABCIncClient_991690389.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ABCIncClient_991690389.Controllers
{
    /// <summary>
    /// Controller using API
    /// all actions go through API
    /// </summary>
    public class EmployeeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7024/api");
        private readonly HttpClient _httpClient;

        public EmployeeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        /// <summary>
        /// Returns all the employees on Index View
        /// </summary>
        public ActionResult Index()
        {
            List<EmployeeVM> employees = new List<EmployeeVM>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee/GetEmployees").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<EmployeeVM>>(data);
            }
            return View(employees);
        }

        /// <summary>
        /// Goes to AddEmployee Page
        /// </summary>
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        /// <summary>
        /// Adds employee
        /// checks modelstate for validations
        /// </summary>
        [HttpPost]
        public ActionResult AddEmployee(EmployeeVM emp) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string data = JsonConvert.SerializeObject(emp);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync(_httpClient.BaseAddress + "/employee/AddEmployee", content).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Goes to EditEmployee page
        /// Grabs employee to edit
        /// </summary>
        [HttpGet]
        public ActionResult EditEmployee(int id) 
        { 
            EmployeeVM emp = new EmployeeVM();

            HttpResponseMessage responseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + "/employee/GetEmployee/" + id).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                emp = JsonConvert.DeserializeObject<EmployeeVM>(data); // install NewtonSoft.json 
            }
            return View(emp);
        }

        /// <summary>
        /// Saves changes to db
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(EmployeeVM emp)
        {
            string data = JsonConvert.SerializeObject(emp);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync(_httpClient.BaseAddress + "/employee/UpdateEmployee/" + emp.eId, stringContent).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Deletes employee with id
        /// </summary>
        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            HttpResponseMessage httpResponse = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/employee/DeleteEmployee/" + id).Result;
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Goes to page displaying the info about employee
        /// </summary>
        [HttpGet]
        public ActionResult EmployeeDetails(int id) 
        {
            EmployeeVM emp = new EmployeeVM();

            HttpResponseMessage responseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + "/employee/GetEmployee/" + id).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                emp = JsonConvert.DeserializeObject<EmployeeVM>(data); // install NewtonSoft.json 
            }
            return View(emp);
        }

        /// <summary>
        /// Goes to Search Page
        /// </summary>
        [HttpGet]
        public ActionResult EmployeeByType () 
        { 
            return View();
        }

        /// <summary>
        /// Display employees with matching type
        /// Uses Made search view to have employees and search result
        /// </summary>
        [HttpPost]
        public ActionResult EmployeeByType (SearchView<string> type) 
        {
            List<EmployeeVM> employees = new List<EmployeeVM>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee/FindByType/" + type.Search).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<EmployeeVM>>(data);
            }
            type.Emps = employees;
            return View(type);
        }

        /// <summary>
        /// Goes to search page
        /// </summary>
        [HttpGet]
        public ActionResult EmployeeBySalary()
        {
            return View();
        }

        /// <summary>
        /// Returns list of employees with a higher salary
        /// uses made search view to have employees and search result
        /// </summary>
        [HttpPost]
        public ActionResult EmployeeBySalary(SearchView<int> type)
        {
            List<EmployeeVM> employees = new List<EmployeeVM>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee/FindHighPaid/" + type.Search).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<EmployeeVM>>(data);
            }
            type.Emps = employees;
            return View(type);
        }

        /// <summary>
        /// Gets info about me to display
        /// </summary>
        [HttpGet]
        public ActionResult DeveloperInfo()
        {
            StudentVM student = new StudentVM();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee/DevInfo").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<StudentVM>(data);
            }
            return View(student);
        }

    }
}
