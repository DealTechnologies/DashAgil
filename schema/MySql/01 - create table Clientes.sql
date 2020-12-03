USE db_a114c8_dashagi;

DROP TABLE IF EXISTS db_a114c8_dashagi.Squads;

CREATE TABLE Clientes(
	Id int AUTO_INCREMENT PRIMARY KEY NOT NULL,
	Nome varchar(200) NOT NULL,
	ProvedorId int NOT NULL,
	DataInicio datetime NOT NULL,
	DataCancelamento datetime NULL,
	Status int NOT NULL,
    
    CONSTRAINT FK_Clientes_ProvedorId FOREIGN KEY (ProvedorId)
    REFERENCES db_a114c8_dashagi.Provedores(Id)
);

--  SQLINES DEMO *** ---------------------------------------------------
	
INSERT INTO Clientes VALUES (null, 'Banco Rendimento', 1, Now(), null, 1);
INSERT INTO Clientes VALUES (null, 'Banco Votorantim', 2, Now(), null, 1);
INSERT INTO Clientes VALUES (null, 'Tool Seguros', 3, Now(), Now(), 2);
INSERT INTO Clientes VALUES (null, 'LTM', 3, Now(), null, 1);


