CREATE TABLE db_a114c8_dashagi.Usuarios (
	Id CHAR(38) PRIMARY KEY NOT NULL,
	Nome varchar (200) NOT NULL,
	Email varchar (250) NOT NULL,
	PerfilId int NOT NULL
);

ALTER TABLE db_a114c8_dashagi.Usuarios ADD CONSTRAINT FK_Usuarios_PerfilId FOREIGN KEY(PerfilId)
REFERENCES db_a114c8_dashagi.Perfis (Id);


INSERT INTO db_a114c8_dashagi.Usuarios VALUES ('CEF95AA6-BFD0-4CDE-8A5B-685A9E920E96', 'Luciano Santos', 'luciano.henrique@deal.com.br',1);
INSERT INTO db_a114c8_dashagi.Usuarios VALUES ('027FAEE0-65B2-4E18-8764-FA3E99DFE927', 'Sergio Takeda', 'sergio.takeda@deal.com.br',1);
INSERT INTO db_a114c8_dashagi.Usuarios VALUES ('6A944199-5A87-4A22-969F-7E3DC59E7FCA', 'Fernando Madureira', 'fernando.madureira@deal.com.br',1);
INSERT INTO db_a114c8_dashagi.Usuarios VALUES ('C8B7A4FD-0686-46E3-8F7D-AD1A813B2482', 'Marcos Ulber Baião', 'marcos.vitor@deal.com.br',1);


