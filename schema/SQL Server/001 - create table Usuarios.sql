USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Usuarios]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Usuarios]
END
GO

CREATE TABLE [dbo].[Usuarios](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar] (200) NOT NULL,
	[Email] [varchar] (250) NOT NULL,
	[PerfilId] [int] NOT NULL
	
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_PerfilId] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfis] ([Id])
GO

-----------------------------------------------------------------------	

BEGIN
	
	INSERT INTO [Usuarios] VALUES ('CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 'Luciano Santos', 'luciano.henrique@deal.com.br',1)
	INSERT INTO [Usuarios] VALUES ('027FAEE0-65B2-4E18-8764-FA3E99DFE927', 'Sergio Takeda', 'sergio.takeda@deal.com.br',1)
	INSERT INTO [Usuarios] VALUES ('6A944199-5A87-4A22-969F-7E3DC59E7FCA', 'Fernando Madureira', 'fernando.madureira@deal.com.br',1)
	INSERT INTO [Usuarios] VALUES ('C8B7A4FD-0686-46E3-8F7D-AD1A813B2482', 'Marcos Ulber Baião', 'marcos.vitor@deal.com.br',1)
	
END
