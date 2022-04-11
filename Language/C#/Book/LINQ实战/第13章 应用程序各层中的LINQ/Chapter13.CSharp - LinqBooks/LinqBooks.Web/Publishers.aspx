<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Publishers.aspx.cs" Inherits="LinqBooks.Web.Publishers" Title="Publishers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h1>Publishers</h1>
  
  <asp:UpdatePanel ID="updPublishers" runat="server" RenderMode="Block">
    <ContentTemplate>
      <asp:GridView ID="GridViewPublishers" runat="server" AutoGenerateColumns="False" 
	      OnRowDatabound="GridViewPublishers_RowDataBound">
	      <columns>
		      <asp:hyperlinkfield DataNavigateUrlFields="ID" 
		        DataNavigateUrlFormatString="~/Publisher.aspx?ID={0}" DataTextField="Name" 
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
  
  <asp:UpdateProgress ID="UpdateProgressAddPublisher" runat="server" AssociatedUpdatePanelID="updAddPublisher">
    <ProgressTemplate>
      <asp:Image ID="imgProgress" runat="server" SkinID="Progress" />
    </ProgressTemplate>
  </asp:UpdateProgress>
  <asp:UpdatePanel ID="updAddPublisher" runat="server" RenderMode="Block">
    <ContentTemplate>

      <p><asp:Button ID="btnShowAddPublisher" runat="server" Text="Add a publisher..." 
	      onclick="btnShowAddPublisher_Click" /></p>
	    
      <div id="divAddPublisher" runat="server" visible="false">
        <div>
          <div>
            Name: <asp:TextBox ID="txtName" runat="server" />
            <asp:RequiredFieldValidator ID="vldName" runat="server" ErrorMessage="Name required" ControlToValidate="txtName" />
          </div>
          <asp:Button ID="btnAddPublisher" runat="server" Text="Add this publisher" 
		        onclick="btnAddPublisher_Click" />
		    </div>
      </div>
      
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>