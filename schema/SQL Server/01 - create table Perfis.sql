USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Perfis]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Perfis]
END
GO

CREATE TABLE [dbo].[Perfis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar] (100) NOT NULL
	
 CONSTRAINT [PK_Perfis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-----------------------------------------------------------------------	

BEGIN
	
	INSERT INTO [Perfis] VALUES ('Owner')
	INSERT INTO [Perfis] VALUES ('Administrador')
	INSERT INTO [Perfis] VALUES ('Scrum Master (SM)')
	INSERT INTO [Perfis] VALUES ('Convidado')
	
END

