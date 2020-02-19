using System.Collections.Generic;
using Department.DTO;
using Employee.DTO;

namespace Employee.BLL
{
    public interface IEmployeeManagement
    {
      //  DepartmentDetail AddDepartmentDetail(DepartmentDetail departmentDetail);
        EmployeeDetail AddEmployeeDetail(EmployeeDetail employeeDetail);
        void DeleteEmployeeDetail(int accountNumber);
        EmployeeDetail GetSingleEmployeeDetail(int accountNumber);
      //  List<DepartmentDetail> ShowAllDepartmentDetail();
        List<EmployeeDetail> ShowAllEmployeeDetail();
        void UpdateEmployeeDetail(int Id, int Experience, string marriedStatus);
    }
}