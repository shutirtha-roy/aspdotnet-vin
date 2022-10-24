using HRIS.Web.Models;
using HRIS.Web.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Web.Controllers
{
    public class EmployeeLeaveController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeLeaveController(IUnitOfWork unitOfWork)
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
        public IActionResult Create(EmployeeLeaveModel obj)
        {
            obj.Id = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                _unitOfWork.EmployeeLeave.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Create");
            }

            return View(obj);
        }
    }
}
