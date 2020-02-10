﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs"
    Inherits="OnlineLoanCalculator.Home"%>

<asp:Content ID="FirstContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="SecondContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:GridView ID="GridViewId" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True"
        AutoGenerateEditButton="True" DataKeyNames="id" OnRowCancelingEdit="GridView_RowCancelingEdit"
        OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing"
        OnRowUpdating="GridView_RowUpdating" ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="100">
                <ItemTemplate>
                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="insertId" runat="server" Text="Insert" OnClick="InsertClick"></asp:Button>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" MaxLength="30" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="nameId" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="DateOfBirth">
                <EditItemTemplate>
                    <asp:TextBox ID="txtBirth" MaxLength="30" runat="server" Text='<%# Bind("dateofbirth") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblBirth" runat="server" Text='<%# Bind("dateofbirth") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="birthId" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmail" MaxLength="30" runat="server" Text='<%# Bind("email_id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email_id") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="emailId" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="EmploymentType">
                <EditItemTemplate>
                    <asp:TextBox ID="txtType" MaxLength="30" runat="server" Text='<%# Bind("employment_type") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblType" runat="server" Text='<%# Bind("employment_type") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="typeId" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Monthly_Salary">
                <EditItemTemplate>
                    <asp:TextBox ID="txtSalary" MaxLength="30" runat="server" Text='<%# Bind("monthly_salary") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSalary" runat="server" Text='<%# Bind("monthly_salary") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="salaryId" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Current_Company">
                <EditItemTemplate>
                    <asp:TextBox ID="txtCompany" MaxLength="30" runat="server" Text='<%# Bind("current_company") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCompany" runat="server" Text='<%# Bind("current_company") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="companyId" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAddress" MaxLength="30" runat="server" Text='<%# Bind("address") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("address") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="addressId" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pincode">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPincode" MaxLength="6" runat="server" Text='<%# Bind("pincode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPincode" runat="server" Text='<%# Bind("pincode") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="pincodeId" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="MobileNumber">
                <EditItemTemplate>
                    <asp:TextBox ID="txtNumber" MaxLength="10" runat="server" Text='<%# Bind("mobilenumber") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblNumber" runat="server" Text='<%# Bind("mobilenumber") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="mobileId" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Password">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPassword" MaxLength="30" runat="server" Text='<%# Bind("customer_password") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPassword" runat="server" Text='<%# Bind("customer_password") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="passwordId" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

