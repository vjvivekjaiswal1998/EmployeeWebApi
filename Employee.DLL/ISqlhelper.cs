using System.Data;
using Department.DTO;
using Employee.DTO;

namespace Employee.DAL
{
    public interface ISqlhelper
    {
        void AddConstraint();
        void DeleteEmployeeDetail(int accountId);
        void EstablishConnection();
        DataTable FillDetail();
        DataTable DepartmentFillDetail();
        void SaveEmployeeDetail(EmployeeDetail employeeDetail);
        void UpdateEmployeeDetail(int accountid, int Experience, string MarriedStatus);
        void SaveDepartmentDetail(DepartmentDetail departmentDetail);
    }
}