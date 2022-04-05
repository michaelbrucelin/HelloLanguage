<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookList.ascx.cs" Inherits="LinqBooks.Web.Controls.BookList" %>

<asp:GridView ID="GridViewBooks" runat="server"
  AutoGenerateColumns="False" 
  BorderStyle="None" ShowHeader="False" Width="100%">
  <Columns>
    <asp:HyperLinkField DataNavigateUrlFields="Id" 
      DataNavigateUrlFormatString="~/Book.aspx?ID={0}"
      DataTextField="Title" 
      HeaderText="Title" />
  </Columns>
</asp:GridView>