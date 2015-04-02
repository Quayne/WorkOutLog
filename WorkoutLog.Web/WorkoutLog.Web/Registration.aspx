<%@ Page Language="C#" MasterPageFile="WorkoutLog.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WorkoutLog.Web.Registration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <div class="container top-edge" >
        
        <div class="form-group">
            <label class="col-lg-2 control-label">Username</label>
            <div class="col-lg-4">
                <input type="text" class="form-control" id="username" placeholder="Hazza" />
            </div>
            <div class="col-lg-6">
                <p class="bg-danger" id="usernameMsg"></p>              
            </div>
        </div>

      <div class="form-group">
        <label  class="col-sm-2 control-label">Email</label>
        <div class="col-lg-4">
          <input type="email" class="form-control" id="emailTextBox" placeholder="username@domain.com" />
        </div>
          <div class="col-lg-6">
              <p class="bg-danger" id="emailMsg"></p>
          </div>
      </div>

      <div class="form-group">
        <label class="col-lg-2 control-label">Password</label>
        <div class="col-lg-4">
          <input type="password" class="form-control" id="password" placeholder="Password" />
        </div> 
          <div class="col-lg-6">
              <p class="bg-danger" id="passwordMsg"></p>
          </div>
      </div>

      <div class="form-group">
        <label class="col-lg-2 control-label">Confirm Password</label>
        <div class="col-lg-4">
          <input type="password" class="form-control" id="confirmPassword" placeholder="Re-type Password" />
        </div> 
      </div>
        

      <div class="form-group">
        <div class="col-lg-offset-2 col-lg-4">
          <button type="submit" class="btn btn-default" onclick="return submitRegistrationEvent()">Register</button>
        </div>
      </div>

    </div>
</asp:Content>