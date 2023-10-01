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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="container"  style="width:95%; max-width:95%;height:100%; max-height:100%">
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
                <div class="field buttons align-items-end" >


                    <asp:LinkButton runat="server" ID="btn1" Text="Upload File" class="button is-fullwidth is-success align align-content-center "  BackColor="#f39658">Upload File  <i class="fas fa-upload " style="margin-left:2em" ></i> </asp:LinkButton>


                </div>
            </div>
        </div>
        <div class="row">


            <div class="col-12">



                <asp:DataGrid runat="server" ID="DataGridUsers" Width="100%" class="table table-striped  table-hover border-0 " AutoGenerateColumns="false">


                    <Columns>
                        <asp:BoundColumn HeaderText="FFID" DataField="FFID" />
                        <asp:BoundColumn HeaderText="OwnerID" DataField="OwnerID" />
                        <asp:BoundColumn HeaderText="Name" DataField="Name" />
                        <asp:BoundColumn HeaderText="Type" DataField="Type" />






                        <asp:TemplateColumn HeaderText="Select">
                            <ItemTemplate>
                                <asp:LinkButton BackColor="#F39658"  class="btn  btn-primary border-0 hover" ID="btn_Edit1" runat="server" OnClick="DownloadFile" alt=' <%# ((Eval("FFID"))) %> ' ToolTip=' <%# ((Eval("FFID"))) %> '> Select <i class="fas fa-check " ></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>

                </asp:DataGrid>
            </div>
        </div>
    </div>

    <br />







</asp:Content>
