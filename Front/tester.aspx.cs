using HelperLib;
using HelperLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front
{
    public partial class tester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IEnumerable<FF> UsersList = Preform.GetAllFF();
                DataTable dt = IEnumerableExt.Ext_ToDataTable(UsersList);

                dt.Columns.Remove("Data");

                DataGridUsers.DataSource = dt;


                DataGridUsers.DataBind();

            }

        }
    }
}