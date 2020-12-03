USE db_a114c8_dashagi;

DROP TABLE IF EXISTS db_a114c8_dashagi.SquadIntegrantes;

CREATE TABLE SquadIntegrantes(
	Id bigint AUTO_INCREMENT PRIMARY KEY NOT NULL,
	SquadId bigint NOT NULL,
	IntegranteId bigint NOT NULL,
	AtuacaoId int NOT NULL,
	DataInicio datetime NOT NULL,
	DataFim datetime NULL,
	Status int NOT NULL,
    
	CONSTRAINT FK_SquadIntegrantes_AtuacaoId FOREIGN KEY (AtuacaoId)
    REFERENCES db_a114c8_dashagi.Atuacao(Id),
            
	CONSTRAINT FK_SquadIntegrantes_IntegranteId FOREIGN KEY (IntegranteId)
    REFERENCES db_a114c8_dashagi.Integrantes(Id)

);

--  SQLINES DEMO *** ---------------------------------------------------
	
INSERT INTO SquadIntegrantes VALUES (null, 1, 1, 2, now(), null, 1);
INSERT INTO SquadIntegrantes VALUES (null, 1, 3, 1, now(), null, 1);
INSERT INTO SquadIntegrantes VALUES (null, 3, 3, 2, now(), null, 1);
INSERT INTO SquadIntegrantes VALUES (null, 3, 4, 1, now(), null, 1);
INSERT INTO SquadIntegrantes VALUES (null, 3, 6, 1, now(), null, 1);
-----------------------------------------------------------------------	

-- select 
-- 	U.Nome,
-- 	C.Nome as ClienteName,
-- 	S.Nome as SquadName
-- from 
-- 	UsuarioSquads Us
--	inner join Usuarios U on Us.UsuarioId = U.Id
--	inner join Squads S on Us.SquadId = S.Id
-- 	inner join Clientes C on S.ClienteId = C.Id
