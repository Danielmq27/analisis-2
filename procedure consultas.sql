CREATE DEFINER=`root`@`localhost` PROCEDURE `form_consultas`(
in _id_consulta varchar(40),
in _nombre_interesado varchar(100),
in _telefono int1,
in _email varchar(100),
in _asunto varchar(200),
in _descripcion varchar(500),
in _informacion_requerida varchar(2000),
in _plataforma_ingreso varchar(20),
in _id_usuario varchar(40),
in _fecha datetime,
in _estado boolean,
in acccion varchar(20)
)
BEGIN

case accion

when 'nuevo' then
insert into consulta (id_consulta,nombre_interesado,telefono,email,asunto,descripcion,informacion_requerida,plataforma_ingreso)
values (_id_consulta,_nombre_interesado,_telefono,_email,_asunto,_descripcion,_informacion_requerida,_plataforma_ingreso);

insert into info_consulta (id_consulta,id_usuario,fecha,estado) 
values (_id_consulta,_id_usuario,_fecha,_estado);

when 'editar' then
update consulta set
id_consulta=_id_consulta,nombre_interesado=_nombre_interesado,telefono=_telefono,email=_email,asunto=_asunto,descripcion=_descripcion,informacion_requerida=_informacion_requerida,plataforma_ingreso=_plataforma_ingreso
where id_consulta=_id_consulta;

update info_consulta set
id_consulta=_id_consulta,id_usuario=_id_usuario,fecha=_fecha,estado=_estado
where id_consulta=_id_consulta;

when 'borrar' then
delete from info_consulta where id_consulta=_id_consulta;
delete from consulta where id_consulta=_id_consulta;

when 'seleccion_id' then
select * from consulta where  id_consulta like _id_consulta;
select * from info_consulta where  id_consulta like _id_consulta;

end case;
END