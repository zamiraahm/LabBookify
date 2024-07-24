using Microsoft.AspNetCore.Mvc;
using W23G72.Models;
using W23G72.Data;
using Microsoft.AspNetCore.Authorization;
using W23G72.Data.Repository.IRepository;

namespace W23G72.Areas.Customer.Controllers
{
    [Area("customer")]
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(Contact contact)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Contact.Add(contact);
                _unitOfWork.Save();
                TempData["success"] = "Message has been sent!";
                return RedirectToAction("Index");


            }


            return View("Index", contact);
        }

        public IActionResult SubmissionSuccess()
        {

            return View();
        }
    }
}