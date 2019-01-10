using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CPMS.GUI.Factories;
using CPMS.GUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.GUI.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private IProjectFactory _projectFactory;
        private ITaskFactory _taskFactory;
        private ITimeFactory _timeFactory;

        public ProjectController(IProjectFactory projectFactory, ITaskFactory taskFactory, ITimeFactory timeFactory)
        {
            _projectFactory = projectFactory;
            _taskFactory = taskFactory;
            _timeFactory = timeFactory;
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
                return RedirectToAction("Index");
            }

            ViewData["MessageSuccess"] = "Customer deleted";
            return RedirectToAction("Index");
        }

        [HttpGet("detail/project/id")]
        public async Task<IActionResult> Detail(int id)
        {
            ViewData["TasksCount"] = 0;
            ViewData["TimeCount"] = 0;
            ViewData["TasksCountMonth"] = 0;
            ViewData["TimeCountMonth"] = 0;
            var result = await _projectFactory.GetObject($"api/project/{id}");
            if (result != null)
            {
                var tasks = await _taskFactory.GetObjects($"api/task/project/{id}");
                ViewData["Tasks"] = tasks;
                if (tasks != null)
                {
                    ViewData["TasksCount"] = tasks.Count();
                    ViewData["TasksCountMonth"] = tasks.Where(x => x.StarDate.Month == DateTime.Now.Month || x.CloseDate != null && x.CloseDate.Value.Month == DateTime.Now.Month).Count();
                    var times = await _timeFactory.GetObjects($"api/task/project/time/{id}");
                    if (times != null)
                    {
                        var totalTime = (decimal)times.Sum(x => x.TotalTime);
                        ViewData["TimeCount"] = decimal.Round(totalTime, 2, MidpointRounding.AwayFromZero);
                        var totalTimeMonth = (decimal)times.Where(x => x.Start.Month == DateTime.Now.Month && x.Close.Value.Month == DateTime.Now.Month).Sum(x => x.TotalTime);
                        ViewData["TimeCountMonth"] = decimal.Round(totalTimeMonth, 2, MidpointRounding.AwayFromZero);
                    }
                }
            }
            return View(result);
        }
    }
}