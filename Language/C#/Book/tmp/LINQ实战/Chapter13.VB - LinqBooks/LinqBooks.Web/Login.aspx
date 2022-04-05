<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Login.aspx.vb" Inherits="LinqBooks.Web.Login" Title="Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div>
    <asp:Login ID="Login1" runat="server" RememberMeSet="True" />
  </div>
  <div>Sample user: <b>user1/user1</b></div>
</asp:Content>