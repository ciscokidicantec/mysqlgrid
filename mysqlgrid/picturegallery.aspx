<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="picturegallery.aspx.cs" Inherits="mysqlgrid.picturegallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="FILE LOAD INSERT BLOB" Width="283px" />
            <br />
            <asp:Panel ID="Panel1" runat="server" Width="1500px" BorderStyle="Groove" BorderColor="#000066">
            </asp:Panel>
        </div>
    </form>
</body>
</html>
