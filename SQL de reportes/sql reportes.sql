----SQL DINAMICO QUE DEVUELVE LA CANTIDAD DE TOTALES POR FORMULARIO, PASANDO EL NOMBRE DE LA TABLA COMO 
----ATRIBUTO DESDE EL SISTEMA ESTE PROCEDIMIENTO SE PUEDE RECICLAR PARA CUALQUIER TIPO DE TABLA.
--go
--create procedure CantidadTotales (@nTabla varchar(100))
--as
--begin
--declare @Comando as nvarchar(200)
--set @Comando = 'select count(*) from' + @nTabla
--EXEC sp_executesql @Comando
--end


----Procedimiento que permite obtener el listado de filas de la tabla FormularioCIIE, con base a filtro de fecha de ingres y respuesta,
----este procedimiento recibe tales fechas como un parameto del sitema.
--go
--Create PROCEDURE RangoFechas ( @fecInicial date, @fecFinal date)
--as 
--begin

--select * from	FormularioCIIE where fechaIngreso between @fecInicial
--and @fecFinal

--end


----Procedimiento almacenado que hace un conteo por genero, este procedimiento es dinamico ya que recibe por 
----parametro el nombre de la tabla a consultar
--go
--create procedure CantidadGenero (@nTabla varchar(100))
--as
--begin
--declare @Comando as nvarchar(200)
--set @Comando= 'select generoSolicitante, COUNT(generoSolicitante) as Cantidad
--from ' + @nTabla + ' group by' +' generoSolicitante'
--EXEC sp_executesql @Comando
--end


----Procedimiento almacenado que hace un conteo por tipo de despacho para el FormularioCIIE
--go
--create procedure CantidadDespacho 
--as 
--begin
--select tipoDespacho, COUNT(tipoDespacho) as Cantidad
--from FormularioCIIE group by tipoDespacho
--end


----Procedimiento almacenado que hace un conteo por tipo de consulta para el FormularioCIIE
--GO 
--CREATE PROCEDURE CantidadTipoConsulta
--AS
--BEGIN
--SELECT tipoConsulta, COUNT(tipoConsulta) AS cantidad
--from FormularioCIIE GROUP BY tipoConsulta
--end

--

/*
go
create procedure CantidaRangoFechasIngreso (@fecFrom date, @fecTo date)
as 
begin
SELECT COUNT(*) 
FROM FormularioCIIE
WHERE fechaIngreso between @fecFrom and @fecTo
end

--
go
create procedure CantidaRangoFechasRespuesta (@fecFrom date, @fecTo date)
as 
begin
SELECT COUNT(*) 
FROM FormularioCIIE
WHERE fechaRespuesta between @fecFrom and @fecTo
end
*/






---Reportes CIIE

/* Proceimiento que devuelve la cantida de reportes por tipo de usuario y su porcentaje en un rango de fechas de ingreso al sistema, las cuales son pasadas como parametros desde el sistema
para el formulario CIIE*/
go
alter procedure CantidadTipoUsuarioIngreso (@fecFrom date, @fecTo date)
as 
begin
select tipoDespacho, COUNT(tipoDespacho) as Cantidad, count(tipoDespacho)*100/ (select count(*) from FormularioCIIE where fechaIngreso between @fecFrom and @fecTo) as porcentaje
from FormularioCIIE 
where fechaIngreso between @fecFrom and @fecTo
group by tipoDespacho
end


/* Proceimiento que devuelve la cantida de reportes por tipo de usuario y su porcentaje en un rango de fechas de respuesta al sistema, las cuales son pasadas como parametros desde el sistema
para el formulario CIIE*/
go
alter procedure CantidadTipoUsuarioRespuesta (@fecFrom date, @fecTo date)
as 
begin
select tipoDespacho, COUNT(tipoDespacho) as Cantidad, count(tipoDespacho)*100/ (select count(*) from FormularioCIIE where fechaRespuesta between @fecFrom and @fecTo) as porcentaje
from FormularioCIIE 
where fechaRespuesta between @fecFrom and @fecTo
group by tipoDespacho
end


/* Procedimiento que devuelve la cantidad de registros de la tabla Formulario CIIE en un rango de fechas (Ingreso y respuesta) las cuales son pasadas como parametro 
desde el sistema, orenado por tipo de usuario, cantidad y su porcentaje relativo sobre el total de lineas que hay en la tabla*/
go
alter procedure CantidadTipoUsuarioFromTo(@fecFrom date, @fecTo date)
as
begin
select tipoDespacho AS Tipo_Usuario, COUNT(tipoDespacho) as Cantidad, count(tipoDespacho)*100/ (select count(*) from FormularioCIIE where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo) as Porcentaje
from FormularioCIIE
where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo
group by tipoDespacho
end



