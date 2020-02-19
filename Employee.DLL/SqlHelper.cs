using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Employee.DTO;
using Department.DTO;

namespace Employee.DAL
{
  
        public class Sqlhelper : ISqlhelper
    {
           
            public static SqlDataAdapter dataadapter;
            public static SqlConnection bankdataconn;
            public static DataTable datatable;
            public static SqlCommandBuilder sqlcommandbuilder;

            public void EstablishConnection()
            {
                bankdataconn = new SqlConnection(@"Data Source=CS68-PC\SQLEXPRESS;Initial Catalog=Department&Employee;Integrated Security=True");
                //string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                // bankdataconn = new SqlConnection(connect);
            }

            public void AddConstraint()
            {
                Sqlhelper.datatable.Constraints.Add("EmployeeID", Sqlhelper.datatable.Columns[0], true);
            }

            public DataTable FillDetail()
            {
                //  bankdataconn = new SqlConnection(connect);
                string query = StringUtilityDAL.sqlSelectQuery;
                dataadapter = new SqlDataAdapter(query, bankdataconn);
                sqlcommandbuilder = new SqlCommandBuilder(dataadapter);
                datatable = new DataTable();
                dataadapter.Fill(datatable);
                return datatable;
            }
        public DataTable DepartmentFillDetail()
        {
            //  bankdataconn = new SqlConnection(connect);
            string query = StringUtilityDAL.sqlSelectQueryDepartment;
            dataadapter = new SqlDataAdapter(query, bankdataconn);
            sqlcommandbuilder = new SqlCommandBuilder(dataadapter);
            datatable = new DataTable();
            dataadapter.Fill(datatable);
            return datatable;
        }
        public void SaveDepartmentDetail(DepartmentDetail departmentDetail )
        {
            try
            {
                AddConstraint();
                DataRow dataRow = Sqlhelper.datatable.NewRow();
                dataRow[1] = departmentDetail.DepartmentId;
                dataRow[2] = departmentDetail.DepartmentName;
                Sqlhelper.datatable.Rows.Add(dataRow);
                Sqlhelper.dataadapter.Update(Sqlhelper.datatable);
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


        public void SaveEmployeeDetail(EmployeeDetail employeeDetail)
            {
            try
            {
                // code for disconnected architecture

            //    AddConstraint();
                DataRow dataRow = Sqlhelper.datatable.NewRow();


                dataRow[1] = employeeDetail.EmployeeNumber;
                dataRow[2] = employeeDetail.EmployeeName;
                dataRow[3] = employeeDetail.DOB;
                dataRow[4] = employeeDetail.Experience;
                dataRow[5] = employeeDetail.Gender;
                dataRow[6] = employeeDetail.MarriedStatus;
                dataRow[7] = employeeDetail.DepartmentId;
                Sqlhelper.datatable.Rows.Add(dataRow);
                Sqlhelper.dataadapter.Update(Sqlhelper.datatable);
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

            public void UpdateEmployeeDetail(int accountid, int Experience, string MarriedStatus)
            {
            FillDetail();
                AddConstraint();
              if (Sqlhelper.datatable.Rows.Contains(accountid))
                {
                    DataRow dataRow = Sqlhelper.datatable.Rows.Find(accountid);
                    
                    dataRow.BeginEdit();
                
                   
                dataRow["Experience"] = Experience;
                dataRow["MarriedStatus"] = MarriedStatus;

                 
                    dataRow.EndEdit();
                    Sqlhelper.dataadapter.Update(Sqlhelper.datatable);
                 
                }
            }

            public void DeleteEmployeeDetail(int accountid)
            {
                try
                {
                    Console.WriteLine("Find And Delete");
                    AddConstraint();

                    if (!Sqlhelper.datatable.Rows.Contains(accountid))
                    {
                        Console.WriteLine("NO records found");
                    }
                    else
                    {
                        DataRow dataRow = Sqlhelper.datatable.Rows.Find(accountid);
                     
                        dataRow.Delete();
                     
                        Sqlhelper.dataadapter.Update(Sqlhelper.datatable);
                       
                    }
                    //boolvalue = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("execption caught" + e);
                }
            }

        }
    }


