using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace QLBH
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable tblCL;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = " ";
            Function.Connect();
            txtMaChatLieu.Enabled = false;
            txtTenChatLieu.Enabled = false;
            btnBoQua.Enabled = false;
            if (gvChatLieu.Rows.Count == 0)
            {
                lblThongBao.Text = "Chưa có dữ liệu";
            }    
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void LoadDataGridView()
        {
            string sql;
            sql = "SELECT maChatLieu, tenChatLieu FROM tblChatLieu";
            tblCL = GetDataToTable(sql);
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = " ";
            txtTenChatLieu.Enabled = true;
            txtMaChatLieu.Enabled = true;
            btnBoQua.Enabled = true;
            txtTenChatLieu.Focus();
            return;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.QLBHConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "INSERT INTO tblChatLieu(tenChatLieu,maChatLieu) VALUES(@tenChatLieu, @maChatLieu)";
            if (txtTenChatLieu.Text.Trim().Length == 0)
            {
                lblThongBao.Text = "Vui lòng nhập tên chất liệu";
                txtTenChatLieu.Focus();
                return;
            }
            if (txtMaChatLieu.Text.Trim().Length == 0)
            {
                lblThongBao.Text = "Vui lòng nhập mã chất liệu";
                txtMaChatLieu.Focus();
                return;
            }
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@tenChatLieu", txtTenChatLieu.Text);
            command.Parameters.AddWithValue("@maChatLieu", txtMaChatLieu.Text);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                lblThongBao.Text = "Lưu Thành Công";
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch(SqlException s)
            {
                lblThongBao.Text = "Trùng Mã Chất Liệu! Lưu Thất Bại";
                txtTenChatLieu.Enabled = true;
                txtMaChatLieu.Enabled = true;
                txtMaChatLieu.Focus();
            }
        }
        protected DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Function.Con);
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = Function.Con;
            dap.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }
    }
}