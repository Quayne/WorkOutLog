<%@ Page Language="C#" MasterPageFile="WorkoutLog.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WorkoutLog.Web.Registration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <div class="container top-edge">

        <div class="form-group">
            <asp:Label ID="usernameLabel" AssociatedControlID="usernameTextBox" Text="Username" CssClass="col-lg-2 control-label" runat="server" />
            <div class="col-lg-4">
                <asp:TextBox type="text" CssClass="form-control" ID="usernameTextBox" placeholder="Hazza" runat="server" />
            </div>
            <div class="col-lg-6">                
                <asp:Label ID="usernameMsg" AssociatedControlID="usernameTextBox" Text="" CssClass="bg-danger" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="emailLabel" AssociatedControlID="emailTextBox" Text="Email" CssClass="col-lg-2 control-label" runat="server" />
            <div class="col-lg-4">
                <asp:TextBox type="email" CssClass="form-control" ID="emailTextBox" placeholder="username@domain.com" runat="server" />
            </div>
            <div class="col-lg-6">                
                <asp:Label ID="emailMsg" AssociatedControlID="emailTextBox" Text="" CssClass="bg-danger" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="passwordLabel" AssociatedControlID="passwordTextBox" Text="Password" CssClass="col-lg-2 control-label" runat="server" />
            <div class="col-lg-4">
                <asp:TextBox type="password" CssClass="form-control" ID="passwordTextBox" placeholder="Password" runat="server" />
            </div>
            <div class="col-lg-6">               
                <asp:Label ID="passwordMsg" Text="" AssociatedControlID="passwordTextBox" CssClass="bg-danger" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="confirmPasswordLabel" AssociatedControlID="confirmPasswordTextBox" Text="Re-type Password" CssClass="col-lg-2 control-label" runat="server" />
            <div class="col-lg-4">
                <asp:TextBox type="password" CssClass="form-control" ID="confirmPasswordTextBox" placeholder="Re-type Password" runat="server" />
            </div>
            <div class="col-lg-6">               
                <asp:Label ID="confirmPasswordMsg" Text="" AssociatedControlID="confirmPasswordTextBox" CssClass="bg-danger" runat="server" />
            </div>
        </div>


        <div class="form-group">
            <div class="col-lg-offset-2 col-lg-4">
                <asp:Button ID="registerButton" type="submit" CssClass="btn btn-primary" Text="REGISTER" OnClick="SubmitRegistrationEvent" runat="server" />
            </div>
        </div>

    </div>
</asp:Content>
