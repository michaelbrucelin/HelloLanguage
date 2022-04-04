<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Partitioning.aspx.vb" Inherits="Partitioning" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Partitioning</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h1>Complete results</h1>
      <asp:GridView ID="GridViewComplete" runat="server" />

      <h1>Partial results</h1>
      Start: <asp:DropDownList ID="ddlStart" runat="server" AutoPostBack="True" CausesValidation="True" OnSelectedIndexChanged="ddlStart_SelectedIndexChanged" />
      End: <asp:DropDownList ID="ddlEnd" runat="server" AutoPostBack="True" CausesValidation="True" OnSelectedIndexChanged="ddlStart_SelectedIndexChanged" />
      <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlStart"
        ControlToCompare="ddlEnd" ErrorMessage="The second index must be higher than the first one"
        Operator="LessThanEqual" Type="Integer" /><br />
      <asp:GridView ID="GridViewPartial" runat="server" />
    </div>
    </form>
</body>
</html>