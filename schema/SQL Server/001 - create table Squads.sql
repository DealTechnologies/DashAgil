USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Squads]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Squads]
END
GO

CREATE TABLE [dbo].[Squads] (
	[Id] [bigInt] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar] (200) NOT NULL,
	[Descricao] [varchar] (200) NOT NULL,
	[ProjetoId] [bigInt] NOT NULL,
	[SubSquadId] [bigInt] NULL,
	[DataInicio] [dateTime] NOT NULL,
	[DataFim] [dateTime] NULL,
	[Status] [int] NOT NULL
	
 CONSTRAINT [PK_Squads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Squads]  WITH CHECK ADD  CONSTRAINT [FK_Squads_Projetos] FOREIGN KEY([ProjetoId])
REFERENCES [dbo].[Projetos] ([Id])
GO

ALTER TABLE [dbo].[Squads]  WITH CHECK ADD  CONSTRAINT [FK_Squads_SubSquadId] FOREIGN KEY([SubSquadId])
REFERENCES [dbo].[Squads] ([Id])
GO

-----------------------------------------------------------------------	

BEGIN
	
	INSERT INTO [Squads] VALUES ('HC','Health Check',1,NULL,'2020-12-14 12:49:53',NULL,1)
	INSERT INTO [Squads] VALUES ('BCC','Base Centralizadora de Clientes',1,NULL,'2020-06-17 12:49:53','2020-11-14 12:49:53',2)
	INSERT INTO [Squads] VALUES ('IB','IB',1,NULL,'2020-12-14 12:49:53',NULL,1)
	INSERT INTO [Squads] VALUES ('Melhorias Google','Melhorias Google',1,NULL,'2020-12-14 12:49:53',NULL,1)
	INSERT INTO [Squads] VALUES ('Melhorias Google - A','Melhorias Google',1,4,'2020-12-14 12:49:53',NULL,1)
	INSERT INTO [Squads] VALUES ('Melhorias Google - B','Melhorias Google',1,4,'2020-12-14 12:49:53',NULL,1)
	INSERT INTO [Squads] VALUES ('Melhorias Google - C','Melhorias Google',1,4,'2020-12-14 12:49:53',NULL,1)
	INSERT INTO [Squads] VALUES ('Squad A','Squad A',2,NULL,'2020-11-24 12:49:53','2020-12-04 12:49:53',2)
	INSERT INTO [Squads] VALUES ('Projetos','Projetos',6,NULL,'2020-12-15 11:31:09',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCanaisDigitais\Cadastro Digital','RND.DashboardCanaisDigitais\Cadastro Digital',6,NULL,'2020-12-15 12:01:05',NULL,0)
	INSERT INTO [Squads] VALUES ('Melhorias E Sustentação','Melhorias E Sustentação',6,NULL,'2020-12-15 12:42:27',NULL,0)
	INSERT INTO [Squads] VALUES ('Migração Rendcard','Migração Rendcard',6,NULL,'2020-12-15 13:03:05',NULL,0)
	INSERT INTO [Squads] VALUES ('Regulatórios','Regulatórios',6,NULL,'2020-12-15 13:05:11',NULL,0)
	INSERT INTO [Squads] VALUES ('Sustentação','Sustentação',6,NULL,'2020-12-16 14:29:32',NULL,0)
	INSERT INTO [Squads] VALUES ('Negócios','Negócios',6,NULL,'2020-12-16 14:29:33',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.CadastroDigital','RND.CadastroDigital',5,NULL,'2020-12-16 14:31:31',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCanaisDigitais\BI','RND.DashboardCanaisDigitais\BI',6,NULL,'2020-12-16 14:31:50',NULL,0)
	INSERT INTO [Squads] VALUES ('Arrecadação','Arrecadação',7,NULL,'2020-12-16 14:31:54',NULL,0)
	INSERT INTO [Squads] VALUES ('Integrações','Integrações',6,NULL,'2020-12-16 14:32:29',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.IBCliente','RND.IBCliente',3,NULL,'2020-12-16 14:34:43',NULL,0)
	INSERT INTO [Squads] VALUES ('Segurança','Segurança',6,NULL,'2020-12-16 14:54:43',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.PlatBoletos','RND.PlatBoletos',4,NULL,'2020-12-16 15:11:22',NULL,0)
	INSERT INTO [Squads] VALUES ('Internet Banking','Internet Banking',6,NULL,'2020-12-16 15:32:17',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCanaisDigitais','RND.DashboardCanaisDigitais',6,NULL,'2020-12-16 15:34:01',NULL,0)
	INSERT INTO [Squads] VALUES ('Cash','Cash',7,NULL,'2020-12-16 15:38:15',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashEscritoriodeProjeto','RND.DashEscritoriodeProjeto',8,NULL,'2020-12-16 15:38:20',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCoreBank\SPI','RND.DashboardCoreBank\SPI',7,NULL,'2020-12-16 15:38:23',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCoreBank','RND.DashboardCoreBank',7,NULL,'2020-12-16 15:38:32',NULL,0)
	INSERT INTO [Squads] VALUES ('Melhorias','Melhorias',6,NULL,'2020-12-16 15:39:51',NULL,0)
	INSERT INTO [Squads] VALUES ('Marketing','Marketing',6,NULL,'2020-12-16 15:47:44',NULL,0)
	INSERT INTO [Squads] VALUES ('Onboarding','Onboarding',6,NULL,'2020-12-16 20:04:56',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.Rol','RND.Rol',10,NULL,'2020-12-16 20:05:08',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.Remittance','RND.Remittance',9,NULL,'2020-12-16 20:05:09',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCoreBank\Confirme','RND.DashboardCoreBank\Confirme',7,NULL,'2020-12-16 20:08:06',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCoreBank\PagSat','RND.DashboardCoreBank\PagSat',7,NULL,'2020-12-16 20:10:27',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCoreBank\Registro e Monitoramento CERC','RND.DashboardCoreBank\Registro e Monitoramento CERC',7,NULL,'2020-12-16 20:10:28',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCoreBank\Garantias','RND.DashboardCoreBank\Garantias',7,NULL,'2020-12-16 20:10:28',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCoreBank\CCB','RND.DashboardCoreBank\CCB',7,NULL,'2020-12-16 20:11:09',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCoreBank\24 x 7','RND.DashboardCoreBank\24 x 7',7,NULL,'2020-12-16 20:11:12',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.DashboardCoreBank\Portabilidade','RND.DashboardCoreBank\Portabilidade',7,NULL,'2020-12-16 20:11:18',NULL,0)
	INSERT INTO [Squads] VALUES ('RND.IBCliente\Melhorias','RND.IBCliente\Melhorias',3,NULL,'2020-12-16 20:12:43',NULL,0)
	
END