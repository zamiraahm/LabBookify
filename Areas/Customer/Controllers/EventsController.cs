using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using W23G72.Data.Repository.IRepository;
using W23G72.Models;

namespace W23G72.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class EventsController : Controller
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(ILogger<EventsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Event> eventList = _unitOfWork.Event.GetAll(includeProperties: "Category");
            return View(eventList);
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