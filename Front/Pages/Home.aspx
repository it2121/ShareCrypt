<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" 
    MaintainScrollPositionOnPostBack="true"
    Inherits="Front.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {

            $(document).ready(function () {
                $('#DataGridUsers').DataTable();
            });
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                order: [ [2, 'asc'],[4, 'desc']]

            });
            $('.table1').DataTable();


        });
      
    </script>


    <script>


        document.addEventListener('DOMContentLoaded', () => {
            // Functions to open and close a modal
            function openModal($el) {
                $el.classList.add('is-active');
            }

            function closeModal($el) {
                $el.classList.remove('is-active');
            }

            function closeAllModals() {
                (document.querySelectorAll('.modal') || []).forEach(($modal) => {
                    closeModal($modal);
                });
            }

            // Add a click event on buttons to open a specific modal
            (document.querySelectorAll('.js-modal-trigger') || []).forEach(($trigger) => {
                const modal = $trigger.dataset.target;
                const $target = document.getElementById(modal);

                $trigger.addEventListener('click', () => {
                    openModal($target);
                });
            });

            // Add a click event on various child elements to close the parent modal
            (document.querySelectorAll('.modal-background, .modal-close, .modal-card-head .delete, .modal-card-foot .button') || []).forEach(($close) => {
                const $target = $close.closest('.modal');

                $close.addEventListener('click', () => {
                    closeModal($target);
                });
            });

            // Add a keyboard event to close all modals
            document.addEventListener('keydown', (event) => {
                if (event.code === 'Escape') {
                    closeAllModals();
                }
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 95%; max-width: 95%; height: 100%; max-height: 100%">
        <br />
        <br />
        <br />
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>
        <!DOCTYPE html>

        <asp:Panel runat="server" ID="ButtonsBar" >
            <div class="row " style="margin-bottom:1em">
    
                      <div class="col-auto">
                <div class="field buttons align-items-end">

                    <%--<button class="js-modal-trigger button is-primary" data-target="modal-js-example">

</button>--%>



     <linkbutton style="background-color: white; color: #f39658; font: bold; border-color:#f39658" text="New Folder"
        
         
         data-target="modal-js-example"
                        onclick="showFolderName()"
                        class="js-modal-trigger button is-fullwidth  align align-content-center  button is-ou">New Folder  
                       
                        <i class="fas fa-add " style="margin-left: 1em">

                        </i></linkbutton>

                </div>
            </div>
                

                      <div class="col-auto">
                <div class="field buttons align-items-end">

                    <%--<button class="js-modal-trigger button is-primary" data-target="modal-js-example">

</button>--%>
                    
     <asp:linkbutton runat="server" Visible="false" style="background-color: white; color: #f35858; font: bold; border-color:#f39658" text="Hide Managment Buttons"
                        data-target="modal-js-example"
                        OnClick="ManageGridHide"
         id="ManageGridButtonHide"
                        class="button is-fullwidth   align align-content-center  button is-ou" >Hide Managment Buttons
                        
                        <i class="fa-solid fa-eye-slash " style="margin-left: 1em"></i></asp:linkbutton>


     <asp:linkbutton runat="server" style="background-color: white; color: #f39658; font: bold; border-color:#f39658" text="Manage  Files"
                        data-target="modal-js-example"
                        OnClick="ManageGrid"
         id="ManageGridButton"
                        class="button is-fullwidth   align align-content-center  button is-ou" >Manage Files  
                        
                        <i class="fas fa-edit " style="margin-left: 1em"></i></asp:linkbutton>

                </div>
            </div>
                 <div class="col-lg">
                     </div>
                   <div class="col-auto">
                <div class="field buttons align-items-end">

                    <%--<button class="js-modal-trigger button is-primary" data-target="modal-js-example">

</button>--%>



     <linkbutton style="background-color: white; color: #f39658; font: bold; border-color:#f39658" text="Encrypt Files"
                        data-target="modal-js-example"
                        class="js-modal-trigger button is-fullwidth  align align-content-center  button is-ou">Encrypt Files  
                        
                        <i class="fas fa-hashtag " style="margin-left: 1em">

                        </i></linkbutton>

                </div>
            </div>
                   <div class="col-auto  ">
                <div class="field buttons align-items-end ">

                    <%--<button class="js-modal-trigger button is-primary" data-target="modal-js-example">

</button>--%>



                    <asp:LinkButton  ID="TestButton"  style="background-color: white; color: #f39658; font: bold; border-color:#f39658" text="Share Files"
                       runat="server"
                        OnClick="ShareGrid"
                        class="js-modal-trigger button is-fullwidth  align align-content-center  button is-ou">Share Files  
                        
                        <i class="fas fa-share " style="margin-left: 1em">

                        </i></asp:LinkButton>


                </div>
            </div>
                      <div class="col-auto">
                <div class="field buttons align-items-end">

                      


     <asp:linkbutton runat="server" Visible="true" style="background-color: white; color: #f39658; font: bold; border-color:#f39658" text="Shared"
                        onclick="ShowSharedList"
                        ID="ShowShared"
                        class=" button is-danger is-light">Show Shared Files
                       
                        <i class="fas fa-eye " style="margin-left: 1em">

                        </i></asp:linkbutton>
                    
     <asp:linkbutton runat="server" style="background-color: white; color:#f39658  ; font: bold; border-color:#f39658" text="Shared"
                        onclick="ShowSharedList"
                         ID="ShowOwn"
         Visible="false" 
                        class=" button is-danger is-light">Show Own Files 
                       
                        <i class="fas fa-eye " style="margin-left: 1em">

                        </i></asp:linkbutton>
                </div>
            </div>
            <div class="col-auto">
                <div class="field buttons align-items-end">

                    <%--<button class="js-modal-trigger button is-primary" data-target="modal-js-example">

</button>--%>



                    <linkbutton                         onclick=" showUploadFile()" style="background-color: #f39658; color: white; font: bold;" text="Upload File" data-target="modal-js-example" class="js-modal-trigger button is-fullwidth  align align-content-center ">Upload File   <i class="fas fa-upload " style="margin-left: 1em"></i></linkbutton>


                </div>
            </div>

        </div>
            </asp:Panel>
        <div class="row" >
            <div class="col-12">

                <nav class="breadcrumb bg-light" aria-label="breadcrumbs">

                    <asp:PlaceHolder runat="server" ID="PlaceHolder">



                    </asp:PlaceHolder>
                    <ul id="navbtnlist" runat="server">
          
                    </ul>
                </nav>
            </div>

          
                

        </div>
        <div class="row">


            <div class="col-12">



                <asp:DataGrid runat="server" Visible="true" ID="DataGridUsers" Width="100%" class="table table-striped  table-hover border-0 " AutoGenerateColumns="false">


                    <Columns>
                             <asp:TemplateColumn  Visible="true"  HeaderText="" ItemStyle-Width="2em" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate  >
                           <asp:Image ID="imgCover" runat="server" AlternateText="Image Cover" ImageUrl='<%# Eval("Type").ToString() == "- Folder" ? "../Images/folder.png" : "../Images/file.png" %>' />
                          

                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn Visible="false" HeaderText="FFID" DataField="FFID" />
                        <asp:BoundColumn Visible="false"  HeaderText="OwnerID" DataField="OwnerID" />
                        <asp:BoundColumn HeaderText="Name" DataField="Name" />
                        <asp:BoundColumn HeaderText="Type" DataField="Type" />
                        <asp:BoundColumn HeaderText="Size" DataField="Size" />
                        <asp:BoundColumn HeaderText="Date" DataField="Date" />


                               <asp:TemplateColumn  Visible="false"  HeaderText="Select" ItemStyle-Width="1em" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate  >
                                <asp:LinkButton  Width="20px" Height="20px"  class=" button is-info is-outlined" ID="btn_SelectFolder" OnClick=  "MoveOwnedFF"  Visible='<%# Eval("Type").ToString() == "- Folder" ? true:false  %>'  runat="server"  ToolTip=' <%# ((Eval("FFID"))) %> '>  <i class="fas fa-circle-check " ></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                       

                        <asp:TemplateColumn   HeaderText="" ItemStyle-Width="1em" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate >
                                <asp:LinkButton Width="20px" Height="20px" class="button is-primary is-outlined "  Visible='<%# Eval("Type").ToString() == "- Folder" ? false:true  %>'  ID="btn_file"   runat="server" OnClick= "DownloadFile"   ToolTip=' <%# ((Eval("FFID"))) %> '>  <i class="fas fa-download " ></i></asp:LinkButton>
                                <asp:LinkButton Width="20px" Height="20px" class="button is-primary is-outlined "  Visible='<%# Eval("Type").ToString() == "- Folder" ? true:false  %>'  ID="btn_folder" runat="server" OnClick=  "EnterFolder"    ToolTip=' <%# ((Eval("FFID"))) %> '>  <i class= "fa-solid fa-right-to-bracket"  ></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>



                          <asp:TemplateColumn  Visible="false"  HeaderText="Share" ItemStyle-Width="1em" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate  >
                                <LinkButton 
                                    style="Width:20px; Height:20px"  
                                    data-target="modal-js-example" 
                                    class="js-modal-trigger button is-info is-outlined"
                                    ID="btn_Share" runat="server" 
                                    onclick='<%# String.Format("showShareForm(\"{0}\")",Eval("FFID"))%>'

                                    Visible='<%# Eval("Type").ToString() == "- Folder" ? false:true  %>'   
                                    ToolTip=' <%# ((Eval("FFID"))) %> '>  <i class="fas fa-share " ></i></LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>




                            <asp:TemplateColumn  Visible="false"  HeaderText="Move" ItemStyle-Width="1em"  ItemStyle-HorizontalAlign="center">
                            <ItemTemplate  >
                                <asp:LinkButton  Width="20px" Height="20px"  class=" button is-info is-outlined" ID="btn_Move" runat="server" 
                                    OnClick="MoveSetFFID"  ToolTip=' <%# ((Eval("FFID"))) %> '>  <i class="fas fa-dolly" ></i></asp:LinkButton>
                            </ItemTemplate>

                        </asp:TemplateColumn>

                            <asp:TemplateColumn  Visible="false"  HeaderText="Delete" ItemStyle-Width="1em" ItemStyle-HorizontalAlign="center">  

                                <ItemTemplate  >
                                <%--<LinkButton   data-target="modal-js-example"  style="Width:20px; Height:20px"   class="js-modal-trigger button is-danger is-outlined" ID="btn_Download"  OnClick= "showDeleteConform(\'' +<%# ((Eval("FFID"))) %> + '\')"  ToolTip=' <%# ((Eval("FFID"))) %> '>  <i  class="fas fa-trash " ></i></LinkButton>--%>

                                <Linkbutton
                                    data-target="modal-js-example"  style="Width:20px; Height:20px"  
                                    class="js-modal-trigger button is-danger is-outlined" ID="btn_Delete"  
                            onclick='<%# String.Format("showDeleteConform(\"{0}\")",Eval("FFID"))%>'
                                    ToolTip=' <%# ((Eval("FFID"))) %> '>  <i  class="fas fa-trash " ></i>

                                </Linkbutton>



                            </ItemTemplate>

                        </asp:TemplateColumn>

                    </Columns>

                </asp:DataGrid>
               
                
                
                
                <script>



                </script>
            </div>
        </div>
    </div>

    <br />


    <div id="modal-js-example" class="modal" >
        <div class="modal-background  "></div>

        <div class="modal-content">
            <div class="box bg-light">


                      <panel id="ShareForm" style="display:none;">

                <p>Search</p>


                <br />


                <div class="row">
                    <div  class="col-12">
                         <center>
                   
                        
                             <asp:Label runat="server"  ID="TextBox11" class="label "  Text="Please Search For a User by Username To Share The File With. "></asp:Label>
                  
                                </center>
                    </div>
            <div  class="col-12">
                         <center>
                   
                        
                        <asp:TextBox runat="server"  ID="ShareToUserID" class="input is-warning " BackColor="LightGray" placeholder="Uesrname"></asp:TextBox>
                  
                                </center>
                    </div>
                </div>
                <br />
                <br />
              
                <div class="row">
                   
                    <div class="col-6">
   <center>
                   <asp:LinkButton ID="LinkButton1share"  onclick="ShareFile" runat="server" Font-Bold="true" Width="75%"  Text="Create" class=" button  is-info    align align-content-center text-white ">Share </asp:LinkButton>

         </center>
                    </div>
                        <div class="col-6">
   <center>
                   <asp:LinkButton ID="LinkButton2share"   runat="server" Font-Bold="true" Width="75%" Text="Create" class=" button is-danger  align align-content-center text-white ">Cancel</asp:LinkButton>

         </center>
                    </div>
                </div>
                   
                <br />

                </panel> <panel id="DeleteConform" style="display:none;">

                <p>Warrning!!</p>


                <br />


                <div class="row">
                    <div  class="col-12">
                         <center>
                   
                        
                             <asp:Label runat="server"  ID="TextBox1" class="label "  Text="This File Will Be Permenantly Deleted, Are you sure you want to Delete it?"></asp:Label>
                  
                                </center>
                    </div>
      
                </div>
                <br />
                <br />
              
                <div class="row">
                   
                    <div class="col-6">
   <center>
                   <asp:LinkButton ID="LinkButton1"  onclick="DeleteFF" runat="server" Font-Bold="true" Width="75%"  Text="Create" class=" button is-danger  align align-content-center text-white ">Delete </asp:LinkButton>

         </center>
                    </div>
                        <div class="col-6">
   <center>
                   <asp:LinkButton ID="LinkButton2"   runat="server" Font-Bold="true" Width="75%" Text="Create" class=" button is-info  align align-content-center text-white ">Keep File </asp:LinkButton>

         </center>
                    </div>
                </div>
                   
                <br />

                </panel>



                    <panel id="FolderNamePanel" style="display:none;">

                <p>New Folder</p>


                <br />


                <div class="row">
                    <div class="col-12">
                         <center>
                   
                        <asp:TextBox runat="server"  ID="NewFolderName" class="input is-warning " BackColor="LightGray" placeholder="File Address"></asp:TextBox>
                       
                                </center>
                    </div>
      
                </div>
                <br />
                <br />
              
                <div class="row">
                   
                    <div class="col-12">
   <center>
                   <asp:LinkButton ID="CreateNewFolderBtn"  onclick="CreateNewFolder" runat="server" Font-Bold="true" Width="75%" BackColor="#f39658" Text="Create" class=" button is-fullwidth  align align-content-center text-white ">Create <i class="fas fa-create " style="margin-left: 2em"></i></asp:LinkButton>

         </center>
                    </div>
                </div>
                   
                <br />

                </panel>





                <%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%>
                <%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%>
                <%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%><%--//////////////////////////////////////////--%>

                <panel id="UploadPanel" style="display:none;">

                <p>Upload File</p>


                <br />


                <div class="row">
                    <div class="col-12">
                         <center>
                       <button  class="button is-danger is-outlined" style="width:100%; color:#f39658;">

<%--                        <asp:TextBox runat="server" ReadOnly="true" ID="FileAdrs" class="input is-warning " BackColor="LightGray" placeholder="File Address"></asp:TextBox>--%>
                                                    <asp:FileUpload ID="FileUploadControl" Visible="true" runat="server" Width="100%"/>
                         </button>
                                </center>
                    </div>
                    <div class="col-3">
<%--                            <asp:FileUpload id="FileUploadControl" Visible="false" runat="server"/>--%>
                        
<%--                        <asp:Button   runat="server" Font-Bold="true"  BackColor="DarkGray" Text="Browse" class=" button is-fullwidth  align align-content-center text-white "> </asp:Button>--%>
                     

                    </div>
                </div>
                <br />
                <br />
              
                <div class="row">
                   
                    <div class="col-12">
   <center>
                   <asp:LinkButton ID="UpBtn"  onclick="Upload" runat="server" Font-Bold="true" Width="75%" BackColor="#f39658" Text="Upload" class=" button is-fullwidth  align align-content-center text-white ">Upload <i class="fas fa-upload " style="margin-left: 2em"></i></asp:LinkButton>

         </center>
                    </div>
                </div>
                   
                <br />

                </panel>

            </div>
        </div>

        <button  class="modal-close is-large" aria-label="close"></button>
    </div>


        <script type="text/javascript">

            function showFolderName() {
                document.getElementById('FolderNamePanel').style.display = "block";
                document.getElementById('UploadPanel').style.display = "none";
                document.getElementById('DeleteConform').style.display = "none";
                document.getElementById('ShareForm').style.display = "none";

            }

            function showDeleteConform(FFID) {
                document.getElementById('DeleteConform').style.display = "block";
                document.getElementById('FolderNamePanel').style.display = "none";
                document.getElementById('UploadPanel').style.display = "none";
                document.getElementById('ShareForm').style.display = "none";


                PageMethods.SetFFID(FFID);
             
            }
            function showShareForm(FFID) {
                document.getElementById('ShareForm').style.display = "block";
                document.getElementById('DeleteConform').style.display = "none";
                document.getElementById('FolderNamePanel').style.display = "none";
                document.getElementById('UploadPanel').style.display = "none";


                PageMethods.SetFFID(FFID);

            }
            function showUploadFile() {
                document.getElementById('FolderNamePanel').style.display = "none";
                document.getElementById('UploadPanel').style.display = "block";
                document.getElementById('DeleteConform').style.display = "none";
                document.getElementById('ShareForm').style.display = "none";

            }
        </script>

</asp:Content>
