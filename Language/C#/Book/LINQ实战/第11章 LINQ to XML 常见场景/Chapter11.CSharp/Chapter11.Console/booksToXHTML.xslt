<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="books">
		<html>
			<title>Book Catalog</title>
			<ul>
				<xsl:apply-templates select="book"/>
			</ul>
		</html>
	</xsl:template>
	<xsl:template match="book">
		<li>
			<xsl:value-of select="title"/> by <xsl:apply-templates select="author"/>
		</li>
	</xsl:template>
	<xsl:template match="author">
		<xsl:if test="position() > 1">, </xsl:if>
		<xsl:value-of select="."/>
	</xsl:template>
</xsl:stylesheet>