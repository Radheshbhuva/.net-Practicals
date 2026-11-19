using System;
using System.Web.UI;

namespace OnlineRegistrationForm
{
    public partial class Form : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string course = ddlCourse.SelectedValue;
            string gender = "";

            if (rbMale.Checked)
            {
                gender = "Male";
            }
            else if (rbFemale.Checked)
            {
                gender = "Female";
            }

            if (name == "")
            {
                lblMessage.Text = "Please enter your name.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (email == "")
            {
                lblMessage.Text = "Please enter your email.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (phone == "")
            {
                lblMessage.Text = "Please enter your phone number.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (gender == "")
            {
                lblMessage.Text = "Please select your gender.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (course == "")
            {
                lblMessage.Text = "Please select your course.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (txtPassword.Text == "")
            {
                lblMessage.Text = "Please enter a password.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (txtConfirmPassword.Text == "")
            {
                lblMessage.Text = "Please confirm your password.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblMessage.Text = "Passwords do not match.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            lblMessage.Text = "Registration Successful!";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}