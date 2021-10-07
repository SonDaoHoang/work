<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DMChatLieu.aspx.cs" Inherits="QLBH.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <div style="margin-left: 200px">
            <asp:Label ID="lblDanhMucChatLieu" runat="server" Text="DANH MỤC CHẤT LIỆU"></asp:Label>
        </div>
        <asp:Label ID="lblThongBao" style="color:red" runat="server" Text="Thông Báo"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="lblTenChatLieu" runat="server" Text="Tên Chất Liệu"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTenChatLieu" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="lblMaChatLieu" runat="server" Text="Mã Chất Liệu"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtMaChatLieu" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:GridView ID="gvChatLieu" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="563px" AutoGenerateColumns="False" DataKeyNames="MaChatLieu" DataSourceID="QLBH">
            <Columns>

                <asp:BoundField DataField="MaChatLieu" HeaderText="Mã Chất Liệu" ReadOnly="True" SortExpression="MaChatLieu" />
                <asp:BoundField DataField="TenChatLieu" HeaderText="Tên Chất Liệu" SortExpression="TenChatLieu" />
                <asp:CommandField HeaderText="Sửa/Xóa" ShowDeleteButton="True" ShowEditButton="True" />

            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="QLBH" runat="server" ConnectionString="<%$ ConnectionStrings:QuanlybanhangConnectionString %>" SelectCommand="SELECT * FROM [tblChatLieu]" DeleteCommand="DELETE FROM [tblChatLieu] WHERE maChatLieu=@maChatLieu" UpdateCommand="UPDATE [tblChatLieu] SET TenChatLieu=@tenChatLieu WHERE MaChatLieu=@maChatLieu"></asp:SqlDataSource>
        <br />
        <asp:Button ID="btnThem" runat="server" Text="Thêm" Width="175px" OnClick="btnThem_Click" />
&nbsp;<asp:Button ID="btnLuu" runat="server" style="margin-left: 0px" Text="Lưu" Width="175px" OnClick="btnLuu_Click" />
&nbsp;<asp:Button ID="btnBoQua" runat="server" style="margin-left: 0px" Text="Bỏ qua" Width="205px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
