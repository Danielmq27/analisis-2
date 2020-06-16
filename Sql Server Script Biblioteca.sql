create database ARE_Biblioteca_Legislativa;

use ARE_Biblioteca_Legislativa;


--creacion de Tablas para el sistema.

--TABLA DE ROLES.

Create table InformacionRol(
Id INTEGER  identity(1,1) primary key,
nombre varchar(20) not null,
descripcion varchar(200) not null
);
--

--TABLA DE USUARIOS.
create table Usuario(
Id INTEGER  identity(1,1) primary key,
cedula varchar(20) unique not null,
nombre varchar(40) not null,
apellido1 varchar(20) not null,
apellido2 varchar(20) not null,
email varchar(100) unique not null,
clave varchar(40) not null,
IdRol int not null,
foreign key (IdRol) references InformacionRol (Id)
);
--

-- TABLAS CIIE
create table FormularioCIIE(
Id INTEGER  identity(1,1) primary key,
nombreSolicitante varchar(40) not null,
apellidoSolicitante1 VARCHAR(20) not null,
apellidoSolicitante2 VARCHAR(20) not null,
telefono INTEGER not null,
email VARCHAR(100),
tipoDespacho VARCHAR(40) not null,
fraccion VARCHAR(10) not null,
especificacionDespacho VARCHAR(50),
tipoConsulta VARCHAR(20) not null,
especificacionConsulta VARCHAR(50),
tema VARCHAR(50) not null,
informacionRequerida VARCHAR(max) not null,
usoInformacion VARCHAR(40) not null,
generoSolicitante VARCHAR(10) not null,
fechaIngreso DATE not null,
fechaRespuesta DATE not null,
estado VARCHAR(20) not null
);

create table Usuario_FormularioCIIE(
Id INTEGER  identity(1,1) primary key,
IdUsuario INTEGER not null,
IdFormularioCIIE INTEGER not null,
nombre VARCHAR(40) not null,
apellido1 VARCHAR(20) not null,
apellido2 VARCHAR(20) not null,
foreign key (IdUsuario) references Usuario (Id),
foreign key (IdFormularioCIIE) references FormularioCIIE (Id)
);

create table AuditoriaCIIE(
Id INTEGER  identity(1,1) primary key,
nombreTabla VARCHAR(30) not null,
fecha DATE not null,
accion VARCHAR(20) not null,
usuario VARCHAR(40) not null
);
--

--TABLAS PRESTAMO EQUIPO
create table PrestamoEquipo(
Id INTEGER  identity(1,1) primary key,
nombreSolicitante VARCHAR(40) not null,
apellidoSolicitante1 VARCHAR(20) not null,
apellidoSolicitante2 VARCHAR(20) not null,
cedulaSolicitante VARCHAR(20) not null,
departamento VARCHAR(40) not null,
tipoEquipo VARCHAR(20) not null,
implementos VARCHAR(40),
especificacionImplementos VARCHAR(50),
generoSolicictante VARCHAR(10) not null,
fechaIngreso DATE not null,
fechaRespuesta DATE not null,
estado VARCHAR(20) not null
);

create table Usuario_PrestamoEquipo(
Id INTEGER  identity(1,1) primary key,
IdUsuario INTEGER not null,
IdPrestamoEquipo INTEGER not null,
nombre VARCHAR(40) not null,
apellido1 VARCHAR(20) not null,
apellido2 VARCHAR(20) not null,
foreign key (IdUsuario) references Usuario (Id),
foreign key (IdPrestamoEquipo) references PrestamoEquipo (Id)
);

create table AuditoriaPrestamoEquipo(
Id INTEGER  identity(1,1) primary key,
nombreTabla VARCHAR(30) not null,
fecha DATE not null,
accion VARCHAR(20) not null,
usuario VARCHAR(40) not null
);
--

--TABLAS PRESTAMOS PERMANENTES
create table PrestamoPermanente(
Id INTEGER  identity(1,1) primary key,
nombreSolicitante VARCHAR(40) not null,
apellidoSolicitante1 VARCHAR(20) not null,
apellidoSolicitante2 VARCHAR(20) not null,
despacho VARCHAR(40) not null,
telefono INTEGER not null,
extension VARCHAR(10),
informacionAdicional VARCHAR(max),
generoSolicictante VARCHAR(10) not null,
fechaPrestamo DATE not null,
estado VARCHAR(20) not null
);

