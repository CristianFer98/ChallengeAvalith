create database Parking

CREATE TABLE Usuarios
(
	Id int IDENTITY(1,1) Primary Key,
	DNI nvarchar(256) UNIQUE not null,
	Nombre nvarchar(256) UNIQUE not null,
);

  CREATE TABLE Autos
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
	IdCliente int not null,
    Patente NVARCHAR(256) UNIQUE NOT NULL,
    Modelo NVARCHAR(256) not null,
	Marca NVARCHAR(256) not null,
    FOREIGN KEY (IdCliente) REFERENCES Usuarios(Id)
);

CREATE TABLE Parking
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Direccion nvarchar(256) not null,
	IdAuto int not null,
	DuracionEnHoras decimal not null,
	FOREIGN KEY(IdAuto) references Autos(Id)
)