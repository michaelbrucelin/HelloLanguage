<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sorting.aspx.cs" Inherits="Sorting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sorting</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server">
        <Columns>
          <asp:BoundField HeaderText="Publisher" DataField="Publisher" />
          <asp:BoundField HeaderText="Price" DataField="Price" />
          <asp:BoundField HeaderText="Book" DataField="Title" />
        </Columns>
      </asp:GridView>
    </div>
    </form>
</body>
</html>
