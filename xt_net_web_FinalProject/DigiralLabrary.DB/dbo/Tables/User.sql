CREATE TABLE [dbo].[User] (
    [UserId]     INT             IDENTITY (1, 1) NOT NULL,
    [Login]      NVARCHAR (50)   NOT NULL,
    [Password]   NVARCHAR (50)   NOT NULL,
    [Image]      VARBINARY (MAX) NULL,
    [Role]       NVARCHAR (50)   NOT NULL,
    [FamilyName] NVARCHAR (50)   NOT NULL,
    [Name]       NVARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

