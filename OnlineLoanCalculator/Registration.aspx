<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OnlineLoanCalculator.Registration" %>
<asp:Content ID="FirstContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="SecondContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="signUp">
            <h1>Registration Form</h1>
            <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>Name:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtName" placeholder="Enter Full Name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="nameRequiredFieldValidator" runat="server" ControlToValidate="txtName"   
ErrorMessage="Please enter a user name" ForeColor="Red"></asp:RequiredFieldValidator>  
                    </asp:TableCell>
                </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>DateOfBirth:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtDate" placeholder="dd-mm-yyyy" TextMode="Date" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
    ErrorMessage="Invalid date format." ></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="dateRequiredFieldValidator" runat="server" ControlToValidate="txtName"   
ErrorMessage="Please enter a user name" ForeColor="Red"></asp:RequiredFieldValidator>  
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>EmailID:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtEmail" TextMode="Email" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="emailRegularExpressionValidator" runat="server" ControlToValidate="txtEmail"   
 ErrorMessage="Invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">  
             </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>  
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow>
                <asp:TableCell>Employment-Type:</asp:TableCell>
                <asp:TableCell> <asp:RadioButtonList ID="txtType" runat="server">  
                            <asp:ListItem>self-employed</asp:ListItem>  
                            <asp:ListItem>salaried</asp:ListItem>  
                        </asp:RadioButtonList> 
                <asp:RequiredFieldValidator ID="typeRequiredFieldValidator" runat="server" ControlToValidate="txtType" ForeColor="Red"></asp:RequiredFieldValidator>  
                </asp:TableCell>
                </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Monthly Salary
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="txtSalary" placeholder="Rs." TextMode="Number"  runat="server"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="salaryRegularExpressionValidator" runat="server" ControlToValidate="txtSalary"   
 ErrorMessage="Please enter valid salary" ForeColor="Red" ValidationExpression="[0-9]|^[a-z]|^[A-Z]">  
             </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="salaryRequiredFieldValidator" runat="server" ControlToValidate="txtSalary" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Current Company</asp:TableCell>
                    <asp:TableCell>
                <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="companyRegularExpressionValidator" runat="server" ControlToValidate="txtCompany"   
 ErrorMessage="invalid" ForeColor="Red" ValidationExpression="^[0-9]|[a-z]|[A-Z]">  
             </asp:RegularExpressionValidator>
              <asp:RequiredFieldValidator ID="companyRequiredFieldValidator " runat="server" ControlToValidate="txtCompany" ForeColor="Red"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Address</asp:TableCell>
                    <asp:TableCell>
                <asp:TextBox ID="txtAddress"  runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="addressRegularExpressionValidator" runat="server" ControlToValidate="txtAddress"   
 ErrorMessage="invalid address" ForeColor="Red" ValidationExpression="^[0-9]|[a-z]|[A-Z]">  
             </asp:RegularExpressionValidator>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompany" ForeColor="Red"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Pincode</asp:TableCell>
                    <asp:TableCell>
                <asp:TextBox ID="txtPincode" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                <asp:TableCell>MobileNumber:</asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server"  
ControlToValidate="txtNumber" ErrorMessage="Please Enter a mobilenumber" ForeColor="Red" 
ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>  
                    <asp:RequiredFieldValidator ID="valid" runat="server" ControlToValidate="txtNumber" ForeColor="Red"></asp:RequiredFieldValidator>  
                </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                <asp:TableCell>Password:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="password" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter a password"   
ForeColor="Red"></asp:RequiredFieldValidator>  
                </asp:TableCell>
            </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Button ID="btnCenter" text="Register" runat="server" OnClick="Button_Load"></asp:Button></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
</asp:Content>

