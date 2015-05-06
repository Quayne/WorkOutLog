<%@ Page Language="C#" MasterPageFile="WorkoutLog.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WorkoutLog.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <div class="container top-edge">

        <%--<div class="form-group">
            <asp:Label Text="Email" ID="emailLabel" AssociatedControlID="emailTextBox" CssClass="col-sm-2 control-label" runat="server" />
            <div class="col-sm-4">
                <asp:TextBox type="email" CssClass="form-control" name="login_email" ID="emailTextBox" placeholder="email@something.com" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label Text="Password" ID="passwordLabel" AssociatedControlID="passwordTextBox" CssClass="col-sm-2 control-label" runat="server" />
            <div class="col-sm-4">
                <asp:TextBox type="password" CssClass="form-control" name="login_password" ID="passwordTextBox" placeholder="Password" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <div class="checkbox">
                    <asp:CheckBox Text="Remember Me" runat="server" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button type="submit" Text="Log In" CssClass="btn btn-primary" OnClick="SubmitCredentials" runat="server" />
            </div>
        </div>--%>
        <asp:Login ID="lgSignIn" runat="server"></asp:Login>
        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="lgSignIn" runat="server" />
    </div>
    
</asp:Content>