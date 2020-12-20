USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[RadarAgil]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[RadarAgil]
END
GO

CREATE TABLE [dbo].[RadarAgil](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SquadId] [bigint] NOT NULL,
	[ProjetoId] [bigint] NULL,
	[DataExecucao] [datetime] NOT NULL,
	[SprintId] [bigint] NOT NULL,
	[NomeSquad] [varchar](1000) NULL,
	[JsonRadar] [varchar](max) NULL

	
 CONSTRAINT [PK_RadarAgil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-----------------------------------------------------------------------	

select * from RadarAgil ra s 