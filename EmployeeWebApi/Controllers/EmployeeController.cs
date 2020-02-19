using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Department.DTO;
using Employee.BLL;
using Employee.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Product[] products = new Product[]
      {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
      };
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        private readonly IEmployeeManagement _employeeManagement;
        private readonly IDepartmentManagement _departmentManagement;
        EmployeeDetail employeeDetail = new EmployeeDetail();
        readonly DepartmentDetail departmentDetail = new DepartmentDetail();
        public EmployeeController(IEmployeeManagement employeeManagement, IDepartmentManagement departmentManagement)
        {
            _employeeManagement = employeeManagement;
            _departmentManagement = departmentManagement;

        }
        [HttpGet]
        public ActionResult<List<EmployeeDetail>> ShowEmployeeDetail()
        {
            List<EmployeeDetail> EmployeeDetail = _employeeManagement.ShowAllEmployeeDetail();
            return EmployeeDetail;
        }   
      [HttpGet("{id}")]
    public ActionResult<EmployeeDetail> GetEmployeeDetail(int EmployeeID)
        {
            EmployeeDetail employeeDetail = _employeeManagement.GetSingleEmployeeDetail(EmployeeID);
            return employeeDetail;
        }

        [HttpPost]
        public EmployeeDetail AddEmployeeDetail([FromBody]EmployeeDetail employeeDetail)
        {
            if (employeeDetail != null)
            {
                _employeeManagement.AddEmployeeDetail(employeeDetail);
            }
            return employeeDetail;
        }

        [HttpPut("{EmployeeID}")]
        public string UpdateEmployeeDetail( int EmployeeID, [FromBody]EmployeeModel employeeModel)
        {
            _employeeManagement.UpdateEmployeeDetail(EmployeeID, employeeModel);
            return "update successfully";
        }

        [HttpDelete("{id}")]
        public string DeleteEmployeeDetail(int EmployeeID)
        {
            _employeeManagement.DeleteEmployeeDetail(EmployeeID);
            return "Deleted successfully";
        }
    }
}