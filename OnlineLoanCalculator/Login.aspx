<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineLoanCalculator.Login" %>
<asp:Content ID="FirstContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="SecondContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div>
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>UserID</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtID" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Password</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox1" TextMode="Password" size="16" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="password" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter a password"   
ForeColor="Red"></asp:RequiredFieldValidator>  
                </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                  <asp:TableCell><asp:Button ID="btnCenter" text="Login" runat="server" OnClick="Button_Click"></asp:Button></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
 </asp:Content>