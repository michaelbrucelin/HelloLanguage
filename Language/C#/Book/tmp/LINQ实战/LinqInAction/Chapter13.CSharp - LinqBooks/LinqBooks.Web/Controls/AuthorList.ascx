<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuthorList.ascx.cs" Inherits="LinqBooks.Web.Controls.AuthorList" %>

<asp:GridView ID="GridViewAuthors" runat="server" AutoGenerateColumns="False" 
  BorderStyle="None" ShowHeader="False" Width="100%" DataKeyNames="ID" 
onrowdeleting="GridViewAuthors_RowDeleting">
  <columns>
    <asp:hyperlinkfield DataNavigateUrlFields="Id" 
      DataNavigateUrlFormatString="~/Author.aspx?ID={0}" DataTextField="FullName" 
      HeaderText="Name" />
    <asp:CommandField ButtonType="Button" ShowDeleteButton="true" />
  </columns>
</asp:GridView>