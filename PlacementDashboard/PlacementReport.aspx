<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="PlacementReport.aspx.cs"
    Inherits="PlacementDashboard.PlacementReport" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Student Placement Report</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            background: #f1f5f9;
            color: #1e293b;
            margin: 0;
            padding: 25px;
        }

        .report {
            max-width: 1100px;
            margin: auto;
            padding: 30px;
            background: white;
            border-radius: 8px;
        }

        h1, .subtitle {
            text-align: center;
        }

        .summary {
            display: flex;
            flex-wrap: wrap;
            gap: 15px;
            margin: 25px 0;
        }

        .card {
            flex: 1;
            min-width: 150px;
            padding: 18px;
            background: #eff6ff;
            border: 1px solid #bfdbfe;
            border-radius: 6px;
        }

        .card h3 {
            font-size: 14px;
        }

        .number {
            font-size: 26px;
            font-weight: bold;
        }

        .grid {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .grid th {
            background: #173b72;
            color: white;
            padding: 10px;
            text-align: left;
        }

        .grid td {
            padding: 10px;
            border: 1px solid #dbe3ed;
        }

        .actions {
            margin: 20px 0;
            text-align: center;
        }

        .button {
            padding: 10px 18px;
            background: #173b72;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin: 5px;
        }

        @media print {
            body {
                background: white;
                padding: 0;
            }

            .report {
                max-width: none;
                padding: 0;
            }

            .actions {
                display: none;
            }

            .card {
                break-inside: avoid;
            }

            .grid {
                font-size: 10px;
            }

            .grid th {
                background: #dbeafe !important;
                color: black !important;
                -webkit-print-color-adjust: exact;
                print-color-adjust: exact;
            }

            .grid tr {
                break-inside: avoid;
            }
        }
    </style>

    <script>
        function printReport() {
            window.print();
        }
    </script>
</head>

<body>
<form id="form1" runat="server">

    <div class="report">

        <div class="actions">
            <asp:Button ID="btnBack" runat="server"
                Text="Back to Dashboard"
                CssClass="button"
                CausesValidation="false"
                OnClick="btnBack_Click" />

            <button type="button" class="button"
                onclick="printReport()">
                Print / Save as PDF
            </button>
        </div>

        <h1>STUDENT PLACEMENT REPORT</h1>

        <p class="subtitle">
            Placement Management System
        </p>

        <p>
            <strong>Report Generated:</strong>
            <asp:Label ID="lblDate" runat="server" />
        </p>

        <div class="summary">

            <div class="card">
                <h3>Total Students</h3>
                <asp:Label ID="lblTotal" runat="server"
                    CssClass="number" />
            </div>

            <div class="card">
                <h3>Students Placed</h3>
                <asp:Label ID="lblPlaced" runat="server"
                    CssClass="number" />
            </div>

            <div class="card">
                <h3>Not Placed</h3>
                <asp:Label ID="lblNotPlaced" runat="server"
                    CssClass="number" />
            </div>

            <div class="card">
                <h3>Placement Percentage</h3>
                <asp:Label ID="lblPercentage" runat="server"
                    CssClass="number" />
            </div>

        </div>

        <h2>Placement Details</h2>

        <div style="overflow-x:auto;">

            <asp:GridView ID="gvReport" runat="server"
                AutoGenerateColumns="False"
                CssClass="grid"
                GridLines="None"
                EmptyDataText="No placement records found.">

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

</form>
</body>
</html>