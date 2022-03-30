<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LinqBooks.Web.Login" Title="Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div>
    <asp:Login ID="Login1" runat="server" RememberMeSet="True" />
  </div>
  <div>Sample user: <b>user1/user1</b></div>
</asp:Content>