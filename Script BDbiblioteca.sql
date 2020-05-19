create schema db_biblioteca;
use db_biblioteca;

create table informacion_rol(
id_rol varchar(40) not null primary key,
nombre_rol varchar(40) not null,
descripcion varchar(100) not null 
);




create table usuario(
id_usuario varchar(40) not null primary key,
nombre varchar(40) not null,
apellido1 varchar(40) not null,
apellido2 varchar(40) not null,
pass varchar(40) not null,
email varchar(100) not null,
telefono int1 not null,
id_rol varchar(40) not null,
foreign key (id_rol) references informacion_rol(id_rol)
);


create table consulta(
id_consulta varchar(40) not null primary key,
nombre_interesado varchar(100) not null,
telefono int1,
email varchar(100) not null,
asunto varchar(200) not null,
descripcion varchar(500),
informacion_requerida varchar(2000) not null,
plataforma_ingreso varchar(20) 
);

create table info_consulta(
id_consulta varchar(40) not null,
id_usuario varchar(40) not null,
fecha datetime not null,
estado boolean not null,
foreign key (id_usuario) references usuario(id_usuario),
foreign key (id_consulta) references consulta(id_consulta)
);

create table form_cedil(
id_form_cedil varchar(40) not null primary key,
persona_usuaria varchar(40) not null,
procedencia varchar(30) not null,
especificacion varchar(100) not null,
ubicacion varchar(100) not null,
telefono int1,
tipo_solicitud varchar(40) not null,
informacion_requerida varchar(500),
vencimiento datetime not null,
uso varchar(40) not null
);

create table info_form_cedil(
id_form_cedil varchar(40) not null,
id_usuario varchar(40) not null,
fecha datetime not null,
estado boolean not null,
foreign key (id_usuario) references usuario(id_usuario),
foreign key (id_form_cedil) references form_cedil(id_form_cedil)
);

create table form_ciie(
id_form_ciie varchar(40) not null primary key,
nombre_consultante varchar(40) not null,
telefono int1,
oficina varchar(40) not null,
fraccion varchar(10) not null,
especificacion_despacho varchar(30) not null,
tipo_consulta varchar(30) not null,
especificacion_consulta varchar(100),
tema varchar(50) not null,
informacion_requerida varchar(500),
uso_informacion varchar(50) not null
);

create table info_form_ciie(
id_form_ciie varchar(40) not null,
id_usuario varchar(40) not null,
fecha_ingreso datetime not null,
fecha_finalizado datetime not null,
estado boolean not null,
foreign key (id_usuario) references usuario(id_usuario),
foreign key (id_form_ciie) references form_ciie(id_form_ciie)
);

create table prestamo_permanente(
id_prestamo_permanente varchar(40) not null primary key,
nombre_solicitante varchar(40) not null,
oficina varchar(40) not null,
telefono int1,
extension int1,
informacion varchar(200)
);

create table info_prestamo_permanente(
id_prestamo_permanente varchar(40) not null,
id_usuario varchar(40) not null,
fecha_ingreso datetime not null,
estado boolean not null,
foreign key (id_usuario) references usuario(id_usuario),
foreign key (id_prestamo_permanente) references prestamo_permanente(id_prestamo_permanente)
);

create table prestamo_equipo(
id_prestamo_equipo varchar(40) not null primary key,
nombre_solicitante varchar(40) not null,
cedula_solicitante int2 not null,
oficina varchar(40) not null,
tipo_equipo varchar(30) not null,
implementos varchar(40) not null,
especificacion_otros varchar(100),
fecha datetime not null
);


create table info_prestamo_equipo(
id_prestamo_equipo varchar(40) not null,
id_usuario varchar(40) not null,
fecha_finalizacion datetime not null,
estado boolean not null,
foreign key (id_usuario) references usuario(id_usuario),
foreign key (id_prestamo_equipo) references prestamo_equipo(id_prestamo_equipo)
);





