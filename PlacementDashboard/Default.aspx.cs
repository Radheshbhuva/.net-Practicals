using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PlacementDashboard
{
    public partial class Default : System.Web.UI.Page
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings[
                "EmployeeConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboard();
                LoadStudents("");
            }
        }

        private DataTable GetStudents(string searchName)
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
                    WHERE StudentName LIKE @StudentName
                    ORDER BY StudentId";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@StudentName",
                        SqlDbType.VarChar, 100).Value =
                        "%" + searchName.Trim() + "%";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        private void LoadDashboard()
        {
            using (SqlConnection con =
                new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        COUNT(*) AS TotalStudents,
                        SUM(CASE
                            WHEN PlacementStatus = 'Placed'
                            THEN 1 ELSE 0
                        END) AS PlacedStudents,
                        SUM(CASE
                            WHEN PlacementStatus = 'Not Placed'
                            THEN 1 ELSE 0
                        END) AS NotPlacedStudents
                    FROM dbo.PlacementStudents";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int total = Convert.ToInt32(
                                reader["TotalStudents"]);

                            int placed = Convert.ToInt32(
                                reader["PlacedStudents"]);

                            int notPlaced = Convert.ToInt32(
                                reader["NotPlacedStudents"]);

                            lblTotal.Text = total.ToString();
                            lblPlaced.Text = placed.ToString();
                            lblNotPlaced.Text = notPlaced.ToString();

                            double percentage = total > 0
                                ? (placed * 100.0) / total
                                : 0;

                            lblPercentage.Text =
                                percentage.ToString("0.00") + "%";
                        }
                    }
                }
            }
        }

        private void LoadStudents(string searchName)
        {
            gvPlacement.DataSource = GetStudents(searchName);
            gvPlacement.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvPlacement.PageIndex = 0;

            LoadStudents(txtSearch.Text);
            LoadDashboard();

            lblMessage.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            gvPlacement.PageIndex = 0;

            LoadStudents("");
            LoadDashboard();

            lblMessage.Text = "";
        }

        protected void gvPlacement_PageIndexChanging(
            object sender,
            System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvPlacement.PageIndex = e.NewPageIndex;

            LoadStudents(txtSearch.Text);
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlacementReport.aspx");
        }
    }
}