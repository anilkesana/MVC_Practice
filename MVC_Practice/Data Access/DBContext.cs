using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MVC_Practice.Models;
using System.Web.Configuration;

namespace MVC_Practice.Data_Access
{
    public class DBContext
    {
        public IList<Employee> GetEmployees()
        {
            string strConfig = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            List<Employee> emplist = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(strConfig))
            {



                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = "SELECT [EmpId],[Name],[Gender],[DeptId] FROM [Sample].[dbo].[tblEmployee]";

                cmd.CommandType = CommandType.Text;

                conn.Open();

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {

                    Employee emp = new Employee();

                    emp.EmployeeId = Convert.ToInt32(rdr["EmpId"]);
                    emp.EmployeeName = Convert.ToString(rdr["Name"]);
                    emp.EmployeeGender = Convert.ToString(rdr["Gender"]);
                    emp.DepartmentId = Convert.ToInt32(rdr["DeptId"]);
                    emplist.Add(emp);

                }

                conn.Close();

                rdr = null;

                cmd = null;

            }

            return emplist;

        }

        public void SaveData(Employee emp)
{
    // define INSERT query with parameters
    string query = "INSERT INTO [Sample].[dbo].[tblEmployee] (Name,Gender,DeptId) " + 
                   "VALUES ('"+emp.EmployeeName+"','"+emp.EmployeeGender+"','"+emp.DepartmentId+"') ";

    // create connection and command
    string strConfig = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    using (SqlConnection cn = new SqlConnection(strConfig))
    using(SqlCommand cmd = new SqlCommand(query, cn))
    {
        // define parameters and their values
        cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50).Value = emp.EmployeeName;
        cmd.Parameters.Add("@EmployeeGender", SqlDbType.VarChar, 50).Value = emp.EmployeeGender;
        cmd.Parameters.Add("@DepartmentId", SqlDbType.VarChar, 50).Value = emp.DepartmentId;

        // open connection, execute INSERT, close connection
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }
}
        public void DeleteData(int id)
        {
            // define INSERT query with parameters
            string query = "DELETE FROM [Sample].[dbo].[tblEmployee] WHERE EmpId=@id";

            // create connection and command
            string strConfig = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(strConfig))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value =id;
                // open connection, execute Delete, close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void UpdateData(Employee emp)
        {
            // define INSERT query with parameters
            string query = "UPDATE [Sample].[dbo].[tblEmployee] SET Name='" + emp.EmployeeName + "',Gender='" + emp.EmployeeGender + "',DeptId='" + emp.DepartmentId + "' where EmpId='"+emp.EmployeeId+"'";

            // create connection and command
            string strConfig = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(strConfig))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
               
                // open connection, execute Delete, close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }


    }
}