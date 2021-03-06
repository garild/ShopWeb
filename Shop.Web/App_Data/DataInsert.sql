USE [ShopWeb]
GO


ALTER TABLE  [dbo].[Books]
ADD  CONSTRAINT [DF_Books_IsSuperPromtion]  DEFAULT ((0)) FOR [IsSuperPromtion]

GO

IF  (SELECT count(1) FROM [dbo].[Books_D_BookType] WITH(NOLOCK)) = 0
BEGIN
	INSERT [dbo].[Books_D_BookType] ( [Name], [Description]) VALUES ( N'ALL', 'Wszystkie')
	INSERT [dbo].[Books_D_BookType] ( [Name], [Description]) VALUES ( N'Audiobooks', 'Audioboki')
	INSERT [dbo].[Books_D_BookType] ( [Name], [Description]) VALUES ( N'EBooks', 'E-Booki')
END
GO

IF  (SELECT count(1) FROM [dbo].[Books] WITH(NOLOCK)) = 0
BEGIN
	INSERT [dbo].[Books] ( [Name], [DateRelease], [Price], [Author], [Publisher], [BookType_Id],[IsSuperPromtion]) VALUES ( N'„Pokój pełen liści 1”', CAST(N'2017-07-25' AS Date), CAST(25.20 AS Decimal(18, 2)), N'Aiken Joan', N'PWN', 1,1)
	INSERT [dbo].[Books] ( [Name], [DateRelease], [Price], [Author], [Publisher], [BookType_Id]) VALUES ( N'„Baśnie 4”', CAST(N'2017-08-25' AS Date), CAST(35.30 AS Decimal(18, 2)), N'Andersen H.CH.', N'GT', 1)
	INSERT [dbo].[Books] ( [Name], [DateRelease], [Price], [Author], [Publisher], [BookType_Id]) VALUES ( N'„Kolej żelazna 3”', CAST(N'2017-08-10' AS Date), CAST(45.25 AS Decimal(18, 2)), N'Appelfeld Aharon', N'ABB', 2)
	INSERT [dbo].[Books] ( [Name], [DateRelease], [Price], [Author], [Publisher], [BookType_Id]) VALUES ( N'„No właśnie co. Dramaty i proza w przekładzie Antoniego 2 Libery”', CAST(N'2014-08-03' AS Date), CAST(21.00 AS Decimal(18, 2)), N'Beckett Samuel ', N'Anon', 1)
	INSERT [dbo].[Books] ( [Name], [DateRelease], [Price], [Author], [Publisher], [BookType_Id]) VALUES ( N'„Kulturowe sprzeczności kapitalizmu”', CAST(N'2011-01-12' AS Date), CAST(85.00 AS Decimal(18, 2)), N'Bell Daniel', N'SRT', 1)
	INSERT [dbo].[Books] ( [Name], [DateRelease], [Price], [Author], [Publisher], [BookType_Id]) VALUES ( N'„Zaburzenie”', CAST(N'2019-05-25' AS Date), CAST(100.40 AS Decimal(18, 2)), N'Bernhardt Thomas 5', N'OSP', 2 )
	INSERT [dbo].[Books] ( [Name], [DateRelease], [Price], [Author], [Publisher], [BookType_Id]) VALUES ( N'„Szumy, zlepy, ciągi”', CAST(N'2017-08-26' AS Date), CAST(32.20 AS Decimal(18, 2)), N'Białoszewski Miron', N'GT', 3)
	INSERT [dbo].[Books] ( [Name], [DateRelease], [Price], [Author], [Publisher], [BookType_Id],[IsSuperPromtion]) VALUES ( N'„Uwiedzeni 2”', CAST(N'2017-08-12' AS Date), CAST(150.90 AS Decimal(18, 2)), N'8 Bolecka Anna', N'FT',1,1)
END
GO


IF  (SELECT count(1) FROM [dbo].[Covers] WITH(NOLOCK)) = 0
BEGIN
INSERT [dbo].[Covers] ( [Name]) VALUES ( N'Okładka jednolita')
INSERT [dbo].[Covers] ( [Name]) VALUES ( N'Grzbiet ')
INSERT [dbo].[Covers] ( [Name]) VALUES ( N'Wkład wieloskładkowy')
INSERT [dbo].[Covers] ([Name]) VALUES ( N'Wkład jednoskładkowy')
END
GO

IF  (SELECT count(1) FROM [dbo].[Editions] WITH(NOLOCK)) = 0
BEGIN
INSERT [dbo].[Editions] ( [Name]) VALUES ( N'1985')
INSERT [dbo].[Editions] ( [Name]) VALUES ( N'1659')
INSERT [dbo].[Editions] ([Name]) VALUES ( N'2017')
INSERT [dbo].[Editions]  ([Name]) VALUES ( N'2015')
END
GO
IF  (SELECT count(1) FROM [dbo].[Mediums] WITH(NOLOCK)) = 0
BEGIN
INSERT [dbo].[Mediums] ( [Name]) VALUES ( N'karta dziurkowana')
INSERT [dbo].[Mediums] ( [Name]) VALUES ( N'taśma dziurkowana')
INSERT [dbo].[Mediums] ( [Name]) VALUES ( N'taśma magnetyczna')
INSERT [dbo].[Mediums] ( [Name]) VALUES ( N'bęben magnetyczny')
END 
GO 
IF  (SELECT count(1) FROM [dbo].[Publishers] WITH(NOLOCK)) = 0
BEGIN
INSERT [dbo].[Publishers] ( [Name]) VALUES ( N'ABE Dom Wydawniczy')
INSERT [dbo].[Publishers] ( [Name]) VALUES ( N'Academica - Wydawnictwo SWPS')
INSERT [dbo].[Publishers] ( [Name]) VALUES ( N'Ad Oculos')
INSERT [dbo].[Publishers] ( [Name]) VALUES ( N'Akademia Sztuk Pięknych w Katowicach')
INSERT [dbo].[Publishers] ( [Name]) VALUES ( N'Albus Wydawnictwo')
END
