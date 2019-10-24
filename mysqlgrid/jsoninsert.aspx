<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jsoninsert.aspx.cs" Inherits="mysqlgrid.jsoninsert" %>

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
    <form id="form1" runat="server">
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="height: 26px" Text="Button" />
        </p>
        <div>
    <svg>
        <circle cx="280" cy="40" r="196" style="stroke:#006600; fill:#00cc00"/>
    </svg>
    <img src="Data/octicons.svg" height="350" />
    <asp:GridView ID="grdJSON2Grid" runat="server">
            </asp:GridView>
            <br />
            <br />
            <br />
    <asp:GridView ID="grdJSON3Grid" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:GridView ID="grdJSON4Grid" runat="server">
            </asp:GridView>
            <br />
        </div>
    <svg     4
       xmlns="http://www.w3.org/2000/svg"     5
       version="1.1"
       width="150"
       height="150">
      <rect width="90" height="90" x="30" y="30" style="fill:#0000ff;fill-opacity:0.75;stroke:#000000"/>
    </svg>
    </form>
</body>
</html>
