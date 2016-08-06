CREATE TABLE [dbo].[Table] (
    [Id]        INT           NOT NULL,
    [Type]      NVARCHAR (50) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [Address]   NVARCHAR (50) NOT NULL,
    [Pin]       INT   NOT NULL,
    [Contact]   INT  NOT NULL,
    [City]      NVARCHAR (50) NOT NULL,
    [Photo]     IMAGE         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
