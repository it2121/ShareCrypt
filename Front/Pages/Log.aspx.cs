using HelperLib;
using HelperLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.Pages
{
    public partial class Log : System.Web.UI.Page
    {
        public static string fuckoff = "none";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["redirected"] = "1";

            }
            }
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            Users user = Preform.LogIn(UsernameTB.Text,PassTB.Text);

            if (user != null)
            {


                Session["User"] = user;

                Response.Redirect("Home.aspx");

            }
            else
            {
                NotFound.Visible= true;


            }
        }
  
    }
}