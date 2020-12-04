USE DashAgil 
GO  
IF NOT EXISTS(SELECT 1 FROM sys.sysobjects where name = 'TiposWorkItensDevops')
BEGIN
	CREATE TABLE dbo.TiposWorkItensDevops(
		Id UNIQUEIDENTIFIER primary key,
		Nome varchar(500) not null,
		Url varchar(3000) null,
		WorkItemTypeId varchar(100) not null, 
		DataCadastro datetime not null
	)
END
