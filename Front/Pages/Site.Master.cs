using HelperLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.Pages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public static bool redirected = false;
        protected void Page_Load(object sender, EventArgs e)
        {
           

                if (Session["User"] == null && Session["redirected"].ToString().Equals("0"))
                {
                Session["redirected"] = "1";
                   // redirected=true;
                    Response.Redirect("Log.aspx");

                }
                else if (Session["User"] != null ) {

                Users user = (Users)Session["User"];
                NavBar.Visible = true;


                UserFullNameLbl.Text = user.Fullname;




            }


            

        }
    }
}