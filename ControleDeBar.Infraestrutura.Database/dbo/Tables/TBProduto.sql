﻿CREATE TABLE [dbo].[TBProduto] (
    [Id]    UNIQUEIDENTIFIER NOT NULL,
    [Nome]  NVARCHAR (100)   NOT NULL,
    [Preco] DECIMAL (18)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

