using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using buoi4.Models;

namespace buoi4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult ShowEmployees2()
        {
            List<Employee> listEmployee = new List<Employee>();
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    //string conStr = "Data Source=A204PC42; database=QL_DTDD1 - Copy (2);Integrated Security=True";
                    string conStr = @"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=QL_NhanSu;Integrated Security=True";

                    con.ConnectionString = conStr;
                    string sql = "Select *from tbl_Employee";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var emp = new Employee();
                        emp.ID = (int)row["Id"];
                        emp.Name = row["Name"].ToString();
                        emp.Gender = row["Gender"].ToString();
                        emp.City = row["City"].ToString();

                        listEmployee.Add(emp);
                    }
                }
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult ShowEmployees2()
        {
            List<Employee> listEmployee = new List<Employee>();
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    //string conStr = "Data Source=A204PC42; database =QL_NhanSu;Integrated Security=True";
                    //string constr = "Data Source=A204PC42; Initial Catalog=QL_DTDD1ver2; Integrated Security=True";
                    string constr = @"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=QL_NhanSu;Integrated Security=True";
                    con.ConnectionString = constr;
                    string sql = "Select *from tbl_Employee";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var emp = new Employee();
                        emp.ID = (int)row["Id"];
                        emp.Name = row["Name"].ToString();
                        emp.Gender = row["Gender"].ToString();
                        emp.City = row["City"].ToString();

                        listEmployee.Add(emp);
                    }
                }
                return View(listEmployee);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
