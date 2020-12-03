USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Clientes]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Clientes]
END
GO

CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[ProvedorId] [int] NOT NULL,
	[DataInicio] [datetime] NOT NULL,
	[DataCancelamento] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_ProvedorId] FOREIGN KEY([ProvedorId])
REFERENCES [dbo].[Provedores] ([Id])
GO

-----------------------------------------------------------------------	

BEGIN
	
	INSERT INTO [Clientes] VALUES ('Banco Rendimento', 1, GETDATE(), null, 1)
	INSERT INTO [Clientes] VALUES ('Banco Votorantim', 2, GETDATE(), null, 1)
	INSERT INTO [Clientes] VALUES ('Tool Seguros', 3, GETDATE(), GETDATE(), 2)
	INSERT INTO [Clientes] VALUES ('LTM', 3, GETDATE(), null, 1)
	
END

