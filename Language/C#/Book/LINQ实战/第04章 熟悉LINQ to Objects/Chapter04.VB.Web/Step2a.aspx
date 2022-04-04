<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Step2a.aspx.vb" Inherits="Step2a" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Step 2 - Grid columns</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
          <asp:BoundField HeaderText="Book" DataField="Title" />
          <asp:BoundField HeaderText="Price" DataField="Price" />
        </Columns>
      </asp:GridView>
    </div>
    </form>
</body>
</html>