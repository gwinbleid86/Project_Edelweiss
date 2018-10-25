using System.Diagnostics;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Project_Edelweiss.Models;

namespace Project_Edelweiss.Controllers
{
    public class HomeController : Controller
    {
        IAgentService agentService;

        public HomeController(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(AgentDTO agentDTO)
        {
            agentService.Create(agentDTO);
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
