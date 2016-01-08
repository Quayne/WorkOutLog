<%@ Page Language="C#" MasterPageFile="WorkoutLog.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WorkoutLog.Web.Login" %>

<%@ Register Src="~/UserControls/Twitter.ascx" TagPrefix="wl" TagName="Twitter" %>

<asp:Content ID="Registration" ContentPlaceHolderID="RegistrationLink" runat="server">
    <a href="/Registration.aspx">Register</a>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <div class="container top-edge">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
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

                <p class="text-info">
                    <span class="bg-info">Email:</span> quayne@workout.com or tester@workout.com
            <br />
                    <span class="bg-info">Password:</span> 123
                </p>

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
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Email is required." ToolTip="Email is required." ValidationGroup="lgSignIn">*</asp:RequiredFieldValidator>
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
            </div>
        </div>
        <br />
        <hr />


    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <div class="row">
                    <%-- ABOUT SECTION --%>
                    <div class="col-md-12">
                        <h2 class="h2 text-center">About Workout Log</h2>
                        <p>Workout Log is an ASP.NET web form application that is used to keep track of your exercise activities. It requires you to have membership before your login can be authenticated. Once you are a member and your login credentials are verified, all of your exercise records will return from the database or an xml file and will be displayed in a table. You will then have functionality to add, edit or delete records.</p>
                        <p>The purpose of this application is to build my resume portfolio and demonstrate some of the skills and qualifications that I possess. As time goes by, I will continuously be making changes to optimize performance to the best of my abilities.</p>
                    </div>
                </div>
                <div class="row">
                    <h2 class="h2 text-center">Things I did in this project</h2>
                    <div class="col-md-4">
                        <ul>
                            <li>ASP.NET Web Form 4.0</li>
                            <li>Javascript</li>
                            <li>jQuery</li>
                            <li>C#</li>
                            <li>ADO.NET</li>
                            <li>Web Config</li>
                        </ul>
                    </div>
                    <div class="col-md-4">
                        <ul>
                            <li>SQL<a href="https://github.com/Quayne/WorkOutLog/blob/master/WorkoutLog.Web/WorkoutLog.Core/bin/Debug/ExerciseLog.sql">(.sql)</a></li>
                            <li>XML</li>
                            <li>OOP</li>
                            <li>Abstract Class</li>
                            <li>Interfaces</li>
                            <li>LINQ</li>
                        </ul>
                    </div>
                    <div class="col-md-4">
                        <ul>
                            <li>Bootstrap</li>
                            <li>ASP.NET Built-in Login control</li>
                            <li>Web Forms Master Page</li>
                            <li>Source Control(<a href="https://github.com/Quayne/WorkOutLog">GitHub</a>)</li>
                            <li>Visual Studio 2013</li>
                            <li>MS SQL Server 2014</li>
                        </ul>
                    </div>
                </div>
                <%--<div class="row">                    
                    <div class="col-md-6">
                        <h4 class="h4 text-center">Bootstrap</h4>                        
                        <p> I use bootstrap because it provides a good user experience for mobile and desktop browsers.(<a href="http://codeboxr.com/blogs/top-5-advantages-of-responsive-web-page-design" title="Link to more info.">Responsive Web Design</a>)</p>
                    </div>
                    <div class="col-md-6">
                        <h4 class="h4 text-center">Javascript</h4>
                        <p>In this project, I used javascript and jQuery to do validations on each text box when the user submits or edit an exercise.</p>
                    </div>
                </div>--%>
                <div class="row">
                    <h2 class="text-center">Things to be done</h2>
                    <div class="col-md-12">
                        <ol>
                            <li class="completed-task">Password hashing</li>
                            <li><span class="completed-task">Make a copy of the current project in MVC.</span><a href="http://workoutlog-mvc.quayne.net/"> (MVC link)</a></li>
                            <li>Make a copy of the current project using AngularJS and Web API</li>
                            <li>Add password changing capability</li>
                            <li>Allow member cancellation</li>                            
                        </ol>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-12 col-xs-12">
                <div>
                    <wl:Twitter runat="server" ID="Twitter" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
