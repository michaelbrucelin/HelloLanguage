<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Joins.aspx.vb" Inherits="Joins" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Joins</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h1>Group Join</h1>
      <asp:GridView ID="GridViewGroupJoin" AutoGenerateColumns="false" runat="server">
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

      <h1>Inner Join</h1>
      <asp:GridView ID="GridViewInnerJoin" runat="server">
      </asp:GridView>

      <h1>Left Outer Join</h1>
      <asp:GridView ID="GridViewLeftOuterJoin" runat="server">
      </asp:GridView>

      <h1>Cross Join</h1>
      <asp:GridView ID="GridViewCrossJoin" runat="server">
      </asp:GridView>
    </div>
    </form>
</body>
</html>