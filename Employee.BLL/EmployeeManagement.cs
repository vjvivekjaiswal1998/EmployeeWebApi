using System;
using System.Collections.Generic;
using System.Data;
using Employee.DTO;
using Employee.DAL;
using Department.DTO;

namespace Employee.BLL
{

    public class EmployeeManagement : IEmployeeManagement
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IEmployeeAccess _iEmployeeAccess;
        public EmployeeManagement(IEmployeeAccess iEmployeeAccess)
        {
            _iEmployeeAccess = iEmployeeAccess;
            log.Info("Hello logging world!");
        }


        private static DataTable dataTable = new DataTable();

        EmployeeDetail employeeDetail = new EmployeeDetail();


        public EmployeeDetail AddEmployeeDetail(EmployeeDetail employeeDetail)
        {
            _iEmployeeAccess.SaveEmployeeDetail(employeeDetail);
            log.Info("Employee Detail Addedd Successfully");
            return employeeDetail;
        }

        public List<EmployeeDetail> ShowAllEmployeeDetail()
        {
            dataTable = _iEmployeeAccess.ShowEmployeeDetail();
            var EmployeeData = new List<EmployeeDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                EmployeeDetail employeeDTO = new EmployeeDetail()
                {
                    EmployeeId = int.Parse(row[StringUtilityBLL.EmployeeIdfield.ToString()].ToString()),
                    EmployeeNumber = int.Parse(row[StringUtilityBLL.EmployeeNumberfield.ToString()].ToString()),
                    EmployeeName = row[StringUtilityBLL.EmployeeNamefield.ToString()].ToString(),
                    DOB = Convert.ToDateTime(row[StringUtilityBLL.DOBfield.ToString()].ToString()),
                    Experience = int.Parse(row[StringUtilityBLL.Experiencefield.ToString()].ToString()),
                    Gender = row[StringUtilityBLL.Genderfield.ToString()].ToString(),
                    MarriedStatus = row[StringUtilityBLL.MarriedStatusfield.ToString()].ToString(),
                    DepartmentId =int.Parse(row[StringUtilityBLL.DepartmentIdfield.ToString()].ToString())
                };
                EmployeeData.Add(employeeDTO);
            }
            log.Info("Display all Employee detail");
            return EmployeeData;
        }

        public void UpdateEmployeeDetail(int Id, int Experience, string marriedStatus)
        {
            _iEmployeeAccess.UpdateEmployee(Id, Experience, marriedStatus);
            log.Info("update Employee detail");
        }
        public void DeleteEmployeeDetail(int accountNumber)
        {
            _iEmployeeAccess.DeleteEmployee(accountNumber);
            log.Info("Delete Employee detail");

        }
        public EmployeeDetail GetSingleEmployeeDetail(int accountNumber)
        {
            dataTable = _iEmployeeAccess.GetSingleEmployeeDetail(accountNumber);
            foreach (DataRow row in dataTable.Rows)
            {
                employeeDetail.EmployeeId = int.Parse(row[StringUtilityBLL.EmployeeIdfield.ToString()].ToString());
                employeeDetail.EmployeeNumber = int.Parse(row[StringUtilityBLL.EmployeeNumberfield.ToString()].ToString());
                employeeDetail.EmployeeName = row[StringUtilityBLL.EmployeeNamefield.ToString()].ToString();
                employeeDetail.DOB = Convert.ToDateTime(row[StringUtilityBLL.DOBfield.ToString()].ToString());
                employeeDetail.Experience = int.Parse(row[StringUtilityBLL.Experiencefield.ToString()].ToString());
                employeeDetail.Gender = row[StringUtilityBLL.Genderfield.ToString()].ToString();
                employeeDetail.MarriedStatus = row[StringUtilityBLL.MarriedStatusfield.ToString()].ToString();
                employeeDetail.DepartmentId= int.Parse(row[StringUtilityBLL.DepartmentIdfield.ToString()].ToString());
            }
            log.Info("Single Employee detail");
            return employeeDetail;

        }


       
    }


}
