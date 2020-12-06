USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Projetos]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Projetos]
END
GO

CREATE TABLE [dbo].[Projetos](
	[Id] [bigInt] IDENTITY(1,1) NOT NULL,
	[ExternalId] [varchar] (max) NULL,
	[OrganizacaoId] [bigInt] NULL,
	[Nome] [varchar] (100) NOT NULL,
	[Descricao] [varchar] (100) NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataModificacao] [datetime] NULL,
	[DataExclusao] [datetime] NULL

	
 CONSTRAINT [PK_Projetos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Projetos]  WITH CHECK ADD  CONSTRAINT [FK_Projetos_OrganizacaoId] FOREIGN KEY([OrganizacaoId])
REFERENCES [dbo].[Organizacoes] ([Id])
GO

-----------------------------------------------------------------------	

BEGIN
	
	INSERT INTO [Projetos] VALUES (null, 1, 'COP.API.Natureza', null, GETDATE(), GETDATE(), null)
	INSERT INTO [Projetos] VALUES (null, 1, 'COP.AzureAutomations', 'Projeto Utilizado para automação de processos e instalações nos clusters e ambientes Azure', GETDATE(), GETDATE(), null)
	INSERT INTO [Projetos] VALUES (null, 1, 'COP.BCC', 'Base de Cadastro Centralizada', GETDATE(), GETDATE(), null)
	INSERT INTO [Projetos] VALUES (null, 1, 'COP.Corporate', 'Dashboard para equipe Corporate', GETDATE(), GETDATE(), null)
	INSERT INTO [Projetos] VALUES (null, 1, 'COP.ESB.Investimento', 'API de Investimento a ser integrado na ESB do Rendimento', GETDATE(), GETDATE(), null)
	INSERT INTO [Projetos] VALUES (null, 1, 'BV.PIX', null, GETDATE(), GETDATE(), null)
	INSERT INTO [Projetos] VALUES (null, 1, 'BV.Conta Corrente', null, GETDATE(), GETDATE(), null)
	INSERT INTO [Projetos] VALUES (null, 1, 'BV.Conta.Juridica', null, GETDATE(), GETDATE(), null)
	
END