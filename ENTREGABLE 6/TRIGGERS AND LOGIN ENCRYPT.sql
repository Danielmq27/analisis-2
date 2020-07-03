USE MASTER;

USE ARE_Biblioteca_Legislativa;

--PROCEDURES

/*se comenta el bloke de roles ya que estos son solo pruebas */

---PROCEDURE DE ROLES
/*
GO
CREATE PROC INSERTAR_ROL
(@NOMBRE varchar(20), @DESCRIPCION varchar(200))
AS
BEGIN
INSERT INTO InformacionRol ( nombre, descripcion)
VALUES (@NOMBRE, @DESCRIPCION)
END

GO
CREATE PROC ACTUALIZAR_ROL
(@NOMBRE varchar(20), @DESCRIPCION varchar(200))
AS 
BEGIN
UPDATE InformacionRol
set nombre = @Nombre, descripcion = @DESCRIPCION
where nombre = @NOMBRE
end
go

GO
CREATE PROC SELECCION_ROL_TODO
(@NOMBRE varchar(20), @DESCRIPCION varchar(200))
AS
BEGIN
	SELECT * FROM InformacionRol;
END

GO
CREATE PROC SELECCION_ROL
(@NOMBRE varchar(20))
AS
begin
SELECT * from InformacionRol WHERE nombre = @NOMBRE
END


go 
create proc BORRAR_ROL
(@NOMBRE varchar(20))
AS
begin
DELETE InformacionRol WHERE nombre = @NOMBRE
END
*/

--PROCEDIMIENTO A LA HORA DE INSERTAR
/*este procedimiento permite insertar un usuario a la tabla usuario, declarando variables por parametro para obtener los datos desde la aplicacion. 
Se us una variable temporal que permite imprimir un mensaje de validacion para la existencia del usuario. Esta validacion se hace por medio del IF, haciendo conteo de la
fila cedula para buscar si hay algo igual  */
go
create PROC INSERTAR_USUARIO 
(@CEDULA varchar(20), @NOMBRE varchar(40), @APELLIDO1 varchar(20), @APELLIDO2 varchar(20),
@EMAIL varchar(100), @CLAVE varchar(40), @IDROL INT)
as
 declare @TEXTO varchar(50) 
BEGIN
if (select count(*) from Usuario where cedula = @CEDULA)  = 0
INSERT INTO Usuario (cedula, nombre, apellido1, apellido2, email, clave, IdRol) values
(@CEDULA, @NOMBRE, @APELLIDO1, @APELLIDO2, ENCRYPTBYPASSPHRASE('llave', @EMAIL), ENCRYPTBYPASSPHRASE('llave', @CLAVE), @IDROL);
else 
select @TEXTO = 'Usuario existente con la misma cedula'
END
go



--PROCEDIMIENTO PARA LOGIN
/* Este procedure utiliza dos variable temporales @claveEncriptada y @claveDesencriptada,  en la primera se recupera el valor encriptado, y en la segunda usando la llave se desencripta el valor*/
CREATE PROC LOGIN_USUARIO
(@CEDULA varchar(20), @CLAVE varchar(40), @RES BIT output)
as
declare
@ClaveEncriptada as varchar(100),
@ClaveDesencriptada as varchar(40)
begin
Select @ClaveEncriptada = Clave from Usuario
where cedula=@CEDULA

set @ClaveDesencriptada = DECRYPTBYPASSPHRASE('llave', @ClaveEncriptada)
end

begin
if @CLAVE=@ClaveDesencriptada 
SET @RES = 1
else
SET @RES = 0
END



---seleccionar todos los usuario
GO
CREATE PROC SELECCIONAR_USUARIO_TODO
AS
BEGIN
	SELECT * FROM Usuario;
END


---Seleccionar un solo user
/* select en base al campo unico id*/

go
CREATE PROC SELECCIONAR_USUARIO 
(@ID int)
as
 declare @TEXTO varchar(50) 
BEGIN
if (select count(*) from Usuario where Id = @ID)  = 0
select @TEXTO = 'No existente un usurio con la misma especificacion'
else 
select * from Usuario where Id=@ID;
END



---UPDATE USER
/* se setea un update en base al campo unico cedula*/
GO 
CREATE PROCEDURE ACTUALIZAR_USUARIO
(@ID INT, @CEDULA varchar(20), @NOMBRE varchar(40), @APELLIDO1 varchar(20), @APELLIDO2 varchar(20),
@EMAIL varchar(100), @CLAVE varchar(40), @IDROL INT)
AS
BEGIN
UPDATE Usuario
SET cedula=@CEDULA, nombre=@NOMBRE, apellido1=@APELLIDO1, apellido2=@APELLIDO2, email = ENCRYPTBYPASSPHRASE('llave', @EMAIL), clave= ENCRYPTBYPASSPHRASE('llave', @CLAVE), IdRol=@IDROL
where id=@id
end
go


---DELETE USUARIO
GO
CREATE PROCEDURE BORRAR_USUARIO(@ID int)
AS
begin
DELETE Usuario WHERE Id = @ID
END


