using HelperLib;
using HelperLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Front.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        static FF ff = new FF();
        static int CurrentFolderID = 1;
        static DataTable FFs = null;
        static DataTable OwnedFFs = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {




                Session["redirected"] = "0";

                if ((Users)Session["User"] != null)
                {
                    SelectFolder(CurrentFolderID);

                }

            }
          
                SetNavBar();



            


        }

        public void SetNavBar() {
            if (FilesNabBarLi.Count == 0)
            {

                HtmlGenericControl newLi = new HtmlGenericControl("li");

                newLi.Attributes.Add("Height", "1em");


                LinkButton LinkButton1 = new LinkButton();




                LinkButton1.Text = "Root";
                LinkButton1.ToolTip = "1";
                LinkButton1.Click += new EventHandler(NabBarClick);


                FilesNabBarButtons.Add(LinkButton1);
                FilesNabBarLi.Add(newLi);

                newLi.Controls.Add(LinkButton1);
                navbtnlist.Controls.Add(newLi);


            }
            else
            {

                foreach (LinkButton lb in FilesNabBarButtons)

                {

                    HtmlGenericControl newLi = new HtmlGenericControl("li");

                    newLi.Attributes.Add("Height", "1em");


                    LinkButton LinkButton1 = new LinkButton();




                    LinkButton1.Text = lb.Text;
                    LinkButton1.ToolTip = lb.ToolTip;
                    LinkButton1.Click += new EventHandler(NabBarClick);


                    /*   FilesNabBarButtons.Add(LinkButton1);
                       FilesNabBarLi.Add(newLi);*/

                    newLi.Controls.Add(LinkButton1);
                    navbtnlist.Controls.Add(newLi);


                }

            }


        }


        public static List<LinkButton> FilesNabBarButtons = new List<LinkButton>();
        public static List<HtmlGenericControl> FilesNabBarLi = new List<HtmlGenericControl>();

        protected void NabBarClick(object sender, EventArgs e)

        {
            
            bool last = ((LinkButton)sender).Text.Equals(FilesNabBarButtons.Last().Text);
            if (!last) { 
            List<LinkButton> FilesNabBarButtonsTemp = new List<LinkButton>();
                List<HtmlGenericControl> FilesNabBarLiTemp = new List<HtmlGenericControl>();
               
                FilesNabBarButtonsTemp.Clear();
            FilesNabBarLiTemp.Clear();
        int i = 0;


            HtmlGenericControl tempUl = new HtmlGenericControl("ul");
        
            foreach (LinkButton lb in FilesNabBarButtons)
            {

                if (!lb.ToolTip.Equals(((LinkButton)sender).ToolTip))
                {
                    tempUl.Controls.Add(FilesNabBarLi[i]);
                    FilesNabBarLiTemp.Add(FilesNabBarLi[i]);
                    FilesNabBarButtonsTemp.Add(lb);
                } else if (lb.ToolTip.Equals(((LinkButton)sender).ToolTip)) {

                    tempUl.Controls.Add(FilesNabBarLi[i]);
                    FilesNabBarLiTemp.Add(FilesNabBarLi[i]);
                    FilesNabBarButtonsTemp.Add(lb);

                    break;

                }
                i++;
            }
                FilesNabBarButtons.Clear();
                FilesNabBarLi.Clear();
                navbtnlist.Controls.Clear();
                FilesNabBarButtons =FilesNabBarButtonsTemp;
              
            FilesNabBarLi = FilesNabBarLiTemp;
                navbtnlist = tempUl;

            }
            SetNavBar();
            EnterFolderMethod(Convert.ToInt32(((LinkButton)sender).ToolTip), ((LinkButton)sender).Text,true);

              Response.Redirect(Request.RawUrl);

        }
        public void SetFiledNavBar(int FolderID, string FolderName)
        {


            HtmlGenericControl newLi = new HtmlGenericControl("li");

            newLi.Attributes.Add("Height", "1em");


            LinkButton LinkButton1 = new LinkButton();


            LinkButton1.Text = FolderName;
            LinkButton1.ToolTip = FolderID.ToString();
      
            LinkButton1.Click += new EventHandler(NabBarClick);
   
            FilesNabBarButtons.Add(LinkButton1);
            FilesNabBarLi.Add(newLi);

            newLi.Controls.Add(LinkButton1);
            navbtnlist.Controls.Add(newLi);

        }
        public void SelectFolder(int folderID = -1)
        {

            if (folderID != CurrentFolderID)
            {
                CurrentFolderID = folderID;

            }

            Users user = (Users)Session["User"];


            IEnumerable<FF> GerFFs = Preform.GetUserFF(user);
            IEnumerable<OwnedFF> OwnedFF = Preform.GetOwnedFF(user);

            FFs = IEnumerableExt.Ext_ToDataTable(GerFFs);
            OwnedFFs = IEnumerableExt.Ext_ToDataTable(OwnedFF);



            FFs.Columns.Remove("Data");
            DataTable ShownFiles = FFs.Clone();


            ShownFiles.Rows.Clear();

            int i = 0;
            foreach (DataRow dr in FFs.Rows)
            {

                if (OwnedFF.ElementAt(i).ParantID == CurrentFolderID)
                {


                    ShownFiles.ImportRow(dr);

                }
                i++;
            }


            DataGridUsers.DataSource = ShownFiles;


            DataGridUsers.DataBind();





        }
        public void refresh()
        {

            SelectFolder(CurrentFolderID);


        }
        protected bool SetUpFile()
        {



            if (FileUploadControl.HasFile)
            {
                string filename = Path.GetFileName(FileUploadControl.PostedFile.FileName);
                string ext = FileUploadControl.PostedFile.ContentType;
                string size = "";

                if ((FileUploadControl.PostedFile.ContentLength / 1024 / 1024) == 0)
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


        protected void ShowShareButtons(object sender, EventArgs e)
        {
            foreach (DataGridColumn dc in DataGridUsers.Columns)
            {

                if (dc.HeaderText.Equals("Share"))
                    dc.Visible = true;


            }


        }
        protected void CreateNewFolder(object sender, EventArgs e)
        {


            if (NewFolderName.Text.Length > 0)
            {
                ff.Name = NewFolderName.Text;
                ff.Type = "- Folder";
                ff.Size = null;
                ff.Date = DateTime.Now.ToString("MM / dd / yyyy hh: mm tt");
                ff.Data = null;

                InsertFFsAndFolders();
            }




        }
        public void InsertFFsAndFolders()
        {

            int newFFID = Preform.InsertFF((Users)Session["User"], ff);
            Preform.InsertOwnedFF((Users)Session["User"], newFFID, CurrentFolderID);




            refresh();

        }
        protected void Upload(object sender, EventArgs e)
        {



            if (SetUpFile())
            {


                InsertFFsAndFolders();
            }




        }

        protected void DownloadFile(object sender, EventArgs e)
        {

            FF SelectedFile = new FF();

            SelectedFile.FFID = Convert.ToInt32(((LinkButton)sender).ToolTip);
            SelectedFile = Preform.GetFF(SelectedFile);



            ByteArrayToDownload(SelectedFile);




        }
        protected void EnterFolder(object sender, EventArgs e)
        {
            string name = "";
            CurrentFolderID = Convert.ToInt32(((LinkButton)sender).ToolTip);
            foreach (DataRow dr in FFs.Rows) {
                if (dr["FFID"].ToString().Equals(((LinkButton)sender).ToolTip)) {

                    name = dr["Name"] + "";


                }
            }
            EnterFolderMethod(CurrentFolderID,name,false);
        }

        public void EnterFolderMethod(int FolderID,string name,bool fromNav)
        {

            if (!fromNav) {
            SetFiledNavBar(FolderID, name);
            }

            SelectFolder(FolderID);

        }

        public void ByteArrayToDownload(FF SelectedFile)
        {

            Response.ContentType = SelectedFile.Type;
            Response.Clear();
            Response.BufferOutput = true;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + SelectedFile.Name);
            Response.BinaryWrite(SelectedFile.Data);
            Response.Flush();


        }
        protected void FileNavClick(object sender, EventArgs e)
        {

        }
    }
}