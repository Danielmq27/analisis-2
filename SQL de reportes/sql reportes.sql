--SQL DINAMICO QUE DEVUELVE LA CANTIDAD DE TOTALES POR FORMULARIO, PASANDO EL NOMBRE DE LA TABLA COMO 
--ATRIBUTO DESDE EL SISTEMA ESTE PROCEDIMIENTO SE PUEDE RECICLAR PARA CUALQUIER TIPO DE TABLA.
go
create procedure CantidadTotales (@nTabla varchar(100))
as
begin
declare @Comando as nvarchar(200)
set @Comando = 'select count(*) from' + @nTabla
EXEC sp_executesql @Comando
end


--Procedimiento que permite obtener el listado de filas de la tabla FormularioCIIE, con base a filtro de fecha de ingres y respuesta,
--este procedimiento recibe tales fechas como un parameto del sitema.
go
Create PROCEDURE RangoFechas ( @fecInicial date, @fecFinal date)
as 
begin

select * from	FormularioCIIE where fechaIngreso between @fecInicial
and @fecFinal

end


--Procedimiento almacenado que hace un conteo por genero, este procedimiento es dinamico ya que recibe por 
--parametro el nombre de la tabla a consultar
go
create procedure CantidadGenero (@nTabla varchar(100))
as
begin
declare @Comando as nvarchar(200)
set @Comando= 'select generoSolicitante, COUNT(generoSolicitante) as Cantidad
from ' + @nTabla + ' group by' +' generoSolicitante'
EXEC sp_executesql @Comando
end


--Procedimiento almacenado que hace un conteo por tipo de despacho para el FormularioCIIE
go
create procedure CantidadDespacho 
as 
begin
select tipoDespacho, COUNT(tipoDespacho) as Cantidad
from FormularioCIIE group by tipoDespacho
end


--Procedimiento almacenado que hace un conteo por tipo de consulta para el FormularioCIIE
GO 
CREATE PROCEDURE CantidadTipoConsulta
AS
BEGIN
SELECT tipoConsulta, COUNT(tipoConsulta) AS cantidad
from FormularioCIIE GROUP BY tipoConsulta
end