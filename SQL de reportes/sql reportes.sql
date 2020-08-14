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

--
go
Create procedure CantidadTipoUsuarioIngreso (@fecFrom date, @fecTo date)
as 
begin
select tipoDespacho, COUNT(tipoDespacho) as Cantidad, count(tipoDespacho)*100/ (select count(*) from FormularioCIIE)
from FormularioCIIE 
where fechaIngreso between @fecFrom and @fecTo
group by tipoDespacho
end


--
go
Create procedure CantidadTipoUsuarioRespuesta (@fecFrom date, @fecTo date)
as 
begin
select tipoDespacho, COUNT(tipoDespacho) as Cantidad, count(tipoDespacho)*100/ (select count(*) from FormularioCIIE)
from FormularioCIIE 
where fechaRespuesta between @fecFrom and @fecTo
group by tipoDespacho
end






--select count(*) 
--from FormularioCIIE

--select count(*)
--from FormularioCIIE
--where tipoDespacho = 'bg'

select tipoDespacho AS Tipo_Usuario, COUNT(tipoDespacho) as Cantidad, count(tipoDespacho)*100/ (select count(*) from FormularioCIIE) as Porcentaje
from FormularioCIIE 
where fechaIngreso between '01-01-2019' and '01-02-2019'
group by tipoDespacho

--select tipoDespacho, count(tipoDespacho)*100/ (select count(*) from FormularioCIIE)
--from FormularioCIIE
--group by tipoDespacho

select tipoDespacho AS Tipo_Usuario, COUNT(tipoDespacho) as Cantidad, count(tipoDespacho)*100/ (select count(*) from FormularioCIIE) as Porcentaje
from FormularioCIIE 
where fechaIngreso >= '01-01-2019' and  fechaRespuesta <= '04-20-2019'
group by tipoDespacho

select * from FormularioCIIE