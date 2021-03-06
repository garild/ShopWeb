/****** Script for SelectTopNRows command from SSMS  ******/
IF NOT EXISTS (SELECT 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_BooksView]'))
                EXEC dbo.sp_executesql @statement = N'
                CREATE VIEW [dbo].[vw_BooksView]
				AS
				SELECT [Id]
				,[Name]
				,[DateRelease]
				,[Price]
				,[Author]
				,[Publisher]
				,[BookType_Id]
				,[NewsType_Id] =	CASE WHEN NewsType_Id IS NULL AND [DateRelease] >=  GETDATE()  AND DATEDIFF(D, GETDATE(),[DateRelease]) <= 14 THEN 1
									WHEN  NewsType_Id IS NULL AND  DATEDIFF(D, GETDATE(),[DateRelease]) > 14 THEN 2
									ELSE NewsType_Id END
				FROM [dbo].[Books] WITH(NOLOCK)'

GO