USE db_a114c8_dashagi;

DROP TABLE IF EXISTS db_a114c8_dashagi.Provedores;


CREATE TABLE Provedores(
	Id int AUTO_INCREMENT PRIMARY KEY NOT NULL,
	Descricao varchar (200) NOT NULL,
	Ativo bit NOT NULL	
);

--  SQLINES DEMO *** ---------------------------------------------------

INSERT INTO Provedores VALUES (null, 'DevOps', 1);
INSERT INTO Provedores VALUES (null, 'Jira', 1);
INSERT INTO Provedores VALUES (null, 'Trello', 1);	
