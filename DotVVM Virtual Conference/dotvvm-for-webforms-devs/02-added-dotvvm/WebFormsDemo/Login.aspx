<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormsDemo.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-4 col-md-offset-4">

            <asp:Login ID="Login1" runat="server" CssClass="form" DestinationPageUrl="~/">
                <LayoutTemplate>
                    
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" ID="UserNameLabel">User Name:</asp:Label>
                        <div>
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" 
                            ErrorMessage="User Name is required." ValidationGroup="Login1" 
                            ID="UserNameRequired" CssClass="text-danger">User Name is required.</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" ID="PasswordLabel">Password:</asp:Label>
                        <div>
                            <asp:TextBox runat="server" TextMode="Password" ID="Password" CssClass="form-control"  />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" 
                                ErrorMessage="Password is required." ValidationGroup="Login1" 
                                ID="PasswordRequired" CssClass="text-danger">Password is required.</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div>
                            <asp:CheckBox runat="server" Text="Remember me next time." ID="RememberMe" />
                        </div>
                    </div>
                    <div class="form-group text-danger">
                        <asp:Literal runat="server" ID="FailureText" EnableViewState="False" />
                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" CommandName="Login" 
                            Text="Log In" ValidationGroup="Login1" 
                            ID="LoginButton" CssClass="btn btn-primary" />
                    </div>
                </LayoutTemplate>
            </asp:Login>

        </div>
    </div>

</asp:Content>
