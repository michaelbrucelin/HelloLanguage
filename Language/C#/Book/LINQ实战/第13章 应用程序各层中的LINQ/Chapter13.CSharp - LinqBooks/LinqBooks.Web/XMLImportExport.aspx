<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="XMLImportExport.aspx.cs" Inherits="LinqBooks.Web.XmlImportExport" Title="XML Import/Export" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h1>XML Import/Export</h1>

  <h2>Export</h2>
  
  <div>
    <asp:HyperLink ID="lnkXml" runat="server" Text="Get data as XML" NavigateUrl="~/GetXML.ashx" />
  </div>
  
  <h2>Import</h2>
  
  <div>
    <div>
      <div style="font-style: italic">You can try this feature with the sample file named SampleExport.xml</div>
      <asp:FileUpload ID="uploadXml" runat="server" />
      <asp:RequiredFieldValidator ID="vldUploadXml" runat="server" 
        ErrorMessage="File required" ControlToValidate="uploadXml" />
    </div>
    <div>
      <asp:Button ID="btnUpload" runat="server" Text="Upload XML" 
        OnClick="btnUpload_Click" />
    </div>
  </div>
  
  <div id="divData" runat="server" visible="false">
    <div style="margin-top: 1em">Books already in catalog:</div>
    <asp:GridView ID="GridViewDataSetExisting" runat="server" EmptyDataText="No data">
    </asp:GridView>
    
    <div style="margin-top: 1em">Books not in catalog yet:</div>
    <asp:GridView ID="GridViewDataSetNew" runat="server" EmptyDataText="No data" DataKeyNames="Id"
      AutoGenerateColumns="false">
      <Columns>
        <asp:TemplateField HeaderText="Import" ItemStyle-HorizontalAlign="Center">
          <ItemTemplate>
            <asp:CheckBox ID="chkImport" runat="server" />
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
        <asp:BoundField DataField="Isbn" HeaderText="ISBN" />
        <asp:BoundField DataField="Subject" HeaderText="Subject" />
      </Columns>
    </asp:GridView>
    
    <div>
      <asp:Button ID="btnImport" runat="server" Text="Import"
        ValidationGroup="Import"
        onclick="btnImport_Click" />
    </div>    
  </div>
</asp:Content>