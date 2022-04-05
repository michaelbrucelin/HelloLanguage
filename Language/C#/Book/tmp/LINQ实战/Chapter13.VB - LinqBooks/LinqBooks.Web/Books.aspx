<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Books.aspx.vb" Inherits="LinqBooks.Web.Books" title="Books" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h1>Books</h1>
  
  <p><asp:HyperLink ID="lnkAddBooks" runat="server" Text="Add books" NavigateUrl="~/AddBooks.aspx" /></p>
  
  <i>Sorting and paging with a LinqDataSource...</i>
  <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
    OnSelecting="LinqDataSource1_Selecting">
  </asp:LinqDataSource>
  <asp:UpdatePanel ID="updBooks" runat="server">
    <ContentTemplate>
      <asp:GridView ID="GridViewBooks" runat="server"
        AllowSorting="True" AllowPaging="True" PageSize="3"
        AutoGenerateColumns="False" DataSourceID="LinqDataSource1">
        <Columns>
          <asp:HyperLinkField
            DataNavigateUrlFields="Id"
            DataNavigateUrlFormatString="~/Book.aspx?ID={0}"
            DataTextField="Title"
            HeaderText="Title"
            SortExpression="Title" />
          <asp:BoundField DataField="Publisher" HeaderText="Publisher" ReadOnly="True" 
            SortExpression="Publisher" />
          <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" 
            SortExpression="Price" DataFormatString="{0:F2}" HtmlEncode="false" />
        </Columns>
      </asp:GridView>
    </ContentTemplate>
  </asp:UpdatePanel>
  
  <div style="margin-top: 1em">
    <div>Total price: <asp:Label ID="lblTotalPrice" runat="server" /></div>
    <div>Book with highest number of pages: <asp:HyperLink ID="lnkBiggestBook" runat="server" /> (<asp:Label ID="lblPageCount" runat="server" />)</div>
    <div>Best-rated book: <asp:HyperLink ID="lnkBestBook" runat="server" /> (<asp:Label ID="lblRating" runat="server" />)</div>
  </div>
</asp:Content>