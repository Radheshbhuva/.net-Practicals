<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PlacementDashboard.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Placement Dashboard</title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <style>
        body {
            margin: 0;
            font-family: Arial, sans-serif;
            background: #f3f6fb;
            color: #1f2937;
        }

        .header {
            background: #173b72;
            color: white;
            padding: 24px 35px;
        }

        .header h1 {
            margin: 0 0 8px;
        }

        .container {
            padding: 25px;
            max-width: 1200px;
            margin: auto;
        }

        .cards {
            display: flex;
            flex-wrap: wrap;
            gap: 18px;
            margin-bottom: 25px;
        }

        .card {
            flex: 1;
            min-width: 190px;
            background: white;
            padding: 22px;
            border-radius: 10px;
            box-shadow: 0 3px 12px #00000010;
        }

        .card h3 {
            margin-top: 0;
            color: #64748b;
            font-size: 15px;
        }

        .number {
            font-size: 30px;
            font-weight: bold;
            color: #173b72;
        }

        .panel {
            background: white;
            padding: 22px;
            border-radius: 10px;
            box-shadow: 0 3px 12px #00000010;
            margin-bottom: 22px;
        }

        .search {
            padding: 10px;
            width: 240px;
            max-width: 90%;
            border: 1px solid #cbd5e1;
            border-radius: 5px;
        }

        .button {
            padding: 10px 16px;
            background: #173b72;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin: 4px;
        }

        .button:hover {
            background: #24539a;
        }

        .grid {
            width: 100%;
            border-collapse: collapse;
            margin-top: 18px;
        }

        .grid th {
            background: #173b72;
            color: white;
            padding: 12px;
            text-align: left;
        }

        .grid td {
            padding: 12px;
            border-bottom: 1px solid #e2e8f0;
        }

        .grid tr:nth-child(even) {
            background: #f8fafc;
        }

        .message {
            display: block;
            margin-top: 12px;
            color: #b91c1c;
        }

        .table-wrap {
            overflow-x: auto;
        }

        @media (max-width: 600px) {
            .container {
                padding: 12px;
            }

            .header {
                padding: 20px;
            }
        }
    </style>
</head>

<body>
<form id="form1" runat="server">

    <div class="header">
        <h1>Placement Dashboard</h1>
        <p>Student Placement Management System</p>
    </div>

    <div class="container">

        <div class="cards">

            <div class="card">
                <h3>Total Students</h3>
                <asp:Label ID="lblTotal" runat="server"
                    CssClass="number" Text="0" />
            </div>

            <div class="card">
                <h3>Students Placed</h3>
                <asp:Label ID="lblPlaced" runat="server"
                    CssClass="number" Text="0" />
            </div>

            <div class="card">
                <h3>Not Placed</h3>
                <asp:Label ID="lblNotPlaced" runat="server"
                    CssClass="number" Text="0" />
            </div>

            <div class="card">
                <h3>Placement Percentage</h3>
                <asp:Label ID="lblPercentage" runat="server"
                    CssClass="number" Text="0%" />
            </div>

        </div>

        <div class="panel">

            <h2>Student Placement Records</h2>

            <asp:TextBox ID="txtSearch" runat="server"
                CssClass="search"
                placeholder="Enter student name" />

            <asp:Button ID="btnSearch" runat="server"
                Text="Search"
                CssClass="button"
                OnClick="btnSearch_Click" />

            <asp:Button ID="btnReset" runat="server"
                Text="Show All"
                CssClass="button"
                OnClick="btnReset_Click" />

            <asp:Button ID="btnReport" runat="server"
                Text="Generate Placement Report"
                CssClass="button"
                OnClick="btnReport_Click" />

            <asp:Label ID="lblMessage" runat="server"
                CssClass="message" />

            <div class="table-wrap">

                <asp:GridView ID="gvPlacement" runat="server"
                    AutoGenerateColumns="False"
                    CssClass="grid"
                    GridLines="None"
                    EmptyDataText="No placement records found."
                    AllowPaging="True"
                    PageSize="5"
                    OnPageIndexChanging="gvPlacement_PageIndexChanging">

                    <Columns>

                        <asp:BoundField DataField="StudentId"
                            HeaderText="ID" />

                        <asp:BoundField DataField="EnrollmentNo"
                            HeaderText="Enrollment No." />

                        <asp:BoundField DataField="StudentName"
                            HeaderText="Student Name" />

                        <asp:BoundField DataField="Department"
                            HeaderText="Department" />

                        <asp:BoundField DataField="CompanyName"
                            HeaderText="Company"
                            NullDisplayText="-" />

                        <asp:BoundField DataField="PackageLPA"
                            HeaderText="Package (LPA)"
                            DataFormatString="{0:N2}"
                            NullDisplayText="-" />

                        <asp:BoundField DataField="PlacementStatus"
                            HeaderText="Status" />

                    </Columns>

                </asp:GridView>

            </div>

        </div>

    </div>

</form>
</body>
</html>