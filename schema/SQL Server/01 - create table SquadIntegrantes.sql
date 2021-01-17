USE [DashAgil]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[SquadIntegrantes]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[SquadIntegrantes]
END
GO


CREATE TABLE [dbo].[SquadIntegrantes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SquadId] [bigint] NOT NULL,
	[IntegranteId] [bigint] NOT NULL,
	[AtuacaoId] [int] NOT NULL,
	[DataInicio] [datetime] NOT NULL,
	[DataFim] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_SquadIntegrantes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SquadIntegrantes]  WITH CHECK ADD  CONSTRAINT [FK_SquadIntegrantes_AtuacaoId] FOREIGN KEY([AtuacaoId])
REFERENCES [dbo].[Atuacao] ([Id])
GO

ALTER TABLE [dbo].[SquadIntegrantes] CHECK CONSTRAINT [FK_SquadIntegrantes_AtuacaoId]
GO

ALTER TABLE [dbo].[SquadIntegrantes]  WITH CHECK ADD  CONSTRAINT [FK_SquadIntegrantes_IntegranteId] FOREIGN KEY([IntegranteId])
REFERENCES [dbo].[Integrantes] ([Id])
GO

ALTER TABLE [dbo].[SquadIntegrantes] CHECK CONSTRAINT [FK_SquadIntegrantes_IntegranteId]
GO

ALTER TABLE [dbo].[SquadIntegrantes]  WITH CHECK ADD  CONSTRAINT [FK_SquadIntegrantes_SquadId] FOREIGN KEY([SquadId])
REFERENCES [dbo].[Squads] ([Id])
GO

ALTER TABLE [dbo].[SquadIntegrantes] CHECK CONSTRAINT [FK_SquadIntegrantes_SquadId]
GO

-----------------------------------------------------------------------	

--BEGIN

--	INSERT INTO [SquadIntegrantes] VALUES (1, 1, 2, getdate(), null, 1)
--	INSERT INTO [SquadIntegrantes] VALUES (1, 3, 1, getdate(), null, 1)				
--	INSERT INTO [SquadIntegrantes] VALUES (3, 3, 2, getdate(), null, 1)
--	INSERT INTO [SquadIntegrantes] VALUES (3, 4, 1, getdate(), null, 1)
--	INSERT INTO [SquadIntegrantes] VALUES (3, 6, 1, getdate(), null, 1)
	
--END

-----------------------------------------------------------------------	
