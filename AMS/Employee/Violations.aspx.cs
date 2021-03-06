﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace AMS.Employee
{
    public partial class Violations : System.Web.UI.Page
    {
        DAL.Violation violation = new DAL.Violation();
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Session["UserId"] == null)
                {
                    Response.Redirect("~/Employee/Employee.aspx");
                }

                hfUserId.Value = Session["UserId"].ToString();

                BindData();

                if (!User.IsInRole("Admin") && !User.IsInRole("HR"))
                {
                    btnOpenModal.Visible = false;
                    gvViolations.Columns[1].Visible = false;
                    gvViolations.Columns[6].Visible = false;
                }
            }
        }

        private void BindData()
        {
            Guid UserId = Guid.Parse(hfUserId.Value);
            gvViolations.DataSource = violation.getViolationsById(UserId);
            gvViolations.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            violation.addViolation(
                Guid.Parse(hfUserId.Value),
                txtAddViolation.Text,
                txtAddCode.Text,
                txtAddDate.Text,
                txtAddRemarks.Text);

            BindData();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "HideShowModalScript", sb.ToString(), false);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            violation.updateViolation(
                txtEditViolation.Text,
                txtEditCode.Text,
                txtEditDate.Text,
                txtEditRemarks.Text,
                lblRowId.Text);

            BindData();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#updateModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
        }

        protected void gvViolations_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string rowId = ((Label)gvViolations.Rows[e.RowIndex].FindControl("lblRowId")).Text;
            violation.deleteViolation(rowId);

            BindData();
        }

        protected void gvViolations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            dt = new DataTable();

            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editRecord"))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                dt = violation.getViolationByRowId((int)(gvViolations.DataKeys[index].Value));
                lblRowId.Text = dt.Rows[0]["Id"].ToString();
                txtEditViolation.Text = dt.Rows[0]["VIOLATION"].ToString();
                txtEditCode.Text = dt.Rows[0]["CODE"].ToString();
                txtEditDate.Text = dt.Rows[0]["DATE"].ToString();
                txtEditRemarks.Text = dt.Rows[0]["REMARKS"].ToString();

                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#updateModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditShowModalScript", sb.ToString(), false);
            }
            else if (e.CommandName.Equals("deleteRecord"))
            {
                string rowId = ((Label)gvViolations.Rows[index].FindControl("lblRowId")).Text;
                hfDeleteId.Value = rowId;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#deleteModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteShowModalScript", sb.ToString(), false);
            }
        }

        protected void btnOpenModal_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            violation.deleteViolation(hfDeleteId.Value);

            BindData();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#deleteModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteHideModalScript", sb.ToString(), false);
        }
    }
}