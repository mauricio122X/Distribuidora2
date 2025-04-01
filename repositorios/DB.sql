Create database DB_Distribuidora ;
go 
use DB_Distribuidora;
go 

create table Bodegas(
	ID int primary key identity(1,1),
	Nombre varchar(50) not null,
	Capacidad_max int not null
);

go

create table [Productos](
	[ID] int primary key identity(1,1),
	[Nombre] varchar(50) not null,
	[Precio_Compra] float not null,
	[Cantidad_Embase] int not null,
	[Descripcion] varchar(100) not null,
	[Stock] int not null
);

create table [Vehiculos](
	[ID] int primary key identity(1,1),
	[Placa] varchar(10) not null,
	[Tipo] varchar(50) not null,
	[Capacidad] int not null
);

create table [Roles](
	[ID] int primary key identity(1,1),
	[Nombre] varchar(50) not null,
	[Salario] decimal(10,2) not null
);

Create table [Empresas](
	[ID] int primary key identity(1,1),
	[Nombre] varchar(50) not null,
	[Direccion] varchar(50) not null,
	[NIT] varchar(100) not null,
	[Tipo] varchar(50) not null,
	[Telefono] varchar(50) not null
);
/*   No se a ejecutado */
Create table [Documentos](
	[ID] int primary key identity(1,1),
	[Tipo_Movimiento] varchar(50) not null,
	[Fecha] smalldatetime not null,
	[Valor] float not null,

);



/*Inserts*/
insert into Bodegas values('Bodega 1', 1000), ('Bodega2',200); 