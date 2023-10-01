<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="Front.Pages.Log" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="hero is-fullheight body " style="width:100%; max-width:100%;height:100%; max-height:100%">

        

        <div class="hero-body">
            <div class="container">
                <div class="columns is-centered">
                    <div class="column is-6-tablet is-5-desktop is-4-widescreen">


                       <center> <h1 class="title">Please sign in</h1></center>
                        <br />
                        <div class="card">
                            <div class="card-content">
                                <center>
                                      <img src="../Images/SCLogo.png" width="212px" >
                                    </center>
                                <div class="field">
                                    <label for="" class="label">Username</label>
                                    <div class="control has-icons-left">
                                        <asp:TextBox runat="server" ID="UsernameTB" type="text" placeholder="Username" class="input" required />
                                        <span class="icon is-small is-left">
                                            <i class="fa fa-envelope"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="field">
                                    <label for="" class="label">Password</label>
                                    <div class="control has-icons-left">
                                        <asp:TextBox runat="server" ID="PassTB" type="password" placeholder="*******" class="input" required />
                                        <span class="icon is-small is-left">
                                            <i class="fa fa-lock"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="field">
                                    <label for="" class="checkbox">
                                        <input type="checkbox">
                                        Remember me
                                    </label>
                                </div>

                                <div class="field buttons">
                                    <asp:Button runat="server" OnClick="SubmitBtn_Click" ID="btn" Text="Log In" class="button is-fullwidth is-success" BackColor="#f39658"></asp:Button>
                                </div>

                                <center>
                                    <h4>Don't Have An Accont? <a href="Home.aspx" style="color: deepskyblue">Sign Up</a></h4>
                                </center>

                            </div>


                        </div>

                    </div>
                </div>
                <center>
                    <asp:Panel runat="server" ID="NotFound" Visible="false" Width="40%">



                        <article class="message is-danger" >
  <div class="message-header">
    <p>Not Found</p>
    <button class="delete" aria-label="delete"></button>
  </div>
  <div class="message-body">
  Account not found. Please make sure to use the correct username and password 
  </div>
</article>


                    </asp:Panel>
                    </center>

            </div>

        </div>
    </div>
</asp:Content>
