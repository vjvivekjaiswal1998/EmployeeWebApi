using Department.DTO;
using Employee.DAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Employee.BLL
{
    public class DepartmentManagement : IDepartmentManagement
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IDepartmentAccess _iDepartmentAccess;
        public DepartmentManagement(IDepartmentAccess iDepartmentAccess)
        {
            _iDepartmentAccess = iDepartmentAccess;
            log.Info("Hello logging world!");
        }



        //public DepartmentDetail AddDepartmentDetail(DepartmentDetail departmentDetail)
        //{
        //    _iDepartmentAccess.SaveDepartmentDetail(departmentDetail);
        //    log.Info("Department Detail Addedd Successfully");
        //    return departmentDetail;
        //}
        private static DataTable dataTable = new DataTable();
        public List<DepartmentDetail> ShowAllDepartmentDetail()
        {
            dataTable = _iDepartmentAccess.ShowDepartmentDetail();
            var DepartmentData = new List<DepartmentDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                DepartmentDetail DepartmentDTO = new DepartmentDetail()
                {
                    DepartmentId = int.Parse(row[StringUtilityBLL.DepartmentIdfield.ToString()].ToString()),

                    DepartmentName = row[StringUtilityBLL.DepartmentNamefield.ToString()].ToString(),


                };
                DepartmentData.Add(DepartmentDTO);
            }
            log.Info("Display all Employee detail");
            return DepartmentData;
        }
        public bool AddDepartment(string Name, IFormFile EmployeeDetails)
        {
            string filepath;
            if (EmployeeDetails.Length > 0)
            {
                filepath = "Files";
                var stream = new FileStream(filepath, FileMode.Create);
                EmployeeDetails.CopyTo(stream);
                var saved = File.Create("wwwroot\\Files\\Temp.ods");
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(saved);
            }
            return true;
            //  return _iDepartmentAccess.NewDepartment(Name);
           // return _iDepartmentAccess.SaveDepartmentDetail();
        }

    }
}

