create database ControleDeValor
go
use ControleDeValor
go
create table Usuario(
	id int primary key identity(1,1) not null,
	email varchar(100) not null,
	senha varchar(12) not null,
	diaAtualiza varchar(2),
	mesAtualiza varchar(2),
)
go
create table Valor(
	id int primary key identity(1,1) not null,
	id_usuario int foreign key references
		Usuario(id) not null,
	valorTotal Decimal(15, 2) not null,
	valorGuardado Decimal(15, 2),
	data date not null
)
go
create table Gasto(
	id int primary key identity(1,1) not null,
	id_valor int foreign key references
		Valor(id) not null,
	valor Decimal(15, 2) not null,
	descricao varchar(100) not null,
	data date not null
)
go
create table Produto(
	id int primary key identity(1,1) not null,
	id_usuario int foreign key references
		Usuario(id) not null,
	nome_produto varchar(100) not null,
	valor Decimal(15, 2) not null,
	valorMes Decimal(15, 2) not null,
	valorAcumulado Decimal(15, 2)
)