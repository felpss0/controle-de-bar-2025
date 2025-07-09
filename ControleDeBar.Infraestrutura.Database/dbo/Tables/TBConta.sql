CREATE TABLE [dbo].[TBConta] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Titular]    NVARCHAR (100)   NOT NULL,
    [Mesa_Id]    UNIQUEIDENTIFIER NOT NULL,
    [Garcom_Id]  UNIQUEIDENTIFIER NOT NULL,
    [Abertura]   DATETIME2 (7)    NOT NULL,
    [Fechamento] DATETIME2 (7)    NULL,
    [EstaAberta] BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBConta_TBGarcom] FOREIGN KEY ([Garcom_Id]) REFERENCES [dbo].[TBGarcom] ([Id]),
    CONSTRAINT [FK_TBConta_TBMesa] FOREIGN KEY ([Mesa_Id]) REFERENCES [dbo].[TBMesa] ([Id])
);

