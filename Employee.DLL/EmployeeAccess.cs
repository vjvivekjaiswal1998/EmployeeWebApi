using Department.DTO;
using Employee.DTO;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Employee.DAL
{

    public class EmployeeAccess : IEmployeeAccess
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ISqlhelper _sqlhelper;

        public EmployeeAccess(ISqlhelper sqlhelper)
        {
            _sqlhelper = sqlhelper;
            _sqlhelper.EstablishConnection();
            log.Info("connection has been established");
        }

        private Boolean boolvalue;

        public DataTable ShowEmployeeDetail()
        {
            _sqlhelper.FillDetail();
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
        public DataTable GetSingleEmployeeDetail(int accountId)
        {
            _sqlhelper.FillDetail();
            log.Info("Fill the Details");
            
            return Sqlhelper.datatable;
        }
        //To Insert The Detail Of Bank To DataBase
        public void SaveEmployeeDetail(EmployeeDetail employeeDetail)
        {
            _sqlhelper.FillDetail();
            log.Info("Fill the Details");
            // FillDetail();
            try
            {

                _sqlhelper.SaveEmployeeDetail(employeeDetail);

            }
            catch (Exception e)
            {
                Console.WriteLine(StringUtilityDAL.exceptionCaught + e);
            }
            finally
            {
                //   bankdataconn.Close();
            }
        }
        public void UpdateEmployee(int Id, int Experience, string MarriedStatus)
        {
            _sqlhelper.FillDetail();
            log.Info("Fill the Details");
            _sqlhelper.UpdateEmployeeDetail(Id, Experience, MarriedStatus);
        }


        public Boolean DeleteEmployee(int accountId)
        {
            _sqlhelper.FillDetail();
            log.Info("Fill the Details");
            //FillDetail();
            boolvalue = false;
            try
            {
                _sqlhelper.DeleteEmployeeDetail(accountId);
                boolvalue = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("execption caught" + e);
            }

            return boolvalue;
        }
       
    }
}



