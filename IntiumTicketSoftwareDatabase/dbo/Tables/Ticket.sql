CREATE TABLE [dbo].[Ticket] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (256) NOT NULL,
    [Queue] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

