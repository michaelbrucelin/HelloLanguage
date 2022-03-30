<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="LinqBooks.Web.BookPage" Title="Book" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h1>Book</h1>
  
  <h2>Book details</h2>
  
  <asp:UpdatePanel ID="updBookDetails" runat="server" RenderMode="Block">
    <ContentTemplate>
      <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False">
        <FieldHeaderStyle Font-Bold="True" />
        <Fields>
          <asp:BoundField DataField="Title" HeaderText="Title" />
          <asp:BoundField DataField="Isbn" HeaderText="ISBN" />
          <asp:BoundField DataField="Summary" HeaderText="Summary" />
          <asp:BoundField DataField="Notes" HeaderText="Notes" />
          <asp:BoundField DataField="PageCount" HeaderText="Page count" />
          <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:F2}" HtmlEncode="false" />
          <asp:BoundField DataField="PubDate" HeaderText="Publication date" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
          <asp:HyperLinkField DataNavigateUrlFields="PublisherId" 
            DataNavigateUrlFormatString="~/Publisher.aspx?ID={0}" 
            DataTextField="PublisherName" HeaderText="Publisher" />
          <asp:TemplateField HeaderText="Authors">
            <ItemTemplate>
              <linqBooks:AuthorList ID="AuthorList" runat="server" />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="Subject" HeaderText="Subject" />
          <asp:TemplateField HeaderText="Average rating">
            <ItemTemplate>
              <ajaxToolkit:Rating ID="Rating" runat="server" ReadOnly="true" />
            </ItemTemplate>
          </asp:TemplateField>
        </Fields>
      </asp:DetailsView>
    </ContentTemplate>
  </asp:UpdatePanel>
  
  <div>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" 
      OnClientClick="if (!confirm('Are you sure?')) return false;" 
      OnClick="btnDelete_Click" />
  </div>

  <h2>Authors</h2>
  
  <asp:UpdateProgress ID="UpdateProgressAddAuthor" runat="server" AssociatedUpdatePanelID="updAddAuthor">
    <ProgressTemplate>
      <asp:Image ID="imgProgressAddAuthor" runat="server" SkinID="Progress" />
    </ProgressTemplate>
  </asp:UpdateProgress>
  <asp:UpdatePanel ID="updAddAuthor" runat="server" RenderMode="Block">
    <ContentTemplate>

      <p>
        <asp:Button ID="btnShowAddAuthor" runat="server" Text="Add an author..."
          OnClick="btnShowAddAuthor_Click" />
      </p>
      
      <div id="divAddAuthor" runat="server" visible="false">
        <div>
          <div>
            <asp:DropDownList ID="ddlAuthor" runat="server" AppendDataBoundItems="True"
              ValidationGroup="AddAuthor" />
            <asp:RequiredFieldValidator ID="vldAuthor" runat="server" 
              ValidationGroup="AddAuthor"
              ErrorMessage="Author required" ControlToValidate="ddlAuthor" InitialValue="0" />
          </div>
          <asp:Button ID="btnAddAuthor" runat="server" Text="Add this author"
            ValidationGroup="AddAuthor"
            OnClick="btnAddAuthor_Click" />
        </div>
      </div>
      
    </ContentTemplate>
  </asp:UpdatePanel>
    
  <h2>Reviews</h2>

  <asp:UpdateProgress ID="UpdateProgressAddReview" runat="server" AssociatedUpdatePanelID="updReviews">
    <ProgressTemplate>
      <asp:Image ID="imgProgressAddReview" runat="server" SkinID="Progress" />
    </ProgressTemplate>
  </asp:UpdateProgress>
  <asp:UpdatePanel ID="updReviews" runat="server" RenderMode="Block">
    <ContentTemplate>

      <asp:GridView ID="GridViewReviews" runat="server" AutoGenerateColumns="false" 
        EmptyDataText="no reviews yet" DataKeyNames="ID"
        OnRowDataBound="GridViewReviews_RowDataBound"
        OnRowDeleting="GridViewReviews_RowDeleting">
        <Columns>
          <asp:TemplateField HeaderText="Rating">
            <ItemTemplate>
              <ajaxToolkit:Rating ID="Rating" runat="server" ReadOnly="true" />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="Comments" HeaderText="Comments" />
          <asp:CommandField ButtonType="Button" ShowDeleteButton="true" />
        </Columns>
      </asp:GridView>

      <p>
        <asp:Button ID="btnShowAddReview" runat="server" Text="Add a review..." 
          OnClick="btnShowAddReview_Click" />
      </p>
      
      <div id="divAddReview" runat="server" visible="false">
        <ajaxToolkit:Rating ID="ReviewRating" runat="server" RatingAlign="Vertical" 
          RatingDirection="RightToLeftBottomToTop" style="float: left" />
        <asp:TextBox ID="txtReviewComments" runat="server" TextMode="MultiLine" Columns="80" Rows="5" />
        <div>
          <asp:Button ID="btnAddReview" runat="server" Text="Add this review" 
            OnClick="btnAddReview_Click" />
        </div>
      </div>
      
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>