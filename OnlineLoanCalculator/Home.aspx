﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OnlineLoanCalculator.Home" %>
<asp:Content ID="FirstContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="SecondContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="id" OnRowDataBound="RowDataBound" OnRowUpdating="RowUpdating" OnRowDeleting="RowDeleting" EmptyDataText="No records has been added." AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" AutoGenerateColumns="false" AllowPaging="true"
    OnPageIndexChanging="OnPaging" OnRowEditing="RowEditing" OnRowCancelingEdit="RowCancelingEdit" PageSize="4">
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="id" HeaderText="Customer ID" />
        <asp:BoundField ItemStyle-Width="150px" DataField="name" HeaderText="Customer Name" />
        <asp:BoundField ItemStyle-Width="150px" DataField="current_company" HeaderText="Company" />
        <asp:BoundField ItemStyle-Width="150px" DataField="monthly_salary" HeaderText="Monthly_Salary" />
         </Columns>
</asp:GridView>
</asp:Content>

