USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Demandas]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Demandas]
END
GO

CREATE TABLE [dbo].[Demandas](
	[Id] [uniqueidentifier] NOT NULL,
	[ExternalId] [varchar] (max) NOT NULL,
	[ClienteId] [int] NOT NULL,
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

	
 CONSTRAINT [PK_Demandas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Demandas]  WITH CHECK ADD  CONSTRAINT [FK_Demandas_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO

ALTER TABLE [dbo].[Demandas]  WITH CHECK ADD  CONSTRAINT [FK_Demandas_SquadId] FOREIGN KEY([SquadId])
REFERENCES [dbo].[Squads] ([Id])
GO

ALTER TABLE [dbo].[Demandas]  WITH CHECK ADD  CONSTRAINT [FK_Demandas_DemandaPaiId] FOREIGN KEY([DemandaPaiId])
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

	INSERT INTO [Demandas] VALUES ('D50B631C-17B1-4FF7-BBB6-A067F8E548DE', '4', 1, 1, 1, null, null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	INSERT INTO [Demandas] VALUES ('A5CB0A0F-CA93-4975-B6BA-6F9C8AFF9967', '5', 1, 1, 2, 'D50B631C-17B1-4FF7-BBB6-A067F8E548DE', null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	INSERT INTO [Demandas] VALUES ('2FBA7D69-6B99-4A19-B1DB-3808E5F1C504', '6', 1, 1, 3, 'A5CB0A0F-CA93-4975-B6BA-6F9C8AFF9967', null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	INSERT INTO [Demandas] VALUES ('B2FC9C51-5075-4773-9D8A-9752041C438F', '7', 1, 1, 4, '2FBA7D69-6B99-4A19-B1DB-3808E5F1C504', null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)

	INSERT INTO [Demandas] VALUES ('67A01E08-7DCD-46CA-BD14-6B931734C8AD', '1', 2, 8, 1, null, null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	INSERT INTO [Demandas] VALUES ('948B8DA5-E242-439D-9E53-9689904107F1', '2', 2, 8, 2, '67A01E08-7DCD-46CA-BD14-6B931734C8AD', null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	INSERT INTO [Demandas] VALUES ('27424B0C-BF7D-4A2C-9CB6-F366E6B38CC5', '3', 2, 8, 3, '948B8DA5-E242-439D-9E53-9689904107F1', null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	INSERT INTO [Demandas] VALUES ('B72ABCE4-16FA-41CA-A4B0-40522C68A84A', '3', 2, 8, 4, '27424B0C-BF7D-4A2C-9CB6-F366E6B38CC5', null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	INSERT INTO [Demandas] VALUES ('78203C63-D0C5-44AE-A957-130C76369D99', '3', 2, 8, 4, '27424B0C-BF7D-4A2C-9CB6-F366E6B38CC5', null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	INSERT INTO [Demandas] VALUES ('0605DA6B-F491-45A9-8C4D-3001546ADDA0', '3', 2, 8, 4, '27424B0C-BF7D-4A2C-9CB6-F366E6B38CC5', null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	INSERT INTO [Demandas] VALUES ('0138432C-705A-4D7C-BF2D-B3B00392246D', '3', 2, 8, 4, '27424B0C-BF7D-4A2C-9CB6-F366E6B38CC5', null, GETDATE(), null, null, null, null, null, null, null, null, null, null, 1)
	
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
