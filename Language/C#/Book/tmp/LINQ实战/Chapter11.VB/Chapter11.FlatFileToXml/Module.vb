Imports System.IO
Imports System.Xml.Linq

Module FlatFileToXmlWithXmlLiterals
	Sub Main()
		Dim xml As XElement = <books>
														<%= From line In File.ReadAllLines("books.txt") _
															Where Not line.StartsWith("#") _
															Let items = line.Split(",") _
															Select _
															<book>
																<title><%= items(1) %></title>
																<authors>
																	<%= From authorFullName In items(2).Split(";") _
																		Let authorNameParts = authorFullName.Split(" ") _
																		Select <author>
																						 <firstName><%= authorNameParts(0) %></firstName>
																						 <lastName><%= authorNameParts(1) %></lastName>
																					 </author> _
																	%>
																</authors>
																<publisher><%= items(3) %></publisher>
																<publicationDate><%= items(4) %></publicationDate>
																<price><%= items(5) %></price>
																<isbn><%= items(0) %></isbn>
															</book> _
														%>
													</books>

		Console.WriteLine(xml)
	End Sub
End Module
