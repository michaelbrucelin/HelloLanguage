Imports LinqInAction.LinqBooks.Common
Imports System.Linq

Module XmlFromObjectsUsingXmlLiterals
	Sub Main()
		Dim rss = _
			<?xml version="1.0" encoding="utf-8"?>
			<rss version="2.0">
				<channel>
					<title>Book Reviews</title>
					<description>LINQBooks Book Reviews</description>
					<%= From book In SampleData.Books _
						Where Not IsNothing(book.Reviews) AndAlso book.Reviews.Count > 0 _
						Select _
						From review In book.Reviews _
						Select _
						<item>
							<title>Review of <%= book.Title %> by <%= review.User.Name %></title>
							<description><%= review.Comments %></description>
						</item> %>
				</channel>
			</rss>

		Console.WriteLine(rss)
	End Sub
End Module
