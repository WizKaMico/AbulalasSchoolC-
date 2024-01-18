using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AbulalasElementaryApp
{
    public partial class communication : System.Web.UI.Page
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
    }
}