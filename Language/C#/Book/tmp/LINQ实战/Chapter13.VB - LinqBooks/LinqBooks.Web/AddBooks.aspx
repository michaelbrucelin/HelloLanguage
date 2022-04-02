<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="AddBooks.aspx.vb" Inherits="LinqBooks.Web.AddBooks" Title="Add books" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h1>Add books</h1>
  
  <h2>Add a book by hand</h2>

  <asp:Panel ID="pnlByHand" runat="server" DefaultButton="btnAddByHand">
    <table>
    <tr>
      <td>Title:</td>
      <td>
        <asp:TextBox ID="txtTitle" runat="server" Columns="50" />
		    <asp:RequiredFieldValidator ID="vldTitle" runat="server" 
		      ValidationGroup="ByHand"
		      ErrorMessage="Title required" ControlToValidate="txtTitle" />
		  </td>
    </tr>
    <tr>
      <td>ISBN:</td>
      <td>
        <asp:TextBox ID="txtIsbn" runat="server" Columns="13" />
      </td>
    </tr>
    <tr>
      <td>Summary:</td>
      <td>
        <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine" Columns="50" 
		      Rows="3" />
		  </td>
    </tr>
    <tr>
      <td>Notes:</td>
      <td>
        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Columns="50" 
		      Rows="3" />
		  </td>
    </tr>
    <tr>
      <td>Page count:</td>
      <td>
        <asp:TextBox ID="txtPageCount" runat="server" Columns="4" /> 
		    <asp:CompareValidator ID="vldPageCount" runat="server" 
		      ValidationGroup="ByHand"
	        ErrorMessage="Invalid page count" Operator="DataTypeCheck" 
	        ControlToValidate="txtPageCount" Type="Integer" />
	    </td>
    </tr>
    <tr>
      <td>Price:</td>
      <td>
        <asp:TextBox ID="txtPrice" runat="server" Columns="6" /> <asp:CompareValidator ID="vldPageCp" runat="server" 
		      ValidationGroup="ByHand"
	        ErrorMessage="Invalid price" Operator="DataTypeCheck" 
	        ControlToValidate="txtPageCount" Type="Currency" />
	    </td>
    </tr>
    <tr>
      <td>PubDate:</td>
      <td>
        <asp:Calendar ID="PubDate" runat="server" />
      </td>
    </tr>
    <tr>
      <td>Publisher:</td>
      <td>
        <asp:DropDownList ID="ddlPublisher" runat="server" AppendDataBoundItems="True" >
		      <asp:ListItem Selected="True" Value="0">(select a value)</asp:ListItem>
		    </asp:DropDownList>
		    <asp:RequiredFieldValidator ID="vldPublisher" runat="server" 
		      ValidationGroup="ByHand"
		      ErrorMessage="Publisher required" ControlToValidate="ddlPublisher" InitialValue="0" />
		  </td>
    </tr>
    <tr>
      <td>Subject:</td>
      <td>
        <asp:DropDownList ID="ddlSubjectByHand" runat="server" AppendDataBoundItems="True" >
          <asp:ListItem Selected="True" Value="0">(select a value)</asp:ListItem>
        </asp:DropDownList>
		    <asp:RequiredFieldValidator ID="vldSubjectByHand" runat="server" 
		      ValidationGroup="ByHand"
		      ErrorMessage="Subject required" ControlToValidate="ddlSubjectByHand" InitialValue="0" />
      </td>
    </tr>
    <tr>
      <td></td>
      <td>
        <asp:Button ID="btnAddByHand" runat="server" Text="Add" onclick="btnAddByHand_Click"
		      ValidationGroup="ByHand" />
      </td>
    </tr>
  </table>
  </asp:Panel>
  
  <h2>Import books from Amazon</h2>

  <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
    <table>
      <tr>
        <td>Keywords:</td>
        <td>
          <asp:TextBox ID="txtSearchKeywords" runat="server" Columns="50" />
		      <asp:RequiredFieldValidator ID="vldSearchKeywords" runat="server" 
		        ValidationGroup="SearchAmazon"
		        ErrorMessage="Keywords required" ControlToValidate="txtSearchKeywords" />
		    </td>
      </tr>
      <tr>
        <td>Publisher:</td>
        <td>
          <asp:TextBox ID="txtSearchPublisher" runat="server" Columns="50" />
        </td>
      </tr>
      <tr>
        <td></td>
        <td>
          <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click"
		        ValidationGroup="SearchAmazon" />
        </td>
      </tr>
    </table>
  </asp:Panel>

  <asp:UpdatePanel ID="updAmazonBooks" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <asp:GridView ID="GridViewAmazonBooks" runat="server"
        AutoGenerateColumns="false" EmptyDataText="no books found" CellPadding="4">
        <Columns>
          <asp:TemplateField HeaderText="Import" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
              <asp:CheckBox ID="chkImport" runat="server" />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="Title" HeaderText="Title" />
          <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
          <asp:BoundField DataField="Isbn" HeaderText="ISBN" />
          <asp:BoundField DataField="Year" HeaderText="Year" />
          <asp:BoundField DataField="Price" HeaderText="Price" />
          <asp:BoundField DataField="PageCount" HeaderText="Pages" />
        </Columns>
      </asp:GridView>
      
      <div id="divImport" runat="server" visible="false" style="margin-top: 1em">
        Subject:
        <asp:DropDownList ID="ddlSubjectFromAmazon" runat="server" AppendDataBoundItems="True">
          <asp:ListItem Selected="True" Value="0">(select a value)</asp:ListItem>
        </asp:DropDownList>
	      <asp:RequiredFieldValidator ID="vldSubjectFromAmazon" runat="server" 
	        ValidationGroup="Import"
	        ErrorMessage="Subject required" ControlToValidate="ddlSubjectFromAmazon" InitialValue="0" />

        <div>
          <asp:Button ID="btnImport" runat="server" Text="Import"
            ValidationGroup="Import"
		        onclick="btnImport_Click" />
		    </div>
		  </div>
    </ContentTemplate>
    <Triggers>
      <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
    </Triggers>
  </asp:UpdatePanel>
  
</asp:Content>
