﻿using System;
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
    public class TaskController : Controller
    {
        private ITaskFactory _taskFactory;
        private ITimeFactory _timeFactory;
        private IProjectFactory _projectFactory;

        public TaskController(ITaskFactory taskFactory, ITimeFactory timeFactory, IProjectFactory projectFactory)
        {
            _taskFactory = taskFactory;
            _projectFactory = projectFactory;
            _timeFactory = timeFactory;
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

        [HttpGet("edit/time/task/id")]
        public async Task<IActionResult> EditTime(int id)
        {
            var item = await _timeFactory.GetObject($"api/time/{id}");
            ViewData["id"] = item.TaskID;
            return View(item);
        }

        [HttpPost("edit/time/task/id")]
        public async Task<IActionResult> EditTime(TimeModel model)
        {
            var status = await _timeFactory.PutObject($"api/time/edit", model);

            if (!status)
            {
                ViewData["Message"] = "Something wrong";
                return View();
            }

            ViewData["MessageSuccess"] = "Time edited";
            return View();
        }

        [HttpGet("log/task/id")]
        public IActionResult LogTime(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [HttpPost("log/task/id")]
        public async Task<IActionResult> LogTime(TimeModel model)
        {
            var status = await _timeFactory.PostObject($"api/time/", model);

            if (!status)
            {
                ViewData["Message"] = "Something wrong";
                return View();
            }

            ViewData["MessageSuccess"] = "Time logged";
            return View();
        }

        [HttpGet("remove/time/task/id")]
        public async Task<IActionResult> RemoveTime(int id)
        {
            var result = await _timeFactory.DeleteObject($"api/time/{id}");
            if (!result)
            {
                ViewData["Message"] = "Something wrong";
                return RedirectToAction("Index");
            }

            ViewData["MessageSuccess"] = "Time deleted";
            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }

            ViewData["MessageSuccess"] = "Task deleted";
            return RedirectToAction("Index");
        }

        [HttpGet("detail/task/id")]
        public async Task<IActionResult> Detail(int id)
        {
            ViewData["TotalTime"] = 0;
            var result = await _taskFactory.GetObject($"api/task/{id}");
            if (result != null)
            {
                var project = await _projectFactory.GetObject($"api/project/{result.ProjectID}");
                if (project != null)
                {
                    ViewData["Project"] = project.Name;
                }

                var times = await _timeFactory.GetObjects($"api/time/task/{id}");
                if (times != null)
                {
                    ViewData["Times"] = times;
                    var totalTime = (decimal)times.Sum(x => x.TotalTime);
                    ViewData["TotalTime"] = decimal.Round(totalTime, 2, MidpointRounding.AwayFromZero); 
                }
            }
            return View(result);
        }

        [HttpGet("close/task/id")]
        public async Task<IActionResult> CloseTask(int id)
        {
            var detailID = id;
            var result = await _taskFactory.GetObject($"api/task/{id}");
            if (result != null)
            {
                result.CloseDate = DateTime.Now;

                var status = await _taskFactory.PutObject($"api/task/edit", result);

                if (!status)
                {
                    ViewData["Message"] = "Something wrong";
                    return RedirectToAction("Detail", new { id = detailID});
                }

                ViewData["MessageSuccess"] = "Task edited";
                return RedirectToAction("Detail", new { id = detailID });
            }
            return View(result);
        }
    }
}