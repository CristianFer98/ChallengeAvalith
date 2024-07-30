create database Parking

use Parking

CREATE TABLE Usuario
(
Id int Primary Key Identity (1,1),
DNI varchar(100) not null,
Nombre varchar(150) not null
);

CREATE TABLE Autos 
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT NOT NULL,
    Patente VARCHAR(50) NOT NULL,
    Modelo VARCHAR(100) NOT NULL,
    Marca VARCHAR(100) NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);

CREATE TABLE Parking
(
Id int not null Primary Key IDENTITY(1,1),
IdAuto int not null,
IdUsuario int not null,
Direccion varchar(500) not null,
DuracionEnHoras int not null
FOREIGN KEY (IdAuto) REFERENCES Autos(Id),
FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)

);

--INSERT USERS
INSERT INTO Usuario (DNI, Nombre) VALUES ('41139455', 'Cristian Fernandez');
INSERT INTO Usuario (DNI, Nombre) VALUES ('44413552', 'Lara Acosta');
INSERT INTO Usuario (DNI, Nombre) VALUES ('21004652', 'Carmen Melian');

--INSERT CARS
INSERT INTO Autos (IdUsuario, Patente, Modelo, Marca) VALUES (1, 'ABC123', 'Civic', 'Honda');
INSERT INTO Autos (IdUsuario, Patente, Modelo, Marca) VALUES (1, 'DEF456', 'Corolla', 'Toyota');
INSERT INTO Autos (IdUsuario, Patente, Modelo, Marca) VALUES (2, 'GHI789', 'Model S', 'Tesla');
INSERT INTO Autos (IdUsuario, Patente, Modelo, Marca) VALUES (3, 'JKL012', 'Mustang', 'Ford');
INSERT INTO Autos (IdUsuario, Patente, Modelo, Marca) VALUES (3, 'MNO345', 'Accord', 'Honda');

--INSERT PARKINGS
INSERT INTO Parking (IdAuto, Direccion, DuracionEnHoras, IdUsuario) VALUES (1, '123 Calle Falsa', 2, 1);
INSERT INTO Parking (IdAuto, Direccion, DuracionEnHoras, IdUsuario) VALUES (2, '456 Avenida Siempre Viva', 3, 1);
INSERT INTO Parking (IdAuto, Direccion, DuracionEnHoras, IdUsuario) VALUES (3, '789 Boulevard Solitario', 4, 1);
INSERT INTO Parking (IdAuto, Direccion, DuracionEnHoras, IdUsuario) VALUES (4, '1011 Calle Luna', 5, 3);
INSERT INTO Parking (IdAuto, Direccion, DuracionEnHoras, IdUsuario) VALUES (5, '1213 Calle Estrella', 6, 2);