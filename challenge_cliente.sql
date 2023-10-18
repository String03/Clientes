create database CLIENTEDB
go

use CLIENTEDB
go

create table Cliente(
	id int primary key identity(1,1),
	nombres varchar,
	apellidos varchar,
	fecha_de_nacimiento datetime,
	CUIT varchar,
	domicilio varchar,
	telefono_celular varchar,
	email varchar
)
go