<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Default.aspx.vb" Inherits="LinqBooks.Web._Default" Title="Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <asp:HyperLink ID="lnkRss" runat="server" SkinId="RSS" NavigateUrl="~/RSS.asmx/GetReviews" />
</asp:Content>