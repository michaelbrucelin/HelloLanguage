using System;
using System.Linq;
using System.Web.UI.WebControls;

using LinqInAction.LinqBooks.Common;

public partial class Partitioning : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Display the complete list
            GridViewComplete.DataSource = SampleData.Books.Select((book, index) => new { Index = index, Book = book.Title });
            GridViewComplete.DataBind();

            // Prepare the comboboxes
            int count = SampleData.Books.Count();
            for (int i = 0; i < count; i++)
            {
                ddlStart.Items.Add(i.ToString());
                ddlEnd.Items.Add(i.ToString());
            }
            ddlStart.SelectedIndex = 2;
            ddlEnd.SelectedIndex = 3;

            // Display the filtered list
            DisplayPartialData();
        }
    }

    protected void ddlStart_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayPartialData();
    }

    private void DisplayPartialData()
    {
        // Retrieve the start and end indexes
        int startIndex = int.Parse(ddlStart.SelectedValue);
        int endIndex = int.Parse(ddlEnd.SelectedValue);

        // Display the filtered list
        GridViewPartial.DataSource = SampleData.Books
            .Select((book, index) => new { Index = index, Book = book.Title })
            .Skip(startIndex).Take(endIndex - startIndex + 1);
        GridViewPartial.DataBind();
    }
}
