<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AuthorList.ascx.vb" Inherits="LinqBooks.Web.AuthorList" %>

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