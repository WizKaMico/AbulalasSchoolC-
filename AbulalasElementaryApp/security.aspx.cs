using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AbulalasElementaryApp
{
    public partial class security : System.Web.UI.Page
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
            }
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            string userEmail = Session["UserEmail"]?.ToString();
            string UID = Session["UID"]?.ToString();
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var status = "NOT USED";
            int enteredCode = int.Parse(txtCode.Text.Trim());

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string validateSecurity = "SELECT * FROM user_security WHERE uid = '" + UID + "' AND email = '" + userEmail + "' AND code = '" + enteredCode + "' AND status = '" + status + "' AND date_created = '" + date + "' ";
                MySqlCommand cmd = new MySqlCommand(validateSecurity, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int i = cmd.ExecuteNonQuery();
                if (dt.Rows.Count > 0)
                {
                    var stat = "USED";
                    string update_the_code = "UPDATE user_security SET status = '" + stat + "' WHERE code = '" + enteredCode + "'";
                    MySqlCommand ucode = new MySqlCommand(update_the_code, connection);
                    int rowsUpdated = ucode.ExecuteNonQuery(); // ExecuteNonQuery instead of ExecuteReader


        
                    string check_communication = "SELECT * FROM announcement";
                    MySqlCommand checkCom = new MySqlCommand(check_communication, connection);
                    MySqlDataAdapter cc = new MySqlDataAdapter(checkCom);
                    DataTable CheckCommunication = new DataTable();
                    cc.Fill(CheckCommunication);
                    int c = checkCom.ExecuteNonQuery(); // ExecuteNonQuery instead of ExecuteReader
                    if (CheckCommunication.Rows.Count > 0)
                    {
                        Response.Redirect("communication.aspx");
                    }
                    else
                    {
                        Response.Redirect("home.aspx");
                    }
                }
            }
        }
    }
}