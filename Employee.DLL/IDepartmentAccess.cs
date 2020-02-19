using System.Data;
using Department.DTO;

namespace Employee.DAL
{
    public interface IDepartmentAccess
    {
        void SaveDepartmentDetail(DepartmentDetail departmentDetail);
        DataTable ShowDepartmentDetail();
    }
}