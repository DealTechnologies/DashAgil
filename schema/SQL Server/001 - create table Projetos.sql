USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Projetos]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Projetos]
END
GO

CREATE TABLE [dbo].[Projetos](
	[Id] [bigInt] IDENTITY(1,1) NOT NULL,
	[ExternalId] [varchar] (max) NULL,
	[OrganizacaoId] [bigInt] NULL,
	[Nome] [varchar] (100) NOT NULL,
	[Descricao] [varchar] (100) NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataModificacao] [datetime] NULL,
	[DataExclusao] [datetime] NULL

	
 CONSTRAINT [PK_Projetos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Projetos]  WITH CHECK ADD  CONSTRAINT [FK_Projetos_OrganizacaoId] FOREIGN KEY([OrganizacaoId])
REFERENCES [dbo].[Organizacoes] ([Id])
GO

-----------------------------------------------------------------------	

BEGIN
	
	INSERT INTO [Projetos] VALUES ('NULL',1,'COP.API.Natureza',NULL,'2020-12-14 12:49:47','2020-12-14 12:49:47',NULL)
	INSERT INTO [Projetos] VALUES ('Projeto Utilizado para automação de processos e instalações nos clusters e ambientes Azure',1,'COP.AzureAutomations','Projeto Utilizado para automação de processos e instalações nos clusters e ambientes Azure','2020-12-14 12:49:47','2020-12-14 12:49:47',NULL)
	INSERT INTO [Projetos] VALUES ('Interface Cliente do Novo Internet Banking',2,'RND.IBCliente','Interface Cliente do Novo Internet Banking','2020-12-15 11:09:03','2019-10-07 09:25:16',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.PlatBoletos',NULL,'2020-12-15 11:09:03','2019-10-30 10:19:00',NULL)
	INSERT INTO [Projetos] VALUES ('Cadastro digital',2,'RND.CadastroDigital','Cadastro digital','2020-12-15 11:20:29','2019-10-07 09:22:27',NULL)
	INSERT INTO [Projetos] VALUES ('Dashboard dos projetos da equipe de Canais Digitais',2,'RND.DashboardCanaisDigitais','Dashboard dos projetos da equipe de Canais Digitais','2020-12-15 11:20:29','2020-09-15 18:41:00',NULL)
	INSERT INTO [Projetos] VALUES ('Dashboard dos projetos da equipe Core Bank',2,'RND.DashboardCoreBank','Dashboard dos projetos da equipe Core Bank','2020-12-15 11:20:29','2020-06-26 18:08:57',NULL)
	INSERT INTO [Projetos] VALUES ('Dashboard dos projetos da equipe - Escritório de Projeto',2,'RND.DashEscritoriodeProjeto','Dashboard dos projetos da equipe - Escritório de Projeto','2020-12-16 15:19:35','2020-07-17 14:01:07',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.Remittance',NULL,'2020-12-16 20:03:27','2019-10-07 09:53:46',NULL)
	INSERT INTO [Projetos] VALUES ('Rendimento Online',2,'RND.Rol','Rendimento Online','2020-12-16 20:03:28','2020-02-20 16:00:23',NULL)
	INSERT INTO [Projetos] VALUES ('Projeto desenvolvido pelo Andre Padial para leitura do arquivo de retorno do PagSeguro',2,'RND.PagSeguro','Projeto desenvolvido pelo Andre Padial para leitura do arquivo de retorno do PagSeguro','2020-12-16 20:20:05','2018-10-26 11:37:36',NULL)
	INSERT INTO [Projetos] VALUES ('RND.MS.BaaS.Autenticação',2,'RND.MS.BaaS.Autenticação','RND.MS.BaaS.Autenticação','2020-12-16 20:20:05','2020-08-10 16:52:24',NULL)
	INSERT INTO [Projetos] VALUES ('Interface Cliente do Novo Internet Banking',2,'RND.IBCliente','Interface Cliente do Novo Internet Banking','2020-12-16 20:20:05','2019-10-07 09:25:16',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.Automate',NULL,'2020-12-16 20:20:05','2017-07-15 12:05:04',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.Relatorios',NULL,'2020-12-16 20:20:05','2020-03-10 10:59:29',NULL)
	INSERT INTO [Projetos] VALUES ('Ripple',2,'RND.Ripple','Ripple','2020-12-16 20:20:05','2020-02-21 15:21:58',NULL)
	INSERT INTO [Projetos] VALUES ('Sistemas do Fornecedor Presenta Bacen Jud Web Jud',2,'RND.Presenta','Sistemas do Fornecedor Presenta Bacen Jud Web Jud','2020-12-16 20:20:05','2019-12-11 14:33:12',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.AnaliseCdc',NULL,'2020-12-16 20:20:05','2019-11-28 10:41:54',NULL)
	INSERT INTO [Projetos] VALUES ('APP para acesso ao IB Cliente',2,'RND.IBClienteAPP','APP para acesso ao IB Cliente','2020-12-16 20:20:05','2017-07-24 14:19:04',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.WSTemplateEmail',NULL,'2020-12-16 20:20:05','2020-06-04 17:45:22',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.InboundReports',NULL,'2020-12-16 20:20:05','2020-12-16 11:50:06',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.MS.BaaS.PIX.Dict',NULL,'2020-12-16 20:20:05','2020-08-10 14:32:06',NULL)
	INSERT INTO [Projetos] VALUES ('Site institucional mantido pela Just',2,'RND.SiteInstitucional','Site institucional mantido pela Just','2020-12-16 20:20:05','2020-04-09 19:23:02',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.BAAS.MS.DebitosVeiculares',NULL,'2020-12-16 20:20:05','2020-05-21 15:06:59',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.PlatBoletos',NULL,'2020-12-16 20:20:05','2019-10-30 10:19:00',NULL)
	INSERT INTO [Projetos] VALUES ('Sistema Siscoserv',2,'RND.Siscoserv','Sistema Siscoserv','2020-12-16 20:20:05','2019-11-22 16:42:02',NULL)
	INSERT INTO [Projetos] VALUES ('RND.BAAS.MS.RecargaCelular',2,'RND.BAAS.MS.RecargaCelular','RND.BAAS.MS.RecargaCelular','2020-12-16 20:20:05','2020-06-23 11:04:41',NULL)
	INSERT INTO [Projetos] VALUES ('Open Banking',2,'RND.OpenBanking','Open Banking','2020-12-16 20:20:05','2019-12-06 13:21:02',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.Integracoes',NULL,'2020-12-16 20:20:05','2020-06-30 12:12:41',NULL)
	INSERT INTO [Projetos] VALUES ('RND.MS.BaaS.PIX.QRCode',2,'RND.MS.BaaS.PIX.QRCode','RND.MS.BaaS.PIX.QRCode','2020-12-16 20:20:05','2020-08-10 16:51:10',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.VarejoCota',NULL,'2020-12-16 20:20:05','2019-12-02 13:18:28',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.FtpMan',NULL,'2020-12-16 20:20:05','2017-07-15 12:05:06',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.MS.BaaS.PIX.Pagamentos',NULL,'2020-12-16 20:20:05','2020-08-10 15:53:06',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.IBOpenBanking.TurboConvenios',NULL,'2020-12-16 20:20:05','2020-01-30 10:07:46',NULL)
	INSERT INTO [Projetos] VALUES ('Interface de administração do Novo Internet Banking',2,'RND.IBAdmin','Interface de administração do Novo Internet Banking','2020-12-16 20:20:05','2019-11-27 15:59:22',NULL)
	INSERT INTO [Projetos] VALUES ('Sistema EXChange do Rendimento',2,'RND.Change','Sistema EXChange do Rendimento','2020-12-16 20:20:05','2019-11-22 16:41:09',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.BAAS.MS.ParametrosPagamento',NULL,'2020-12-16 20:20:05','2020-08-18 11:41:55',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.Balcao',NULL,'2020-12-16 20:20:05','2019-10-07 16:17:51',NULL)
	INSERT INTO [Projetos] VALUES ('Sistemas do fornecedor Legal Control Sistema de Controle Documentos Juridicos',2,'RND.LegalControl', 'Sistemas do fornecedor Legal Control Sistema de Controle Documentos Juridicos','2020-12-16 20:20:05','2019-12-11 14:43:48',NULL)
	INSERT INTO [Projetos] VALUES ('Sistema MesaCambio  Padrão para a pasta Build:  Build   -> MesaCambio     -> MesaAsp       ...asp ',2,'RND.MesaCambio','Sistema MesaCambio  Padrão para a pasta Build:  Build   -> MesaCambio     -> MesaAsp       ...asp ','2020-12-16 20:20:05','2020-12-01 14:17:16',NULL)
	INSERT INTO [Projetos] VALUES ('PPV',2,'RND.RemessaExpressaRE-Corretora','PPV','2020-12-16 20:20:05','2020-05-06 16:51:21',NULL)
	INSERT INTO [Projetos] VALUES ('Sistema MDC4WEB - Sistema de Controle de Acesso do fornecedor Trielo',2,'RND.MDC4WEB','Sistema MDC4WEB - Sistema de Controle de Acesso do fornecedor Trielo','2020-12-16 20:20:05','2019-12-11 14:45:42',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.BRDMaster',NULL,'2020-12-16 20:20:05','2017-07-15 12:05:07',NULL)
	INSERT INTO [Projetos] VALUES ('RND.MS.BaaS.PIX',2,'RND.MS.BaaS.PIX','RND.MS.BaaS.PIX','2020-12-16 20:20:05','2020-08-10 16:51:50',NULL)
	INSERT INTO [Projetos] VALUES ('Sistema Eguardian do Fornecedor AdviceTech',2,'RND.EGuardian','Sistema Eguardian do Fornecedor AdviceTech','2020-12-16 20:20:05','2019-12-11 14:42:07',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.WebEDI',NULL,'2020-12-16 20:20:05','2020-05-20 14:50:00',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.SGPC',NULL,'2020-12-16 20:20:05','2019-10-29 15:45:28',NULL)
	INSERT INTO [Projetos] VALUES ('CRM Rendimento - Alicerce',2,'RND.CRMRendimento','CRM Rendimento - Alicerce','2020-12-16 20:20:05','2020-02-17 14:50:09',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.APP.PIX',NULL,'2020-12-16 20:20:05','2020-06-01 14:36:53',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.Remittance',NULL,'2020-12-16 20:20:05','2019-10-07 09:53:46',NULL)
	INSERT INTO [Projetos] VALUES ('Projeto CROSS-BORDER-PAYMENT',2,'RND.CrossBorderPayment','Projeto CROSS-BORDER-PAYMENT','2020-12-16 20:20:05','2019-10-16 17:34:48',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.IBCliente.Api',NULL,'2020-12-16 20:20:05','2020-08-10 15:03:06',NULL)
	INSERT INTO [Projetos] VALUES ('Sistemas do fornecedor Bludata: Rol',2,'RND.Bludata','Sistemas do fornecedor Bludata: Rol','2020-12-16 20:20:05','2020-03-10 16:51:10',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.NewSpace',NULL,'2020-12-16 20:20:05','2017-07-15 12:05:08',NULL)
	INSERT INTO [Projetos] VALUES ('Dashboard dos projetos da equipe - Escritório de Projeto',2,'RND.DashEscritoriodeProjeto','Dashboard dos projetos da equipe - Escritório de Projeto','2020-12-16 20:20:05','2020-07-17 14:01:07',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.ZipZap',NULL,'2020-12-16 20:20:05','2019-10-21 09:11:53',NULL)
	INSERT INTO [Projetos] VALUES ('RND.Baas.API',2,'RND.Baas.API','RND.Baas.API','2020-12-16 20:20:05','2020-04-29 14:52:32',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.AutomateManager',NULL,'2020-12-16 20:20:05','2017-07-15 12:05:08',NULL)
	INSERT INTO [Projetos] VALUES ('Interface para Webservices internos desenvolvida pela Quanto',2,'RND.Porteiro','Interface para Webservices internos desenvolvida pela Quanto','2020-12-16 20:20:05','2018-01-13 13:08:28',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.IBOpenBanking.TurboTributo',NULL,'2020-12-16 20:20:05','2020-03-10 14:40:48',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.ControleSustentacao',NULL,'2020-12-16 20:20:05','2017-07-15 12:05:09',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.RemittanceComprovantes',NULL,'2020-12-16 20:20:05','2017-07-15 12:05:09',NULL)
	INSERT INTO [Projetos] VALUES ('Projeto de BI do Rendimento',2,'RND.BI','Projeto de BI do Rendimento','2020-12-16 20:20:05','2020-02-17 17:56:02',NULL)
	INSERT INTO [Projetos] VALUES ('Cadastro digital',2,'RND.CadastroDigital','Cadastro digital','2020-12-16 20:20:05','2019-10-07 09:22:27',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.CadastroFeriados',NULL,'2020-12-16 20:20:05','2017-07-15 12:05:09',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.BAAS.MS.Estorno',NULL,'2020-12-16 20:20:05','2020-04-09 11:42:48',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.MoneyTransfer',NULL,'2020-12-16 20:20:05','2020-01-23 08:38:55',NULL)
	INSERT INTO [Projetos] VALUES ('Sistemas do fornecedor Easyway EasyePIS/COFINS EasyIRPJ| EasyTributos',2,'RND.Easyway','Sistemas do fornecedor Easyway EasyePIS/COFINS EasyIRPJ| EasyTributos','2020-12-16 20:20:05','2019-12-11 14:40:33',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.IBOpenBanking.TurboTitulos',NULL,'2020-12-16 20:20:05','2020-01-29 14:24:05',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.Unific',NULL,'2020-12-16 20:20:05','2019-11-26 15:18:36',NULL)
	INSERT INTO [Projetos] VALUES ('NULL',2,'RND.Confirme',NULL,'2020-12-16 20:20:05','2019-10-15 15:43:48',NULL)
	INSERT INTO [Projetos] VALUES ('Dashboard dos projetos da equipe de Canais Digitais',2,'RND.DashboardCanaisDigitais','Dashboard dos projetos da equipe de Canais Digitais','2020-12-16 20:20:05','2020-09-15 18:41:00',NULL)
	INSERT INTO [Projetos] VALUES ('Dashboard dos projetos da equipe Core Bank',2,'RND.DashboardCoreBank','Dashboard dos projetos da equipe Core Bank','2020-12-16 20:20:05','2020-06-26 18:08:57',NULL)
	INSERT INTO [Projetos] VALUES ('RND.MS.BaaS.ConciliacaoCobranca',2,'RND.MS.BaaS.ConciliacaoCobranca','RND.MS.BaaS.ConciliacaoCobranca','2020-12-16 20:20:05','2020-08-13 15:22:56',NULL)
	INSERT INTO [Projetos] VALUES ('Rendimento Online',2,'RND.Rol','Rendimento Online','2020-12-16 20:20:05','2020-02-20 16:00:23',NULL)
	
END
