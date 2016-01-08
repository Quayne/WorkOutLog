<%@ Page Language="C#" MasterPageFile="WorkoutLog.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WorkoutLog.Web.Registration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <div class="container top-edge">

        <div class="row" id="registrationErrorList">
            <div class="col-lg-12">
                <div class="alert alert-danger" role="alert">
                    <ul></ul>
                </div>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="usernameLabel" AssociatedControlID="usernameTextBox" Text="Username" CssClass="col-lg-2 control-label" runat="server" />
            <div class="col-lg-4">
                <asp:TextBox CssClass="form-control personProperty" ID="usernameTextBox" data-error-text="USERNAME field must be more than 3 characters in length." placeholder="Your name" runat="server" ClientIDMode="Static" />
            </div>
            <div class="col-lg-6">                
                <asp:Label ID="usernameMsg" AssociatedControlID="usernameTextBox" Text="" CssClass="bg-danger" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="emailLabel" AssociatedControlID="emailTextBox" Text="Email" CssClass="col-lg-2 control-label" runat="server" />
            <div class="col-lg-4">
                <asp:TextBox CssClass="form-control personProperty" ID="emailTextBox" data-error-text="EMAIL format incorrect. Example: username@domain.com." placeholder="username@domain.com" runat="server" ClientIDMode="Static"/>
            </div>
            <div class="col-lg-6">                
                <asp:Label ID="emailMsg" AssociatedControlID="emailTextBox" Text="" CssClass="bg-danger" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="passwordLabel" AssociatedControlID="passwordTextBox" Text="Password" CssClass="col-lg-2 control-label" runat="server" />
            <div class="col-lg-4">
                <asp:TextBox TextMode="Password" CssClass="form-control personProperty" ID="passwordTextBox" data-error-text="PASSWORD field must be at least 3 characters in length. " placeholder="Password" runat="server" ClientIDMode="Static"/>
            </div>
            <div class="col-lg-6">               
                <asp:Label ID="passwordMsg" Text="" AssociatedControlID="passwordTextBox" CssClass="bg-danger" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="confirmPasswordLabel" AssociatedControlID="confirmPasswordTextBox" Text="Confirm Password" CssClass="col-lg-2 control-label" runat="server" />
            <div class="col-lg-4">
                <asp:TextBox TextMode="Password" CssClass="form-control personProperty" ID="confirmPasswordTextBox" data-error-text="CONFIRM PASSWORD field must be at least 3 characters in length and must be the exact match as the PASSSWORD field." placeholder="Confirm Password" runat="server"  ClientIDMode="Static" />
            </div>
            <div class="col-lg-6">               
                <asp:Label ID="confirmPasswordMsg" Text="" AssociatedControlID="confirmPasswordTextBox" CssClass="bg-danger" runat="server" />
            </div>
        </div>


        <div class="form-group">
            <div class="col-lg-offset-2 col-lg-4">
                <asp:Button ID="registerButton" type="submit" CssClass="btn btn-primary btn-submit-user" Text="REGISTER" OnClick="SubmitRegistrationEvent" runat="server" />
            </div>
        </div>

    </div>
</asp:Content>
