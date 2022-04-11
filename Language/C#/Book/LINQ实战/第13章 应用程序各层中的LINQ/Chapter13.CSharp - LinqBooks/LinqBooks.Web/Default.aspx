<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinqBooks.Web._Default" MasterPageFile="~/Main.Master" Title="Home" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="MainContent">
  <asp:HyperLink ID="lnkRss" runat="server" SkinId="RSS" NavigateUrl="~/RSS.asmx/GetReviews" />
</asp:Content>