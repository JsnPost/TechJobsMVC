using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Models;
using TechJobsMVC.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller

    {
        private static List<Job> _jobs;

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.jobs = _jobs;
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
            {
                _jobs = JobData.FindAll();
            }
            else
            {
                _jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }


            ViewBag.jobs = _jobs;

            ViewBag.columns = ListController.ColumnChoices;

            return Redirect("/Search/Index");
        }
    }
}
