using labs1.Models;
using Microsoft.AspNetCore.Mvc;
using labs1.Data;

namespace labs1.Controllers
{
    public class ProjectsController : Controller
    {
        // The database context, given to us by ASP.NET Core
        private readonly ApplicationDbContext _context;

        // Constructor: ASP.NET Core passes in the ApplicationDbContext automatically
        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Shows the list of projects:  /Projects
        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
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
            // PostgreSQL needs dates marked as UTC
            project.StartDate = DateTime.SpecifyKind(project.StartDate, DateTimeKind.Utc);
            project.EndDate = DateTime.SpecifyKind(project.EndDate, DateTimeKind.Utc);

            _context.Projects.Add(project);   // prepare to insert the new project
            _context.SaveChanges();           // actually save it to the database
            return RedirectToAction("Index"); // go back to the list
        }

        // Shows one project:  /Projects/Details/1
        public IActionResult Details(int id)
        {
            Project? project = _context.Projects.FirstOrDefault(p => p.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
    }
}