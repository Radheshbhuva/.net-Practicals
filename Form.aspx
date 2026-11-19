<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs"
    Inherits="OnlineRegistrationForm.Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Registration Form</title>

    <style>
        body {
            font-family: Arial;
            background-color: #f2f2f2;
        }

        .container {
            width: 500px;
            margin: 30px auto;
            background-color: white;
            padding: 25px;
            border-radius: 8px;
            box-shadow: 0 0 10px gray;
        }

        h2 {
            text-align: center;
            color: #333333;
        }

        .row {
            margin-bottom: 15px;
        }

        .label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .textbox,
        .dropdown {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
        }

        .button {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            cursor: pointer;
            font-size: 16px;
        }

        .button:hover {
            background-color: #0056b3;
        }

        .message {
            display: block;
            margin-top: 15px;
            text-align: center;
            font-weight: bold;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="container">

            <h2>Student Registration Form</h2>

            <div class="row">
                <asp:Label ID="lblName" runat="server"
                    Text="Full Name" CssClass="label"></asp:Label>

                <asp:TextBox ID="txtName" runat="server"
                    CssClass="textbox"></asp:TextBox>
            </div>

            <div class="row">
                <asp:Label ID="lblEmail" runat="server"
                    Text="Email" CssClass="label"></asp:Label>

                <asp:TextBox ID="txtEmail" runat="server"
                    CssClass="textbox"
                    TextMode="Email"></asp:TextBox>
            </div>

            <div class="row">
                <asp:Label ID="lblPhone" runat="server"
                    Text="Phone Number" CssClass="label"></asp:Label>

                <asp:TextBox ID="txtPhone" runat="server"
                    CssClass="textbox"></asp:TextBox>
            </div>

            <div class="row">
                <asp:Label ID="lblGender" runat="server"
                    Text="Gender" CssClass="label"></asp:Label>

                <asp:RadioButton ID="rbMale" runat="server"
                    Text="Male" GroupName="Gender" />

                &nbsp;&nbsp;

                <asp:RadioButton ID="rbFemale" runat="server"
                    Text="Female" GroupName="Gender" />
            </div>

            <div class="row">
                <asp:Label ID="lblCourse" runat="server"
                    Text="Course" CssClass="label"></asp:Label>

                <asp:DropDownList ID="ddlCourse" runat="server"
                    CssClass="dropdown">

                    <asp:ListItem Text="-- Select Course --"
                        Value=""></asp:ListItem>

                    <asp:ListItem Text="B.Tech Computer Engineering"
                        Value="B.Tech Computer Engineering"></asp:ListItem>

                    <asp:ListItem Text="B.Tech Information Technology"
                        Value="B.Tech Information Technology"></asp:ListItem>

                    <asp:ListItem Text="BCA"
                        Value="BCA"></asp:ListItem>

                    <asp:ListItem Text="MCA"
                        Value="MCA"></asp:ListItem>

                </asp:DropDownList>
            </div>

            <div class="row">
                <asp:Label ID="lblPassword" runat="server"
                    Text="Password" CssClass="label"></asp:Label>

                <asp:TextBox ID="txtPassword" runat="server"
                    CssClass="textbox"
                    TextMode="Password"></asp:TextBox>
            </div>

            <div class="row">
                <asp:Label ID="lblConfirmPassword" runat="server"
                    Text="Confirm Password" CssClass="label"></asp:Label>

                <asp:TextBox ID="txtConfirmPassword" runat="server"
                    CssClass="textbox"
                    TextMode="Password"></asp:TextBox>
            </div>

            <div class="row">
                <asp:Button ID="btnRegister" runat="server"
                    Text="Register"
                    CssClass="button"
                    OnClick="btnRegister_Click" />
            </div>

            <asp:Label ID="lblMessage" runat="server"
                CssClass="message"></asp:Label>

        </div>

    </form>
</body>
</html>