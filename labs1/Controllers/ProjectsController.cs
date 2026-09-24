using labs1.Models;
using Microsoft.AspNetCore.Mvc;

namespace labs1.Controllers
{
    public class ProjectsController : Controller
    {
        // A simple list kept in memory (no database yet).
        // "static" means it stays while the app is running.
        private static List<Project> _projects = new List<Project>();

        // Shows the list of projects:  /Projects
        public IActionResult Index()
        {
            return View(_projects);
        }

        // Shows the empty form:  /Projects/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Receives the filled-in form
        [HttpPost]
        public IActionResult Create(Project project)
        {
            // If something is wrong (e.g. no name), show the form again
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            project.ProjectId = _projects.Count + 1;   // give it the next number
            _projects.Add(project);
            return RedirectToAction("Index");          // go back to the list
        }

        // Shows one project:  /Projects/Details/1
        public IActionResult Details(int id)
        {
            Project? project = _projects.FirstOrDefault(p => p.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
    }
}