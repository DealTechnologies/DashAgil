USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Sprints]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Sprints]
END
GO

CREATE TABLE [dbo].[Sprints] (
	[Id] [bigInt] IDENTITY(1,1) NOT NULL,
	[ExternalId] [varchar] (max) NULL,
	[ProjetoId] [bigInt] NULL,
	[Nome] [varchar] (100) NOT NULL,
	[Descricao] [varchar] (100) NULL,
	[DataInicio] [datetime] NOT NULL,
	[DataFim] [datetime] NULL,
	[DataConclusao] [datetime] NULL,
	[Status] [int] NOT NULL

	
 CONSTRAINT [PK_Sprints] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sprints]  WITH CHECK ADD  CONSTRAINT [FK_Sprints_ProjetoId] FOREIGN KEY([ProjetoId])
REFERENCES [dbo].[Projetos] ([Id])
GO

-----------------------------------------------------------------------	

--Status:
--1 - New
--2 - Active
--3 - Resolved
--4 - Closed


BEGIN
	
	INSERT INTO [Sprints] VALUES (Null, 1, 'sprint 1', 'sprint numero 1', getdate(), getdate(), dateAdd(day, 3,getdate()), 3)
	INSERT INTO [Sprints] VALUES (Null, 1, 'sprint 1', 'sprint numero 1', getdate(), getdate(), dateAdd(day, 3,getdate()), 3)
	INSERT INTO [Sprints] VALUES (Null, 1, 'sprint 1', 'sprint numero 1', getdate(), getdate(), dateAdd(day, 3,getdate()), 3)
	INSERT INTO [Sprints] VALUES (Null, 1, 'sprint 1', 'sprint numero 1', getdate(), getdate(), dateAdd(day, 3,getdate()), 3)
	INSERT INTO [Sprints] VALUES (Null, 1, 'sprint 1', 'sprint numero 1', getdate(), getdate(), dateAdd(day, 3,getdate()), 3)
	INSERT INTO [Sprints] VALUES (Null, 1, 'sprint 1', 'sprint numero 1', getdate(), getdate(), dateAdd(day, 3,getdate()), 3)
	INSERT INTO [Sprints] VALUES (Null, 1, 'sprint 1', 'sprint numero 1', getdate(), getdate(), dateAdd(day, 3,getdate()), 3)
	INSERT INTO [Sprints] VALUES (Null, 1, 'sprint 1', 'sprint numero 1', getdate(), getdate(), dateAdd(day, 3,getdate()), 3)
	
END