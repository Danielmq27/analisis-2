CREATE DEFINER=`root`@`localhost` PROCEDURE `_roles`(
in _id varchar(40),
in _nombre_rol  varchar(40),
in acccion varchar(20)
)
BEGIN

case accion 

when 'seleccion_id' then
select * from informacion_rol where  id_rol LIKE _id;

when 'seleccion_nombre' then
select * from informacion_rol where  nombre_rol LIKE _nombre_rol;
end case;
END