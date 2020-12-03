USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[UsuarioSquads]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[UsuarioSquads]
END
GO

CREATE TABLE [dbo].[UsuarioSquads](
	[Id] [bigInt] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [uniqueidentifier] NOT NULL,
	[SquadId] [bigInt] NOT NULL,
	[DataExclusão] [datetime] NULL,
	[Status] [int] NOT NULL

	
 CONSTRAINT [PK_UsuarioSquads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UsuarioSquads]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioSquads_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[UsuarioSquads]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioSquads_SquadId] FOREIGN KEY([SquadId])
REFERENCES [dbo].[Squads] ([Id])
GO

-----------------------------------------------------------------------	

BEGIN
	
	INSERT INTO [UsuarioSquads] VALUES ('CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 1, null, 1)
	INSERT INTO [UsuarioSquads] VALUES ('CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 2, null, 1)
	INSERT INTO [UsuarioSquads] VALUES ('CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 3, null, 1)
	INSERT INTO [UsuarioSquads] VALUES ('CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 4, null, 1)
	INSERT INTO [UsuarioSquads] VALUES ('CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 5, null, 1)
	INSERT INTO [UsuarioSquads] VALUES ('CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 6, null, 1)
	INSERT INTO [UsuarioSquads] VALUES ('CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 7, null, 1)
	INSERT INTO [UsuarioSquads] VALUES ('CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 8, null, 1)	
	
END

-----------------------------------------------------------------------	

--select 
--	U.Nome,
--	C.Nome as ClienteName,
--	S.Nome as SquadName
--from 
--	UsuarioSquads Us
--	inner join Usuarios U on Us.UsuarioId = U.Id
--	inner join Squads S on Us.SquadId = S.Id
--	inner join Clientes C on S.ClienteId = C.Id
