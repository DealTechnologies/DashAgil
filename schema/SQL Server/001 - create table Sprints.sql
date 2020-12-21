USE [DashAgil]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[Sprints]','U') IS NOT NULL
BEGIN
	DROP TABLE[dbo].[Sprints]
END
GO

CREATE TABLE [dbo].[Sprints] (
	[Id] [bigInt] IDENTITY(1,1) NOT NULL,
	[ExternalId] [varchar] (max) NULL,
	[ProjetoId] [bigInt] NULL,
	[SprintId] [bigInt] NULL,
	[Nome] [varchar] (100) NOT NULL,
	[Descricao] [varchar] (100) NULL,
	[DataInicio] [datetime] NOT NULL,
	[DataFim] [datetime] NULL,
	[DataConclusao] [datetime] NULL,
	[Status] [int] NOT NULL

	
 CONSTRAINT [PK_Sprints] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sprints]  WITH CHECK ADD  CONSTRAINT [FK_Sprints_ProjetoId] FOREIGN KEY([ProjetoId])
REFERENCES [dbo].[Projetos] ([Id])
GO

ALTER TABLE [dbo].[Sprints]  WITH CHECK ADD  CONSTRAINT [FK_Sprints_SprintId] FOREIGN KEY([SprintId])
REFERENCES [dbo].[Sprints] ([Id])
GO

-----------------------------------------------------------------------	

--Status:
--1 - New
--2 - Active
--3 - Resolved
--4 - Closed


--BEGIN
	
