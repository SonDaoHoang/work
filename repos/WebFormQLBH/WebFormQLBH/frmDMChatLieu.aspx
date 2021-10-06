<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDMChatLieu.aspx.cs" Inherits="WebFormQLBH.frmMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }
    </style>
</head>
<body style="height: 483px">
    <form id="form1" runat="server">
        <div class="auto-style1">
            Danh mục chất liệu<br />
            <br />
            Mã Chất Liệu:<br />
            <asp:TextBox ID="txtTenChatLieu" runat="server" OnTextChanged="TextBox2_TextChanged" Width="168px"></asp:TextBox>
            <br />
            Tên Chất Liệu:<br />
            <asp:TextBox ID="txtMaChatLieu" runat="server"></asp:TextBox>
            <asp:GridView ID="gvChatLieu" runat="server" AutoGenerateColumns="False" DataKeyNames="MaChatLieu" DataSourceID="SqlQLBH" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="692px">
                <Columns>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    <asp:BoundField DataField="MaChatLieu" HeaderText="MaChatLieu" ReadOnly="True" SortExpression="MaChatLieu" />
                    <asp:BoundField DataField="TenChatLieu" HeaderText="TenChatLieu" SortExpression="TenChatLieu" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlQLBH" runat="server" ConnectionString="<%$ ConnectionStrings:QuanLyBanHangConnectionString %>" SelectCommand="SELECT * FROM [tblChatLieu]"></asp:SqlDataSource>
            <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" />
            <asp:Button ID="btnLuu" runat="server" OnClick="btnSave_Click" Text="Lưu" />
            <asp:Button ID="btnBoQua" runat="server" Text="Bỏ qua" OnClick="btnBoQua_Click" />
            <br />
        </div>
    </form>
</body>
</html>
