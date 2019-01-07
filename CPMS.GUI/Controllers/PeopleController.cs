using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CPMS.GUI.Factories;
using CPMS.GUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CPMS.GUI.Controllers
{
    public class PeopleController : Controller
    {
        private ICustomerFactory _customerFactory;
        private IDeveloperFactory _developerFactory;

        public PeopleController(ICustomerFactory customerFactory, IDeveloperFactory developerFactory)
        {
            _customerFactory = customerFactory;
            _developerFactory = developerFactory;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<DeveloperModel> developers = new List<DeveloperModel>();
            IEnumerable<CustomerModel> customers = new List<CustomerModel>();

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:5000");
                    string developersUrl = $"api/developer";
                    string customersUrl = $"api/customer";
                    developers = await _developerFactory.MapToList(client, developersUrl);
                    customers = await _customerFactory.MapToList(client, customersUrl);
                    ViewData["developers"] = developers;
                    ViewData["customers"] = customers;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddDeveloper()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDeveloper(DeveloperModel model)
        {
            var status = await _developerFactory.PostObject($"api/developer/", model);

            if (!status)
            {
                ViewData["Message"] = "Something wrong";
                return View();
            }

            ViewData["MessageSuccess"] = "Developer created";
            return View();
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerModel model)
        {
            var status = await _customerFactory.PostObject($"api/customer/", model);

            if (!status)
            {
                ViewData["Message"] = "Something wrong";
                return View();
            }

            ViewData["MessageSuccess"] = "Customer created";
            return View();
        }

        [HttpGet("edit/customer/id")]
        public async Task<IActionResult> EditCustomer(int id)
        {
            var item = await _customerFactory.GetObject($"api/customer/{id}");
            return View(item);
        }

        [HttpPost("edit/customer/id")]
        public async Task<IActionResult> EditCustomer(CustomerModel model)
        {
            var status = await _customerFactory.PutObject($"api/customer/edit", model);

            if (!status)
            {
                ViewData["Message"] = "Something wrong";
                return View();
            }

            ViewData["MessageSuccess"] = "Customer edited";
            return View();
        }

        [HttpGet("edit/developer/id")]
        public async Task<IActionResult> EditDeveloper(int id)
        {
            var item = await _developerFactory.GetObject($"api/developer/{id}");
            return View(item);
        }

        [HttpPost("edit/developer/id")]
        public async Task<IActionResult> EditDeveloper(DeveloperModel model)
        {
            var status = await _developerFactory.PutObject($"api/developer/edit", model);

            if (!status)
            {
                ViewData["Message"] = "Something wrong";
                return View();
            }

            ViewData["MessageSuccess"] = "Developer edited";
            return View();
        }

        [HttpGet("remove/customer/id")]
        public async Task<IActionResult> RemoveCustomer(int id)
        {
            var result = await _customerFactory.DeleteObject($"api/customer/{id}");
            if (!result)
            {
                ViewData["Message"] = "Something wrong";
                return View("Index");
            }

            ViewData["MessageSuccess"] = "Customer deleted";
            return View("Index");
        }

        [HttpGet("remove/developer/id")]
        public async Task<IActionResult> RemoveDeveloper(int id)
        {
            var result = await _developerFactory.DeleteObject($"api/developer/{id}");
            if (!result)
            {
                ViewData["Message"] = "Something wrong";
                return View("Index");
            }

            ViewData["MessageSuccess"] = "Developer deleted";
            return View("Index");
        }

        [HttpGet("detail/customer/id")]
        public async Task<IActionResult> DetailCustomer(int id)
        {
            var result = await _customerFactory.GetObject($"api/customer/{id}");
            return View(result);
        }

        [HttpGet("detail/developer/id")]
        public async Task<IActionResult> DetailDeveloper(int id)
        {
            var result = await _developerFactory.GetObject($"api/developer/{id}");
            return View(result);
        }
    }
}