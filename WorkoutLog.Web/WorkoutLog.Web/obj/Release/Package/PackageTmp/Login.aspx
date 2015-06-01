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

        <p class="text-info"><span class="bg-info">Email:</span> quayne@live.com or quayne@hotmail.com
            <br /><span class="bg-info">Password:</span> 123
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
                        <p>Workout Log is a web application that can be use to keep track of your exercise activities. It requires you to have a membership before your login can be authenticated. Once you are a member and your login credentials are varified, all of your exercise records will return from a database or a xml file and will be displayed in a table. You will then have functionality to add, edit or delete records.</p>
                        <p>The purpose of this application is to build my resume portfolio and demonstrate some of the skills and qualifications that I possess. As time goes by, I will continuously be making changes to optimize performance to the best of my abilities.</p>
                    </div>
                </div>
                <div class="row">
                    <h2 class="h2 text-center">Things that I do</h2>
                    <div class="col-md-6">
                        <h4 class="h4 text-center">ASP.NET Built-in Login Template</h4>
                        <p>dkjhfvlksdl lksdbfvkj jk sdlkb dlsku dkjfbkdlkflb bdalkkj kbalkfbbhk kblkafhbkjsdfkukjfdau uhfashsdljs dlfygskf gfsdjkgfsd jsdgklddblkds ugdbfui sdgsflkslksdg uk lgu lku ku kudfjgsd hdhjgdfj hdf fjgsdkjhg y jhg yghd ygk h yj rgsg dfdg   ghhfkhjshkhdshkgdsk jhk  hkjdkhjshjfk h gh kjhgf h gdg kjkgkhhkj gh khj jh g gds  shjksdjhf dfgsfvdf.</p>
                    </div>
                    <div class="col-md-6">
                        <h4 class="h4 text-center">ASP.NET Web Form</h4>
                        <p>jkhdsfjhkjh jh hkj y dslhjd fu jkfgsdlkuh dfg hkgsdlukhdfg hgdsg  gjkhlsghfg hl s sls lk jfjdk f dkjfjfjkghhkj  k hfkdd gkdkhlkhdfg hjgkhjdfgkljh hjdskhdsfg hldfgkuh glkhdsgkuh kluhsdklh kjhs kluh sklug skgh sdku slkg sdkgsglghk jgh skjghsdkul gl sdghsgd lghks h sgls lkhgsghlg shklgsd hjsdghlsdhjlg lh hgl gk slhgsdf ghfg ljhs kjhsdghjfdglk ljd hkjg ddlhjg kjsd fldg erli  hlgslg lierglger lg d lkghsfgldg lsh skhgdsfkls.</p>
                    </div>
                </div>
                <div class="row">                    
                    <div class="col-md-6">
                        <h4 class="h4 text-center">Bootstrap</h4>                        
                        <p> I use bootstrap because it provides a good user experience for mobile and desktop browsers.(<a href="http://codeboxr.com/blogs/top-5-advantages-of-responsive-web-page-design" title="Link to more info.">Responsive Web Design</a>)</p>
                    </div>
                    <div class="col-md-6">
                        <h4 class="h4 text-center">Javascript</h4>
                        <p>In this project, I used javascript and jQuery to do validations on each text box when the user submits or edit an exercise.</p>
                    </div>
                </div>
                <div class="row">
                    <h2 class="text-center">Things to be done</h2>
                    <div class="col-md-12">
                        <ol>
                            <li>Password hashing</li>
                            <li>Redo in MVC</li>
                            <li>Redo using AngularJS and Web API</li>
                            <li>Add password changing capibility</li>
                            <li>Allow member cancellation</li>
                            <li>Make dropdown items more realistic</li>
                            <li>Style login controls</li>
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
