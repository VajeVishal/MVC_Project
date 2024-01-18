using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace ModelController2.Controllers
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public static Employee GetSingleEmployee(int EmpNo)
        {
            Employee? emp = new Employee();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Employees WHERE EmpNo = @a1";
                cmd.Parameters.AddWithValue("@a1", EmpNo);
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    emp.EmpNo = EmpNo;
                    emp.Name = dr.GetString("Name");
                    emp.Basic = dr.GetDecimal("Basic");
                    emp.DeptNo = dr.GetInt32("DeptNo");

                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return emp;

        }


        public static List<Employee> GetAllEmployees()
        {
            List<Employee> lstEmps = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";


                SqlDataReader dr = cmd.ExecuteReader();
                Employee obj;

                while (dr.Read())
                {
                    obj = new Employee();
                    obj.EmpNo = dr.GetInt32("EmpNo"); ;
                    obj.Name = dr.GetString("Name");
                    obj.Basic = dr.GetDecimal("Basic");
                    obj.DeptNo = dr.GetInt32("DeptNo");
                    lstEmps.Add(obj);
                }

                dr.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return lstEmps;
        }

        public static void Update(Employee employee)
        {
           
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Employees SET Name = @Name, Basic = @Basic, DeptNo = @DeptNo WHERE EmpNo = @EmpNo";
                             
                cmd.Parameters.AddWithValue("@EmpNo", employee.EmpNo);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Basic", employee.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", employee.DeptNo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               throw;
            }
        }
        public static void Create(Employee employee)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Employees (EmpNo, Name, Basic, DeptNo) VALUES (@EmpNo, @Name, @Basic, @DeptNo)";

                cmd.Parameters.AddWithValue("@EmpNo", employee.EmpNo);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Basic", employee.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", employee.DeptNo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void Delete(int empno)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Employees Where EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo",empno);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }

}
