USE db_a114c8_dashagi;

DROP TABLE IF EXISTS db_a114c8_dashagi.Squads;

CREATE TABLE Squads(
	Id bigInt AUTO_INCREMENT PRIMARY KEY NOT NULL,
	Nome varchar (200) NOT NULL,
	Descricao varchar (200) NOT NULL,
	ClienteId int NOT NULL,
	SubSquadId bigInt NULL,
	DataInicio dateTime NOT NULL,
	DataFim dateTime NULL,
	Status int NOT NULL,
    
	CONSTRAINT FK_Squads_ClienteId FOREIGN KEY (ClienteId)
    REFERENCES db_a114c8_dashagi.Clientes(Id),
            
	CONSTRAINT FK_Squads_SubSquadId FOREIGN KEY (SubSquadId)
    REFERENCES db_a114c8_dashagi.Squads(Id)
);

--  SQLINES DEMO *** ---------------------------------------------------
	
INSERT INTO Squads VALUES (null, 'HC', 'Health Check', 1, null, Now(), null, 1);
INSERT INTO Squads VALUES (null, 'BCC', 'Base Centralizadora de Clientes', 1, null, DATE_ADD(Now(), Interval -180 day), DATE_ADD(Now(), Interval -30 day), 2);
INSERT INTO Squads VALUES (null, 'IB', 'IB', 1, null, Now(), null, 1);
INSERT INTO Squads VALUES (null, 'Melhorias Google', 'Melhorias Google', 1, null, Now(), null, 1);
INSERT INTO Squads VALUES (null, 'Melhorias Google - A', 'Melhorias Google', 1, 4, Now(), null, 1);
INSERT INTO Squads VALUES (null, 'Melhorias Google - B', 'Melhorias Google', 1, 4, Now(), null, 1);
INSERT INTO Squads VALUES (null, 'Melhorias Google - C', 'Melhorias Google', 1, 4, Now(), null, 1);
INSERT INTO Squads VALUES (null, 'Squad A', 'Squad A', 2, null, DATE_ADD(Now(), Interval -20 day),  DATE_ADD(Now(), Interval -10 day), 2);
