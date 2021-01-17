USE db_a114c8_dashagi;

DROP TABLE IF EXISTS db_a114c8_dashagi.UsuarioSquads;

CREATE TABLE UsuarioSquads(
	Id bigInt AUTO_INCREMENT PRIMARY KEY NOT NULL,
	UsuarioId varchar(38) NOT NULL,
	SquadId bigInt NOT NULL,
	DataExclusão datetime NULL,
	Status int NOT NULL,

	CONSTRAINT FK_UsuarioSquads_UsuarioId FOREIGN KEY (UsuarioId)
    REFERENCES db_a114c8_dashagi.Usuarios(Id),
            
	CONSTRAINT FK_UsuarioSquads_SquadId FOREIGN KEY (SquadId)
    REFERENCES db_a114c8_dashagi.Squads(Id)
);

--  SQLINES DEMO *** ---------------------------------------------------
	
INSERT INTO UsuarioSquads VALUES (null, 'CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 1, null, 1);
INSERT INTO UsuarioSquads VALUES (null, 'CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 2, null, 1);
INSERT INTO UsuarioSquads VALUES (null, 'CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 3, null, 1);
INSERT INTO UsuarioSquads VALUES (null, 'CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 4, null, 1);
INSERT INTO UsuarioSquads VALUES (null, 'CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 5, null, 1);
INSERT INTO UsuarioSquads VALUES (null, 'CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 6, null, 1);
INSERT INTO UsuarioSquads VALUES (null, 'CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 7, null, 1);
INSERT INTO UsuarioSquads VALUES (null, 'CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 8, null, 1);

--  SQLINES DEMO *** ---------------------------------------------------

-- select 
-- 	U.Nome,
-- 	C.Nome as ClienteName,
-- 	S.Nome as SquadName
-- from 
-- 	UsuarioSquads Us
-- 	inner join Usuarios U on Us.UsuarioId = U.Id
-- 	inner join Squads S on Us.SquadId = S.Id
-- 	inner join Clientes C on S.ClienteId = C.Id
