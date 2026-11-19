using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PlacementDashboard
{
    public partial class PlacementReport : System.Web.UI.Page
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings[
                "EmployeeConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT StudentId, EnrollmentNo, StudentName,
                           Department, CompanyName, PackageLPA,
                           PlacementStatus
                    FROM dbo.PlacementStudents
                    ORDER BY StudentId";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                using (SqlDataAdapter da =
                    new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            int total = dt.Rows.Count;
            int placed = 0;
            int notPlaced = 0;

            foreach (DataRow row in dt.Rows)
            {
                string status =
                    Convert.ToString(row["PlacementStatus"]);

                if (status == "Placed")
                {
                    placed++;
                }
                else if (status == "Not Placed")
                {
                    notPlaced++;
                }
            }

            double percentage = total > 0
                ? (placed * 100.0) / total
                : 0;

            lblTotal.Text = total.ToString();
            lblPlaced.Text = placed.ToString();
            lblNotPlaced.Text = notPlaced.ToString();

            lblPercentage.Text =
                percentage.ToString("0.00") + "%";

            lblDate.Text =
                DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");

            gvReport.DataSource = dt;
            gvReport.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}