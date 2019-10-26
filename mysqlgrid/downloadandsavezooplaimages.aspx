<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downloadandsavezooplaimages.aspx.cs" Inherits="mysqlgrid.downloadandsavezooplaimages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Download Zoopla Pictures and Save Tem By Post Code" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Download Image From Database Using Stream" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Image ID="Image1" runat="server" Height="235px" Width="255px" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Width="1500px" BorderStyle="Groove" BorderColor="#000066" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
