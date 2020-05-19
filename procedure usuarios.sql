CREATE DEFINER=`root`@`localhost` PROCEDURE `_usuarios`(
in _id varchar(40),
in _nombre varchar(40),
in _apellido1 varchar(40),
in _apellido2 varchar(40),
in _pass varchar(40),
in _email varchar(100),
in _telefono int1,
in _id_rol varchar(40),
in acccion varchar(20)
)
Begin 
case acccion 
when 'nuevo' then 
insert into usuario(id_usuario,nombre,apellido1,apellido2,pass,email,telefono,id_rol)
values (_id,_nombre,_apellido1,_apellido2,_pass,_email,_telefono,_id_rol);

when 'editar' then
update usuario set
id_usuario=_id,nombre=_nombre,apellido1=_apellido1,apellido2=_apellido2,pass=_pass,email=_email,telefono=_telefono,id_rol=_id_rol
where id_usuario=_id;

when 'borrar' then
delete from usuario where id_usuario=_id;

when 'seleccion_id' then
select * from usuario where  id_usuario LIKE _id;

when 'seleccion_nombre' then
select * from usuario where  nombre LIKE _nombre;

end case;
END