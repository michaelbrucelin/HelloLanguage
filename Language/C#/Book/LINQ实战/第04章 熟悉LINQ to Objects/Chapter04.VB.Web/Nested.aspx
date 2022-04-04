<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Nested.aspx.vb" Inherits="Nested" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Nested queries</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
          <asp:BoundField HeaderText="Publisher" DataField="Publisher" />
          <asp:TemplateField HeaderText="Books">
            <ItemTemplate>
              <asp:BulletedList ID="BulletedList1" runat="server"
                DataSource='<% #Eval("Books") %>' DataValueField="Title" />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </div>
    </form>
</body>
</html>