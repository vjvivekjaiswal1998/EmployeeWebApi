using System.Data;
using Department.DTO;
using Employee.DTO;

namespace Employee.DAL
{
    public interface IEmployeeAccess
    {
        bool DeleteEmployee(int accountId);
        DataTable GetSingleEmployeeDetail(int accountId);
    //    void SaveDepartmentDetail(DepartmentDetail departmentDetail);
        void SaveEmployeeDetail(EmployeeDetail employeeDetail);
     //   DataTable ShowDepartmentDetail();
        DataTable ShowEmployeeDetail();
        void UpdateEmployee(int Id, int Experience, string MarriedStatus);
    }
}