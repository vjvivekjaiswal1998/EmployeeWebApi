using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.DAL
{
    class StringUtilityDAL
    {
 

            public static string sqlSelectQuery = "Select * from Employee";
            public static string sqlInsertQuery = "insert into Employee values(@EmployeeID,@EmployeeNumber,@EmployeeName,@EmployeeDOB,@EmployeeExperience,@Gender,@MarriedStatus)";
            public static string exceptionCaught = "execption caught";
            public static string sqlSelectSingleQuery = "Select * from Employee where EmployeeID = ";
            public static string EmployeeDetailsAddedSuccessfully = "Employeee Details Added Successfully";

        public static string sqlSelectQueryDepartment = "Select * from Department";
        public static string sqlInsertQueryDepartment = "insert into Departmentvalues(@DepartmentID,@DepartmentName)";
    }

}

