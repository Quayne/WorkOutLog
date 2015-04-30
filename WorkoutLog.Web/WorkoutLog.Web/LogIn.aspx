<%@ Page Language="C#" MasterPageFile="WorkoutLog.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WorkoutLog.Web.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <div class="container top-edge" >

      <div class="form-group">
        <label class="col-sm-2 control-label">Email</label>
        <div class="col-sm-4">
          <input type="email" class="form-control" name="login_email" id="login_email" placeholder="email@something.com" />
        </div>
      </div>

      <div class="form-group">
        <label class="col-sm-2 control-label">Password</label>
        <div class="col-sm-4">
          <input type="password" class="form-control" name="login_password" id="login-password" placeholder="Password" />
        </div> 
      </div>

      <div class="form-group">
        <div class="col-sm-offset-2 col-sm-4">
          <div class="checkbox">
            <label>
              <input type="checkbox" /> Remember me
            </label>
          </div>
        </div>
      </div>

      <div class="form-group">
        <div class="col-sm-offset-2 col-sm-4">
          <button type="submit" class="btn btn-default" onclick="SubmitCredentials">Log in</button>
        </div>
      </div>

       

    </div>
</asp:Content>