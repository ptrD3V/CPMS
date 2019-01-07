using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CPMS.GUI.Factories;
using CPMS.GUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CPMS.GUI.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectFactory _projectFactory;

        public ProjectController(IProjectFactory projectFactory)
        {
            _projectFactory = projectFactory;
        }

        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:5000");
                    string url = $"api/project";
                    ViewData["projects"] = await _projectFactory.MapToList(client, url);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProjectModel model)
        {
            var status = await _projectFactory.PostObject($"api/project/", model);

            if (!status)
            {
                ViewData["Message"] = "Something wrong";
                return View();
            }

            ViewData["MessageSuccess"] = "Project created";
            return View();
        }

        [HttpGet("edit/project/id")]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _projectFactory.GetObject($"api/project/{id}");
            return View(item);
        }

        [HttpPost("edit/project/id")]
        public async Task<IActionResult> Edit(ProjectModel model)
        {
            var status = await _projectFactory.PutObject($"api/project/edit", model);

            if (!status)
            {
                ViewData["Message"] = "Something wrong";
                return View();
            }

            ViewData["MessageSuccess"] = "Developer edited";
            return View();
        }

        [HttpGet("remove/project/id")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _projectFactory.DeleteObject($"api/project/{id}");
            if (!result)
            {
                ViewData["Message"] = "Something wrong";
                return View("Index");
            }

            ViewData["MessageSuccess"] = "Customer deleted";
            return View("Index");
        }

        [HttpGet("detail/project/id")]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _projectFactory.GetObject($"api/project/{id}");
            return View(result);
        }
    }
}