<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getblob.aspx.cs" Inherits="mysqlgrid.getblob" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
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
            <br />
            <br />
            <br />
            <br />
            <br />


        </div>
    </form>
</body>
</html>
