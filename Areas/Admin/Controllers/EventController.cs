using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using W23G72.Data.Repository.IRepository;
using W23G72.DataAccess.Repository.IRepository;
using W23G72.Models;
using W23G72.ViewModels;

namespace W23G72.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EventController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var events = _unitOfWork.Event.GetAll(includeProperties: "Category")
                                           .Skip((page - 1) * pageSize)
                                           .Take(pageSize)
                                           .ToList();

            return View(events);
        }


        public IActionResult Upsert(int? id)
        {

            EventVM eventVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Event = new Event()
            };
            if (id == null || id == 0)
            {
                //create
                return View(eventVM);
            }
            else
            {
                //update
                eventVM.Event = _unitOfWork.Event.Get(u=>u.Id == id);
                return View(eventVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(EventVM eventVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file!=null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                   // string productPath = Path.Combine(wwwRootPath, @"images\event\");

                    //if (!string.IsNullOrEmpty(eventVM.Event.ImageUrl))
                    //{
                    //    //delete the old image
                    //    var oldImagePath =
                    //        Path.Combine(wwwRootPath, eventVM.Event.ImageUrl.TrimStart('\\'));

                    //    if (System.IO.File.Exists(oldImagePath))
                    //    {
                    //        System.IO.File.Delete(oldImagePath);
                    //    }
                    //}
                    //using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    //{
                    //    file.CopyTo(fileStream);
                    //}

                    //eventVM.Event.ImageUrl = @"images\event\" +  fileName;
                }

                if (eventVM.Event.Id == 0)
                {
                    _unitOfWork.Event.Add(eventVM.Event);
                }
                else
                {
                    _unitOfWork.Event.Update(eventVM.Event);
                }
                _unitOfWork.Save();
                TempData["success"] = "Event created successfully";
                return RedirectToAction("Index");
            } else
            {
                eventVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(eventVM);
            }
          

        }
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Event> objEventList = _unitOfWork.Event.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objEventList });
        }

        public IActionResult Delete(int? id)
        {
            var eventToBeDeleted = _unitOfWork.Event.Get(u => u.Id == id);
            if (eventToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath =
                          Path.Combine(_webHostEnvironment.WebRootPath,
                          eventToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {  
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Event.Remove(eventToBeDeleted);
            _unitOfWork.Save();

        
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}