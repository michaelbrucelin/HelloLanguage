#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

using LinqInAction.LinqBooks.Common;

#endregion Imports

namespace LinqInAction.Chapter05
{
    public partial class FormConditionalQuery : Form
    {
        public FormConditionalQuery()
        {
            InitializeComponent();

            cbxPageCount.DisplayMember = "Key";
            cbxPageCount.ValueMember = "Value";
            cbxPageCount.DataSource = new KeyValuePair<String, int?>[] {
                new KeyValuePair<String, int?>("any", null),
                new KeyValuePair<String, int?>("at least 100", 100),
                new KeyValuePair<String, int?>("at least 200", 200),
                new KeyValuePair<String, int?>("at least 300", 300)
            };

            cbxPageCount.SelectedIndex = 0;
            cbxSortOrder.SelectedIndex = 0;

            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Title", HeaderText = "Title" });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "PageCount", HeaderText = "Pages" });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Publisher", HeaderText = "Publisher" });
        }

        private void ConditionalQuery<TSortKey>(int? minPageCount, String titleFilter, Func<Book, TSortKey> sortSelector)
        {
            IEnumerable<Book> query;

            query = SampleData.Books;
            if (minPageCount.HasValue)
                query = query.Where(book => book.PageCount >= minPageCount.Value);
            if (!String.IsNullOrEmpty(titleFilter))
                query = query.Where(book => book.Title.Contains(titleFilter));
            if (sortSelector != null)
                query = query.OrderBy(sortSelector);
            var completeQuery = query.Select(book => new { book.Title, book.PageCount, Publisher = book.Publisher.Name });

            dataGridView.DataSource = completeQuery.ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? minPageCount;
            string titleFilter;

            minPageCount = (int?)cbxPageCount.SelectedValue;
            titleFilter = txtTitleFilter.Text;
            if (cbxSortOrder.SelectedIndex == 1)
                ConditionalQuery(minPageCount, titleFilter, book => book.Title);
            else if (cbxSortOrder.SelectedIndex == 2)
                ConditionalQuery(minPageCount, titleFilter, book => book.Publisher.Name);
            else if (cbxSortOrder.SelectedIndex == 3)
                ConditionalQuery(minPageCount, titleFilter, book => book.PageCount);
            else
                ConditionalQuery<Object>(minPageCount, titleFilter, null);
        }
    }
}