create table Usuario_PrestamoPermanente(
Id INTEGER  identity(1,1) primary key,
IdUsuario INTEGER not null,
IdPrestamoPermanente INTEGER not null,
nombre VARCHAR(40) not null,
apellido1 VARCHAR(20) not null,
apellido2 VARCHAR(20) not null,
foreign key (IdUsuario) references Usuario (Id),
foreign key (IdPrestamoPermanente) references PrestamoPermanente (Id)
);

create table AuditoriaPrestamoPermanente(
Id INTEGER  identity(1,1) primary key,
nombreTabla VARCHAR(30) not null,
fecha DATE not null,
accion VARCHAR(20) not null,
usuario VARCHAR(40) not null
);
--

--TABLAS CONSULTA
create table Consulta(
Id INTEGER  identity(1,1) primary key,
nombreSolicitante varchar(40) not null,
apellidoSolicitante1 VARCHAR(20) not null,
apellidoSolicitante2 VARCHAR(20) not null,
telefono INTEGER not null,
email VARCHAR(100) not null,
asunto VARCHAR(50) not null,
descripcion VARCHAR(500),
respuesta VARCHAR(max) not null,
metodoIngreso VARCHAR(20) not null,
generoSolicitante VARCHAR(10) not null,
fechaIngreso DATE not null,
fechaRespuesta DATE not null,
estado VARCHAR(20) not null
);

create table Usuario_Consulta(
Id INTEGER  identity(1,1) primary key,
IdUsuario INTEGER not null,
IdConsulta INTEGER not null,
nombre VARCHAR(40) not null,
apellido1 VARCHAR(20) not null,
apellido2 VARCHAR(20) not null,
foreign key (IdUsuario) references Usuario (Id),
foreign key (IdConsulta) references Consulta (Id)
);

create table AuditoriaConsulta(
Id INTEGER  identity(1,1) primary key,
nombreTabla VARCHAR(30) not null,
fecha DATE not null,
accion VARCHAR(20) not null,
usuario VARCHAR(40) not null
);
--

--TABLAS PRESTAMOS AUDIOVISUALES

CREATE TABLE PrestamoAudiovisual(
Id INTEGER  identity(1,1) primary key,
nombreSolicitante varchar(40) not null,
apellidoSolicitante1 VARCHAR(20) not null,
apellidoSolicitante2 VARCHAR(20) not null,
telefono INTEGER not null,
departamento VARCHAR(40),
nombreActividad VARCHAR(50) not null,
categoria VARCHAR(40) not null,
especificacionCategoria VARCHAR(100),
ubicacion VARCHAR(100),
horaInicio DATETIME not null,
horaFin DATETIME not null,
descripcion VARCHAR(500) not null,
equipoRequerido VARCHAR(40) not null,
aforo INTEGER not null,
generoSolicitante VARCHAR(10) not null
);

create table Usuario_PrestamoAudiovisual(
Id INTEGER  identity(1,1) primary key,
IdUsuario INTEGER not null,
IdPrestamoAudiovisual INTEGER not null,
nombre VARCHAR(40) not null,
apellido1 VARCHAR(20) not null,
apellido2 VARCHAR(20) not null,
foreign key (IdUsuario) references Usuario (Id),
foreign key (IdPrestamoAudiovisual) references PrestamoAudiovisual (Id)
);


create table AuditoriaPrestamoAudiovisual(
Id INTEGER  identity(1,1) primary key,
nombreTabla VARCHAR(30) not null,
fecha DATE not null,
accion VARCHAR(20) not null,
usuario VARCHAR(40) not null
);

--

--TABLA SOLICITANTE
create table Solicitante(
Id INTEGER  identity(1,1) primary key,
nombre varchar(40) not null,
apellido1 varchar(20) not null,
apellido2 varchar(20) not null,
email varchar(100) unique not null,
genero VARCHAR(10) 
);


