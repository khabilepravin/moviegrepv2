USE [miner]
GO
/****** Object:  Table [dbo].[LookupGroup]    Script Date: 08/12/2014 16:24:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupGroup](
	[GroupId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_LookupGroup] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExternalSource]    Script Date: 08/12/2014 16:24:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalSource](
	[Id] [bigint] NOT NULL,
	[TitleId] [int] NULL,
	[ExternalSourceId] [nvarchar](500) NULL,
	[Name] [nvarchar](500) NULL,
	[URL] [nvarchar](1000) NULL,
	[Type] [nvarchar](100) NULL,
 CONSTRAINT [pk_id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExternalSource', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key to the titles table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExternalSource', @level2type=N'COLUMN',@level2name=N'TitleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'External source id for more information like NetflixID/TMDB ID/RottoenTomatoes ID etc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExternalSource', @level2type=N'COLUMN',@level2name=N'ExternalSourceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the external source Netflix/TMDB/IMDB whatever..' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExternalSource', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL even if its direct web link or a api url it will be here' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExternalSource', @level2type=N'COLUMN',@level2name=N'URL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type will tell us whether its an API or a direct web link' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExternalSource', @level2type=N'COLUMN',@level2name=N'Type'
GO
/****** Object:  Table [dbo].[UserFavorites]    Script Date: 08/12/2014 16:24:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserFavorites](
	[UserFavoriteId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserIdentification] [varchar](100) NOT NULL,
	[IdentificationSource] [varchar](100) NOT NULL,
	[SubtitleTextId] [bigint] NOT NULL,
	[Rating] [tinyint] NOT NULL,
	[RecordStatus] [char](1) NOT NULL,
 CONSTRAINT [PK_UserFavorites] PRIMARY KEY CLUSTERED 
(
	[UserFavoriteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TitleSubtitle]    Script Date: 08/12/2014 16:24:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TitleSubtitle](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TitleId] [bigint] NULL,
	[SubtitleText] [nvarchar](max) NULL,
	[SubtitleLanguageCode] [nvarchar](10) NULL,
 CONSTRAINT [PK_TitleSubtitle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Titles]    Script Date: 08/12/2014 16:24:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Titles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Season] [nvarchar](100) NULL,
	[Episode] [nvarchar](100) NULL,
	[Year] [nvarchar](50) NULL,
	[IndexStatus] [varchar](50) NULL,
	[RowStatus] [varchar](10) NULL,
	[Tags] [xml] NULL,
	[LanguageCode] [varchar](10) NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Titles', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Movie/TV series title/name ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Titles', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The season information if its a TV-series' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Titles', @level2type=N'COLUMN',@level2name=N'Season'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Episode information may apply both to the movies and to TV series' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Titles', @level2type=N'COLUMN',@level2name=N'Episode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The year the movie/series released' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Titles', @level2type=N'COLUMN',@level2name=N'Year'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Since the indexing is a different service this status will tell us if the data for this title is indexed' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Titles', @level2type=N'COLUMN',@level2name=N'IndexStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Generic row status to handle soft delete etc.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Titles', @level2type=N'COLUMN',@level2name=N'RowStatus'
GO
/****** Object:  Table [dbo].[SystemProperty]    Script Date: 08/12/2014 16:24:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemProperty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Value] [nvarchar](1000) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[RowStatus] [nchar](1) NOT NULL,
 CONSTRAINT [PK_SystemProperty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubtitlesText]    Script Date: 08/12/2014 16:24:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubtitlesText](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SubtitleTextId] [bigint] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[SubtitleText] [nvarchar](max) NULL,
	[PopularityIndex] [int] NULL,
 CONSTRAINT [PK_SubtitlesText] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubtitlesText', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key to the titles table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubtitlesText', @level2type=N'COLUMN',@level2name=N'SubtitleTextId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Start time when the dialog started in the movie' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubtitlesText', @level2type=N'COLUMN',@level2name=N'StartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'End time of the dialog ended in the movie ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubtitlesText', @level2type=N'COLUMN',@level2name=N'EndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The actual parsed dialog from the subtitle text' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubtitlesText', @level2type=N'COLUMN',@level2name=N'SubtitleText'
GO
/****** Object:  UserDefinedFunction [dbo].[SplitCSVToIntTable]    Script Date: 08/12/2014 16:24:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SplitCSVToIntTable]
(
	@csv varchar(max), @delimiter varchar
)
RETURNS 
	@ParsedList table (	Item bigint NOT NULL PRIMARY KEY CLUSTERED)
AS
BEGIN
	DECLARE @Item varchar(100), @Pos int

	SET @csv = LTRIM(RTRIM(@csv))+ @delimiter
	SET @Pos = CHARINDEX(@delimiter, @csv, 1)

	IF REPLACE(@csv, @delimiter, '') <> ''
	BEGIN
		WHILE @Pos > 0
		BEGIN
			SET @Item = LTRIM(RTRIM(LEFT(@csv, @Pos - 1)))
			IF @Item <> ''
			BEGIN
				IF NOT EXISTS (SELECT * FROM @ParsedList WHERE Item = @Item)
				INSERT INTO @ParsedList (Item) VALUES (@Item) 
			END
			SET @csv = RIGHT(@csv, LEN(@csv) - @Pos)
			SET @Pos = CHARINDEX(@delimiter, @csv, 1)
		END
	END	
	RETURN
END
GO
/****** Object:  Table [dbo].[LookupValue]    Script Date: 08/12/2014 16:24:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupValue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Value] [nvarchar](2000) NULL,
	[Description] [nvarchar](2000) NULL,
	[RowStatus] [nchar](1) NULL,
 CONSTRAINT [PK_LookupValues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_ExternalSource_Update]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_ExternalSource_Update] 
    @Id int,
    @TitleId int,
    @ExternalSourceId nvarchar(500),
    @Name nvarchar(500),
    @URL nvarchar(1000),
    @Type nvarchar(100)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[ExternalSource]
	SET    [Id] = @Id, [TitleId] = @TitleId, [ExternalSourceId] = @ExternalSourceId, [Name] = @Name, [URL] = @URL, [Type] = @Type
	WHERE  [Id] = @Id
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [TitleId], [ExternalSourceId], [Name], [URL], [Type]
	FROM   [dbo].[ExternalSource]
	WHERE  [Id] = @Id	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_ExternalSource_Select]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_ExternalSource_Select] 
    @Id INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [Id], [TitleId], [ExternalSourceId], [Name], [URL], [Type] 
	FROM   [dbo].[ExternalSource] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_ExternalSource_Insert]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_ExternalSource_Insert] 
    @Id int,
    @TitleId int,
    @ExternalSourceId nvarchar(500),
    @Name nvarchar(500),
    @URL nvarchar(1000),
    @Type nvarchar(100)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[ExternalSource] ([Id], [TitleId], [ExternalSourceId], [Name], [URL], [Type])
	SELECT @Id, @TitleId, @ExternalSourceId, @Name, @URL, @Type
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [TitleId], [ExternalSourceId], [Name], [URL], [Type]
	FROM   [dbo].[ExternalSource]
	WHERE  [Id] = @Id
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_UserFavorites_Update]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_UserFavorites_Update] 
    @UserFavoriteId bigint,    
    @Rating tinyint    
AS 
	SET NOCOUNT ON 
	
	UPDATE [dbo].[UserFavorites]
	SET    [Rating] = @Rating
	WHERE  [UserFavoriteId] = @UserFavoriteId
GO
/****** Object:  StoredProcedure [dbo].[usp_UserFavorites_Select]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_UserFavorites_Select] 
    @UserIdentification varchar(100)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	SELECT ST.SubtitleText, SF.SubtitleId, UF.UserFavoriteId
	FROM   [dbo].[UserFavorites] UF INNER JOIN [dbo].[SubtitleText] ST
	ON UF.SubtitleId = ST.SubtitleId		
	WHERE  UF.UserIdentification = @UserIdentification
GO
/****** Object:  StoredProcedure [dbo].[usp_UserFavorites_Insert]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_UserFavorites_Insert] 
	@UserFavoriteId bigint output,
    @UserIdentification varchar(100),
    @IdentificationSource varchar(100),
    @SubtitleTextId bigint,
    @Rating tinyint,
    @RecordStatus char(1)
AS 
	SET NOCOUNT ON 
	
	
	INSERT INTO [dbo].[UserFavorites] ([UserIdentification], [IdentificationSource], [SubtitleTextId], [Rating], [RecordStatus])
	SELECT @UserIdentification, @IdentificationSource, @SubtitleTextId, @Rating, @RecordStatus
	
	--If user rating is greater than 3 then increase the popularity index of the subtitle text
	IF(@Rating IS NOT NULL AND @Rating >= 3)
	BEGIN		
		UPDATE SubtitlesText SET PopularityIndex = (ISNULL(PopularityIndex, 0) +1)	WHERE Id = @SubtitleTextId
	END
		
	SET @UserFavoriteId = SCOPE_IDENTITY()
	RETURN @UserFavoriteId
GO
/****** Object:  StoredProcedure [dbo].[usp_TitleSubtitle_Update]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_TitleSubtitle_Update] 
    @Id bigint,
    @TitleId bigint,
    @SubtitleText nvarchar(MAX),
    @SubtitleLanguageCode nvarchar(10)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[TitleSubtitle]
	SET    [TitleId] = @TitleId, [SubtitleText] = @SubtitleText, [SubtitleLanguageCode] = @SubtitleLanguageCode
	WHERE  [Id] = @Id
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [TitleId], [SubtitleText], [SubtitleLanguageCode]
	FROM   [dbo].[TitleSubtitle]
	WHERE  [Id] = @Id	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_TitleSubtitle_SelectGetByTitle]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_TitleSubtitle_SelectGetByTitle] 
    @TitleId BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT S.[Id], [TitleId], [SubtitleText], [SubtitleLanguageCode] 
	FROM   [dbo].[TitleSubtitle] as S
	INNER JOIN [dbo].[Titles] as T
	on T.Id = S.TitleId
	WHERE  T.Id= @TitleId

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_TitleSubtitle_Select]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_TitleSubtitle_Select] 
    @Id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [Id], [TitleId], [SubtitleText], [SubtitleLanguageCode] 
	FROM   [dbo].[TitleSubtitle] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_TitleSubtitle_Insert]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_TitleSubtitle_Insert] 
    @TitleId bigint,
    @SubtitleText nvarchar(MAX),
    @SubtitleLanguageCode nvarchar(10),
    @Id bigint output
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[TitleSubtitle] ([TitleId], [SubtitleText], [SubtitleLanguageCode])
	SELECT @TitleId, @SubtitleText, @SubtitleLanguageCode
	
	-- Begin Return Select <- do not remove
	set @Id = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_TitleSubtitle_Delete]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_TitleSubtitle_Delete] 
    @Id bigint
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[TitleSubtitle]
	WHERE  [Id] = @Id

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_Titles_Update]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Titles_Update] 
    @Id int,
    @Title nvarchar(500),
    @Season nvarchar(100),
    @Episode nvarchar(100),
    @Year nvarchar(50),
    @IndexStatus varchar(50),
    @RowStatus varchar(10)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	

	UPDATE [dbo].[Titles]
	SET    [Title] = @Title, [Season] = @Season, [Episode] = @Episode, [Year] = @Year, [IndexStatus] = @IndexStatus, [RowStatus] = @RowStatus
	WHERE  [Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Titles_Select_All]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Titles_Select_All]     
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [Id], [Title], [Season], [Episode], [Year], [IndexStatus], [RowStatus],  [Tags] 
	FROM   [dbo].[Titles] 
	WHERE  (RowStatus is null or RowStatus <> 'I')

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_Titles_Select]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Titles_Select] 
    @Id INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [Id], [Title], [Season], [Episode], [Year], [IndexStatus], [RowStatus],  [Tags] 
	FROM   [dbo].[Titles] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_Titles_Insert]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Titles_Insert] 
	@Id int output,
    @Title nvarchar(500),
    @Season nvarchar(100),
    @Episode nvarchar(100),
    @Year nvarchar(50),
    @IndexStatus varchar(50),
    @RowStatus varchar(10),
    @Tags xml
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	INSERT INTO [dbo].[Titles] ([Title], [Season], [Episode], [Year], [IndexStatus], [RowStatus], [Tags])
	SELECT @Title, @Season, @Episode, @Year, @IndexStatus, @RowStatus, @Tags
	
	-- Begin Return Select <- do not remove
	set @Id = SCOPE_IDENTITY()
	return @id
	-- End Return Select <- do not remove
GO
/****** Object:  StoredProcedure [dbo].[usp_Titles_IndexStatus_Update]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Titles_IndexStatus_Update] 
    @Id int,
    @IndexStatus varchar(50)  
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	

	UPDATE [dbo].[Titles]
	SET    [IndexStatus] = @IndexStatus
	WHERE  [Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[usp_Titles_CheckDuplicity]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Titles_CheckDuplicity] 
    @Title nvarchar(500),
    @Season nvarchar(100) = null,
    @Episode nvarchar(100) = null,
    @Year nvarchar(50) = null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT Id FROM   [dbo].[Titles] WHERE  
	[Title] = @Title AND 
	isnull(Season,1) = ISNULL(@Season,isnull(Season,1)) AND 
	isnull(Episode,1) = ISNULL(@Episode,isnull(Episode,1)) AND 
	isnull(Year,1) = ISNULL(@Year,isnull(Year,1))
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_Title_GetEndTime]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Title_GetEndTime]
	@TitleId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT MAX(S.EndTime) FROM dbo.SubtitlesText S
    INNER JOIN dbo.TitleSubtitle B
    ON B.Id = S.SubtitleTextId
    INNER JOIN dbo.Titles T
    ON T.Id = B.TitleId
     WHERE T.Id = @TitleId
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SystemProperty_Update]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SystemProperty_Update] 
    @Id int,
    @Name nvarchar(200),
    @Value nvarchar(1000),
    @Description nvarchar(1000),
    @RowStatus nchar(1)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[SystemProperty]
	SET    [Name] = @Name, [Value] = @Value, [Description] = @Description, [RowStatus] = @RowStatus
	WHERE  [Id] = @Id
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [Name], [Value], [Description], [RowStatus]
	FROM   [dbo].[SystemProperty]
	WHERE  [Id] = @Id	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_SystemProperty_Select]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SystemProperty_Select] 
    @Id INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [Id], [Name], [Value], [Description], [RowStatus] 
	FROM   [dbo].[SystemProperty] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_SystemProperty_Insert]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SystemProperty_Insert] 
    @Name nvarchar(200),
    @Value nvarchar(1000),
    @Description nvarchar(1000),
    @RowStatus nchar(1)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[SystemProperty] ([Name], [Value], [Description], [RowStatus])
	SELECT @Name, @Value, @Description, @RowStatus
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [Name], [Value], [Description], [RowStatus]
	FROM   [dbo].[SystemProperty]
	WHERE  [Id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_SystemProperty_Delete]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SystemProperty_Delete] 
    @Id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[SystemProperty]
	WHERE  [Id] = @Id

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_SubtitlesText_Update]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SubtitlesText_Update] 
    @Id int,
    @SubtitleTextId bigint,
    @StartTime time,
    @EndTime time,
    @SubtitleText nvarchar(MAX)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[SubtitlesText]
	SET    [SubtitleTextId] = @SubtitleTextId, [StartTime] = @StartTime, [EndTime] = @EndTime, [SubtitleText] = @SubtitleText
	WHERE  [Id] = @Id
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [SubtitleTextId], [StartTime], [EndTime], [SubtitleText]
	FROM   [dbo].[SubtitlesText]
	WHERE  [Id] = @Id	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_SubtitlesText_SelectByTitleId]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SubtitlesText_SelectByTitleId] 
    @TitleId INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT S.[Id], S.[SubtitleTextId], S.[StartTime], S.[EndTime], S.[SubtitleText], T.Title
	FROM   [dbo].[SubtitlesText] as S
	INNER JOIN [dbo].[TitleSubtitle] as B on
	S.SubtitleTextId = B.Id
	INNER JOIN [dbo].[Titles] as T on
	T.Id = B.TitleId	
	WHERE  T.[Id] = @TitleId 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_SubtitlesText_SelectByIds]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SubtitlesText_SelectByIds] 
    @Ids varchar(max)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT S.[Id], S.[SubtitleTextId], [StartTime], [EndTime], S.[SubtitleText], T.Title, T.Id as TitleId
	FROM   [dbo].[SubtitlesText] as S 
	INNER JOIN [dbo].[TitleSubtitle] as B on
	S.SubtitleTextId = B.Id
	INNER JOIN [dbo].[Titles] as T on
	T.Id = B.TitleId
	inner join [dbo].[SplitCSVToIntTable](@Ids, ',') as C on
	c.Item = S.Id
	
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_SubtitlesText_Select]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SubtitlesText_Select] 
    @Id INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT S.[Id], [SubtitleTextId], [StartTime], [EndTime], S.[SubtitleText], T.Title
	FROM   [dbo].[SubtitlesText] as S 
	INNER JOIN [dbo].[TitleSubtitle] as B on
	S.SubtitleTextId = B.Id
	INNER JOIN [dbo].[Titles] as T on
	T.Id = B.TitleId
	WHERE  (S.[Id] = @Id OR @Id IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_SubtitlesText_Insert]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SubtitlesText_Insert] 
	@Id int output,
    @SubtitleTextId bigint,
    @StartTime time,
    @EndTime time,
    @SubtitleText nvarchar(MAX)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	INSERT INTO [dbo].[SubtitlesText] ([SubtitleTextId], [StartTime], [EndTime], [SubtitleText])
	SELECT @SubtitleTextId, @StartTime, @EndTime, @SubtitleText
	
	-- Begin Return Select <- do not remove
	set @Id = SCOPE_IDENTITY()
	return @id
	-- End Return Select <- do not remove
GO
/****** Object:  StoredProcedure [dbo].[usp_RandomSubtitleId_Get]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_RandomSubtitleId_Get]	
	@userId varchar(100) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
    -- Insert statements for procedure here
	declare @minid bigint
	declare @maxid bigint	
	select @minid = MIN(id) from SubtitlesText
	select @maxid = MAX(id) from SubtitlesText
	
	declare @subtitleIdRandom bigint 
	
	select @subtitleIdRandom =ROUND(((@maxid - @minid -1) * RAND() + @minid), 0)
	
	if(@userId is null)
	begin
		select S.*, 
				T.Title, 
				null as Rating, 
				null as UserFavoriteId  
		from SubtitlesText S 
		INNER JOIN [dbo].[TitleSubtitle] as B on
		S.SubtitleTextId = B.Id
		INNER JOIN [dbo].[Titles] as T on
		T.Id = B.TitleId
		where S.Id = @subtitleIdRandom
	end
	else
	begin
		select S.*, 
			   T.Title, 
			   UF.Rating, 
			   UF.UserFavoriteId  
		from SubtitlesText S 
		INNER JOIN [dbo].[TitleSubtitle] as B on
		S.SubtitleTextId = B.Id
		INNER JOIN [dbo].[Titles] as T on
		T.Id = B.TitleId
		LEFT OUTER JOIN [dbo].[UserFavorites] UF
		ON UF.SubtitleTextId = S.Id
		where S.Id = @subtitleIdRandom	AND 
		exists(select UserIdentification from userfavorites f where f.UserIdentification = @userId)		
	end
END
GO
/****** Object:  StoredProcedure [dbo].[usp_LookupValue_Update]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_LookupValue_Update] 
    @Id int,
    @GroupId int,
    @Name nvarchar(200),
    @Value nvarchar(2000),
    @Description nvarchar(2000),
    @RowStatus nchar(1)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[LookupValue]
	SET    [GroupId] = @GroupId, [Name] = @Name, [Value] = @Value, [Description] = @Description, [RowStatus] = @RowStatus
	WHERE  [Id] = @Id
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [GroupId], [Name], [Value], [Description], [RowStatus]
	FROM   [dbo].[LookupValue]
	WHERE  [Id] = @Id	
	-- End Return Select <- do not remove

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_LookupValue_SelectByGroup]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_LookupValue_SelectByGroup] 
    @GroupName nvarchar(100)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT 
		V.[Id], 
		V.[GroupId], 
		V.[Name], 
		V.[Value], 
		V.[Description], 
		V.[RowStatus] 
	FROM   [dbo].[LookupValue] as V 
	INNER JOIN [dbo].[LookupGroup] as G
	On V.GroupId = G.GroupId
	WHERE  (G.Name = @GroupName OR @GroupName IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_LookupValue_Select]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_LookupValue_Select] 
    @Id INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [Id], [GroupId], [Name], [Value], [Description], [RowStatus] 
	FROM   [dbo].[LookupValue] 
	WHERE  ([Id] = @Id OR @Id IS NULL) 

	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_LookupValue_Insert]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_LookupValue_Insert] 
    @GroupId int,
    @Name nvarchar(200),
    @Value nvarchar(2000),
    @Description nvarchar(2000),
    @RowStatus nchar(1)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[LookupValue] ([GroupId], [Name], [Value], [Description], [RowStatus])
	SELECT @GroupId, @Name, @Value, @Description, @RowStatus
	
	-- Begin Return Select <- do not remove
	SELECT [Id], [GroupId], [Name], [Value], [Description], [RowStatus]
	FROM   [dbo].[LookupValue]
	WHERE  [Id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_LookupValue_Delete]    Script Date: 08/12/2014 16:24:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_LookupValue_Delete] 
    @Id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[LookupValue]
	WHERE  [Id] = @Id

	COMMIT
GO
/****** Object:  ForeignKey [FK_LookupValues_LookupGroup]    Script Date: 08/12/2014 16:24:24 ******/
ALTER TABLE [dbo].[LookupValue]  WITH CHECK ADD  CONSTRAINT [FK_LookupValues_LookupGroup] FOREIGN KEY([GroupId])
REFERENCES [dbo].[LookupGroup] ([GroupId])
GO
ALTER TABLE [dbo].[LookupValue] CHECK CONSTRAINT [FK_LookupValues_LookupGroup]
GO
