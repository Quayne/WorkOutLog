<%@ Page Language="C#" MasterPageFile="WorkoutLog.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WorkoutLog.Web.Login" %>

<%@ Register Src="~/UserControls/Twitter.ascx" TagPrefix="wl" TagName="Twitter" %>

<asp:Content ID="Registration" ContentPlaceHolderID="RegistrationLink" runat="server">
    <a href="/Registration.aspx">Register</a>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <div class="container top-edge">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <

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
                        <p>Workout Log is an ASP.NET web form application that is used to keep track of your exercise activities. It requires you to have a membership before your login can be authenticated. Once you are a member and your login credentials are verified, all of your exercise records will return from the database and will be displayed in a table. You will then have functionality to add, edit or delete records.</p>
                        <p>The purpose of this application is to build my resume portfolio and demonstrate some of the skills and qualifications that I possess. As time goes by, I will continuously be making changes to optimize performance to the best of my abilities.</p>
                    </div>
                </div>
                <div class="row">
                    <h2 class="h2 text-center">Technologies used</h2>
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
                            <li>Visual Studio 2015 Enterprise</li>
                            <li>MS SQL Server 2014</li>
                        </ul>
                    </div>
                </div>
             
                <div class="row">
                    <h2 class="text-center">To Do's</h2>
                    <div class="col-md-12">
                        <ol>
                            <li class="completed-task">Password hashing</li>
                            <li><span class="completed-task">Make a copy of the current project in MVC.</span><a href="http://workoutlog-mvc.quayne.net/"> (MVC link)</a></li>
                            <li>Make a copy of the current project using AngularJS and Web API</li>
                            <li>Give user the ability to enter their own body party type and exercise type</li>
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
