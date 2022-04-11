<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Authors.aspx.vb" Inherits="LinqBooks.Web.Authors" Title="Authors" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h1>Authors</h1>
  
  <asp:UpdatePanel ID="updAuthors" runat="server" RenderMode="Block">
    <ContentTemplate>
      <asp:GridView ID="GridViewAuthors" runat="server" AutoGenerateColumns="False" 
	  onrowdatabound="GridViewAuthors_RowDataBound">
	  <columns>
		  <asp:hyperlinkfield DataNavigateUrlFields="ID" 
		    DataNavigateUrlFormatString="~/Author.aspx?ID={0}" DataTextField="FullName" 
		    HeaderText="Name">
		  </asp:hyperlinkfield>
	    <asp:TemplateField HeaderText="Books">
	      <ItemTemplate>
		      <linqBooks:BookList ID="BookList" runat="server" />
	      </ItemTemplate>
	    </asp:TemplateField>
	  </columns>
  </asp:GridView>
    </ContentTemplate>
  </asp:UpdatePanel>
  
  <asp:UpdateProgress ID="UpdateProgressAddAuthor" runat="server" AssociatedUpdatePanelID="updAddAuthor">
    <ProgressTemplate>
      <asp:Image ID="imgProgress" runat="server" SkinID="Progress" />
    </ProgressTemplate>
  </asp:UpdateProgress>
  <asp:UpdatePanel ID="updAddAuthor" runat="server" RenderMode="Block">
    <ContentTemplate>

      <p><asp:Button ID="btnShowAddAuthor" runat="server" Text="Add an author..." 
	      onclick="btnShowAddAuthor_Click" /></p>
	    
      <div id="divAddAuthor" runat="server" visible="false">
        <div>
          <div>
            First name: <asp:TextBox ID="txtFirstName" runat="server" />
            <asp:RequiredFieldValidator ID="vldFirstName" runat="server" ErrorMessage="First name required" ControlToValidate="txtFirstName" />
          </div>
          <div>
            Last name: <asp:TextBox ID="txtLastName" runat="server" />
            <asp:RequiredFieldValidator ID="vldLastName" runat="server" ErrorMessage="Last name required" ControlToValidate="txtLastName" />
          </div>
          <asp:Button ID="btnAddAuthor" runat="server" Text="Add this author" 
		        onclick="btnAddAuthor_Click" />
		    </div>
      </div>
      
    </ContentTemplate>
  </asp:UpdatePanel>
  
</asp:Content>
