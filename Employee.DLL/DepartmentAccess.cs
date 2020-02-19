using Department.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Employee.DAL
{
  public  class DepartmentAccess : IDepartmentAccess
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ISqlhelper _sqlhelper;
        public DepartmentAccess(ISqlhelper sqlhelper)
        {         
                _sqlhelper = sqlhelper;
                _sqlhelper.EstablishConnection();
                log.Info("connection has been established");
        }
        public void SaveDepartmentDetail(DepartmentDetail departmentDetail)
        {
            _sqlhelper.DepartmentFillDetail();
            log.Info("Fill the Details");
        }
        public DataTable ShowDepartmentDetail()
        {
            _sqlhelper.DepartmentFillDetail();
            try
            {

                log.Info("Fill the Details");
                //  FillDetail();
            }
            catch (Exception e)
            {
                Console.WriteLine(StringUtilityDAL.exceptionCaught + e);
            }
            finally
            {
                //   bankdataconn.Close();
            }
            log.Info("Filled data table is been returned");
            return Sqlhelper.datatable;

        }
    }
}
