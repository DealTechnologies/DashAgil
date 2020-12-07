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
	
	INSERT INTO [Squads] VALUES ('HC', 'Health Check', 1, null, GETDATE(), null, 1)
	INSERT INTO [Squads] VALUES ('BCC', 'Base Centralizadora de Clientes', 1, null, DATEADD(day, -180, GETDATE()), DATEADD(day, -30, GETDATE()), 2)
	INSERT INTO [Squads] VALUES ('IB', 'IB', 1, null, GETDATE(), null, 1)
	INSERT INTO [Squads] VALUES ('Melhorias Google', 'Melhorias Google', 1, null, GETDATE(), null, 1)
	INSERT INTO [Squads] VALUES ('Melhorias Google - A', 'Melhorias Google', 1, 4, GETDATE(), null, 1)
	INSERT INTO [Squads] VALUES ('Melhorias Google - B', 'Melhorias Google', 1, 4, GETDATE(), null, 1)
	INSERT INTO [Squads] VALUES ('Melhorias Google - C', 'Melhorias Google', 1, 4, GETDATE(), null, 1)
	INSERT INTO [Squads] VALUES ('Squad A', 'Squad A', 2, null, DATEADD(day, -20, GETDATE()),  DATEADD(day, -10, GETDATE()), 2)
	
END
