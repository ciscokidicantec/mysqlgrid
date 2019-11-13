<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getdetails.aspx.cs" Inherits="mysqlgrid.getdetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <asp:ListBox ID="ListBox1" runat="server" Height="437px" Width="712px"></asp:ListBox>
        <asp:ListBox ID="ListBox3" runat="server" Height="430px" Width="1049px"></asp:ListBox>
    </p>
        <p>
            <asp:ListBox ID="ListBox2" runat="server" CssClass="auto-style1" Height="288px" Width="713px"></asp:ListBox>
    </p>

        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Details And Price Search For &lt;a href" Width="402px" />
        </div>
    </form>
</body>
</html>
