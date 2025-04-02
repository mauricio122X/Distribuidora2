CREATE DATABASE DB_Distribuidora ;
GO 
USE DB_Distribuidora;
GO 

CREATE TABLE [Bodegas](
	[ID] INT PRIMARY KEY IDENTITY (1,1),
	[Nombre] NVARCHAR (50) not null,
	[Capacidad_max] INT not null
);


CREATE TABLE [Productos](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[Nombre] NVARCHAR (50) not null,
	[Precio_Compra] DECIMAL not null,
	[Cantidad_Embase] INT not null,
	[Descripcion] NVARCHAR (100) not null,
	[Stock] INT not null
);

CREATE TABLE [Vehiculos](
	[ID] INT PRIMARY KEY IDENTITY (1,1),
	[Placa] NVARCHAR (10) not null,
	[Tipo] NVARCHAR (50) not null,
	[Capacidad] INT not null
);

CREATE TABLE [Roles](
	[ID] INT PRIMARY KEY IDENTITY (1,1),
	[Nombre] NVARCHAR (50) not null,
	[Salario] DECIMAL (10,2) not null
);

CREATE TABLE [Empresas](
	[ID] INT PRIMARY KEY IDENTITY (1,1),
	[Nombre] NVARCHAR (50) not null,
	[Direccion] NVARCHAR (50) not null,
	[NIT] NVARCHAR (100) not null,
	[Tipo] NVARCHAR (50) not null,
	[Telefono] NVARCHAR (50) not null
);

CREATE TABLE [Documentos](
	[ID] INT PRIMARY KEY IDENTITY (1,1),
	[Tipo_Movimiento] NVARCHAR (50) not null,
	[ID_Bodega] INT not null,
	[Valor] DECIMAL not null,
	[Fecha] SMALLDATETIME not null,
	[ID_Empresa] INT not null,
	FOREIGN KEY ([ID_Bodega]) REFERENCES [Bodegas] ([ID]),
	FOREIGN KEY ([ID_Empresa]) REFERENCES [Empresas] ([ID])
);

CREATE TABLE [Empleados](
[ID] INT PRIMARY KEY IDENTITY (1,1) not null,
[Carnet] NVARCHAR (50) not null,
[Nombre] NVARCHAR (50) not null,
[ID_Roles] INT,
[ID_Bodega] INT,
FOREIGN KEY ([ID_Roles]) REFERENCES [Roles] ([ID]),
FOREIGN KEY ([ID_Bodega]) REFERENCES [Bodegas] ([ID])
);

CREATE TABLE [Productos_Documentos](
[ID] INT PRIMARY KEY IDENTITY (1,1) not null,
[Cantidad] INT not null,
[ID_Documento] INT not null,
[ID_Producto] INT not null,
FOREIGN KEY ([ID_Documento]) REFERENCES [Documentos] ([ID]),
FOREIGN KEY ([ID_Producto]) REFERENCES [Productos] ([ID])
);

CREATE TABLE [Vehiculos_Documentos](
[ID] INT PRIMARY KEY IDENTITY (1,1) not null,
[Cantidad] INT not null,
[ID_Documento] INT not null,
[ID_Vehiculo] INT not null,
FOREIGN KEY ([ID_Documento]) REFERENCES [Documentos] ([ID]),
FOREIGN KEY ([ID_Vehiculo]) REFERENCES [Vehiculos] ([ID])
);


/*Inserts*/
insert into Bodegas values('Bodega 1', 1000), ('Bodega2',200);