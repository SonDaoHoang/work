using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WebFormQLBH
{
    public partial class _Default : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\source\repos\Quanlybanhang\Quanlybanhang\QuanLyBanHang.mdf;Integrated Security=True;Connect Timeout=30");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvbind();
            }
        }
        protected void gvbind()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from detail", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                .DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
        }  
{
    public static class MessageBox
        {
            public static void Show(this Page Page, string Message)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "myalert", "<script language='javascript'>alert('" + Message + "');</script>");
            }
        }
        public class Function
        {
            public static SqlConnection Con;
            public static void Connect()
            {
                Con = new SqlConnection();
                Con.ConnectionString = Properties.Settings.Default.QLBanHangConnectionString;
                Con.Open();
            }
            public static void Disconnect()
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                    Con.Dispose();
                    Con = null;
                }
            }
            public static DataTable GetDataToTable(string sql)
            {
                SqlDataAdapter dap = new SqlDataAdapter();
                dap.SelectCommand = new SqlCommand();
                dap.SelectCommand.Connection = Con;
                dap.SelectCommand.CommandText = sql;
                DataTable table = new DataTable();
                dap.Fill(table);
                return table;
            }
            public static void RunSQL(string sql)
            {
                SqlCommand cmd;
                cmd = new SqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
                cmd.Dispose();
                cmd = null;
            }
            public static bool CheckKey(string sql)
            {
                SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
                DataTable table = new DataTable();
                dap.Fill(table);
                if (table.Rows.Count > 0)
                    return true;
                else return false;
            }

        }
    }
}