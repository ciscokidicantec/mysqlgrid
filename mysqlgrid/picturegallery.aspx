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
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Stored Procedure To Insert BLOB" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Insert Stored Proceedure Using Array" Width="296px" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" Height="321px" Width="1138px">
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
            <asp:ListBox ID="ListBox1" runat="server" Height="357px" Width="990px"></asp:ListBox>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Not Started Yet."></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Width="1500px" BorderStyle="Groove" BorderColor="#000066">
            </asp:Panel>
        </div>
    </form>
</body>
</html>
