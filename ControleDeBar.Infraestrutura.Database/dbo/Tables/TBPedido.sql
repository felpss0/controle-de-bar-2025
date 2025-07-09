CREATE TABLE [dbo].[TBPedido] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Produto_Id] UNIQUEIDENTIFIER NOT NULL,
    [Conta_Id]   UNIQUEIDENTIFIER NOT NULL,
    [Quantidade] INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