--
--
--
go 
alter procedure CANTIDAD_GENERO_INGRESO_CIIE (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from FormularioCIIE where fechaIngreso between @fecFrom and @fecTo) as porcentaje
from FormularioCIIE 
where fechaIngreso between @fecFrom and @fecTo
group by generoSolicitante
END

--
go 
alter procedure CANTIDAD_GENERO_RESPUESTA_CIIE (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from FormularioCIIE where fechaRespuesta between @fecFrom and @fecTo) as porcentaje
from FormularioCIIE 
where fechaRespuesta between @fecFrom and @fecTo
group by generoSolicitante
END



--
go 
alter procedure CANTIDAD_GENERO_FROM_TO_CIIE (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from FormularioCIIE where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo) as porcentaje
from FormularioCIIE 
where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo
group by generoSolicitante
END



--Reportes Consultas

/* Proceimiento que devuelve la cantida de reportes por tipo de usuario y su porcentaje en un rango de fechas de ingreso al sistema, las cuales son pasadas como parametros desde el sistema
para el formulario Consultas*/

go
CREATE procedure CANTIDAD_METODO_INGRESO_CONSULTA (@fecFrom date, @fecTo date)
as 
begin
select metodoIngreso, COUNT(metodoIngreso) as Cantidad, count(metodoIngreso)*100/ (select count(*) from Consulta where fechaIngreso between @fecFrom and @fecTo) as porcentaje
from Consulta 
where fechaIngreso between @fecFrom and @fecTo
group by metodoIngreso
end


/* Proceimiento que devuelve la cantida de reportes por tipo de usuario y su porcentaje en un rango de fechas de respuesta al sistema, las cuales son pasadas como parametros desde el sistema
para el formulario CIIE*/
go
CREATE procedure CANTIDAD_METODO_INGRESO_CONSULTA_RESPUESTA (@fecFrom date, @fecTo date)
as 
begin
select metodoIngreso, COUNT(metodoIngreso) as Cantidad, count(metodoIngreso)*100/ (select count(*) from Consulta where fechaRespuesta between @fecFrom and @fecTo) as porcentaje
from Consulta 
where fechaRespuesta between @fecFrom and @fecTo
group by metodoIngreso
end



/* Procedimiento que devuelve la cantidad de registros de la tabla Formulario CIIE en un rango de fechas (Ingreso y respuesta) las cuales son pasadas como parametro 
desde el sistema, orenado por tipo de usuario, cantidad y su porcentaje relativo sobre el total de lineas que hay en la tabla*/
go
CREATE procedure CANTIDAD_METODO_INGRESO_CONSULTA_FROM_TO (@fecFrom date, @fecTo date)
as
begin
select metodoIngreso AS MetodoIngreso, COUNT(metodoIngreso) as Cantidad, count(metodoIngreso)*100/ (select count(*) from Consulta where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo) as Porcentaje
from Consulta
where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo
group by metodoIngreso
end



--
--
--
go 
CREATE procedure CANTIDAD_GENERO_INGRESO_CONSULTA (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from Consulta where fechaIngreso between @fecFrom and @fecTo) as porcentaje
from Consulta 
where fechaIngreso between @fecFrom and @fecTo
group by generoSolicitante
END

--
go 
create procedure CANTIDAD_GENERO_RESPUESTA_CONSULTA (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from Consulta where fechaRespuesta between @fecFrom and @fecTo) as porcentaje
from Consulta 
where fechaRespuesta between @fecFrom and @fecTo
group by generoSolicitante
END



--
go 
create procedure CANTIDAD_GENERO_FROM_TO_CONSULTA (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from Consulta where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo) as porcentaje
from Consulta 
where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo
group by generoSolicitante
END



--Reportes PP

/* Proceimiento que devuelve la cantida de reportes por tipo de usuario y su porcentaje en un rango de fechas de ingreso al sistema, las cuales son pasadas como parametros desde el sistema
para el formulario PP*/

go
CREATE procedure CANTIDAD_DESPACHO_INGRESO_PP (@fecFrom date, @fecTo date)
as 
begin
select despacho, COUNT(despacho) as Cantidad, count(despacho)*100/ (select count(*) from PrestamoPermanente where fechaPrestamo between @fecFrom and @fecTo) as porcentaje
from PrestamoPermanente 
where fechaPrestamo between @fecFrom and @fecTo
group by despacho
end


--
--
--
go 
CREATE procedure CANTIDAD_GENERO_INGRESO_PP (@fecFrom date, @fecTo date)
as 
begin
select generoSolicictante, COUNT(generoSolicictante) as Cantidad, count(generoSolicictante)*100/ (select count(*) from PrestamoPermanente where fechaPrestamo between @fecFrom and @fecTo) as porcentaje
from PrestamoPermanente 
where fechaPrestamo between @fecFrom and @fecTo
group by generoSolicictante
END



