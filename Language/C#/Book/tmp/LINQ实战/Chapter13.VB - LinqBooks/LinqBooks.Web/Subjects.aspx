<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Subjects.aspx.vb" Inherits="LinqBooks.Web.Subjects" Title="Subjects" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h1>Subjects</h1>
  
  <asp:UpdatePanel ID="updSubjects" runat="server" RenderMode="Block">
    <ContentTemplate>
      <asp:GridView ID="GridViewSubjects" runat="server" AutoGenerateColumns="False" 
	      onrowdatabound="GridViewSubjects_RowDataBound">
	      <columns>
		      <asp:hyperlinkfield DataNavigateUrlFields="ID" 
		        DataNavigateUrlFormatString="~/Subject.aspx?ID={0}" DataTextField="Name" 
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
  
  <asp:UpdateProgress ID="UpdateProgressAddSubject" runat="server" AssociatedUpdatePanelID="updAddSubject">
    <ProgressTemplate>
      <asp:Image ID="imgProgressAddSubject" runat="server" SkinID="Progress" />
    </ProgressTemplate>
  </asp:UpdateProgress>
  <asp:UpdatePanel ID="updAddSubject" runat="server" RenderMode="Block">
    <ContentTemplate>

      <p><asp:Button ID="btnShowAddSubject" runat="server" Text="Add a subject..." 
	      onclick="btnShowAddSubject_Click" /></p>
	    
      <div id="divAddSubject" runat="server" visible="false">
        <div>
          <div>
            Name: <asp:TextBox ID="txtName" runat="server" />
            <asp:RequiredFieldValidator ID="vldName" runat="server" ErrorMessage="Name required" ControlToValidate="txtName" />
          </div>
          <asp:Button ID="btnAddSubject" runat="server" Text="Add this subject" 
		        onclick="btnAddSubject_Click" />
		    </div>
      </div>
      
    </ContentTemplate>
  </asp:UpdatePanel>
  
  <h2>Books by subject</h2>
  
  <div>
    <asp:UpdateProgress ID="UpdateProgressDalSample" runat="server" AssociatedUpdatePanelID="updDalSample">
      <ProgressTemplate>
        <asp:Image ID="imgProgressDalSample" runat="server" SkinID="Progress" />
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updDalSample" runat="server">
      <ContentTemplate>
        <div>
          <asp:DropDownList ID="ddlSubject" runat="server"
            AppendDataBoundItems="True" AutoPostBack="true"
            OnSelectedIndexchanged="ddlSubject_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="0">(select a value)</asp:ListItem>
          </asp:DropDownList>
        </div>
        <linqBooks:BookList ID="BookListDalSample" runat="server" Visible="false" />
      </ContentTemplate>
    </asp:UpdatePanel>
  </div>
</asp:Content>
