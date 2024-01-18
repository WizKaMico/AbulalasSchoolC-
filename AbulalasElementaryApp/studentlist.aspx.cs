using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AbulalasElementaryApp
{
    public partial class studentlist : System.Web.UI.Page
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

                StudentList();
            }
        }

        private void StudentList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string checkStudentTotal = "SELECT * FROM user_login UL LEFT JOIN user_information UI ON UL.uid = UI.uid WHERE UL.designation = 3";
                    MySqlCommand cmd = new MySqlCommand(checkStudentTotal, connection);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Assuming you have a GridView control called "studentGridView" in your form
                    studentGridView.DataSource = dt;
                    studentGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
            }
        }


        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string checkAnnouncementTotal = "SELECT * FROM user_login UL LEFT JOIN user_information UI ON UL.uid = UI.uid WHERE UL.designation = 3";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(checkAnnouncementTotal, connection))
                {
                    connection.Open();

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            // Add a worksheet and populate it with data
                            var ws = wb.Worksheets.Add("StudentList");
                            ws.Cell(1, 1).InsertTable(dt);

                            // Style the header row
                            ws.Row(1).Style.Font.Bold = true;
                            ws.Row(1).Style.Fill.BackgroundColor = XLColor.FromArgb(79, 129, 189);
                            ws.Row(1).Style.Font.FontColor = XLColor.White;

                            // Set the content type and file name for the response
                            Response.Clear();
                            Response.Buffer = true;
                            Response.AddHeader("content-disposition", "attachment;filename=StudentList.xlsx");
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                            // Write the Excel workbook to the response stream
                            using (MemoryStream ms = new MemoryStream())
                            {
                                wb.SaveAs(ms);
                                ms.Seek(0, SeekOrigin.Begin);
                                ms.CopyTo(Response.OutputStream);
                            }

                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // This method is required to avoid a runtime error when rendering the GridView
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            DataTable dt = PerformSearch(searchQuery);

            // Bind the filtered data to the GridView
            studentGridView.DataSource = dt;
            studentGridView.DataBind();
        }

        private DataTable PerformSearch(string searchQuery)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string checkAnnouncementTotal = "SELECT * FROM user_login UL LEFT JOIN user_information UI ON UL.uid = UI.uid WHERE UL.designation = 3 AND UI.fname LIKE @searchQuery OR UI.mname LIKE @searchQuery OR UI.lname LIKE @searchQuery";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(checkAnnouncementTotal, connection))
                {
                    connection.Open();

                    // Use parameterized query to avoid SQL injection
                    cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }
}