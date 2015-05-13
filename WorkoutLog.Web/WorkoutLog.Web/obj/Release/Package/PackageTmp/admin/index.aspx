<%@ Page Language="C#" MasterPageFile="/WorkoutLog.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WorkoutLog.Web.WorkoutTable" %>





<asp:Content ID="Content5" ContentPlaceHolderID="Header" runat="Server">
    <div class="container top-edge">
        <div class="row">
            <div class="col-lg-8">
                <h1>Hello
                    <asp:Label Text="" ID="LoginName" runat="server" />
                </h1>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="Server">

    <div class="container">        

        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-hover table-condensed">
                    <thead>
                        <tr>
                            <th>Sets</th>
                            <th>Body Part</th>
                            <th>Exercise</th>
                            <th>Weights</th>
                            <th>Reps</th>
                            <th>Total Weight</th>
                            <th>&nbsp</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td><%#Eval("ExerciseSets")%></td>
                        <td><%#Eval("BodyParts")%></td>
                        <td><%#Eval("ExerciseName")%></td>
                        <td><%#Eval("Weights")%></td>
                        <td><%#Eval("Reps")%></td>
                        <td><%#Eval("TotalWeights")%></td>
                        <td class="fixed-column">
                            <a href="WorkoutLog.aspx?id=<%# Eval("ID") %>" class="btn btn-default">Edit</a>
                            <asp:Button ID="btnDelete" Text="Delete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("ID") %>' OnCommand="btnDelete_Command" OnClientClick="return confirm('Are you sure you want to delete this record?');" CssClass="btn btn-warning" />
                        </td>
                    </tr>
                </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div class="row">
            <div class="col-lg-12">
                <a class="btn btn-primary btn-md btn-block" href="WorkoutLog.aspx">Add New</a>
            </div>
        </div>
    </div>
    
</asp:Content>
