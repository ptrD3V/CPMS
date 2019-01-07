using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CPMS.GUI.Factories;
using CPMS.GUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.GUI.Controllers
{
    public class TaskController : Controller
    {
        private ITaskFactory _taskFactory;
        private IProjectFactory _projectFactory;

        public TaskController(ITaskFactory taskFactory, IProjectFactory projectFactory)
        {
            _taskFactory = taskFactory;
            _projectFactory = projectFactory;
        }

        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:5000");
                    string url = $"api/task";
                    ViewData["tasks"] = await _taskFactory.MapToList(client, url);
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
        public async Task<IActionResult> Add(TaskModel model)
        {
            var status = await _taskFactory.PostObject($"api/task/", model);

            if (!status)
            {
                ViewData["Message"] = "Something wrong";
                return View();
            }

            ViewData["MessageSuccess"] = "Task created";
            return View();
        }

        [HttpGet("edit/task/id")]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _taskFactory.GetObject($"api/task/{id}");
            return View(item);
        }

        [HttpPost("edit/task/id")]
        public async Task<IActionResult> Edit(TaskModel model)
        {
            var status = await _taskFactory.PutObject($"api/task/edit", model);

            if (!status)
            {
                ViewData["Message"] = "Something wrong";
                return View();
            }

            ViewData["MessageSuccess"] = "Task edited";
            return View();
        }

        [HttpGet("remove/task/id")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _taskFactory.DeleteObject($"api/task/{id}");
            if (!result)
            {
                ViewData["Message"] = "Something wrong";
                return View("Index");
            }

            ViewData["MessageSuccess"] = "Task deleted";
            return View("Index");
        }

        [HttpGet("detail/task/id")]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _taskFactory.GetObject($"api/task/{id}");
            if (result != null)
            {
                var project = await _projectFactory.GetObject($"api/project/{result.ProjectID}");
                if (project != null)
                {
                    ViewData["Project"] = project.Name;
                }
            }
            return View(result);
        }
    }
}