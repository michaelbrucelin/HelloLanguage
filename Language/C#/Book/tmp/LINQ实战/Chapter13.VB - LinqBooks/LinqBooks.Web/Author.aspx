<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Author.aspx.vb" Inherits="LinqBooks.Web.AuthorPage" Title="Author" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h1>Author</h1>
  
  <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
	  ondatabound="DetailsView1_DataBound">
		<fieldheaderstyle font-bold="True" />
	  <fields>
		  <asp:boundfield DataField="LastName" HeaderText="Last name" />
		  <asp:boundfield DataField="FirstName" HeaderText="First name" />
		  <asp:TemplateField HeaderText="Books">
		    <ItemTemplate>
		      <linqBooks:BookList ID="BookList" runat="server" />
		    </ItemTemplate>
		  </asp:TemplateField>
	  </fields>
  </asp:DetailsView>

  <div>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" 
		OnClientClick="if (!confirm('Are you sure?')) return false;" 
		onclick="btnDelete_Click" />
  </div>
</asp:Content>
