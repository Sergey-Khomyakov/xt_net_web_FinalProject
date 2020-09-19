CREATE TABLE [dbo].[BookModel] (
    [BookModelId]     INT             IDENTITY (1, 1) NOT NULL,
    [Author]          NVARCHAR (50)   NOT NULL,
    [Pages]           INT             NOT NULL,
    [Image]           VARBINARY (MAX) NULL,
    [DateCreatedBook] DATETIME        NOT NULL,
    [Genre]           NVARCHAR (50)   NOT NULL,
    [Description]     NVARCHAR (MAX)  NOT NULL,
    [BookId]          INT             NOT NULL,
    [Title]           NVARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_BookModel] PRIMARY KEY CLUSTERED ([BookModelId] ASC)
);

