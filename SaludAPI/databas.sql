create database Salud

use salud 

CREATE TABLE Usuario
(
Id int Primary Key Identity (1,1),
NumeroDeTramite varchar(100) not null,
DNI varchar(150) not null,
Nombre varchar(500) not null
);

CREATE TABLE CentroDeSalud
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(500) NOT NULL,
);

CREATE TABLE Especialidad
(
	Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(500) NOT NULL,
);

CREATE TABLE Turnos
(
Id int not null Primary Key IDENTITY(1,1),
IdUsuario int not null,
IdCentroDeSalud int not null,
IdEspecialidad int not null,
Horario varchar(500) not null,
FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
FOREIGN KEY (IdCentroDeSalud) REFERENCES CentroDeSalud(Id),
FOREIGN KEY (IdEspecialidad) REFERENCES Especialidad(Id),
);

INSERT INTO Usuario (NumeroDeTramite, DNI, Nombre) VALUES ('123456','41139455', 'Cristian Fernandez');
INSERT INTO Usuario (NumeroDeTramite, DNI, Nombre) VALUES ('654321','44413552', 'Lara Acosta');
INSERT INTO Usuario (NumeroDeTramite, DNI, Nombre) VALUES ('999999','21004652', 'Carmen Melian');
INSERT INTO Usuario (NumeroDeTramite, DNI, Nombre) VALUES ('987654','44444444', 'Romanof');
INSERT INTO Usuario (NumeroDeTramite, DNI, Nombre) VALUES ('111111','11111111', 'Jose');


INSERT INTO CentroDeSalud(Nombre) VALUES ('Favaloro');
INSERT INTO CentroDeSalud(Nombre) VALUES ('Centro Del Sur');
INSERT INTO CentroDeSalud(Nombre) VALUES ('Centro Pami');
INSERT INTO CentroDeSalud(Nombre) VALUES ('Centro OSDE');

INSERT INTO Especialidad(Nombre) VALUES ('CARDIOLOGIA');
INSERT INTO Especialidad(Nombre) VALUES ('PEDIATRIA');
INSERT INTO Especialidad(Nombre) VALUES ('NEUROLOGÍA');
INSERT INTO Especialidad(Nombre) VALUES ('OTORRINOLARINGOLOGÍA');
INSERT INTO Especialidad(Nombre) VALUES ('KINESIOLOGÍA');


INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (1, 1, 1, '2024-08-01 08:30');
INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (2, 2, 2, '2024-08-01 09:00');
INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (3, 3, 3, '2024-08-01 10:00');
INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (1, 4, 4, '2024-08-02 11:00');
INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (2, 1, 5, '2024-08-02 11:30');
INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (3, 2, 1, '2024-08-03 08:00');
INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (1, 3, 2, '2024-08-03 09:30');
INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (2, 4, 3, '2024-08-03 10:30');
INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (3, 1, 4, '2024-08-04 08:30');
INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (1, 2, 5, '2024-08-04 09:00');
INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (2, 3, 1, '2024-08-04 10:00');
INSERT INTO Turnos (IdUsuario, IdCentroDeSalud, IdEspecialidad, Horario) VALUES (3, 4, 2, '2024-08-05 11:00');