USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Provedores]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Provedores]
END
GO

CREATE TABLE [dbo].[Provedores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar] (200) NOT NULL,
	[Ativo] [bit] NOT NULL	
	
 CONSTRAINT [PK_Provedores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-----------------------------------------------------------------------	

BEGIN
	
	INSERT INTO [Provedores] VALUES ('DevOps', 1)
	INSERT INTO [Provedores] VALUES ('Jira', 1)
	INSERT INTO [Provedores] VALUES ('Trello', 1)
	
END
