USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Organizacoes]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Organizacoes]
END
GO

CREATE TABLE [dbo].[Organizacoes](
	[Id] [bigInt] IDENTITY(1,1) NOT NULL,
	[ExternalId] [varchar] (max) NULL,
	[ClienteId] [int] NOT NULL,
	[Nome] [varchar] (100) NOT NULL,
	[Descricao] [varchar] (100) NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataModificacao] [datetime] NULL

	
 CONSTRAINT [PK_Organizacoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Organizacoes]  WITH CHECK ADD  CONSTRAINT [FK_Organizacoes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO

-----------------------------------------------------------------------	

BEGIN
	
	INSERT INTO [Organizacoes] VALUES (null, 1, 'Corporativo', 'CORP', GETDATE(), GETDATE())
	INSERT INTO [Organizacoes] VALUES (null, 1, 'Rendimento', 'REND', GETDATE(), GETDATE())
	INSERT INTO [Organizacoes] VALUES (null, 2, 'Jira', 'Jira', GETDATE(), GETDATE())
	INSERT INTO [Organizacoes] VALUES (null, 3, 'Tool', 'Tool', GETDATE(), GETDATE())	
	
END