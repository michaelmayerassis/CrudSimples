CREATE DATABASE provaMichael DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
use  provaMichael;
create table DEPARTAMENTO(
Id integer  UNSIGNED  auto_increment primary key,
Nome varchar(60) not null,
Cidade varchar(40) not null,
Fg_Ativo integer not null
)CHARACTER SET utf8 COLLATE utf8_general_ci;

create table FUNCIONARIO(
Id integer  UNSIGNED  auto_increment primary key,
Departamento_Id integer UNSIGNED not null,
Nome varchar(60) not null,
Dt_Nascimento date not null,
Salario numeric (9,2) not null,
Cargo varchar(60) not null,
Fg_Ativo integer not null,
CONSTRAINT fk_Dep_funcionario FOREIGN KEY(Departamento_Id) REFERENCES DEPARTAMENTO (Id))CHARACTER SET utf8 COLLATE utf8_general_ci;