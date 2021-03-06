create database ARE_Biblioteca_Legislativa;

use ARE_Biblioteca_Legislativa;


--creacion de Tablas para el sistema.

--TABLA DE ROLES.

Create table InformacionRol(
Id INTEGER  identity(1,1) primary key,
nombre varchar(20) not null,
descripcion varchar(200) not null
);

--INSERTS DE ROLES
insert into InformacionRol values('Administrador', 'control total');
insert into InformacionRol values('editar', 'Puede agregar, editar, eliminar, actualizar');
insert into InformacionRol values('Colaborador', 'Puede ver, agregar y actualizar.');
insert into InformacionRol values('Consulta', 'Puede visualizar los datos');

--CONSULTA
select * from InformacionRol;
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

--INSERTS USUARIOS
insert into Usuario values('207440757', 'Jose Daniel', 'Matamoros', 'Quesada', 'danielasamblea@hotmail.com', ENCRYPTBYPASSPHRASE('8', 'pass'), 2);
insert into Usuario values('307440789', 'Juan Carlos', 'Mata', 'Quiros', 'Carlosasamblea@hotmail.com', ENCRYPTBYPASSPHRASE('8', 'pass'), 2);
insert into Usuario values('107440767', 'Jose Miguel', 'Fellini', 'Campos', 'miguelasamblea@hotmail.com', ENCRYPTBYPASSPHRASE('8', 'pass'), 1);
insert into Usuario values('207440786', 'Gloriana', 'Segura', 'Zeledon', 'Glorianaasamblea@hotmail.com', ENCRYPTBYPASSPHRASE('8', 'pass'), 3);

--Consulta
select * from Usuario

delete from Usuario

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
--INSERTS CIIE
INSERT INTO FormularioCIIE values('Raquel', 'Vallada', 'Valerin', 88956765, '', 'tecnico', 'PLN', '', 'analisis', '', 'Mociones por diputado', 'se procede a la busqueda de la informacion', 'creacion reporte', 'Femenino', GETDATE(), GETDATE(), 'pendiene');
INSERT INTO FormularioCIIE values('Raquel', 'Vallada', 'Valerin', 88956765, '', 'tecnico', 'PLN', '', 'analisis', '', 'Mociones del 8/8/2019', 'se presentaron un total de 3 mociones', 'creacion reporte', 'Femenino', GETDATE(), GETDATE(), 'finalizada');
 INSERT INTO FormularioCIIE values('Rafael', 'Matamoros', 'Quesada', 88110950, 'jrmatamoros@gmail.com', 'Diputado', 'FA', '', 'Solicitud Info', '', 'Memoria 2018', 'se adjunta la informacion al correo electonico', 'control politico', 'Masculino', '20-DEC-2018', '22-DEC-2018', 'finalizada');


select * from FormularioCIIE
------

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

--INSERTS USUARIOCIIE
insert into Usuario_FormularioCIIE values(13, 1, 'Jose Miguel', 'Fellini', 'Campos');
insert into Usuario_FormularioCIIE values(13, 2, 'Jose Miguel', 'Fellini', 'Campos');
insert into Usuario_FormularioCIIE values(13, 9, 'Jose Miguel', 'Fellini', 'Campos');

select * from Usuario_FormularioCIIE
delete from Usuario_FormularioCIIE
---
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

--INSERTS
insert into PrestamoEquipo values('Carlos', 'Sabat', 'Garcia', '207440757', 'administrativo', 'video beam', '', '', 'masculino', '10-Jun-2020', GETDATE(), 'finalizado');
insert into PrestamoEquipo values('Karla', 'Perez', 'Solano', '107440752', 'tecnico', 'laptop', 'otro', 'adaptador VGA', 'femenino', '12-Jun-2020', '15-Jun-2020', 'finalizado');
insert into PrestamoEquipo values('Erika', 'Solis', 'Garcia', '407440577', 'administrativo', 'video beam', 'estuche', '', 'femenino', GETDATE(), GETDATE(), 'finalizado');

Select * from PrestamoEquipo;


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

--inserts
insert into Usuario_PrestamoEquipo values(13, 1, 'Jose Miguel', 'Fellini', 'Campos');
insert into Usuario_PrestamoEquipo values(11, 2, 'Jose Daniel', 'Matamoros', 'Quesada');
insert into Usuario_PrestamoEquipo values(13, 3, 'Jose Miguel', 'Fellini', 'Campos');

select * from Usuario_PrestamoEquipo

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

--INSERTS
INSERT INTO PrestamoPermanente VALUES('Carlos', 'Sabat', 'Garcia', 'administrativo', 69897524, '', 'Carlos necesita que se le preste el video beamn de manera permanente para ver la mejenga', 'masculino', GETDATE(), 'prestamo');
INSERT INTO PrestamoPermanente VALUES('Erika', 'Solis', 'Garcia', 'tecnico', 69897689, '', 'Erika Solicita una laptop para llevar sus clases remotas al salir del horario laborar todos los dias', 'femenino', GETDATE(), 'prestamo');

Select * from PrestamoPermanente


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
--INSERTS

insert into Usuario_PrestamoPermanente values(13, 1, 'Jose Miguel', 'Fellini', 'Campos');
insert into Usuario_PrestamoPermanente values(14, 2, 'Gloriana', 'Segura', 'Zeledon');

select * from Usuario_PrestamoPermanente;


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
--INSERTS
INSERT INTO Consulta Values('Manuel', 'Castro', 'Carazo', 24944796, 'MCC@yahoo.com', 'memoria legislativa', 'se consulta la fecha de publicacion de la memoria', 'Se indica que la misma sera publicada el dia 30 de marzo', 'Facebook',
'masculino', '2020-mar-10', '2020-mar-10', 'finalizada');

INSERT INTO Consulta Values('Maria', 'Rosales', 'Calderon', 88956875, 'MRC@yahoo.com', 'Prestamo de libros', 'se consulta si prestan libros a la ciudadania', 'Se indica que si en el tanto su uso sea dentro de la bibliteca', 'Facebook',
'femenino', getdate(), getdate(), 'finalizada');

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
--INSERTS
insert into Usuario_Consulta values(13, 1, 'Jose Miguel', 'Fellini', 'Campos');
insert into Usuario_Consulta values(14, 2, 'Gloriana', 'Segura', 'Zeledon');

select * from Usuario_Consulta;

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

--Inserts
insert into PrestamoAudiovisual values('Carlos', 'Sabat', 'Garcia',69897524, 'administrativo', 'ver la mejenga', 'reunion', '', '', '20200616 10:00:00 AM', '20200616 1:00:00 PM','durante la hora de almuerzo vamos a ver el partido de la champions', 'video beam',
10, 'masculino');

insert into PrestamoAudiovisual values('Graciela', 'Salas', 'Marquez',63297521, 'tecnico', 'plan de pruebas de red', 'reunion', '', '', '20200516 11:00:00 AM', '20200516 2:00:00 PM','Se discutira el proceso de integracion de la nueva red', 'video beam',
4, 'femenino');

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
--inserts
insert into Usuario_PrestamoPermanente values(13, 1, 'Jose Miguel', 'Fellini', 'Campos');
insert into Usuario_PrestamoPermanente values(12, 1, 'Juan Carlos', 'Mata', 'Quiros');


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


