using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using WebFormQLBH;
using System.Configuration;

namespace WebFormQLBH
{
    public partial class frmMain : System.Web.UI.Page
    {
        DataTable tblCL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

            }
            Function.Connect();
            txtMaChatLieu.Enabled = false;
            txtTenChatLieu.Enabled = true;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaChatLieu.Text.Trim().Length == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' Bạn phải nhập tên chất liệu ');", true);
                txtMaChatLieu.Focus();
                return;
            }
            if (txtTenChatLieu.Text.Trim().Length == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' Bạn phải nhập mã chất liệu ');", true);
                txtTenChatLieu.Focus();
                return;
            }
            sql = "Select MaChatLieu From tblChatLieu where MaChatLieu=N'" + txtMaChatLieu.Text.Trim() + "'";
            if (Function.CheckKey(sql))
            {
                sql = "UPDATE tblChatLieu SET TenChatLieu=N'" + txtTenChatLieu.Text + "'WHERE MaChatLieu=N'" + txtMaChatLieu.Text.ToString() + "'";
                Function.RunSQL(sql);
                return;
            }
            sql = "INSERT INTO tblChatLieu VALUES(N'" + txtTenChatLieu.Text + "',N'" + txtMaChatLieu.Text + "')";
            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaChatLieu.Enabled = false;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaChatLieu, TenChatLieu FROM tblChatLieu";
            tblCL = Function.GetDataToTable(sql);
            //gvChatLieu.DataSource = tblCL;
            gvChatLieu.Columns[0].HeaderText = "Mã Chất Liệu";
            gvChatLieu.Columns[1].HeaderText = "Tên Chất Liệu";
            gvChatLieu.AllowCustomPaging = false;
        }
        private void ResetValue()
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvChatLieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql;
            sql = "delete FROM detail where id='" + Convert.ToInt32(gvChatLieu.DataKeys[e.RowIndex].Value.ToString()) + "'";
            GridViewRow row = (GridViewRow)gvChatLieu.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("lblID");
            Function.Connect();
            Function.RunSQL(sql);
            LoadDataGridView();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMaChatLieu.Enabled = true;
            txtTenChatLieu.Enabled = true;
            txtMaChatLieu.Focus();
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCL.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' Không còn dữ liệu ');", true);
                return;
            }

            if (txtTenChatLieu.Text.Trim().Length == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Bạn chưa nhập mã chất liệu');", true);
                return;
            }

            txtMaChatLieu.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnBoQua.Enabled = false;
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCL.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Không còn dữ liệu');", true);
                return;
            }
            else
            {
                sql = "DELETE TOP(1) FROM tblChatLieu";
                Function.RunSQL(sql);
                LoadDataGridView();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        protected void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
        }
    }
}