using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Diagnostics;

namespace AbulalasElementaryApp
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Ensure that this code runs only on the initial page load
            {
                if (Session["UserEmail"] != null && Session["UID"] != null)
                {
                    string userEmail = Session["UserEmail"].ToString();
                    lblEmail.Text = "HI! " + userEmail.ToUpper();
                }
                else
                {
                    // Redirect to the login page
                    Response.Redirect("login.aspx");
                }

                SetTotalStudentLabel();
                SetTotalTeacherLabel();

            }
        }

        private void SetTotalStudentLabel()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string checkStudentTotal = "SELECT COUNT(*) as total FROM user_login UL LEFT JOIN user_information UI ON UL.uid = UI.uid WHERE UL.designation = 3";
                    MySqlCommand cmd = new MySqlCommand(checkStudentTotal, connection);

                    // ExecuteScalar is used to get a single value (in this case, the count)
                    int totalCountStudent = Convert.ToInt32(cmd.ExecuteScalar());

                    // Set the total count to the label
                    TotalStudent.Text = totalCountStudent.ToString();

                    Debug.WriteLine("Total Student Count: " + totalCountStudent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in SetTotalStudentLabel: " + ex.Message);
            }
        }

        private void SetTotalTeacherLabel()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string checkTeacherTotal = "SELECT COUNT(*) as total FROM user_login UL LEFT JOIN user_information UI ON UL.uid = UI.uid WHERE UL.designation = 2";
                    MySqlCommand cmd = new MySqlCommand(checkTeacherTotal, connection);

                    // ExecuteScalar is used to get a single value (in this case, the count)
                    int totalCountTeacher = Convert.ToInt32(cmd.ExecuteScalar());

                    // Set the total count to the label
                    TotalTeacher.Text = totalCountTeacher.ToString();

                    Debug.WriteLine("Total Student Count: " + totalCountTeacher);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in SetTotalTeacherLabel: " + ex.Message);
            }
        }


    }
}