using HelperLib;
using HelperLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Front.Pages
{
    public partial class Home : System.Web.UI.Page
    {
       static FF ff = new FF();

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







            }

      /*      if (IsPostBack && FileUploadControl.PostedFile != null)
            {
                if (FileUploadControl.PostedFile.FileName.Length > 0)
                {
                   FileAdrs.Text = Path.GetFileName(FileUploadControl.PostedFile.FileName);

                }
            }*/



            HtmlGenericControl newLi = new HtmlGenericControl("li");
            HtmlGenericControl newLi1 = new HtmlGenericControl("li");

            newLi.Attributes.Add("Height", "1em");
            newLi1.Attributes.Add("Height", "1em");


            LinkButton LinkButton1 = new LinkButton();
            LinkButton LinkButton11 = new LinkButton();




            LinkButton1.Text = "Add";
            LinkButton11.Text = "Add11";

            newLi.Controls.Add(LinkButton1);
            newLi1.Controls.Add(LinkButton11);
            NavBtnList.Controls.Add(newLi);
            NavBtnList.Controls.Add(newLi1);



        }
        public void refresh() {
            IEnumerable<FF> UsersList = Preform.GetAllFF();
            DataTable dt = IEnumerableExt.Ext_ToDataTable(UsersList);


            dt.Columns.Remove("Data");




            DataGridUsers.DataSource = dt;


            DataGridUsers.DataBind();


        }
        protected bool SetUpFile()
        {



            if (FileUploadControl.HasFile)
            {
                string filename = Path.GetFileName(FileUploadControl.PostedFile.FileName);
                string ext = FileUploadControl.PostedFile.ContentType;
                string size = "";

                //      string sizeInMb =  (FileUploadControl.PostedFile.ContentLength/1024.0/1024.0).ToString("0.0") + " - Mb";
                if ((FileUploadControl.PostedFile.ContentLength / 1024/1024) == 0)
                {

                    size = (FileUploadControl.PostedFile.ContentLength / 1024.0).ToString("0.0") + " - KB";

                }
                else
                {

                    size = (FileUploadControl.PostedFile.ContentLength / 1024.0 / 1024.0).ToString("0.0") + " - Mb";

                }

                ff.Name = filename;
                ff.Type = ext;
                ff.Size = size + "";
                ff.Date = DateTime.Now.ToString("MM / dd / yyyy hh: mm tt");
                /*
                            FileInfo fi = new FileInfo(filename);
                            string ext = fi.Extension;*/
               // FileAdrs.Text = filename;
                if (filename.Length != 0)
                {
                    string contentType = FileUploadControl.PostedFile.ContentType;
                    using (Stream fs = FileUploadControl.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            ff.Data = bytes;

                        }
                    }
                }
                return true;

            }
            else { return false; }
            
        }


        protected void Upload(object sender, EventArgs e)
        {
            if (SetUpFile()) { 
 Preform.InsertFF((Users)Session["User"], ff);
                refresh();    }
        }
        protected void DownloadFile(object sender, EventArgs e)
        {

        }
        protected void FileNavClick(object sender, EventArgs e)
        {

        }
    }
}