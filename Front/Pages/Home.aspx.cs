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
using System.Web.Services;
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
        static OwnedFF ownedff = new OwnedFF();
        static Shared shared = new Shared();
        static int CurrentFolderID = 1;
        static DataTable FFs = null;
        static DataTable OwnedFFs = null;
        static DataTable Shareds = null;
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
        public void SelectFolder(int folderID = -1,int SharedFlag=0)
        {

            if (folderID != CurrentFolderID)
            {
                CurrentFolderID = folderID;

            }

            Users user = (Users)Session["User"];
            DataTable ShownFiles=new DataTable();
            if (SharedFlag == 0)
            {
                IEnumerable<FF> GerFFs = Preform.GetUserFF(user);
                IEnumerable<OwnedFF> OwnedFF = Preform.GetOwnedFF(user);

                FFs = IEnumerableExt.Ext_ToDataTable(GerFFs);
                OwnedFFs = IEnumerableExt.Ext_ToDataTable(OwnedFF);



                FFs.Columns.Remove("Data");
                 ShownFiles = FFs.Clone();


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
            else {

                IEnumerable<FF> GerFFs = Preform.GetFfFromShared(user);
                IEnumerable<Shared> ShareFF = Preform.GetShared(user);

                FFs = IEnumerableExt.Ext_ToDataTable(GerFFs);
                Shareds = IEnumerableExt.Ext_ToDataTable(ShareFF);



                //FFs.Columns.Remove("Data");
                ShownFiles = FFs.Clone();


                DataGridUsers.DataSource = FFs;


                DataGridUsers.DataBind();





            }

       





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


        protected void ShowSharedList(object sender, EventArgs e)
        {
            if (ButtonsBar.Visible)
            {
                SelectFolder(CurrentFolderID, 1);
                ButtonsBar.Visible = false;
                ShowShared.Visible = false;
                ShowOwn.Visible = true;
            }
            else {

                SelectFolder(CurrentFolderID);
                ButtonsBar.Visible = true;
                ShowShared.Visible = true;
                ShowOwn.Visible = false;
            }

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

            NewFolderName.Text = "";


        }
        public void InsertFFsAndFolders()
        {

            int newFFID = Preform.InsertFF((Users)Session["User"], ff);
            Preform.InsertOwnedFF((Users)Session["User"], newFFID, CurrentFolderID);




            refresh();

        }
        [WebMethod]
        public static  void SetFFID(string FFID)
        {
            ff.FFID =Convert.ToInt32( FFID);
            

           
        }
        protected void DeleteFF(object sender, EventArgs e)
        {

            Preform.DeleteFFAndOwnedFF(ff);
            refresh();
        }
        [WebMethod]
        public static void SetFFIDForDeleting(string FFID)
        {
            ff.FFID = Convert.ToInt32(FFID);

           
        }

    
        protected void ShareGrid(object sender, EventArgs e)
        {

            setAllbuttonVisibilityOff();
            letItBeshown(9);

        } protected void ManageGridHide(object sender, EventArgs e)
        {
            setAllbuttonVisibilityOff();

            ManageGridButtonHide.Visible = false;

            ManageGridButton.Visible = true;


        }
        protected void ManageGrid(object sender, EventArgs e)
        {



            setAllbuttonVisibilityOff();
            letItBeshown(10);
            letItBeshown(11);
            

                ManageGridButtonHide.Visible = true;

                ManageGridButton.Visible = false;
         




        }

        protected void MoveSetFFID(object sender, EventArgs e)
        {
            ff.FFID = Convert.ToInt32(((LinkButton)sender).ToolTip);

            //  select colmn
            setAllbuttonVisibilityOff();
            letItBeshown(7);
        }

        public void letItBeshown(int letItBeshown) {





            if(letItBeshown!=0)
            DataGridUsers.Columns[letItBeshown].Visible = true;




        }

        public void setAllbuttonVisibilityOff() {

            //  select colmn
            DataGridUsers.Columns[7].Visible = false;
            //  delete colmn
            DataGridUsers.Columns[11].Visible = false;
            //  move colmn
            DataGridUsers.Columns[10].Visible = false;


            //  share colmn
            DataGridUsers.Columns[9].Visible = false;

        }
        protected void MoveOwnedFF(object sender, EventArgs e)
        {
         
                
                    ownedff.ParantID =Convert.ToInt32(((LinkButton)sender).ToolTip);
                
                
            
            Preform.MoveOwnedFF (ownedff, ff);


            setAllbuttonVisibilityOff();

            ManageGridButtonHide.Visible = false;

            ManageGridButton.Visible = true;
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