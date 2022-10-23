using HRIS.Web.Models;
using HRIS.Web.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Web.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeaveTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LeaveTypeModel obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LeaveType.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Create");
            }

            return View(obj);
        }
    }
}
