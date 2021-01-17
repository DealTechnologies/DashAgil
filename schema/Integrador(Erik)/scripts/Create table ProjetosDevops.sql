USE DashAgil 
GO  
IF NOT EXISTS(SELECT 1 FROM sys.sysobjects where name = 'ProjetosDevops')
BEGIN
	CREATE TABLE dbo.ProjetosDevops(
		Id UNIQUEIDENTIFIER primary key,
		Nome varchar(500) not null,
		Descricao varchar(3000) null,
		ProjetoId varchar(100) not null,
		DataUltimaAtualizacao datetime not null,
		DataCadastro datetime not null
	)
END

 