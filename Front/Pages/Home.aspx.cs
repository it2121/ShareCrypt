using HelperLib;
using HelperLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Front.Pages
{
    public partial  class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {




                Session["redirected"] = "0";
                IEnumerable<FF> UsersList = Preform.GetAllFF();
                DataTable dt = IEnumerableExt.Ext_ToDataTable(UsersList);

       
                dt.Columns.Remove("Data");
  



                DataGridUsers.DataSource = dt;
         

                DataGridUsers.DataBind();
            /*    foreach (DataGridColumn col in DataGridUsers.Columns) {
                    col.Visible= false;


                }*/



                /*      HtmlGenericControl li = new HtmlGenericControl("li");
                      Button btn = new Button();

                      //   btn.Width = Unit.Pixel(50);
                      btn.ID = string.Format("butDynamic{0}", "a");    // Give the button a unique ID
                      btn.InnerText = "abo al7low";


                      HtmlGenericControl li1 = new HtmlGenericControl("li");
                      HtmlGenericControl btn1 = new HtmlGenericControl("asp:Button");

                      //   btn.Width = Unit.Pixel(50);
                      btn1.ID = string.Format("butDynamic{0}", "a");    // Give the button a unique ID
                      btn1.InnerText = string.Format("butDynamic{0}", "111abo al7low"); // Give the button a unique ID
                      li1.Controls.Add(btn1);
                      BtnsPanel.Controls.Add(li1);*/






                /*          LinkButton Btn = (LinkButton)RootBtnLi.Controls[0];
                          LinkButton newBtn = Btn;
                          //    newBtn. = $"<asp:LinkButton   runat=\"server\" Text=\"aaa\"   class=\"button bg-transparent border-0\" Height=\"1em\" OnClick=\"FileNavClick\" ToolTip=\"1\" Enabled=\"true\" Visible=\"true\"/>";
                          newBtn.Text = "OMG";
                          RootBtnLi.Controls.Add(newBtn);
                          NavBtnList.Controls.Add(RootBtnLi);
                          NavBtnList.Controls.Add(RootBtnLi);
                          NavBtnList.Controls.Add(RootBtnLi);*/

            }


            HtmlGenericControl newLi = new HtmlGenericControl("li");
            HtmlGenericControl newLi1 = new HtmlGenericControl("li");

            newLi.Attributes.Add("Height", "1em");
            newLi1.Attributes.Add("Height", "1em");


            LinkButton LinkButton1 = new LinkButton();
            LinkButton LinkButton11 = new LinkButton();

            /*   LinkButton1.Attributes.Add("runat", "server");
               LinkButton1.Attributes.Add("Text", "one to go");
               LinkButton1.Attributes.Add("class", "button bg-transparent border-0");
               LinkButton1.Attributes.Add("Height", "1em");
               LinkButton1.Attributes.Add("OnClick", "FileNavClick");
               LinkButton1.Attributes.Add("ToolTip", "1");
               LinkButton1.Attributes.Add("Enabled", "true");
               LinkButton1.Attributes.Add("Visible", "true");
               LinkButton1.Attributes.Add("Visible", "true");
               LinkButton1.InnerText = "";*/


            LinkButton1.Text="Add";
            LinkButton11.Text="Add11";

            newLi.Controls.Add(LinkButton1);
            newLi1.Controls.Add(LinkButton11);
            NavBtnList.Controls.Add(newLi);
            NavBtnList.Controls.Add(newLi1);

            /*      HtmlGenericControl anchor = new HtmlGenericControl("a");
                  anchor.Attributes.Add("href", "page.htm");
                  anchor.InnerText = "TabX";


                  NavBtnList.Controls.Add(newLi);*/


            /*
                        HtmlGenericControl newLi = RootBtnLi;
                        HtmlGenericControl newLi1 = RootBtnLi;

                        newLi.ID= "0";
                        newLi1.ID= "01";
                        LinkButton newBtn = (LinkButton)RootBtnLi.Controls[0];
                        LinkButton newBtn1 = (LinkButton)RootBtnLi.Controls[0];
                        newBtn.ID = "0111";
                        newBtn1.ID = "011";
                        newBtn.Text = "suck a dick";
                        newBtn1.Text = "suck two dicks";
                        newLi.Controls.Add(newBtn);
                        newLi1.Controls.Add(newBtn1);
                        NavBtnList.Controls.Clear();
                        NavBtnList.Controls.Add(newLi);

                        NavBtnList.Controls.Add(newLi1);*/


        }
        protected void DownloadFile(object sender, EventArgs e)
        {

        } protected void FileNavClick(object sender, EventArgs e)
        {

        }
    }
}