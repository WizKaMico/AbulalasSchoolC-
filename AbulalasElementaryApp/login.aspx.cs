using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;


namespace AbulalasElementaryApp
{
    public partial class login : System.Web.UI.Page
    {

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string uid = this.txtUID.Text;
            string email = this.txtEmail.Text;
            string password = this.txtPassword.Text;

            // Hash the password using MD5
            string hashedPassword = GetMD5Hash(password);

            // Verify the email and hashed password in your MySQL database and get the user_id
            int? userId = VerifyUserAndGetUserId(email, hashedPassword, uid);

            if (userId.HasValue)
            {
                // Generate a random 4-digit number
                Random random = new Random();
                int securityCode = random.Next(1000, 9999);

                // Send the email with the security code
                SendEmail(email, userId.Value, securityCode.ToString());

                // Insert the security code record into the database
                string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO user_security (uid, email, code, status, date_created) VALUES (@UserId, @Email, @SecurityCode, @Status, @DateGenerated)", connection);
                    command.Parameters.AddWithValue("@UserId", uid);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@SecurityCode", securityCode.ToString());
                    command.Parameters.AddWithValue("@Status", "NOT USED");
                    command.Parameters.AddWithValue("@DateGenerated", DateTime.Today);

                    command.ExecuteNonQuery();
                }

                Session["UserEmail"] = email;
                Session["UID"] = uid;


                // Redirect to the security.aspx page
                Response.Redirect("security.aspx");
            }
            else
            {
                // Show error message or perform any other actions for invalid login
            }
        }

        private string GetMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        // Helper method to get the user_id of the verified user
        private int? VerifyUserAndGetUserId(string email, string hashedPassword, string uid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT user_id FROM user_login WHERE email = @Email AND password = @Password AND uid = @UID", connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", hashedPassword);
                command.Parameters.AddWithValue("@UID", uid);

                object result = command.ExecuteScalar();
                return result != null ? (int?)result : null;
            }
        }

        // Helper method to send the email with the security code
        private void SendEmail(string email, int userId, string securityCode)
        {
            // Replace the following placeholders with your SMTP settings
            string smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
            int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            string smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
            string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

            using (MailMessage message = new MailMessage(smtpUsername, email))
            {
                message.Subject = "Security Code";
                message.Body = $"Your security code is: {securityCode}";

                SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);
                smtpClient.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
            }
        }
    }
}