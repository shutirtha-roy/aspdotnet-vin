using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HRIS.Web.Controllers
{
    public class EmployeeProfileController : Controller
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public EmployeeProfileController(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetEmployeeProfileData()
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * from Hrms_Company_Employee_Profile", _sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            var data1 = ds;
            //var data = from value in _unitOfWork.LeaveType.GetAll() select new { value.Id, value.Title };
            List<SelectListItem> employeeProfileList = new List<SelectListItem>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                employeeProfileList.Add(new SelectListItem { Text = dr["EmployeeName"].ToString(), Value = dr["EmployeeProfileId"].ToString() }); ;
            }

            var data = from value in employeeProfileList select new { value.Text, value.Value };

            _sqlConnection.Dispose();
            command.Dispose();
            ds.Dispose();

            return Json(data);
        }
    }
}
