<%@ Page Language="C#" MasterPageFile="WorkoutLog.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WorkoutLog.Web.Login" %>

<%@ Register Src="~/UserControls/Twitter.ascx" TagPrefix="wl" TagName="Twitter" %>

<asp:Content ID="Registration" ContentPlaceHolderID="RegistrationLink" runat="server">
    <a href="/Registration.aspx">Register</a>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <div class="container top-edge">

        <%-- <div class="form-group">
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


        <asp:Login ID="lgSignIn" runat="server">
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2">Log In</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Email:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="lgSignIn">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="lgSignIn">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="lgSignIn" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="lgSignIn" runat="server" />

        <br />
        <hr />
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <wl:Twitter runat="server" ID="Twitter" />
                </div>
            </div>
       
    </div>

</asp:Content>