--	INSERT INTO [Sprints] VALUES ('75ec67c5-3068-4c5c-a9fe-568cc2e05d9f',6,'Sprint 5','Sprint 5','2020-12-16 20:20:05','2020-12-16 20:20:05', NULL,0)
--	INSERT INTO [Sprints] VALUES ('620ce28d-700f-4ca6-9dbf-3f9e1ec67c2e',6,'Sprint BackLog','Sprint BackLog','2020-12-16 20:20:05','2020-12-16 20:20:05', NULL,0)
--	INSERT INTO [Sprints] VALUES ('af115dfe-c90a-4d60-baf9-aec18aeb3a8b',6,'Sprint 4','Sprint 4','2020-12-16 20:20:06','2020-12-16 20:20:06', NULL,0)
--	INSERT INTO [Sprints] VALUES ('d33e0f13-850d-49cf-baaf-beb0a4425396',6,'Sprint 19','Sprint 19','2020-12-16 20:20:06','2020-12-16 20:20:06', NULL,0)
--	INSERT INTO [Sprints] VALUES ('a251ffcf-9dd1-4f54-8b5a-b4b478f728ee',6,'Sprint 18','Sprint 18','2020-12-16 20:20:11','2020-12-16 20:20:11', NULL,0)
--	INSERT INTO [Sprints] VALUES ('68c47099-5f30-4f7a-bf94-06c56e7fcedf',6,'Sprint 0','Sprint 0','2020-12-16 20:20:11','2020-12-16 20:20:11', NULL,0)
--	INSERT INTO [Sprints] VALUES ('3e9f957a-d8ab-4ff0-93c9-7e5716d224e6',6,'Sprint 16','Sprint 16','2020-12-16 20:20:13','2020-12-16 20:20:13', NULL,0)
--	INSERT INTO [Sprints] VALUES ('7710db56-9953-4f18-8075-f0133abe3351',6,'Sprint 2','Sprint 2','2020-12-16 20:20:15','2020-12-16 20:20:15', NULL,0)
--	INSERT INTO [Sprints] VALUES ('4eaa0856-4c5c-41c5-b6bd-a5a4631926d8',6,'Sprint 17','Sprint 17','2020-12-16 20:20:16','2020-12-16 20:20:16', NULL,0)
--	INSERT INTO [Sprints] VALUES ('7a16453a-20fe-4d2c-a6f6-f9c7a80253c6',6,'Sprint 1','Sprint 1','2020-12-16 20:20:17','2020-12-16 20:20:17', NULL,0)
--	INSERT INTO [Sprints] VALUES ('2d9500c7-e8cf-4a72-b8c0-f20d44b96f4c',7,'Sprint 6','Sprint 6','2020-12-16 20:20:19','2020-12-16 20:20:19', NULL,0)
--	INSERT INTO [Sprints] VALUES ('123030ae-949f-4ce7-9c16-91e756cede36',7,'Sprint 2','Sprint 2','2020-12-16 20:20:19','2020-12-16 20:20:19', NULL,0)
--	INSERT INTO [Sprints] VALUES ('b609fe90-f3bb-42a5-96f5-dfa16cf1c142',7,'Sprint BackLog','Sprint BackLog','2020-12-16 20:20:20','2020-12-16 20:20:20', NULL,0)
--	INSERT INTO [Sprints] VALUES ('a6532a3a-91a5-415a-8678-9d8df6556e29',6,'Sprint 21','Sprint 21','2020-12-16 20:20:21','2020-12-16 20:20:21', NULL,0)
--	INSERT INTO [Sprints] VALUES ('e9c28de9-a23e-4d2d-a6c0-03b92e51bdf1',7,'Sprint 5','Sprint 5','2020-12-16 20:20:21','2020-12-16 20:20:21', NULL,0)
--	INSERT INTO [Sprints] VALUES ('3577a1cc-dd20-4682-bc6c-d2efb916c40d',6,'Sprint 13','Sprint 13','2020-12-16 20:20:23','2020-12-16 20:20:23', NULL,0)
--	INSERT INTO [Sprints] VALUES ('ddefaa94-9235-445b-9158-43a35b389f12',6,'Sprint 12','Sprint 12','2020-12-16 20:20:24','2020-12-16 20:20:24', NULL,0)
--	INSERT INTO [Sprints] VALUES ('b6e1893e-e910-401c-88b6-d377640af0ce',7,'Sprint 4','Sprint 4','2020-12-16 20:20:25','2020-12-16 20:20:25', NULL,0)
--	INSERT INTO [Sprints] VALUES ('967c1798-1082-497f-a614-74388e42ef4e',7,'Sprint 3','Sprint 3','2020-12-16 20:20:28','2020-12-16 20:20:28', NULL,0)
--	INSERT INTO [Sprints] VALUES ('9d4152ed-b639-4215-a7d2-5c4522203b6a',8,'Sprint BackLog','Sprint BackLog','2020-12-16 20:20:32','2020-12-16 20:20:32', NULL,0)
--	INSERT INTO [Sprints] VALUES ('95161d0a-431c-4342-9ecd-521c04957743',6,'Sprint 22','Sprint 22','2020-12-16 20:20:52','2020-12-16 20:20:52', NULL,0)
--	INSERT INTO [Sprints] VALUES ('9e5d2514-4197-4adb-bfaa-2672f2f0927a',6,'Sprint  8','Sprint  8','2020-12-16 20:21:24','2020-12-16 20:21:24', NULL,0)
--	INSERT INTO [Sprints] VALUES ('b30f4c3c-a568-484e-993f-9bb6244d24dd',6,'Sprint 11','Sprint 11','2020-12-16 20:21:38','2020-12-16 20:21:38', NULL,0)
--	INSERT INTO [Sprints] VALUES ('6db658d0-1433-44e0-9855-741ba8d44b60',6,'Sprint 3','Sprint 3','2020-12-16 20:21:44','2020-12-16 20:21:44', NULL,0)
--	INSERT INTO [Sprints] VALUES ('525b9030-bbe5-4673-8db0-edd26fae8f32',6,'Sprint 31','Sprint 31','2020-12-16 20:21:54','2020-12-16 20:21:54', NULL,0)
--	INSERT INTO [Sprints] VALUES ('e2618149-bfa7-49f1-afc5-cb09875f0a13',6,'Sprint 8','Sprint 8','2020-12-16 20:21:54','2020-12-16 20:21:54', NULL,0)
--	INSERT INTO [Sprints] VALUES ('c14bce98-b206-43bf-adea-a7c3ccd5a72b',10,'Sprint BackLog','Sprint BackLog','2020-12-16 20:22:14','2020-12-16 20:22:14', NULL,0)
--	INSERT INTO [Sprints] VALUES ('f368eaca-3f1a-4097-960d-05b3f49993c2',9,'Sprint BackLog','Sprint BackLog','2020-12-16 20:22:15','2020-12-16 20:22:15', NULL,0)
--	INSERT INTO [Sprints] VALUES ('3367c2d6-08d3-4f03-9465-7a759c92a6e1',6,'Sprint 10','Sprint 10','2020-12-16 20:22:15','2020-12-16 20:22:15', NULL,0)
--	INSERT INTO [Sprints] VALUES ('51452b60-b34f-43fc-a6e3-88ffb035c0e6',6,'Sprints antigas','Sprints antigas','2020-12-16 20:22:20','2020-12-16 20:22:20', NULL,0)
--	INSERT INTO [Sprints] VALUES ('62e265af-1a18-4ae6-b339-c49d849edffa',6,'Sprint 20','Sprint 20','2020-12-16 20:22:25','2020-12-16 20:22:25', NULL,0)
--	INSERT INTO [Sprints] VALUES ('bd14de2f-74cd-452a-a274-6d1ea63f1e37',6,'Sprint 28','Sprint 28','2020-12-16 20:23:41','2020-12-16 20:23:41', NULL,0)
--	INSERT INTO [Sprints] VALUES ('fdaf9be2-035a-4ea5-baa7-259c1228974a',6,'Sprint 27','Sprint 27','2020-12-16 20:23:42','2020-12-16 20:23:42', NULL,0)
--	INSERT INTO [Sprints] VALUES ('f2256e1b-ea36-41cd-8be4-b087a490b728',6,'Sprint 25','Sprint 25','2020-12-16 20:23:51','2020-12-16 20:23:51', NULL,0)
--	INSERT INTO [Sprints] VALUES ('d8f1fe7f-88b0-46a7-8592-144a35a24938',6,'Sprint 24','Sprint 24','2020-12-16 20:23:53','2020-12-16 20:23:53', NULL,0)
--	INSERT INTO [Sprints] VALUES ('cd3d24c6-695d-4a13-8d09-46841728b5ad',6,'Sprint 14','Sprint 14','2020-12-16 20:24:44','2020-12-16 20:24:44', NULL,0)
--	INSERT INTO [Sprints] VALUES ('877f1696-c85e-4669-9441-5c97de7a4913',6,'Sprint 29','Sprint 29','2020-12-16 20:25:05','2020-12-16 20:25:05', NULL,0)
--	INSERT INTO [Sprints] VALUES ('3c4518e6-8348-4c26-924d-0e8e14caf458',6,'Sprint 15','Sprint 15','2020-12-16 20:25:10','2020-12-16 20:25:10', NULL,0)
--	INSERT INTO [Sprints] VALUES ('12906932-fcee-41e8-aa62-290de2d60e80',6,'Sprint 7','Sprint 7','2020-12-16 20:27:42','2020-12-16 20:27:42', NULL,0)
--	INSERT INTO [Sprints] VALUES ('f2c86e98-5d4b-465f-9ec1-6373b71df8dd',9,'Lista restritiva - Sprint 1','Lista restritiva - Sprint 1','2020-12-16 20:27:44','2020-12-16 20:27:44', NULL,0)
--	INSERT INTO [Sprints] VALUES ('aa9c2ed5-877d-480e-83a3-348e598d3d4c',6,'Sprint 23','Sprint 23','2020-12-16 20:27:51','2020-12-16 20:27:51', NULL,0)
--	INSERT INTO [Sprints] VALUES ('546c772f-fa1d-4683-a301-591e2c943eee',5,'Sprint BackLog','Sprint BackLog','2020-12-16 20:28:04','2020-12-16 20:28:04', NULL,0)
--	INSERT INTO [Sprints] VALUES ('ae2f65a1-766d-42fb-94ae-a1334b9d57bf',3,'Sprint BackLog','Sprint BackLog','2020-12-16 20:28:16','2020-12-16 20:28:16', NULL,0)
--	INSERT INTO [Sprints] VALUES ('597a213f-2ce6-40fe-b842-42ffa860da84',6,'Sprint 36','Sprint 36','2020-12-16 20:29:10','2020-12-16 20:29:10', NULL,0)
--	INSERT INTO [Sprints] VALUES ('de48df4d-5965-4fc0-a524-94ad98899f09',6,'Sprint 30','Sprint 30','2020-12-16 20:29:10','2020-12-16 20:29:10', NULL,0)
--	INSERT INTO [Sprints] VALUES ('1ef0f883-7787-4eac-a3ff-6d9f0cf41025',6,'Sprint 50','Sprint 50','2020-12-16 20:36:51','2020-12-16 20:36:51', NULL,0)
--	INSERT INTO [Sprints] VALUES ('3a054118-04c3-4926-b0b9-079a8b015c96',6,'Sprint 26','Sprint 26','2020-12-16 20:36:53','2020-12-16 20:36:53', NULL,0)
--	INSERT INTO [Sprints] VALUES ('a204cd25-caaf-4cbc-bede-d962a06c9a8d',6,'Sprint 25 - Projetos','Sprint 25 - Projetos','2020-12-16 20:36:54','2020-12-16 20:36:54', NULL,0)
--	INSERT INTO [Sprints] VALUES ('45f65525-4316-49d6-a722-fcfb201dba6e',7,'Sprint 10','Sprint 10','2020-12-16 20:37:01','2020-12-16 20:37:01', NULL,0)
--	INSERT INTO [Sprints] VALUES ('258c2d9f-4d5f-4023-8363-b745e47e17dc',6,'Sprint 32','Sprint 32','2020-12-16 20:37:10','2020-12-16 20:37:10', NULL,0)
--	INSERT INTO [Sprints] VALUES ('4134478d-44b0-48f0-9027-29156da5d54a',6,'Sprint 29 - Projetos','Sprint 29 - Projetos','2020-12-16 20:37:13','2020-12-16 20:37:13', NULL,0)
--	INSERT INTO [Sprints] VALUES ('b9fde8b3-96d4-4d38-adb3-d91935733488',6,'Sprint 49','Sprint 49','2020-12-16 20:37:36','2020-12-16 20:37:36', NULL,0)
--	INSERT INTO [Sprints] VALUES ('e4380d61-f845-4389-9481-b105fefd49ca',7,'Sprint 9','Sprint 9','2020-12-16 20:37:44','2020-12-16 20:37:44', NULL,0)
--	INSERT INTO [Sprints] VALUES ('a57919e5-1f7f-4c0d-b05f-ba874d11c10a',6,'Sprint 6','Sprint 6','2020-12-16 20:38:01','2020-12-16 20:38:01', NULL,0)
--	INSERT INTO [Sprints] VALUES ('7dfcbe72-a966-48c2-a852-4ff075dc7795',6,'Sprint 35','Sprint 35','2020-12-16 20:38:37','2020-12-16 20:38:37', NULL,0)
--	INSERT INTO [Sprints] VALUES ('5c38ba40-5528-4acd-a0db-f7575327ccdd',6,'Sprint 34','Sprint 34','2020-12-16 20:39:17','2020-12-16 20:39:17', NULL,0)
--	INSERT INTO [Sprints] VALUES ('b306602e-e39a-4c25-b343-25a50125e689',6,'Sprint 48','Sprint 48','2020-12-16 20:39:38','2020-12-16 20:39:38', NULL,0)
--	INSERT INTO [Sprints] VALUES ('6340a184-5187-4936-90bd-fb95ff2c6908',6,'Sprint 28 - Projetos','Sprint 28 - Projetos','2020-12-16 20:40:28','2020-12-16 20:40:28', NULL,0)
--	INSERT INTO [Sprints] VALUES ('42c0d731-80c1-4c6e-99d7-bd19e3721161',7,'Sprint 8','Sprint 8','2020-12-16 20:40:50','2020-12-16 20:40:50', NULL,0)
--	INSERT INTO [Sprints] VALUES ('cb6b4cba-ec0c-4294-bc72-226ab40d18bd',6,'Sprint 33','Sprint 33','2020-12-16 20:41:00','2020-12-16 20:41:00', NULL,0)
--	INSERT INTO [Sprints] VALUES ('2b6578b2-a2b6-4f18-b143-cf40aef63f6d',4,'Sprint BackLog','Sprint BackLog','2020-12-16 20:41:35','2020-12-16 20:41:35', NULL,0)
--	INSERT INTO [Sprints] VALUES ('fb0fc3f2-b8ba-40d5-bf55-76d6870d470c',6,'Sprint 47','Sprint 47','2020-12-16 20:41:40','2020-12-16 20:41:40', NULL,0)
--	INSERT INTO [Sprints] VALUES ('21b6f5ca-4b15-44ff-bee0-e3ef22cc62da',6,'Sprint 27 - Projetos','Sprint 27 - Projetos','2020-12-16 20:42:58','2020-12-16 20:42:58', NULL,0)
--	INSERT INTO [Sprints] VALUES ('a0075612-119d-4d73-b0eb-b8cbd130ccf5',6,'Sprint 46','Sprint 46','2020-12-16 20:43:56','2020-12-16 20:43:56', NULL,0)
--	INSERT INTO [Sprints] VALUES ('474a8eef-151f-4fd0-a14e-0a60c32419ad',6,'Sprint 26 - Projetos','Sprint 26 - Projetos','2020-12-16 20:44:01','2020-12-16 20:44:01', NULL,0)
--	INSERT INTO [Sprints] VALUES ('52eeece8-56ec-4bfd-8706-78a22b054429',6,'Sprint 45','Sprint 45','2020-12-16 20:45:44','2020-12-16 20:45:44', NULL,0)
--	INSERT INTO [Sprints] VALUES ('50a7f09e-ffe3-46aa-a4f6-b51820fe8812',7,'Sprint 7','Sprint 7','2020-12-16 20:45:49','2020-12-16 20:45:49', NULL,0)
--	INSERT INTO [Sprints] VALUES ('558d6568-49a5-4946-8058-7821d459bb02',6,'Sprint 17 - Sustentação','Sprint 17 - Sustentação','2020-12-16 20:54:38','2020-12-16 20:54:38', NULL,0)
	
--END
