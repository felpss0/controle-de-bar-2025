-- script criação das tabelas projeto Controle de Bar

BEGIN

CREATE TABLE [dbo].[TBConta] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Titular]    NVARCHAR (100)   NOT NULL,
    [Mesa_Id]    UNIQUEIDENTIFIER NOT NULL,
    [Garcom_Id]  UNIQUEIDENTIFIER NOT NULL,
    [Abertura]   DATETIME2 (7)    NOT NULL,
    [Fechamento] DATETIME2 (7)    NULL,
    [EstaAberta] BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBConta_TBMesa] FOREIGN KEY ([Mesa_Id]) REFERENCES [dbo].[TBMesa] ([Id]),
    CONSTRAINT [FK_TBConta_TBGarcom] FOREIGN KEY ([Garcom_Id]) REFERENCES [dbo].[TBGarcom] ([Id])
);

CREATE TABLE [dbo].[TBGarcom] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Nome] NVARCHAR (100)   NOT NULL,
    [Cpf]  NVARCHAR (14)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[TBMesa] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Numero]     INT              NOT NULL,
    [Capacidade] INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[TBPedido] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Produto_Id] UNIQUEIDENTIFIER NOT NULL,
    [Conta_Id]   UNIQUEIDENTIFIER NOT NULL,
    [Quantidade] INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

END;