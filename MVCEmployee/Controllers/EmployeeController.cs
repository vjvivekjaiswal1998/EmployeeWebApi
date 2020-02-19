using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Employee.BLL;
using Employee.DTO;
using Department.DTO;

namespace MVCEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManagement _employeeManagement;
        private readonly IDepartmentManagement _departmentManagement;
        EmployeeDetail employeeDetail = new EmployeeDetail();
       readonly DepartmentDetail departmentDetail = new DepartmentDetail();
        public EmployeeController(IEmployeeManagement employeeManagement, IDepartmentManagement departmentManagement)
        {
            _employeeManagement = employeeManagement;
            _departmentManagement = departmentManagement;
            
        }

        public IActionResult Menu()
        {
           
            return View();
        }
        public IActionResult Index()
        {
            ViewBag.Welcome = "Welcome to this website . This website is for employee&Departement system";
            ViewData["Message"] = "Hello Vivek R Jaiswal!";
            return View();
        }
        [HttpGet]
        public IActionResult ShowEmployeeDetail()
        {
            List<EmployeeDetail> EmployeeDetail = new List<EmployeeDetail>();
            EmployeeDetail = _employeeManagement.ShowAllEmployeeDetail();
            return View(EmployeeDetail);
          
        }
        public IActionResult Add(EmployeeDetail employeeDetail)
        {
            _employeeManagement.AddEmployeeDetail(employeeDetail);
            return View("AddEmployeeDetail");
        }
        public IActionResult AddEmployeeDetail()
        {
          //  _employeeManagement.
              return View();
        }

        public IActionResult UpdateEmployeeDetail(int EmployeeID ,int Experience,string MarriedStatus)
        {
            _employeeManagement.UpdateEmployeeDetail(EmployeeID, Experience, MarriedStatus);
            return View(employeeDetail);
        }
        public IActionResult DeleteEmployeeDetail(int EmployeeID)
        {
            _employeeManagement.DeleteEmployeeDetail(EmployeeID);
            return View(employeeDetail);
        }
        [HttpGet]
        public IActionResult GetEmployeeDetail(int EmployeeID)
        {

            employeeDetail = _employeeManagement.GetSingleEmployeeDetail(EmployeeID);

            return View(employeeDetail);

        }
     
        public IActionResult AddDepartment()
        {
            
            return View();
        }
        public IActionResult ShowDepartment()
        {
        
            List<DepartmentDetail> departmentDetail = new List<DepartmentDetail>();
            departmentDetail = _departmentManagement.ShowAllDepartmentDetail();
          
            return View(departmentDetail);
        }
        public IActionResult Default()
        {
            return View();
        }
        public IActionResult EmployeeIndex()
        {
            ViewBag.Welcome = "Welcome to this website . This website is for employee&Departement system";
            ViewData["Message"] = "Hello Vivek R Jaiswal!  EmployeeIndex";
            return View();
        }
        public IActionResult DepartmentIndex()
        {
            ViewBag.Welcome = "Welcome to this website . This website is for employee&Departement system";
            ViewData["Message"] = "Hello Vivek R Jaiswal! Department Index";
            return View();
        }
    }
}
