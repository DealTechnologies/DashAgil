USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Atuacao]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Atuacao]
END
GO

CREATE TABLE [dbo].[Atuacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descicao] [varchar] (100) NOT NULL	

	
 CONSTRAINT [PK_Atuacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-----------------------------------------------------------------------	

BEGIN
	
	INSERT INTO [Atuacao] VALUES ('Dev')
	INSERT INTO [Atuacao] VALUES ('LT')
	INSERT INTO [Atuacao] VALUES ('SM')
	INSERT INTO [Atuacao] VALUES ('QA')
	INSERT INTO [Atuacao] VALUES ('Arquiteto')	
	
END

