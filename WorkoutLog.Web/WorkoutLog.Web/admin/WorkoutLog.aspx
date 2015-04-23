<%@ Page Language="C#" MasterPageFile="../WorkoutLog.Master" Title="Content Page 1" AutoEventWireup="true" CodeBehind="WorkoutLog.aspx.cs" Inherits="WorkoutLog.Web.Workout1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="Server">
    <div class="container top-edge" id="fun">

        <div class="row">
            <div class="col-lg-12">
                <div class="starter-template">
                    <h1 id="form-header">Workout Tracker</h1>
                </div>
            </div>
        </div>

        <div class="row" id="errorList">
            <div class="col-lg-12">
                <div class="alert alert-danger" role="alert">
                    <ul>
                    </ul>
                </div>
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-2 control-label">Body Part</label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddlBodyParts" runat="server" CssClass="form-control" DataTextField="BodyPartName" DataValueField="ID">
                    <asp:ListItem Text="Arm" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Leg" Value="2"></asp:ListItem>
                </asp:DropDownList>
                
            </div>
        </div>

        <div class="form-group">
            <label class="col-sm-2 control-label">Exercise Type</label>
            <div class="col-sm-4">                
                <asp:DropDownList ID="ddlExerciseName" runat="server" CssClass="form-control" DataTextField="ExerciseName" DataValueField="ID">
                    <asp:ListItem Text="Tricep" Value="10"></asp:ListItem>
                    <asp:ListItem Text="Bicep" Value="11"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group" id="setsRow">
            <label class="col-lg-2 control-label">Sets</label>
            <div class="col-lg-4">
                <asp:TextBox ID="txtSets" runat="server" CssClass="form-control validate-number" data-error-text="Please Enter a valid input for SETS. Input must be an integer greater than 0."></asp:TextBox>
            </div>
            <div class="col-lg-6">
                <p class="bg-danger" id="setsMsg"></p>
            </div>
        </div>

        <div class="form-group" id="repsRow">
            <label class="col-lg-2 control-label">Reps</label>
            <div class="col-lg-4">
                <asp:TextBox ID="txtReps" runat="server" CssClass="form-control validate-number" data-error-text="Please Enter a valid input for REPS. Input must be an integer greater than 0."></asp:TextBox>
            </div>
            <div class="col-lg-6">
                <p class="bg-danger" id="repsMsg"></p>
            </div>
        </div>

        <div class="form-group" id="weightsRow">
            <label class="col-lg-2 control-label">Weights</label>
            <div class="col-lg-4">
                <asp:TextBox ID="txtWeights" runat="server" CssClass="form-control validate-number" data-error-text="Please Enter a valid input for WHEIGHTS. Input must be an integer greater than 0."></asp:TextBox>
            </div>
            <div class="col-lg-6">
                <p class="bg-danger" id="weightMsg"></p>
            </div>
        </div>

        <div class="form-group">
            <div class="col-lg-offset-2 col-lg-4">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary btn-save-workout" OnClick="btnSave_Click" />
                <a class="btn btn-danger" href="http://localhost:56792/admin/index.aspx">Cancel</a>
            </div>
        </div>
    </div>
    <!-- /.container -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Footer" runat="Server">
</asp:Content>



