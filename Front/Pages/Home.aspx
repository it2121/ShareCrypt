<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Front.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {

            $(document).ready(function () {
                $('#DataGridUsers').DataTable();
            });
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
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
        <!DOCTYPE html>




        <div class="row">
            <div class="col-9">

                <nav class="breadcrumb bg-light" aria-label="breadcrumbs">
                    <ul id="NavBtnList" runat="server">
                        <li id="RootBtnLi" runat="server">
                            <asp:LinkButton runat="server" Text="aaa" class="button bg-transparent border-0" Height="1em" OnClick="FileNavClick" ToolTip="1" Enabled="true" Visible="true" />
                        </li>
                    </ul>
                </nav>
            </div>

            <div class="col-3">
                <div class="field buttons align-items-end">

                    <%--<button class="js-modal-trigger button is-primary" data-target="modal-js-example">

</button>--%>



                    <linkbutton style="background-color: #f39658; color: white; font: bold;" text="Upload File" data-target="modal-js-example" class="js-modal-trigger button is-fullwidth  align align-content-center ">Upload File   <i class="fas fa-upload " style="margin-left: 2em"></i></linkbutton>


                </div>
            </div>
        </div>
        <div class="row">


            <div class="col-12">



                <asp:DataGrid runat="server" ID="DataGridUsers" Width="100%" class="table table-striped  table-hover border-0 " AutoGenerateColumns="false">


                    <Columns>
                        <asp:BoundColumn Visible="false" HeaderText="FFID" DataField="FFID" />
                        <asp:BoundColumn Visible="false"  HeaderText="OwnerID" DataField="OwnerID" />
                        <asp:BoundColumn HeaderText="Name" DataField="Name" />
                        <asp:BoundColumn HeaderText="Type" DataField="Type" />
                        <asp:BoundColumn HeaderText="Size" DataField="Size" />
                        <asp:BoundColumn HeaderText="Date" DataField="Date" />






                        <asp:TemplateColumn HeaderText="Select">
                            <ItemTemplate>
                                <asp:LinkButton BackColor="#F39658" class="btn  btn-primary border-0 hover" ID="btn_Edit1" runat="server" OnClick="DownloadFile" alt=' <%# ((Eval("FFID"))) %> ' ToolTip=' <%# ((Eval("FFID"))) %> '> Select <i class="fas fa-check " ></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>

                </asp:DataGrid>
            </div>
        </div>
    </div>

    <br />


    <div id="modal-js-example" class="modal" >
        <div class="modal-background  "></div>

        <div class="modal-content">
            <div class="box bg-light">
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
            </div>
        </div>

        <button class="modal-close is-large" aria-label="close"></button>
    </div>




</asp:Content>
