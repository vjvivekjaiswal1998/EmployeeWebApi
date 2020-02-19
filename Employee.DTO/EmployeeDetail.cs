using System;

namespace Employee.DTO
{
    public class EmployeeDetail
    {
        public int EmployeeId { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DOB { get; set; }
        public int Experience { get; set; }
        public string Gender { get; set; }
        public string MarriedStatus { get; set; }
        public int DepartmentId { get; set; }
    }

}
