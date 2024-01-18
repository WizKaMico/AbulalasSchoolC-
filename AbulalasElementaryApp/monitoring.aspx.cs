using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;
using ZXing.Common;

namespace AbulalasElementaryApp
{
    public partial class monitoring : System.Web.UI.Page
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

                if (Request.QueryString["LRN"] != null)
                {
                    string lrn = Request.QueryString["LRN"];

                    string qrCodeContent = lrn;

                    // Create a BarcodeWriter instance
                    BarcodeWriter barcodeWriter = new BarcodeWriter();
                    barcodeWriter.Format = BarcodeFormat.QR_CODE;
               

                    // Generate the QR code bitmap
                    System.Drawing.Bitmap qrCodeBitmap = barcodeWriter.Write(qrCodeContent);

                    // Set the QR code bitmap as the source of the Image control
                    imgQRCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(BitmapToBytes(qrCodeBitmap));
                    // Call the method to set the label using the LRN
                    SetTotalStudentInformationLabel(lrn);
                }


            }
        }

        private void SetTotalStudentInformationLabel(string lrn)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string checkStudentInformation = "SELECT * FROM user_login UL LEFT JOIN user_information UI ON UL.uid = UI.uid WHERE UL.uid = @lrn";
                    MySqlCommand cmd = new MySqlCommand(checkStudentInformation, connection);

                    // Set the parameter for the LRN
                    cmd.Parameters.AddWithValue("@lrn", lrn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Access data from the reader and set the label
                            string studentName = reader["fname"].ToString() + " " + reader["lname"].ToString();
                            string grade = reader["level"].ToString();
                            string email = reader["email"].ToString();
                            string birthdate = reader["birthdate"].ToString();
                            string gender = reader["gender"].ToString();
                            string address = reader["address"].ToString();
                            string role = reader["role"].ToString();
                            Label1.Text = "STUDENT NAME: " + studentName;
                            Label2.Text = "GRADE: " + grade;
                            Label3.Text = "BIRTDATE: " + birthdate;
                            Label4.Text = "GENDER: " + gender;
                            Label5.Text = "ADDRESS: " + address;
                            Label6.Text = "ROLE: " + role;
                            // Add more label assignments for other data you want to display
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        private byte[] BitmapToBytes(System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}