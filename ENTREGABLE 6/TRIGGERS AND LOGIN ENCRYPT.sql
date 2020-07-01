USE MASTER;

USE ARE_Biblioteca_Legislativa;

--PROCEDURES

---PROCEDURE DE ROLES
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


--PROCEDIMIENTO A LA HORA DE INSERTAR
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
(Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, tipoDespacho, fraccion, especificacionDespacho, tipoConsulta, especificacionConsulta
, tema, informacionRequerida, usoInformacion, generoSolicitante, estado, accion, fecha, usuarioBD)
select Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, tipoDespacho, fraccion, especificacionDespacho, tipoConsulta, especificacionConsulta
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
(Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, tipoDespacho, fraccion, especificacionDespacho, tipoConsulta, especificacionConsulta
, tema, informacionRequerida, usoInformacion, generoSolicitante, estado, accion, fecha, usuarioBD)
select Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, tipoDespacho, fraccion, especificacionDespacho, tipoConsulta, especificacionConsulta
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
(Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, cedulaSolicitante, departamento, tipoEquipo, implementos, especificacionImplementos, 
generoSolicictante, estado, accion, fecha, usuarioBD)

select Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, cedulaSolicitante,  departamento, tipoEquipo, implementos,
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
(Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, cedulaSolicitante, departamento, tipoEquipo, implementos, especificacionImplementos, 
generoSolicictante, estado, accion, fecha, usuarioBD)

select Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, cedulaSolicitante,  departamento, tipoEquipo, implementos,
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
(Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, despacho, telefono, extension, informacionAdicional, generoSolicictante, fechaPrestamo, estado, accion, fecha, usuarioBD)

select Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, despacho, telefono, extension, informacionAdicional, generoSolicictante, fechaPrestamo,
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
(Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, despacho, telefono, extension, informacionAdicional, generoSolicictante, fechaPrestamo, estado, accion, fecha, usuarioBD)

select Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, despacho, telefono, extension, informacionAdicional, generoSolicictante, fechaPrestamo,
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
(Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante, 
estado, accion, fecha, usuarioBD)

select Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante,
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
(Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante, 
estado, accion, fecha, usuarioBD)

select Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante,
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
( Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, departamento, nombreActividad, categoria, especificacionCategoria,
ubicacion, horaInicio, horaFin, descripcion, equipoRequerido, aforo, generoSolicitante, accion, fecha, usuarioBD)

select Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, departamento, nombreActividad, categoria, especificacionCategoria,
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
( Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, departamento, nombreActividad, categoria, especificacionCategoria,
ubicacion, horaInicio, horaFin, descripcion, equipoRequerido, aforo, generoSolicitante, accion, fecha, usuarioBD)

select Id, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, telefono, departamento, nombreActividad, categoria, especificacionCategoria,
ubicacion, horaInicio, horaFin, descripcion, equipoRequerido, aforo, generoSolicitante, 'DELETE', getdate(), suser_sname()
from deleted;
end;
