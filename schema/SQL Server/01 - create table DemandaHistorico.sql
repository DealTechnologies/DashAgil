USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[DemandaHistorico]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[DemandaHistorico]
END
GO

CREATE TABLE [dbo].[DemandaHistorico](
	[Id] [uniqueidentifier] NOT NULL,	
	[ExternalId] [varchar] (max) NOT NULL,
	[SprintId] [BigInt] Null,
	[ProjetoId] [Bigint] Null,
	[SquadId] [bigInt] NOT NULL,
	[Tipo] [int] NOT NULL,
	[DemandaPaiId] [uniqueidentifier] NULL,
	[Responsavel] [varchar] (200) NULL,
	[DataInicio] [datetime] NOT NULL,
	[DataModificacao] [datetime] NULL,
	[DataFim] [datetime] NULL,
	[Pontos] [int] NULL,
	[Tags] [varchar] NULL,
	[Prioridade] [int] NULL,
	[HorasEstimadas] [int] NULL,
	[HorasRestantes] [int] NULL,
	[HorasUtilizadas] [int] NULL,
	[Risco] [int] NULL,
	[Comentario] [varchar] (max) NULL,
	[Status] [int] NOT NULL
)
GO

ALTER TABLE [dbo].[DemandaHistorico] WITH CHECK ADD  CONSTRAINT [FK_DemandaHistorico_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Demandas] ([Id])
GO

ALTER TABLE [dbo].[DemandaHistorico] WITH CHECK ADD  CONSTRAINT [FK_DemandaHistorico_ProjetoId] FOREIGN KEY([ProjetoId])
REFERENCES [dbo].[Projetos] ([Id])
GO

ALTER TABLE [dbo].[DemandaHistorico] WITH CHECK ADD  CONSTRAINT [FK_DemandaHistorico_SquadId] FOREIGN KEY([SquadId])
REFERENCES [dbo].[Squads] ([Id])
GO

ALTER TABLE [dbo].[DemandaHistorico] WITH CHECK ADD  CONSTRAINT [FK_DemandaHistorico_DemandaPaiId] FOREIGN KEY([DemandaPaiId])
REFERENCES [dbo].[Demandas] ([Id])
GO

-----------------------------------------------------------------------	

--Tipo:
--1 - Epico
--2 - Feature
--3 - Estoria
--4 - Task
--5 - Atividade
--6 - Cartao

BEGIN

	INSERT INTO [DemandaHistorico] VALUES ('D50B631C-17B1-4FF7-BBB6-A067F8E548DE', '4', 1, 1, 1, 1, null, null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	INSERT INTO [DemandaHistorico] VALUES ('D50B631C-17B1-4FF7-BBB6-A067F8E548DE', '4', 2, 1, 1, 1, null, null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	INSERT INTO [DemandaHistorico] VALUES ('D50B631C-17B1-4FF7-BBB6-A067F8E548DE', '4', 2, 1, 1, 1, null, null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	
END

-----------------------------------------------------------------------	

--SELECT 
--	   D.[Id]
--      ,D.[ExternalId]
--      ,C.Nome as ClienteName
--      ,S.Nome as SquadName
--      , case 
--			when D.[Tipo] = 1 then 'Epico'
--			when D.[Tipo] = 2 then 'Feature'
--			when D.[Tipo] = 3 then 'Estoria'
--			when D.[Tipo] = 4 then 'Task'
--			when D.[Tipo] = 5 then 'Cartão'
--			else cast(D.[Tipo] as varchar(max))
--	   end as Tipo
--      ,D.[DemandaPaiId]
--      ,D.[Responsavel]
--      ,D.[DataInicio]
--      ,D.[DataModificacao]
--      ,D.[DataFim]
--      ,D.[Pontos]
--      ,D.[Tags]
--      ,D.[Prioridade]
--      ,D.[HorasEstimadas]
--      ,D.[HorasRestantes]
--      ,D.[HorasUtilizadas]
--      ,D.[Risco]
--      ,D.[Comentario]
--      ,D.[Status]
--  FROM 
--	[DashAgil].[dbo].[Demandas] D
--	inner join Squads S on D.SquadId = S.Id
--	inner join Clientes C on D.ClienteId = C.Id
--WHERE
--	SquadId = 1
--order by
--	DemandaPaiId



--SELECT 
--	   D.[Id]
--      ,D.[ExternalId]
--      ,C.Nome as ClienteName
--      ,S.Nome as SquadName
--      , case 
--			when D.[Tipo] = 1 then 'Epico'
--			when D.[Tipo] = 2 then 'Feature'
--			when D.[Tipo] = 3 then 'Estoria'
--			when D.[Tipo] = 4 then 'Task'
--			when D.[Tipo] = 5 then 'Cartão'
--			else cast(D.[Tipo] as varchar(max))
--	   end as Tipo
--      ,D.[DemandaPaiId]
--      ,D.[Responsavel]
--      ,D.[DataInicio]
--      ,D.[DataModificacao]
--      ,D.[DataFim]
--      ,D.[Pontos]
--      ,D.[Tags]
--      ,D.[Prioridade]
--      ,D.[HorasEstimadas]
--      ,D.[HorasRestantes]
--      ,D.[HorasUtilizadas]
--      ,D.[Risco]
--      ,D.[Comentario]
--      ,D.[Status]
--  FROM 
--	[DashAgil].[dbo].[Demandas] D
--	inner join Squads S on D.SquadId = S.Id
--	inner join Clientes C on D.ClienteId = C.Id
--WHERE
--	SquadId = 8
--order by
--	DemandaPaiId
