<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWebForm7.aspx.cs" Inherits="Temp_WebApplication.MyTest.MyWebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="./MyStyleSheet7.css" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCookieId" CssClass="label" runat="server" Text="CookieId"></asp:Label>
            <asp:TextBox ID="txtCookieId" CssClass="textbox" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblCookieValue" CssClass="label" runat="server" Text="CookieValue/SessionId"></asp:Label>
            <asp:TextBox ID="txtCookieValue" CssClass="textbox" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblSessionValueKey" CssClass="label" runat="server" Text="SessionValue_Key"></asp:Label>
            <asp:TextBox ID="txtSessionValueKey" CssClass="textbox" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblSessionValueValue" CssClass="label" runat="server" Text="SessionValue_Value"></asp:Label>
            <asp:TextBox ID="txtSessionValueValue" CssClass="textbox" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSet" CssClass="button" runat="server" Text="Set" OnClick="btnSet_Click" />
            <asp:Button ID="btnGet" CssClass="button" runat="server" Text="Get" OnClick="btnGet_Click" />
            <asp:Label ID="lblTips" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
