USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Emails]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Emails]
END
GO

CREATE TABLE [dbo].[Emails](
	[Id] [uniqueidentifier] NOT NULL,
	[Assunto] [varchar] (200) NULL,
	[Conteudo] [varchar] (max) NOT NULL,
	[Anexos] [varchar] (200) NULL,
	[Remetente] [varchar] (150) NOT NULL,
	[Destinatario] [varchar] (200) NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataEnvio] [datetime] NULL,
	[Entregues] [varchar] (max) NULL,
	[Lixo] [varchar] (max) NULL,
	[Rejeitados] [varchar] (max) NULL,
	[Abertos] [varchar] (max) NULL,
	[Status] [int] NOT NULL	

	
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-----------------------------------------------------------------------	