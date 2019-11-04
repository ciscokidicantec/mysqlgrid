<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downloadimage.aspx.cs" Inherits="mysqlgrid.downloadimage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:estateportalConnectionString %>" ProviderName="<%$ ConnectionStrings:estateportalConnectionString.ProviderName %>" SelectCommand="SELECT * FROM images"></asp:SqlDataSource>
        </p>
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Download Image From Internet" Width="254px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Save The File To Disk As Well" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Insert Single Image Using SP BLOB" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Insert Multiple Images Using Stored Procedure" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" Height="321px" Width="1138px" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="250" imageurl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("image"))%>' />
                        </ItemTemplate>
                        <ItemStyle BorderColor="#FF6699" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:Image ID="Image1" runat="server" />
                </EmptyDataTemplate>
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
