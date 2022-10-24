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

        [HttpGet]
        public JsonResult GetAll()
        {
            IEnumerable<LeaveTypeModel> objCoverTypeList = _unitOfWork.LeaveType.GetAll();
            return Json(new { data = objCoverTypeList });
        }

        [HttpGet]
        public ActionResult GetData()
        {
            var data = from value in _unitOfWork.LeaveType.GetAll() select new { value.Id, value.Title };
            return Json(data.ToList());
        }
    }
}
