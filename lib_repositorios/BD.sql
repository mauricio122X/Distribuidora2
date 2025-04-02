use master;
drop database DB_Distribuidora;
go
CREATE DATABASE DB_Distribuidora ;
GO 
USE DB_Distribuidora;
GO 

CREATE TABLE [Bodegas](
	[ID] INT PRIMARY KEY IDENTITY (1,1),
	[Nombre] NVARCHAR (50) not null,
	[Capacidad_max] INT not null
);

Go
CREATE TABLE [Productos](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[Nombre] NVARCHAR (50) not null,
	[Precio_Compra] DECIMAL(10,2) not null,
	[Cantidad_Embase] INT not null,
	[Descripcion] NVARCHAR (100) not null,
	[Precio_Venta] decimal(10,2),
	[Stock] INT not null
);
go
CREATE TABLE [Vehiculos](
	[ID] INT PRIMARY KEY IDENTITY (1,1),
	[Placa] NVARCHAR (50) unique not null,
	[Tipo] NVARCHAR (50) not null,
	[Capacidad] INT not null
);
go
CREATE TABLE [Roles](
	[ID] INT PRIMARY KEY IDENTITY (1,1),
	[Nombre] NVARCHAR (50) not null,
	[Salario] DECIMAL (10,2) not null
);
go
CREATE TABLE [Empresas](
	[ID] INT PRIMARY KEY IDENTITY (1,1),
	[Nombre] NVARCHAR (50) not null,
	[Direccion] NVARCHAR (50) not null,
	[NIT] NVARCHAR (100) not null,
	[Tipo] NVARCHAR (50) not null,
	[Telefono] NVARCHAR (50) not null
);
go
CREATE TABLE [Documentos](
	[ID] INT PRIMARY KEY IDENTITY (1,1),
	[Tipo_Movimiento] NVARCHAR (50) not null,
	[ID_Bodega] INT not null,
	[Valor] DECIMAL(10,2) not null,
	[Fecha] SMALLDATETIME not null,
	[ID_Empresa] INT not null,
	FOREIGN KEY ([ID_Bodega]) REFERENCES [Bodegas] ([ID]),
	FOREIGN KEY ([ID_Empresa]) REFERENCES [Empresas] ([ID])
);
go
CREATE TABLE [Empleados](
[ID] INT PRIMARY KEY IDENTITY (1,1) not null,
[Carnet] NVARCHAR(50) unique not null,
[Nombre] NVARCHAR (50) not null,
[ID_Rol] INT,
[ID_Bodega] INT,
FOREIGN KEY ([ID_Rol]) REFERENCES [Roles] ([ID]),
FOREIGN KEY ([ID_Bodega]) REFERENCES [Bodegas] ([ID])
);
go
CREATE TABLE [Productos_Documentos](
[ID] INT PRIMARY KEY IDENTITY (1,1) not null,
[Cantidad] INT not null,
[ID_Documentos] INT not null,
[ID_Productos] INT not null,
FOREIGN KEY ([ID_Documentos]) REFERENCES [Documentos]([ID]),
FOREIGN KEY ([ID_Productos]) REFERENCES [Productos]([ID])
);
go
CREATE TABLE [Vehiculos_Documentos](
[ID] INT PRIMARY KEY IDENTITY (1,1) not null,
[Cantidad] INT not null,
[ID_Documentos] INT not null,
[ID_Vehiculos] INT not null,
FOREIGN KEY ([ID_Documentos]) REFERENCES [Documentos] ([ID]),
FOREIGN KEY ([ID_Vehiculos]) REFERENCES [Vehiculos] ([ID])
);

go
--Inserts/
insert into Bodegas values('Bodega 1', 1000), ('Bodega2',200);
insert	into Empresas values ('Empresa1' ,'calle1','123','cliente','123' );
insert into Productos values ('producto1',200,20,'descripcion1',300,5);
insert into Roles values('rol1',200);
insert into Vehiculos values('123abc','camioneta',100);
insert into Documentos values ('venta',1,200,GETDATE(),1);
go
select * from Bodegas;
select * from Productos;
select * from Empresas;
select * from Roles; 
select * from Vehiculos;
select * from Documentos;

