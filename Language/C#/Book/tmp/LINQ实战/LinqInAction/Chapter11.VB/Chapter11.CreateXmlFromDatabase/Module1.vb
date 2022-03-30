Imports System
Imports System.Linq
Imports System.Xml.Linq
Imports System.Data.Linq
Imports LinqInAction.LinqToSql


Module Module1

	Sub Main()
		Dim ctx As LinqInActionDataContext = New LinqInActionDataContext()
		ctx.Log = Console.Out

		Dim xml As XElement = <books>
														<%= From book In ctx.Books.ToArray() _
															Select <book>
																			 <authors>
																				 <%= From bookAuthor In book.BookAuthors _
																					 Order By bookAuthor.AuthorOrder _
																					 Select <author>
																										<firstName><%= bookAuthor.Author.FirstName %></firstName>
																										<lastName><%= bookAuthor.Author.LastName %></lastName>
																										<website><%= bookAuthor.Author.WebSite %></website>
																									</author> _
																				 %>
																			 </authors>
																			 <subject>
																				 <name><%= book.Subject.Name %></name>
																				 <description><%= book.Subject.Description %></description>
																			 </subject>
																			 <publisher><%= book.Publisher.Name %></publisher>
																			 <publicationDate><%= book.PubDate %></publicationDate>
																			 <price><%= book.Price %></price>
																			 <isbn><%= book.Isbn %></isbn>
																			 <notes><%= book.Notes %></notes>
																			 <summary><%= book.Summary %></summary>
																			 <reviews>
																				 <%= From review In book.Reviews _
																					 Order By review.Rating _
																					 Select <review>
																										<user><%= review.User.Name %></user>
																										<rating><%= review.Rating %></rating>
																										<comments><%= review.Comments %></comments>
																									</review> _
																				 %>
																			 </reviews>
																		 </book> _
														%>
													</books>

		Console.WriteLine(xml.ToString())
	End Sub

End Module
