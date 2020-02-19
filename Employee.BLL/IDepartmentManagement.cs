using System.Collections.Generic;
using Department.DTO;
using Microsoft.AspNetCore.Http;

namespace Employee.BLL
{
  public  interface IDepartmentManagement
    {
        // AddDepartmentDetail(DepartmentDetail departmentDetail);
        List<DepartmentDetail> ShowAllDepartmentDetail();
        bool AddDepartment(string Name, IFormFile EmployeeDetails);
    }
}