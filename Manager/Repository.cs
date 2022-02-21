using Emp_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Emp_MVC.Manager
{
    public class Repository
    {

        public string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=EmployeeTableMVC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        SqlConnection con;
        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> empList = new List<Employee>();
            using (con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(rdr["EmployeeId"]);
                    emp.Name = rdr["Name"].ToString();
                    emp.ProfileImage = rdr["ProfileImage"].ToString();
                    emp.Gender = rdr["Gender"].ToString();
                    emp.Department = rdr["Department"].ToString();
                    emp.Salary = Convert.ToDecimal(rdr["Salary"]);
                    emp.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    emp.Notes = rdr["Notes"].ToString();
                    empList.Add(emp);
                }
                con.Close();
            }
            return empList;
        }
        public bool AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", id);
                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

    }
}
