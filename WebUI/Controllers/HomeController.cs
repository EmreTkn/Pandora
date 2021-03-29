using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Core.Entities;
using Core.Interfaces;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IJobRepository _jobRepository;

        public HomeController(ILogger<HomeController> logger,IPersonnelRepository personnelRepository,IJobRepository jobRepository)
        {
            _logger = logger;
            _personnelRepository = personnelRepository;
            _jobRepository = jobRepository;
        }


        public IActionResult Assignment()
        {
            var entity = _personnelRepository.GetAllEmployeesJobs();
            if (entity.Count<=0)
            {
                var employees = _personnelRepository.GetPersonnelList();
                Random random = new Random();
                for (int i = 0; i < 6; i++)
                {
                    while (true)
                    {
                        AddToList(employees, random);
                        var numberofEmployee = _personnelRepository.GetEmployeesJobs();
                        var number = (i + 1) * 6;
                        if (number == numberofEmployee)
                        {
                            break;
                        }
                        else if (number != numberofEmployee)
                        {
                            foreach (var item in employees)
                            {
                                var list = _personnelRepository.GetEmployeesJobEntity(item.Id);
                                var indexOfList = i;
                                if (indexOfList + 1 == list.Count)
                                {
                                    _personnelRepository.DeleteTable(list[indexOfList]);
                                }
                            }
                        }
                    }
                }
            } 
            var entity1 = _personnelRepository.GetAllEmployeesJobs(); 
            var model=new Days 
            {
              EmployeesJobs = entity1

            }; 
            return View(model);
        }

        private void AddToList(List<Employees> employees, Random random)
        {
            foreach (var item in employees)
            {
                while (true)
                {
                    var index = random.Next(1, 7);
                    var job = _jobRepository.GetJobById(index);
                    if (job != null)
                    {
                       var result= _personnelRepository.AddJobs(item, job);
                       break;
                    }
                }
            }
            _jobRepository.ChangeToJobs();
        }

        public IActionResult ResetToPage()
        {
            _personnelRepository.DeleteAll();
            _jobRepository.ChangeToJobs();
            return RedirectToAction("Assignment");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
