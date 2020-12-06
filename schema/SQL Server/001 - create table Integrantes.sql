USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Integrantes]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Integrantes]
END
GO

CREATE TABLE [dbo].[Integrantes](
	[Id] [bigInt] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar] (100) NOT NULL,
	[Email] [varchar] (100) NOT NULL,
	[AtuacaoId] [int] NOT NULL,
	[Classificacao] [int] NOT NULL

	
 CONSTRAINT [PK_Integrantes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Integrantes]  WITH CHECK ADD  CONSTRAINT [FK_Integrantes_AtuacaoId] FOREIGN KEY([AtuacaoId])
REFERENCES [dbo].[Atuacao] ([Id])
GO


-----------------------------------------------------------------------	
--Classificacao:
--1 - Estagiário
--2 - Junior
--3 - Pleno
--4 - Senior


BEGIN
	
	INSERT INTO [Integrantes] VALUES ('Luciano Santos Henrique', 'luciano.henrique@deal.com.br', 2, 4)
	INSERT INTO [Integrantes] VALUES ('Sergio Takeda', 'sergio.takeda@deal.com.br', 3, 4)
	INSERT INTO [Integrantes] VALUES ('Hoeliton', 'hoeliton.hoeliton@deal.com.br', 2, 4)
	INSERT INTO [Integrantes] VALUES ('Murilo Carrion', 'murilo.carrion@deal.com.br', 1, 4)
	INSERT INTO [Integrantes] VALUES ('Everson Jean', 'everson.jean@deal.com.br', 1, 4)
	INSERT INTO [Integrantes] VALUES ('Erik Santos', 'erik.santos@deal.com.br', 1, 4)
	INSERT INTO [Integrantes] VALUES ('Madureira', 'madureira@deal.com.br', 3, 4)
	INSERT INTO [Integrantes] VALUES ('Marcos Baião', 'marcos.baiao@deal.com.br', 1, 1)
	
END