---INSERTAR FORM CIIE
/*este procedimiento permite insertar un usuario a la tabla CIIE, declarando variables por parametro para obtener los datos desde la aplicacion. 
Se trabaja con dos variables temporales @maxcode, que se usa para almacenar el valor maximo de la columna ID, con este se hace la validacion de si existe un registro o no
en el IF, en la variable @codigoCIIE se almacena un valor construido por CAST del @maxCode, que servira para identificar las filas de las tablas de manera unica sin hacer referencia
a la llave autoincremental*/
GO
create PROCEDURE INSERTAR_CIIE 
(@nombreSolicitante varchar(40), @apellidoSolicitante1 VARCHAR(20), @apellidoSolicitante2 VARCHAR(20), @telefono INTEGER,
@email VARCHAR(100), @tipoDespacho VARCHAR(40), @fraccion VARCHAR(10), @especificacionDespacho VARCHAR(50),
@tipoConsulta VARCHAR(20), @especificacionConsulta VARCHAR(50), @tema VARCHAR(50), @informacionRequerida VARCHAR(max), 
@usoInformacion VARCHAR(40), @generoSolicitante VARCHAR(10), @fechaIngreso DATE, @fechaRespuesta DATE, @estado VARCHAR(20),
@cedulaUsuario varchar(20), @nombre VARCHAR(40), @apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
AS
DECLARE
@codigoCIIE varchar(40),
@maxCode int;
set @maxCode = (select MAX (Id) from [dbo].[FormularioCIIE]);
if( @maxCode IS NULL) 
SET @codigoCIIE= 'CIIE-1'
ELSE
SET @codigoCIIE = ('CIIE-' + cast(@maxCode+1 as varchar));
BEGIN
INSERT INTO FormularioCIIE (codigoCIIE, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, 
telefono, email, tipoDespacho, fraccion, especificacionDespacho, tipoConsulta, 
especificacionConsulta, tema, informacionRequerida, usoInformacion, generoSolicitante, 
fechaIngreso, fechaRespuesta, estado) 
VALUES
(@codigoCIIE, @nombreSolicitante, @apellidoSolicitante1, @apellidoSolicitante2, 
@telefono, @email, @tipoDespacho, @fraccion, @especificacionDespacho, @tipoConsulta, 
@especificacionConsulta, @tema, @informacionRequerida, @usoInformacion, @generoSolicitante, 
@fechaIngreso, @fechaRespuesta, @estado);

INSERT INTO [dbo].[Usuario_FormularioCIIE] ([cedulaUsuario], [codigoCIIE], nombre, apellido1, apellido2)
values
(@cedulaUsuario, @codigoCIIE, @nombre, @apellido1, @apellido2)
END


--SELECT TODO FROM CIIE
GO
CREATE PROC SELECT_CIIE_TODO
AS
BEGIN
	SELECT a.Id, a.codigoCIIE, a.nombreSolicitante, a.apellidoSolicitante1, a.apellidoSolicitante2, 
a.telefono, a.email, a.tipoDespacho, a.fraccion, a.especificacionDespacho, a.tipoConsulta, 
a.especificacionConsulta, a.tema, a.informacionRequerida, a.usoInformacion, a.generoSolicitante, 
a.fechaIngreso, a.fechaRespuesta, a.estado, b.cedulaUsuario, b.codigoCIIE, b.nombre, b.apellido1, b.apellido2
	FROM Usuario_FormularioCIIE b, FormularioCIIE a
	where a.codigoCIIE = b.codigoCIIE
END

--SELECT FROM CIIE
/* select en base al campo unico @codigoCIIE*/
go
CREATE PROC SELECCIONAR_CIIE
(@CODIGOCIIE varchar(40))
as
 declare @TEXTO varchar(50) 
BEGIN
if (select count(*) from FormularioCIIE where codigoCIIE = @CODIGOCIIE)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion'
else 
SELECT a.Id, a.codigoCIIE, a.nombreSolicitante, a.apellidoSolicitante1, a.apellidoSolicitante2, 
a.telefono, a.email, a.tipoDespacho, a.fraccion, a.especificacionDespacho, a.tipoConsulta, 
a.especificacionConsulta, a.tema, a.informacionRequerida, a.usoInformacion, a.generoSolicitante, 
a.fechaIngreso, a.fechaRespuesta, a.estado, b.cedulaUsuario, b.codigoCIIE, b.nombre, b.apellido1, b.apellido2
	FROM Usuario_FormularioCIIE b, FormularioCIIE a
	where  @CODIGOCIIE=a.codigoCIIE and @CODIGOCIIE=b.codigoCIIE
END


-- DELETE FROM CIIE
go 
create PROCEDURE BORRAR_CIIE
(@CODIGOCIIE varchar(40))
AS
declare @TEXTO varchar(50)
BEGIN
if (select count(*) from FormularioCIIE where codigoCIIE = @CODIGOCIIE)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion'
ELSE
delete from Usuario_FormularioCIIE where @CODIGOCIIE=codigoCIIE;
delete from FormularioCIIE where @CODIGOCIIE=codigoCIIE;
end


--UPDATE CIIE
/* se setea un update en base al campo unico codigo*/
GO
CREATE PROC ACTUALIZAR_CIIE
(@id int, @CodigoCIIE VARCHAR(40), @nombreSolicitante varchar(40), @apellidoSolicitante1 VARCHAR(20), @apellidoSolicitante2 VARCHAR(20), @telefono INTEGER,
@email VARCHAR(100), @tipoDespacho VARCHAR(40), @fraccion VARCHAR(10), @especificacionDespacho VARCHAR(50),
@tipoConsulta VARCHAR(20), @especificacionConsulta VARCHAR(50), @tema VARCHAR(50), @informacionRequerida VARCHAR(max), 
@usoInformacion VARCHAR(40), @generoSolicitante VARCHAR(10), @fechaIngreso DATE, @fechaRespuesta DATE, @estado VARCHAR(20),
@cedulaUsuario varchar(20), @nombre VARCHAR(40), @apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
AS
BEGIN
UPDATE FormularioCIIE 
SET codigoCIIE=@codigoCIIE, nombreSolicitante=@nombreSolicitante, apellidoSolicitante1=@apellidoSolicitante1, apellidoSolicitante2=@apellidoSolicitante2, 
telefono=@telefono, email=@email, tipoDespacho=@tipoDespacho, fraccion=@fraccion, especificacionDespacho=@especificacionDespacho, tipoConsulta=@tipoConsulta, 
especificacionConsulta=@especificacionConsulta, tema=@tema, informacionRequerida=@informacionRequerida, usoInformacion=@usoInformacion, generoSolicitante=@generoSolicitante, 
fechaIngreso=@fechaIngreso, fechaRespuesta=@fechaRespuesta, estado=@estado 
WHERE codigoCIIE=@CodigoCIIE;

UPDATE Usuario_FormularioCIIE
SET cedulaUsuario=@cedulaUsuario, codigoCIIE=@codigoCIIE, nombre=@nombre, apellido1=@apellido1, apellido2=@apellido2
WHERE codigoCIIE=@CodigoCIIE;
end

--INSERTAR PRESTAMO EQUIPO
/*este procedimiento permite insertar un usuario a la tabla PE, declarando variables por parametro para obtener los datos desde la aplicacion. 
Se trabaja con dos variables temporales @maxcode, que se usa para almacenar el valor maximo de la columna ID, con este se hace la validacion de si existe un registro o no
en el IF, en la variable @codigoPE se almacena un valor construido por CAST del @maxCode, que servira para identificar las filas de las tablas de manera unica sin hacer referencia
a la llave autoincremental*/
GO
create PROCEDURE INSERTAR_PrestamoEquipo
(
@nombreSolicitante VARCHAR(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@cedulaSolicitante VARCHAR(20) ,@departamento VARCHAR(40) ,
@tipoEquipo VARCHAR(20) ,@implementos VARCHAR(40),@especificacionImplementos VARCHAR(50),@generoSolicictante VARCHAR(10) ,
@fechaIngreso DATE ,@fechaRespuesta DATE ,@estado VARCHAR(20), @cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
as
declare
@codigoPrestamoEquipo varchar(40),
@maxCode int;
set @maxCode = (select MAX (Id) from PrestamoEquipo);
if( @maxCode IS NULL) 
SET @codigoPrestamoEquipo= 'CPE-1'
ELSE
SET @codigoPrestamoEquipo = ('CPE-' + cast(@maxCode+1 as varchar));
BEGIN
INSERT INTO PrestamoEquipo 
(codigoPrestamoEquipo,nombreSolicitante,apellidoSolicitante1,apellidoSolicitante2,cedulaSolicitante,departamento,tipoEquipo,
implementos,especificacionImplementos,generoSolicictante,fechaIngreso,fechaRespuesta,estado)
VALUES
(@codigoPrestamoEquipo, @nombreSolicitante, @apellidoSolicitante1, @apellidoSolicitante2, 
@cedulaSolicitante, @departamento, @tipoEquipo, @implementos, @especificacionImplementos,
@generoSolicictante, @fechaIngreso, @fechaRespuesta, @estado);

INSERT INTO Usuario_PrestamoEquipo (cedulaUsuario, codigoPrestamoEquipo, 
nombre, apellido1, apellido2)
values
(@cedulaUsuario, @codigoPrestamoEquipo, @nombre, @apellido1, @apellido2);
END

---SELECT TODO PRESTAMO EQUIPO
GO
CREATE PROC SELECCIONAR_PrestamoEquipo_TODO
AS
BEGIN
SELECT a.Id, a.codigoPrestamoEquipo,a.nombreSolicitante,a.apellidoSolicitante1,a.apellidoSolicitante2,a.cedulaSolicitante,a.departamento,
a.tipoEquipo,a.implementos,a.especificacionImplementos,a.generoSolicictante,a.fechaIngreso,a.fechaRespuesta,a.estado,b.cedulaUsuario, 
b.nombre, b.apellido1, b.apellido2
FROM Usuario_PrestamoEquipo b, PrestamoEquipo a
where a.codigoPrestamoEquipo = b.codigoPrestamoEquipo
END

--SELECCION PRESTAMO EQUIPO
/* select en base al campo unico @codigo*/
GO
CREATE PROC SELECCIONAR_PrestamoEquipo
(@CODIGOPE varchar(40))
as
declare  @TEXTO varchar(50) 
BEGIN
if (select count(*) from PrestamoEquipo where codigoPrestamoEquipo = @CODIGOPE)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion'
else 
SELECT  a.Id, a.codigoPrestamoEquipo,a.nombreSolicitante,a.apellidoSolicitante1,a.apellidoSolicitante2,a.cedulaSolicitante,
a.departamento,a.tipoEquipo,a.implementos,a.especificacionImplementos,a.generoSolicictante,a.fechaIngreso,
a.fechaRespuesta,a.estado,b.cedulaUsuario, b.nombre, b.apellido1, b.apellido2
FROM Usuario_PrestamoEquipo b, PrestamoEquipo a
WHERE a.codigoPrestamoEquipo=@CODIGOPE and b.codigoPrestamoEquipo=@CODIGOPE 
end

---ACTULIZAR PRESTAMO EQUIPO
/* se setea un update en base al campo unico codigo*/
GO
create procedure ACTUALIZAR_PrestamoEquipo
(@Id int,@codigoPrestamoEquipo varchar(40),@nombreSolicitante VARCHAR(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,
@cedulaSolicitante VARCHAR(20) ,@departamento VARCHAR(40) ,@tipoEquipo VARCHAR(20) ,@implementos VARCHAR(40),@especificacionImplementos VARCHAR(50),@generoSolicictante VARCHAR(10) ,
@fechaIngreso DATE ,@fechaRespuesta DATE ,@estado VARCHAR(20), @cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
AS
BEGIN
UPDATE PrestamoEquipo
SET codigoPrestamoEquipo=@codigoPrestamoEquipo, nombreSolicitante=@nombreSolicitante, 
apellidoSolicitante1=@apellidoSolicitante1, apellidoSolicitante2=@apellidoSolicitante2,
cedulaSolicitante=@cedulaSolicitante, departamento=@departamento, tipoEquipo=@tipoEquipo,
implementos=@implementos, especificacionImplementos=@especificacionImplementos,
generoSolicictante=@generoSolicictante, fechaIngreso=@fechaIngreso, fechaRespuesta=@fechaRespuesta,
estado=@estado
WHERE codigoPrestamoEquipo=@codigoPrestamoEquipo;

UPDATE Usuario_PrestamoEquipo
SET cedulaUsuario=@cedulaUsuario, codigoPrestamoEquipo=@codigoPrestamoEquipo, nombre=@nombre,
apellido1=@apellido1, apellido2=@apellido2
WHERE codigoPrestamoEquipo=@codigoPrestamoEquipo;
end

--BORRAR PRESTAMO EQUIPO
GO
CREATE PROC BORRAR_PrestamoEquipo
(@codigoPrestamoEquipo VARCHAR(40))
AS
DECLARE @TEXTO VARCHAR(50)
BEGIN
if (select count(*) from PrestamoEquipo where codigoPrestamoEquipo = @codigoPrestamoEquipo)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion' 
else
DELETE FROM Usuario_PrestamoEquipo where codigoPrestamoEquipo = @codigoPrestamoEquipo; 
DELETE FROM PrestamoEquipo where codigoPrestamoEquipo = @codigoPrestamoEquipo; 
END


---INSERTAR PRESTAMO PERMANENTE
/*este procedimiento permite insertar un usuario a la tabla PP, declarando variables por parametro para obtener los datos desde la aplicacion. 
Se trabaja con dos variables temporales @maxcode, que se usa para almacenar el valor maximo de la columna ID, con este se hace la validacion de si existe un registro o no
en el IF, en la variable @codigoPP se almacena un valor construido por CAST del @maxCode, que servira para identificar las filas de las tablas de manera unica sin hacer referencia
a la llave autoincremental*/
GO
CREATE PROCEDURE INSERTAR_PrestamoPermanente
(@nombreSolicitante VARCHAR(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@despacho VARCHAR(40) ,@telefono INTEGER ,
@extension VARCHAR(10),@informacionAdicional VARCHAR(max),@generoSolicictante VARCHAR(10) ,@fechaPrestamo DATE ,@estado VARCHAR(20),@cedulaUsuario varchar(20), @nombre VARCHAR(40),
@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
AS
DECLARE
@codigoPrestamoPermanente varchar(40),
@maxCode int;
set @maxCode = (select MAX (Id) from PrestamoPermanente);
if( @maxCode IS NULL) 
SET @codigoPrestamoPermanente= 'CPP-1'
ELSE
SET @codigoPrestamoPermanente = ('CPP-' + cast(@maxCode+1 as varchar));
BEGIN
insert into PrestamoPermanente
(codigoPrestamoPermanente,nombreSolicitante,apellidoSolicitante1,apellidoSolicitante2,despacho,telefono,extension,
informacionAdicional,generoSolicictante,fechaPrestamo,estado
)
VALUES
(@codigoPrestamoPermanente,@nombreSolicitante,@apellidoSolicitante1,@apellidoSolicitante2,@despacho,@telefono,
@extension,@informacionAdicional,@generoSolicictante,@fechaPrestamo,@estado);

insert into Usuario_PrestamoPermanente 
 (cedulaUsuario, codigoPrestamoPermanente, 
nombre, apellido1, apellido2)
VALUES
(@cedulaUsuario, @codigoPrestamoPermanente, 
@nombre, @apellido1, @apellido2);
END


---SELECCIONAR TODO PRESTAMO PERMANENETE
GO
CREATE PROCEDURE SELECCIONAR_PrestamoPermanente_TODO
AS 
BEGIN
Select
a.Id,a.codigoPrestamoPermanente,a.nombreSolicitante,a.apellidoSolicitante1,a.apellidoSolicitante2,a.despacho,
a.telefono,a.extension,a.informacionAdicional,a.generoSolicictante,a.fechaPrestamo,a.estado,b.cedulaUsuario, 
b.nombre, b.apellido1, b.apellido2
FROM Usuario_PrestamoPermanente b, PrestamoPermanente a
WHERE b.codigoPrestamoPermanente=a.codigoPrestamoPermanente
END

--SELECCIONAR PRESTAMO PERMANENTE
/* select en base al campo unico @codigo*/
GO
CREATE PROCEDURE SELECCIONAR_PrestamoPermanente
(@CODIGOPP varchar(40))
AS 
declare  @TEXTO varchar(50) 
BEGIN
if (select count(*) from PrestamoPermanente where codigoPrestamoPermanente = @CODIGOPP)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion'
else 
Select
a.Id,a.codigoPrestamoPermanente,a.nombreSolicitante,a.apellidoSolicitante1,a.apellidoSolicitante2,
a.despacho,a.telefono,a.extension,a.informacionAdicional,a.generoSolicictante,a.fechaPrestamo,
a.estado,b.cedulaUsuario, b.nombre, b.apellido1, b.apellido2
FROM Usuario_PrestamoPermanente b, PrestamoPermanente a
WHERE b.codigoPrestamoPermanente=@CODIGOPP and @CODIGOPP=a.codigoPrestamoPermanente
END

--ACTUALIZAR PRESTAMO PERMANENTE
/* se setea un update en base al campo unico codigo*/
go
create proc ACTUALIZAR_PrestamoPermanente
(@Id int,@codigoPrestamoPermanente varchar(40),@nombreSolicitante VARCHAR(40) ,@apellidoSolicitante1 VARCHAR(20) ,
@apellidoSolicitante2 VARCHAR(20) ,@despacho VARCHAR(40) ,@telefono INTEGER ,@extension VARCHAR(10),@informacionAdicional VARCHAR(max),
@generoSolicictante VARCHAR(10) ,@fechaPrestamo DATE ,@estado VARCHAR(20),@cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
as
begin
UPDATE PrestamoPermanente
set codigoPrestamoPermanente=@codigoPrestamoPermanente, nombreSolicitante=@nombreSolicitante,
apellidoSolicitante1=@apellidoSolicitante1, apellidoSolicitante2=@apellidoSolicitante2,
despacho=@despacho, telefono=@telefono, extension=@extension, informacionAdicional=@informacionAdicional,
generoSolicictante=@generoSolicictante, fechaPrestamo=@fechaPrestamo, estado=@estado
where codigoPrestamoPermanente=@codigoPrestamoPermanente;

UPDATE Usuario_PrestamoPermanente
SET cedulaUsuario=@cedulaUsuario, codigoPrestamoPermanente=@codigoPrestamoPermanente, 
nombre=@nombre,apellido1=@apellido1, apellido2=@apellido2
where codigoPrestamoPermanente=@codigoPrestamoPermanente;
END


--BORRAR PRESTAMO PERMANENETE
GO
CREATE PROC BORRAR_PrestamoPermanenete
(@codigoPrestamoPermanente VARCHAR(40))
AS
DECLARE @TEXTO VARCHAR(50)
BEGIN
if (select count(*) from PrestamoPermanente where codigoPrestamoPermanente = @codigoPrestamoPermanente)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion' 
else
DELETE FROM Usuario_PrestamoPermanente where codigoPrestamoPermanente = @codigoPrestamoPermanente; 
DELETE FROM PrestamoPermanente where codigoPrestamoPermanente = @codigoPrestamoPermanente; 
END



--- INSERTAR CONSULTA
/*este procedimiento permite insertar un usuario a la tabla Consulta, declarando variables por parametro para obtener los datos desde la aplicacion. 
Se trabaja con dos variables temporales @maxcode, que se usa para almacenar el valor maximo de la columna ID, con este se hace la validacion de si existe un registro o no
en el IF, en la variable @codigoConsulta se almacena un valor construido por CAST del @maxCode, que servira para identificar las filas de las tablas de manera unica sin hacer referencia
a la llave autoincremental*/
go
create proc INSERTAR_CONSULTA
(@nombreSolicitante varchar(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@telefono INTEGER ,
@email VARCHAR(100) ,@asunto VARCHAR(50) ,@descripcion VARCHAR(500),@respuesta VARCHAR(max) ,@metodoIngreso VARCHAR(20) ,@generoSolicitante VARCHAR(10) ,
@fechaIngreso DATE ,@fechaRespuesta DATE ,@estado VARCHAR(20),@cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
AS
DECLARE
@codigoConsulta varchar(40),
@maxCode int;
set @maxCode = (select MAX (Id) from Consulta);
if( @maxCode IS NULL) 
SET @codigoConsulta= 'CC-1'
ELSE
SET @codigoConsulta = ('CC-' + cast(@maxCode+1 as varchar));
BEGIN
Insert into Consulta (codigoConsulta, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2,
telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante, fechaIngreso,
fechaRespuesta, estado)
VALUES
(@codigoConsulta, @nombreSolicitante, @apellidoSolicitante1, @apellidoSolicitante2,
@telefono, @email, @asunto, @descripcion, @respuesta, @metodoIngreso, @generoSolicitante, @fechaIngreso,
@fechaRespuesta, @estado);
insert into Usuario_Consulta 
 (cedulaUsuario, codigoConsulta, 
nombre, apellido1, apellido2)
VALUES
(@cedulaUsuario, @codigoConsulta, 
@nombre, @apellido1, @apellido2);
END


---SELECT DE TODO CONSULTA
GO
CREATE PROC SELECCIONAR_CONSULTA_TODO
AS 
BEGIN
SELECT
a.Id, a.codigoConsulta, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2,
telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante, fechaIngreso,
fechaRespuesta, estado, cedulaUsuario, nombre, apellido1, apellido2
FROM Consulta a, Usuario_Consulta b
where b.codigoConsulta=a.codigoConsulta
END

---SELECT CONSULTA
/* select en base al campo unico @codigo*/
GO
CREATE PROC SELECCIONAR_CONSULTA
(@CODIGOC varchar(40))
AS 
declare  @TEXTO varchar(50)
BEGIN
if (select count(*) from Consulta where codigoConsulta = @CODIGOC)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion'
else 
SELECT
a.Id, a.codigoConsulta, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2,
telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante, fechaIngreso,
fechaRespuesta, estado, cedulaUsuario, nombre, apellido1, apellido2
FROM Consulta a, Usuario_Consulta b
where b.codigoConsulta=@CODIGOC and @CODIGOC=a.codigoConsulta
END

--UPDATE CONSULTA
/* se setea un update en base al campo unico codigo*/
GO 
CREATE PROC ACTUALIZAR_CONSULTA
(@Id int,@codigoConsulta varchar(40),@nombreSolicitante varchar(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@telefono INTEGER ,
@email VARCHAR(100) ,@asunto VARCHAR(50) ,@descripcion VARCHAR(500),@respuesta VARCHAR(max) ,@metodoIngreso VARCHAR(20) ,@generoSolicitante VARCHAR(10) ,@fechaIngreso DATE ,
@fechaRespuesta DATE ,@estado VARCHAR(20),@cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20)
)
AS
BEGIN
UPDATE Consulta
set codigoConsulta=@codigoConsulta, nombreSolicitante=@nombreSolicitante, apellidoSolicitante1=@apellidoSolicitante1,
apellidoSolicitante2=@apellidoSolicitante2, telefono=@telefono, email=@email, asunto=@asunto,
descripcion=@descripcion, respuesta=@respuesta, metodoIngreso=@metodoIngreso, generoSolicitante=@generoSolicitante,
fechaIngreso=@fechaIngreso, fechaRespuesta=@fechaRespuesta, estado=@estado
where codigoConsulta=@codigoConsulta;

UPDATE Usuario_Consulta
SET cedulaUsuario=@cedulaUsuario, codigoConsulta=@codigoConsulta, 
nombre=@nombre,apellido1=@apellido1, apellido2=@apellido2
where codigoConsulta=@codigoConsulta;
END


---BORRAR CONSULTA

GO 
CREATE PROCEDURE BORRAR_CONSULTA
(@codigoConsulta varchar(40))
as
DECLARE @TEXTO VARCHAR(50)
BEGIN
if (select count(*) from Consulta where codigoConsulta = @codigoConsulta)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion' 
else
delete from Usuario_Consulta where codigoConsulta = @codigoConsulta;
delete from Consulta where codigoConsulta = @codigoConsulta;
END


--INSERTAR AUDIOVISUAL
/*este procedimiento permite insertar un usuario a la tabla PA, declarando variables por parametro para obtener los datos desde la aplicacion. 
Se trabaja con dos variables temporales @maxcode, que se usa para almacenar el valor maximo de la columna ID, con este se hace la validacion de si existe un registro o no
en el IF, en la variable @codigoPA se almacena un valor construido por CAST del @maxCode, que servira para identificar las filas de las tablas de manera unica sin hacer referencia
a la llave autoincremental*/
GO
CREATE PROC INSERTAR_AUDIOVISUAL
(@nombreSolicitante varchar(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@telefono INTEGER ,@departamento VARCHAR(40),
@nombreActividad VARCHAR(50) ,@categoria VARCHAR(40) ,@especificacionCategoria VARCHAR(100),@ubicacion VARCHAR(100),@horaInicio DATETIME ,
@horaFin DATETIME ,@descripcion VARCHAR(500) ,@equipoRequerido VARCHAR(40) ,@aforo INTEGER ,@generoSolicitante VARCHAR(10) ,
@cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20)
)
AS
DECLARE
@codigoAudiovisual varchar(40),
@maxCode int;
set @maxCode = (select MAX (Id) from PrestamoAudiovisual);
if( @maxCode IS NULL) 
SET @codigoAudiovisual= 'CPA-1'
ELSE
SET @codigoAudiovisual = ('CPA-' + cast(@maxCode+1 as varchar));
BEGIN
insert into PrestamoAudiovisual (codigoPrestamoAudiovisual, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2,
telefono, departamento, nombreActividad, categoria, especificacionCategoria, ubicacion, horaInicio,
horaFin, descripcion, equipoRequerido, aforo, generoSolicitante)
VALUES
(@codigoAudiovisual, @nombreSolicitante, @apellidoSolicitante1, @apellidoSolicitante2,
@telefono, @departamento, @nombreActividad, @categoria, @especificacionCategoria, @ubicacion, 
@horaInicio, @horaFin, @descripcion, @equipoRequerido, @aforo, @generoSolicitante);

INSERT INTO Usuario_PrestamoAudiovisual (cedulaUsuario, codigoPrestamoAudiovisual, 
nombre, apellido1, apellido2)
values
(@cedulaUsuario, @codigoAudiovisual, 
@nombre, @apellido1, @apellido2);
end

--SELECT TODOS AUDIOVISUAL
GO 
CREATE PROCEDURE SELECCIONAR_AUDIOVISUAL_TODO
AS
BEGIN
SELECT
a.Id, a.codigoPrestamoAudiovisual, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2,
telefono, departamento, nombreActividad, categoria, especificacionCategoria, ubicacion, horaInicio,
horaFin, descripcion, equipoRequerido, aforo, generoSolicitante, cedulaUsuario,  
nombre, apellido1, apellido2
FROM PrestamoAudiovisual a, Usuario_PrestamoAudiovisual b
where a.codigoPrestamoAudiovisual=b.codigoPrestamoAudiovisual
end

--SELECT AUDIOVISUAL
/* select en base al campo unico @codigo*/
GO 
CREATE PROCEDURE SELECCIONAR_AUDIOVISUAL
(@CODIGOAV varchar(40))
AS
BEGIN
SELECT
a.Id, a.codigoPrestamoAudiovisual, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2,
telefono, departamento, nombreActividad, categoria, especificacionCategoria, ubicacion, horaInicio,
horaFin, descripcion, equipoRequerido, aforo, generoSolicitante, cedulaUsuario,  
nombre, apellido1, apellido2
FROM PrestamoAudiovisual a, Usuario_PrestamoAudiovisual b
where a.codigoPrestamoAudiovisual=@CODIGOAV AND @CODIGOAV=b.codigoPrestamoAudiovisual
end

---UPDATE AUDIOVISUAL
GO
CREATE PROCEDURE ACTUALIZAR_AUDIOVISUAL
(@Id int,@codigoAudiovisual varchar(40),@nombreSolicitante varchar(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,
@telefono INTEGER ,@departamento VARCHAR(40),@nombreActividad VARCHAR(50) ,@categoria VARCHAR(40) ,@especificacionCategoria VARCHAR(100),@ubicacion VARCHAR(100),
@horaInicio DATETIME ,@horaFin DATETIME ,@descripcion VARCHAR(500) ,@equipoRequerido VARCHAR(40) ,@aforo INTEGER ,@generoSolicitante VARCHAR(10) ,
@cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20)
)
as
BEGIN
UPDATE PrestamoAudiovisual
SET codigoPrestamoAudiovisual=@codigoAudiovisual, nombreSolicitante=@nombreSolicitante, apellidoSolicitante1=@apellidoSolicitante1, apellidoSolicitante2=@apellidoSolicitante2,
telefono=@telefono, departamento=@departamento, nombreActividad=@nombreActividad, categoria=@categoria, especificacionCategoria=@especificacionCategoria, ubicacion=@ubicacion, horaInicio=@horaInicio,
horaFin=@horaFin, descripcion=@descripcion, equipoRequerido=@equipoRequerido, aforo=@aforo, generoSolicitante=@generoSolicitante
where codigoPrestamoAudiovisual=@codigoAudiovisual;

update Usuario_PrestamoAudiovisual
SET cedulaUsuario=@cedulaUsuario, codigoPrestamoAudiovisual=@codigoAudiovisual, 
nombre=@nombre,apellido1=@apellido1, apellido2=@apellido2
where codigoPrestamoAudiovisual=@codigoAudiovisual;
END

---BORRAR AUDIOVISUAL

GO
CREATE PROCEDURE BORRAR_AUDIOVISUAL
(@codigoAudiovisual varchar(40))
as
DECLARE @TEXTO VARCHAR(50)
BEGIN
if (select count(*) from PrestamoAudiovisual where codigoPrestamoAudiovisual = @codigoAudiovisual)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion' 
ELSE
DELETE FROM Usuario_PrestamoAudiovisual WHERE codigoPrestamoAudiovisual = @codigoAudiovisual;
DELETE FROM PrestamoAudiovisual WHERE codigoPrestamoAudiovisual = @codigoAudiovisual;
END


---SELECIONAR TODO EN REFERENCIA
go
create PROC SELECCIONAR_REFERENCIA_TODO
AS 
BEGIN
SELECT * FROM Referencia;
end


---SELECCIONAR EN REFERENCIA
GO
CREATE  PROC SELECCIONAR_REFERENCIA
(@ID int)
as
 declare @TEXTO varchar(50) 
BEGIN
if (select count(*) from Referencia where Id = @ID)  = 0
select @TEXTO = 'No existente un usurio con la misma especificacion'
else 
select * from Referencia where Id=@ID;
END


--TRIGGER
GO
create TRIGGER Actualizar_Usuario_Trigger
ON Usuario
FOR UPDATE
AS 
SET IDENTITY_INSERT dbo.AuditoriaUsuario ON
BEGIN
INSERT INTO AuditoriaUsuario
(Id, cedula, nombre, apellido1, apellido2, email, accion, fecha, usuarioBD)
SELECT Id, cedula, nombre, apellido1, apellido2, email, 'UPDATE', getdate(), suser_sname()
FROM deleted;
END;


GO
CREATE TRIGGER Borrar_Usuario_Trigger
ON Usuario
FOR DELETE
AS 
SET IDENTITY_INSERT dbo.AuditoriaUsuario ON
BEGIN
INSERT INTO AuditoriaUsuario
(Id, cedula, nombre, apellido1, apellido2, email, accion, fecha, usuarioBD)
SELECT Id, cedula, nombre, apellido1, apellido2, email, 'DELETE', getdate(), suser_sname()
FROM deleted;
END;








--TRIGGERS
go
Create Trigger ACTUALIZAR_CIIE__Trigger 
ON dbo.FormularioCIIE
for update 
as 
SET IDENTITY_INSERT dbo.AuditoriaFormularioCIIE ON
begin
insert into AuditoriaFormularioCIIE
(Id, codigoCIIE, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, tipoDespacho, fraccion, especificacionDespacho, tipoConsulta, especificacionConsulta
, tema, informacionRequerida, usoInformacion, generoSolicitante, estado, accion, fecha, usuarioBD)
select Id, codigoCIIE, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, tipoDespacho, fraccion, especificacionDespacho, tipoConsulta, especificacionConsulta
, tema, informacionRequerida, usoInformacion, generoSolicitante, estado, 'UPDATE', getdate(), suser_sname()
from deleted;
end;


go
Create Trigger BORRAR_CIIE_Trigger 
ON dbo.FormularioCIIE
for delete
as 
SET IDENTITY_INSERT dbo.AuditoriaFormularioCIIE ON
begin
insert into AuditoriaFormularioCIIE
(Id, codigoCIIE, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, tipoDespacho, fraccion, especificacionDespacho, tipoConsulta, especificacionConsulta
, tema, informacionRequerida, usoInformacion, generoSolicitante, estado, accion, fecha, usuarioBD)
select Id, codigoCIIE, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, tipoDespacho, fraccion, especificacionDespacho, tipoConsulta, especificacionConsulta
, tema, informacionRequerida, usoInformacion, generoSolicitante, estado, 'DELETE', getdate(), suser_sname()
from deleted;
end;





 --Triggers
 go
Create Trigger ACTUALIZAR_PrestamoEquipo_Trigger 
ON PrestamoEquipo
for update 
as 
SET IDENTITY_INSERT dbo.AuditoriaPrestamoEquipo ON
begin
insert into AuditoriaPrestamoEquipo
(Id, codigoPrestamoEquipo, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, cedulaSolicitante, departamento, tipoEquipo, implementos, especificacionImplementos, 
generoSolicictante, estado, accion, fecha, usuarioBD)

select Id, codigoPrestamoEquipo, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, cedulaSolicitante,  departamento, tipoEquipo, implementos,
especificacionImplementos, generoSolicictante, estado, 'UPDATE', getdate(), suser_sname()
from deleted;
end;

 go
Create Trigger BORRAR_PrestamoEquipo_Trigger 
ON PrestamoEquipo
for DELETE
as 
SET IDENTITY_INSERT dbo.AuditoriaPrestamoEquipo ON
begin
insert into AuditoriaPrestamoEquipo
(Id, codigoPrestamoEquipo, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, cedulaSolicitante, departamento, tipoEquipo, implementos, especificacionImplementos, 
generoSolicictante, estado, accion, fecha, usuarioBD)

select Id, codigoPrestamoEquipo, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, cedulaSolicitante,  departamento, tipoEquipo, implementos,
especificacionImplementos, generoSolicictante, estado, 'DELETE', getdate(), suser_sname()
from deleted;
end;




--TRIGGERS
 go
Create Trigger ACTUALIZAR_PrestamoPermanente_Trigger 
ON PrestamoPermanente
for update 
as 
SET IDENTITY_INSERT dbo.AuditoriaPrestamoPermanente ON
begin
insert into AuditoriaPrestamoPermanente
(Id, codigoPrestamoPermanente, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, despacho, telefono, extension, informacionAdicional, generoSolicictante, fechaPrestamo, estado, accion, fecha, usuarioBD)

select Id, codigoPrestamoPermanente, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, despacho, telefono, extension, informacionAdicional, generoSolicictante, fechaPrestamo,
estado, 'UPDATE', getdate(), suser_sname()
from deleted;
end;


 go
Create Trigger BORRAR_PrestamoPermanente_Trigger 
ON PrestamoPermanente
for delete
as 
SET IDENTITY_INSERT dbo.AuditoriaPrestamoPermanente ON
begin
insert into AuditoriaPrestamoPermanente
(Id, codigoPrestamoPermanente, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, despacho, telefono, extension, informacionAdicional, generoSolicictante, fechaPrestamo, estado, accion, fecha, usuarioBD)

select Id, codigoPrestamoPermanente, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, despacho, telefono, extension, informacionAdicional, generoSolicictante, fechaPrestamo,
estado, 'DELETE', getdate(), suser_sname()
from deleted;
end;



--TRIGGERS
 go
create Trigger ACTUALIZAR_Consultas_Trigger
ON Consulta
for update 
as 
SET IDENTITY_INSERT dbo.AuditoriaConsulta ON
begin
insert into AuditoriaConsulta
(Id, codigoConsulta, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante, 
estado, accion, fecha, usuarioBD)

select Id, codigoConsulta, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante,
estado, 'UPDATE', getdate(), suser_sname()
from deleted;
end;

 go
Create Trigger BORRAR_Consultas_Trigger
ON Consulta
for delete
as 
SET IDENTITY_INSERT dbo.AuditoriaConsulta ON
begin
insert into AuditoriaConsulta
(Id, codigoConsulta, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante, 
estado, accion, fecha, usuarioBD)

select Id, codigoConsulta, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante,
estado, 'DELETE', getdate(), suser_sname()
from deleted;
end;
 
 

--Trigger
 go
create Trigger ACTUALIZAR_PrestamoAudiovisual_Trigger
ON PrestamoAudiovisual
for update 
as 
SET IDENTITY_INSERT dbo.AuditoriaPrestamoAudiovisual ON
begin
insert into AuditoriaPrestamoAudiovisual
( Id, codigoPrestamoAudiovisual, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, departamento, nombreActividad, categoria, especificacionCategoria,
ubicacion, horaInicio, horaFin, descripcion, equipoRequerido, aforo, generoSolicitante, accion, fecha, usuarioBD)

select Id, codigoPrestamoAudiovisual, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, departamento, nombreActividad, categoria, especificacionCategoria,
ubicacion, horaInicio, horaFin, descripcion, equipoRequerido, aforo, generoSolicitante, 'UPDATE', getdate(), suser_sname()
from deleted;
end;


 go
create Trigger BORRAR_PrestamoAudiovisual_Trigger
ON PrestamoAudiovisual
for delete
as
SET IDENTITY_INSERT dbo.AuditoriaPrestamoAudiovisual ON
begin
insert into AuditoriaPrestamoAudiovisual
( Id, codigoPrestamoAudiovisual, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, departamento, nombreActividad, categoria, especificacionCategoria,
ubicacion, horaInicio, horaFin, descripcion, equipoRequerido, aforo, generoSolicitante, accion, fecha, usuarioBD)

select Id, codigoPrestamoAudiovisual, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, departamento, nombreActividad, categoria, especificacionCategoria,
ubicacion, horaInicio, horaFin, descripcion, equipoRequerido, aforo, generoSolicitante, 'DELETE', getdate(), suser_sname()
from deleted;
end;
