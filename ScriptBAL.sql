USE [master]
GO
/****** Object:  Database [ARE_Biblioteca_Legislativa]    Script Date: 16/11/2020 22:58:04 ******/
CREATE DATABASE [ARE_Biblioteca_Legislativa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ARE_Biblioteca_Legislativa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ARE_Biblioteca_Legislativa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ARE_Biblioteca_Legislativa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ARE_Biblioteca_Legislativa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ARE_Biblioteca_Legislativa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET ARITHABORT OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET RECOVERY FULL 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET  MULTI_USER 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET QUERY_STORE = OFF
GO
USE [ARE_Biblioteca_Legislativa]
GO
/****** Object:  Table [dbo].[AuditoriaConsulta]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaConsulta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoConsulta] [varchar](40) NULL,
	[nombreSolicitante] [varchar](40) NULL,
	[apellidoSolicitante1] [varchar](20) NULL,
	[apellidoSolicitante2] [varchar](20) NULL,
	[telefono] [int] NULL,
	[email] [varchar](100) NULL,
	[asunto] [varchar](50) NULL,
	[descripcion] [varchar](500) NULL,
	[respuesta] [varchar](max) NULL,
	[metodoIngreso] [varchar](20) NULL,
	[generoSolicitante] [varchar](10) NULL,
	[estado] [varchar](20) NULL,
	[accion] [varchar](30) NULL,
	[fechaIngreso] [date] NULL,
	[fechaRespuesta] [date] NULL,
	[fecha] [date] NULL,
	[usuarioBD] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaFormularioCEDIL]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaFormularioCEDIL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoCEDIL] [varchar](40) NULL,
	[nombreSolicitante] [varchar](40) NULL,
	[apellidoSolicitante1] [varchar](20) NULL,
	[apellidoSolicitante2] [varchar](20) NULL,
	[telefono] [int] NULL,
	[procedencia] [varchar](40) NULL,
	[ubicacion] [varchar](40) NULL,
	[tipoSolicitud] [varchar](30) NULL,
	[informacionRequerida] [varchar](500) NOT NULL,
	[usoInformacion] [varchar](100) NOT NULL,
	[generoSolicitante] [varchar](10) NOT NULL,
	[fechaIngreso] [date] NOT NULL,
	[fechaRespuesta] [date] NOT NULL,
	[estado] [varchar](20) NOT NULL,
	[accion] [varchar](30) NULL,
	[fecha] [date] NULL,
	[usuarioBD] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaFormularioCIIE]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaFormularioCIIE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoCIIE] [varchar](40) NULL,
	[nombreSolicitante] [varchar](40) NULL,
	[apellidoSolicitante1] [varchar](20) NULL,
	[apellidoSolicitante2] [varchar](20) NULL,
	[telefono] [int] NULL,
	[email] [varchar](100) NULL,
	[tipoDespacho] [varchar](40) NULL,
	[fraccion] [varchar](10) NULL,
	[especificacionDespacho] [varchar](50) NULL,
	[tipoConsulta] [varchar](20) NULL,
	[especificacionConsulta] [varchar](50) NULL,
	[tema] [varchar](50) NULL,
	[informacionRequerida] [varchar](max) NULL,
	[usoInformacion] [varchar](40) NULL,
	[generoSolicitante] [varchar](10) NULL,
	[estado] [varchar](20) NULL,
	[accion] [varchar](30) NULL,
	[fechaInicio] [date] NULL,
	[fechaFinal] [date] NULL,
	[fecha] [date] NULL,
	[usuarioBD] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaPrestamoAudiovisual]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaPrestamoAudiovisual](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoPrestamoAudiovisual] [varchar](40) NULL,
	[nombreSolicitante] [varchar](40) NULL,
	[apellidoSolicitante1] [varchar](20) NULL,
	[apellidoSolicitante2] [varchar](20) NULL,
	[telefono] [int] NULL,
	[departamento] [varchar](40) NULL,
	[nombreActividad] [varchar](50) NULL,
	[categoria] [varchar](40) NULL,
	[especificacionCategoria] [varchar](100) NULL,
	[ubicacion] [varchar](100) NULL,
	[horaInicio] [datetime] NULL,
	[horaFin] [datetime] NULL,
	[descripcion] [varchar](500) NULL,
	[equipoRequerido] [varchar](40) NULL,
	[aforo] [int] NULL,
	[generoSolicitante] [varchar](10) NULL,
	[accion] [varchar](30) NULL,
	[fecha] [date] NULL,
	[usuarioBD] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaPrestamoEquipo]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaPrestamoEquipo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoPrestamoEquipo] [varchar](40) NULL,
	[nombreSolicitante] [varchar](40) NULL,
	[apellidoSolicitante1] [varchar](20) NULL,
	[apellidoSolicitante2] [varchar](20) NULL,
	[cedulaSolicitante] [varchar](20) NULL,
	[departamento] [varchar](40) NULL,
	[tipoEquipo] [varchar](20) NULL,
	[implementos] [varchar](40) NULL,
	[especificacionImplementos] [varchar](50) NULL,
	[generoSolicictante] [varchar](10) NULL,
	[estado] [varchar](20) NULL,
	[accion] [varchar](30) NULL,
	[fechaInicio] [date] NULL,
	[fechaFinal] [date] NULL,
	[fecha] [date] NULL,
	[usuarioBD] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaPrestamoPermanente]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaPrestamoPermanente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoPrestamoPermanente] [varchar](40) NULL,
	[nombreSolicitante] [varchar](40) NULL,
	[apellidoSolicitante1] [varchar](20) NULL,
	[apellidoSolicitante2] [varchar](20) NULL,
	[despacho] [varchar](40) NULL,
	[telefono] [int] NULL,
	[extension] [varchar](10) NULL,
	[informacionAdicional] [varchar](max) NULL,
	[generoSolicictante] [varchar](10) NULL,
	[fechaPrestamo] [date] NULL,
	[estado] [varchar](20) NULL,
	[accion] [varchar](30) NULL,
	[fecha] [date] NULL,
	[usuarioBD] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Controlador] [nvarchar](100) NULL,
	[Metodo] [nvarchar](100) NULL,
	[Mensaje] [nvarchar](max) NULL,
	[Usuario] [varchar](50) NULL,
	[Fecha] [date] NULL,
	[Tipo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consulta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoConsulta] [varchar](40) NOT NULL,
	[nombreSolicitante] [varchar](40) NOT NULL,
	[apellidoSolicitante1] [varchar](20) NOT NULL,
	[apellidoSolicitante2] [varchar](20) NOT NULL,
	[telefono] [int] NOT NULL,
	[email] [varchar](100) NOT NULL,
	[asunto] [varchar](50) NOT NULL,
	[descripcion] [varchar](500) NULL,
	[respuesta] [varchar](max) NOT NULL,
	[metodoIngreso] [varchar](20) NOT NULL,
	[generoSolicitante] [varchar](10) NOT NULL,
	[fechaIngreso] [date] NOT NULL,
	[fechaRespuesta] [date] NOT NULL,
	[estado] [varchar](20) NOT NULL,
	[documento] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[codigoConsulta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormularioCEDIL]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormularioCEDIL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoCEDIL] [varchar](40) NOT NULL,
	[nombreSolicitante] [varchar](40) NOT NULL,
	[apellidoSolicitante1] [varchar](20) NOT NULL,
	[apellidoSolicitante2] [varchar](20) NOT NULL,
	[telefono] [int] NOT NULL,
	[procedencia] [varchar](40) NULL,
	[ubicacion] [varchar](40) NULL,
	[tipoSolicitud] [varchar](30) NULL,
	[informacionRequerida] [varchar](500) NOT NULL,
	[usoInformacion] [varchar](100) NOT NULL,
	[generoSolicitante] [varchar](10) NOT NULL,
	[fechaIngreso] [date] NOT NULL,
	[fechaRespuesta] [date] NOT NULL,
	[estado] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[codigoCEDIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormularioCIIE]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormularioCIIE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoCIIE] [varchar](40) NOT NULL,
	[nombreSolicitante] [varchar](40) NOT NULL,
	[apellidoSolicitante1] [varchar](20) NOT NULL,
	[apellidoSolicitante2] [varchar](20) NOT NULL,
	[telefono] [int] NOT NULL,
	[email] [varchar](100) NULL,
	[tipoDespacho] [varchar](40) NOT NULL,
	[fraccion] [varchar](10) NOT NULL,
	[especificacionDespacho] [varchar](50) NULL,
	[tipoConsulta] [varchar](20) NOT NULL,
	[especificacionConsulta] [varchar](50) NULL,
	[tema] [varchar](50) NOT NULL,
	[informacionRequerida] [varchar](max) NOT NULL,
	[usoInformacion] [varchar](40) NOT NULL,
	[generoSolicitante] [varchar](10) NOT NULL,
	[fechaIngreso] [date] NOT NULL,
	[fechaRespuesta] [date] NOT NULL,
	[estado] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[codigoCIIE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fraccion]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fraccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InformacionRol]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformacionRol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrestamoAudiovisual]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrestamoAudiovisual](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoPrestamoAudiovisual] [varchar](40) NOT NULL,
	[nombreSolicitante] [varchar](40) NOT NULL,
	[apellidoSolicitante1] [varchar](20) NOT NULL,
	[apellidoSolicitante2] [varchar](20) NOT NULL,
	[telefono] [int] NOT NULL,
	[departamento] [varchar](40) NULL,
	[nombreActividad] [varchar](50) NOT NULL,
	[categoria] [varchar](40) NOT NULL,
	[especificacionCategoria] [varchar](100) NULL,
	[ubicacion] [varchar](100) NULL,
	[horaInicio] [datetime] NOT NULL,
	[horaFin] [datetime] NOT NULL,
	[descripcion] [varchar](500) NOT NULL,
	[equipoRequerido] [varchar](40) NOT NULL,
	[aforo] [int] NOT NULL,
	[generoSolicitante] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[codigoPrestamoAudiovisual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrestamoEquipo]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrestamoEquipo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoPrestamoEquipo] [varchar](40) NOT NULL,
	[nombreSolicitante] [varchar](40) NOT NULL,
	[apellidoSolicitante1] [varchar](20) NOT NULL,
	[apellidoSolicitante2] [varchar](20) NOT NULL,
	[cedulaSolicitante] [varchar](20) NOT NULL,
	[departamento] [varchar](40) NOT NULL,
	[tipoEquipo] [varchar](20) NOT NULL,
	[implementos] [varchar](40) NULL,
	[especificacionImplementos] [varchar](50) NULL,
	[generoSolicictante] [varchar](10) NOT NULL,
	[fechaIngreso] [date] NOT NULL,
	[fechaRespuesta] [date] NOT NULL,
	[estado] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[codigoPrestamoEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrestamoPermanente]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrestamoPermanente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigoPrestamoPermanente] [varchar](40) NOT NULL,
	[nombreSolicitante] [varchar](40) NOT NULL,
	[apellidoSolicitante1] [varchar](20) NOT NULL,
	[apellidoSolicitante2] [varchar](20) NOT NULL,
	[despacho] [varchar](40) NOT NULL,
	[telefono] [int] NOT NULL,
	[extension] [varchar](10) NULL,
	[informacionAdicional] [varchar](max) NULL,
	[generoSolicictante] [varchar](10) NOT NULL,
	[fechaPrestamo] [date] NOT NULL,
	[estado] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[codigoPrestamoPermanente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefConsecutivoCEDIL]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefConsecutivoCEDIL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Consecutivo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefConsecutivoCIIE]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefConsecutivoCIIE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Consecutivo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefConsecutivoConsulta]    Script Date: 16/11/2020 22:58:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefConsecutivoConsulta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Consecutivo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefConsecutivoPA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefConsecutivoPA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Consecutivo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefConsecutivoPE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefConsecutivoPE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Consecutivo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefConsecutivoPP]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefConsecutivoPP](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Consecutivo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Referencia]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Referencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[genero] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](20) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[clave] [varchar](40) NOT NULL,
	[IdRol] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Consulta]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Consulta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cedulaUsuario] [varchar](20) NOT NULL,
	[codigoConsulta] [varchar](40) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_FormularioCEDIL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_FormularioCEDIL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cedulaUsuario] [varchar](20) NOT NULL,
	[codigoCEDIL] [varchar](40) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_FormularioCIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_FormularioCIIE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cedulaUsuario] [varchar](20) NOT NULL,
	[codigoCIIE] [varchar](40) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_PrestamoAudiovisual]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_PrestamoAudiovisual](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cedulaUsuario] [varchar](20) NOT NULL,
	[codigoPrestamoAudiovisual] [varchar](40) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_PrestamoEquipo]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_PrestamoEquipo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cedulaUsuario] [varchar](20) NOT NULL,
	[codigoPrestamoEquipo] [varchar](40) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_PrestamoPermanente]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_PrestamoPermanente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cedulaUsuario] [varchar](20) NOT NULL,
	[codigoPrestamoPermanente] [varchar](40) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[InformacionRol] ([Id])
GO
ALTER TABLE [dbo].[Usuario_Consulta]  WITH CHECK ADD FOREIGN KEY([cedulaUsuario])
REFERENCES [dbo].[Usuario] ([cedula])
GO
ALTER TABLE [dbo].[Usuario_Consulta]  WITH CHECK ADD FOREIGN KEY([codigoConsulta])
REFERENCES [dbo].[Consulta] ([codigoConsulta])
GO
ALTER TABLE [dbo].[Usuario_FormularioCEDIL]  WITH CHECK ADD FOREIGN KEY([cedulaUsuario])
REFERENCES [dbo].[Usuario] ([cedula])
GO
ALTER TABLE [dbo].[Usuario_FormularioCEDIL]  WITH CHECK ADD FOREIGN KEY([codigoCEDIL])
REFERENCES [dbo].[FormularioCEDIL] ([codigoCEDIL])
GO
ALTER TABLE [dbo].[Usuario_FormularioCIIE]  WITH CHECK ADD FOREIGN KEY([cedulaUsuario])
REFERENCES [dbo].[Usuario] ([cedula])
GO
ALTER TABLE [dbo].[Usuario_FormularioCIIE]  WITH CHECK ADD FOREIGN KEY([codigoCIIE])
REFERENCES [dbo].[FormularioCIIE] ([codigoCIIE])
GO
ALTER TABLE [dbo].[Usuario_PrestamoAudiovisual]  WITH CHECK ADD FOREIGN KEY([cedulaUsuario])
REFERENCES [dbo].[Usuario] ([cedula])
GO
ALTER TABLE [dbo].[Usuario_PrestamoAudiovisual]  WITH CHECK ADD FOREIGN KEY([codigoPrestamoAudiovisual])
REFERENCES [dbo].[PrestamoAudiovisual] ([codigoPrestamoAudiovisual])
GO
ALTER TABLE [dbo].[Usuario_PrestamoEquipo]  WITH CHECK ADD FOREIGN KEY([cedulaUsuario])
REFERENCES [dbo].[Usuario] ([cedula])
GO
ALTER TABLE [dbo].[Usuario_PrestamoEquipo]  WITH CHECK ADD FOREIGN KEY([codigoPrestamoEquipo])
REFERENCES [dbo].[PrestamoEquipo] ([codigoPrestamoEquipo])
GO
ALTER TABLE [dbo].[Usuario_PrestamoPermanente]  WITH CHECK ADD FOREIGN KEY([cedulaUsuario])
REFERENCES [dbo].[Usuario] ([cedula])
GO
ALTER TABLE [dbo].[Usuario_PrestamoPermanente]  WITH CHECK ADD FOREIGN KEY([codigoPrestamoPermanente])
REFERENCES [dbo].[PrestamoPermanente] ([codigoPrestamoPermanente])
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_AUDIOVISUAL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTUALIZAR_AUDIOVISUAL]
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
where Id=@Id;

update Usuario_PrestamoAudiovisual
SET cedulaUsuario=@cedulaUsuario, codigoPrestamoAudiovisual=@codigoAudiovisual, 
nombre=@nombre,apellido1=@apellido1, apellido2=@apellido2
where Id=@Id;
END

---BORRAR AUDIOVISUAL
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_CEDIL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[ACTUALIZAR_CEDIL]

 (@id int, @CodigoCEDIL VARCHAR(40), @nombreSolicitante varchar(40), @apellidoSolicitante1 VARCHAR(20), @apellidoSolicitante2 VARCHAR(20), @telefono INTEGER, @procedencia VARCHAR(40), @ubicacion varchar(40),

 @tipoSolicitud varchar(30), @informacionRequerida VARCHAR(500), @usoInformacion VARCHAR(100), @generoSolicitante VARCHAR(10), @fechaIngreso DATE, @fechaRespuesta DATE,

 @estado VARCHAR(20), @cedulaUsuario varchar(20), @nombre VARCHAR(40), @apellido1 VARCHAR(20), @apellido2 VARCHAR(20))

 AS

 BEGIN

 UPDATE FormularioCEDIL

 SET codigoCEDIL=@CodigoCEDIL, nombreSolicitante=@nombreSolicitante, apellidoSolicitante1=@apellidoSolicitante1, apellidoSolicitante2=@apellidoSolicitante2,

 telefono=@telefono, tipoSolicitud=@tipoSolicitud, informacionRequerida=@informacionRequerida, usoInformacion=@usoInformacion, generoSolicitante=@generoSolicitante,

 fechaIngreso=@fechaIngreso, fechaRespuesta=@fechaRespuesta, estado=@estado

 where Id=@id;



UPDATE Usuario_FormularioCEDIL

 SET cedulaUsuario=@cedulaUsuario, codigoCEDIL=@codigoCEDIL, nombre=@nombre, apellido1=@apellido1, apellido2=@apellido2

 WHERE Id=@id;



END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ACTUALIZAR_CIIE]
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
WHERE Id=@id;

UPDATE Usuario_FormularioCIIE
SET cedulaUsuario=@cedulaUsuario, codigoCIIE=@codigoCIIE, nombre=@nombre, apellido1=@apellido1, apellido2=@apellido2
WHERE Id=@id;
end



--INSERTAR PRESTAMO EQUIPO
/*este procedimiento permite insertar un usuario a la tabla PE, declarando variables por parametro para obtener los datos desde la aplicacion. 
Se trabaja con dos variables temporales @maxcode, que se usa para almacenar el valor maximo de la columna ID, con este se hace la validacion de si existe un registro o no
en el IF, en la variable @codigoPE se almacena un valor construido por CAST del @maxCode, que servira para identificar las filas de las tablas de manera unica sin hacer referencia
a la llave autoincremental*/
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_CONSULTA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ACTUALIZAR_CONSULTA]
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
where Id=@Id;

UPDATE Usuario_Consulta
SET cedulaUsuario=@cedulaUsuario, codigoConsulta=@codigoConsulta, 
nombre=@nombre,apellido1=@apellido1, apellido2=@apellido2
where Id=@Id;
END


---BORRAR CONSULTA

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_PrestamoEquipo]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ACTUALIZAR_PrestamoEquipo]
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
WHERE Id=@Id;

UPDATE Usuario_PrestamoEquipo
SET cedulaUsuario=@cedulaUsuario, codigoPrestamoEquipo=@codigoPrestamoEquipo, nombre=@nombre,
apellido1=@apellido1, apellido2=@apellido2
WHERE Id=@Id;
end

--BORRAR PRESTAMO EQUIPO
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_PrestamoPermanente]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ACTUALIZAR_PrestamoPermanente]
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
where Id=@id;

UPDATE Usuario_PrestamoPermanente
SET cedulaUsuario=@cedulaUsuario, codigoPrestamoPermanente=@codigoPrestamoPermanente, 
nombre=@nombre,apellido1=@apellido1, apellido2=@apellido2
where Id=@id;
END


--BORRAR PRESTAMO PERMANENETE
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_USUARIO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTUALIZAR_USUARIO]
(@ID INT, @CEDULA varchar(20), @NOMBRE varchar(40), @APELLIDO1 varchar(20), @APELLIDO2 varchar(20),
@EMAIL varchar(100), @CLAVE varchar(40), @IDROL INT)
AS
BEGIN
UPDATE Usuario
SET cedula=@CEDULA, nombre=@NOMBRE, apellido1=@APELLIDO1, apellido2=@APELLIDO2, email = @EMAIL, clave = @CLAVE, IdRol=@IDROL
where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_AUDIOVISUAL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BORRAR_AUDIOVISUAL]
(@id int)
as
DECLARE @TEXTO VARCHAR(50)
BEGIN
if (select count(*) from PrestamoAudiovisual where Id = @id)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion' 
ELSE
DELETE FROM Usuario_PrestamoAudiovisual WHERE Id = @id;
DELETE FROM PrestamoAudiovisual WHERE Id = @id;
END










GO
/****** Object:  StoredProcedure [dbo].[BORRAR_CEDIL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[BORRAR_CEDIL]

 (@Id int)

 AS

 declare @TEXTO varchar(50)

 BEGIN

 if (select count(*) from FormularioCEDIL where Id = @Id) = 0

 select @TEXTO = 'No existente un formulario con la misma especificacion'

 ELSE

 delete from Usuario_FormularioCEDIL where @Id=Id;

 delete from FormularioCEDIL where @Id=Id;

 end





 ---UPDATE CEDIL



GO
/****** Object:  StoredProcedure [dbo].[BORRAR_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BORRAR_CIIE]
(@id int)
AS
declare @TEXTO varchar(50)
BEGIN
if (select count(*) from FormularioCIIE where id = @id)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion'
ELSE
delete from Usuario_FormularioCIIE where @id=Id;
delete from FormularioCIIE where @id=Id;
end


--UPDATE CIIE
/* se setea un update en base al campo unico codigo*/
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_CONSULTA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BORRAR_CONSULTA]
(@id int)
as
DECLARE @TEXTO VARCHAR(50)
BEGIN
if (select count(*) from Consulta where Id = @id)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion' 
else
delete from Usuario_Consulta where Id = @id;
delete from Consulta where Id = @id;
END


--INSERTAR AUDIOVISUAL
/*este procedimiento permite insertar un usuario a la tabla PA, declarando variables por parametro para obtener los datos desde la aplicacion. 
Se trabaja con dos variables temporales @maxcode, que se usa para almacenar el valor maximo de la columna ID, con este se hace la validacion de si existe un registro o no
en el IF, en la variable @codigoPA se almacena un valor construido por CAST del @maxCode, que servira para identificar las filas de las tablas de manera unica sin hacer referencia
a la llave autoincremental*/
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_FRACCION]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BORRAR_FRACCION](@ID int)
AS
begin
DELETE Fraccion WHERE Id = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_PrestamoEquipo]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BORRAR_PrestamoEquipo]
(@id int)
AS
DECLARE @TEXTO VARCHAR(50)
BEGIN
if (select count(*) from PrestamoEquipo where Id = @id)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion' 
else
DELETE FROM Usuario_PrestamoEquipo where Id = @id; 
DELETE FROM PrestamoEquipo where Id = @id; 
END


---INSERTAR PRESTAMO PERMANENTE
/*este procedimiento permite insertar un usuario a la tabla PP, declarando variables por parametro para obtener los datos desde la aplicacion. 
Se trabaja con dos variables temporales @maxcode, que se usa para almacenar el valor maximo de la columna ID, con este se hace la validacion de si existe un registro o no
en el IF, en la variable @codigoPP se almacena un valor construido por CAST del @maxCode, que servira para identificar las filas de las tablas de manera unica sin hacer referencia
a la llave autoincremental*/
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_PrestamoPermanenete]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BORRAR_PrestamoPermanenete]
(@id int)
AS
DECLARE @TEXTO VARCHAR(50)
BEGIN
if (select count(*) from PrestamoPermanente where id = @id)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion' 
else
DELETE FROM Usuario_PrestamoPermanente where Id = @id; 
DELETE FROM PrestamoPermanente where Id = @id; 
END



--- INSERTAR CONSULTA
/*este procedimiento permite insertar un usuario a la tabla Consulta, declarando variables por parametro para obtener los datos desde la aplicacion. 
Se trabaja con dos variables temporales @maxcode, que se usa para almacenar el valor maximo de la columna ID, con este se hace la validacion de si existe un registro o no
en el IF, en la variable @codigoConsulta se almacena un valor construido por CAST del @maxCode, que servira para identificar las filas de las tablas de manera unica sin hacer referencia
a la llave autoincremental*/
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_TABLAS]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 

CREATE PROCEDURE [dbo].[BORRAR_TABLAS]
(    
    @psTabla VARCHAR(100),
    @psTabla1 VARCHAR(100),
    @psTabla2 VARCHAR(100)
)
AS 
BEGIN
    
    DECLARE @Tabla    AS NVARCHAR(2000)
    DECLARE @Indice AS NVARCHAR(2000)

 

    DECLARE @Tabla1    AS NVARCHAR(2000)
    DECLARE @Indice1 AS NVARCHAR(2000)

 

    DECLARE @Tabla2    AS NVARCHAR(2000)
    DECLARE @Indice2 AS NVARCHAR(2000)

 

    SET @Tabla = 'DELETE FROM ' +  @psTabla
    EXEC sp_executesql @Tabla

 

    SET @Indice = 'DBCC CHECKIDENT(' + CHAR(39) + @psTabla + CHAR(39) + ', RESEED, 0)'
    EXEC sp_executesql @Indice

 


    SET @Tabla1 = 'DELETE FROM ' +  @psTabla1
    EXEC sp_executesql @Tabla1

 

    SET @Indice1 = 'DBCC CHECKIDENT(' + CHAR(39) + @psTabla1 + CHAR(39) + ', RESEED, 0)'
    EXEC sp_executesql @Indice1

 


    SET @Tabla2 = 'DELETE FROM ' +  @psTabla2
    EXEC sp_executesql @Tabla2

 

    SET @Indice2 = 'DBCC CHECKIDENT(' + CHAR(39) + @psTabla2 + CHAR(39) + ', RESEED, 0)'
    EXEC sp_executesql @Indice2
    
END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_USUARIO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BORRAR_USUARIO](@ID int)
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
/****** Object:  StoredProcedure [dbo].[CANTIDAD_DEPARTAMENTO_FROM_TO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_DEPARTAMENTO_FROM_TO] (@fecFrom date, @fecTo date)
as
begin
select departamento AS Departamento, COUNT(departamento) as Cantidad, count(departamento)*100/ (select count(*) from PrestamoAudiovisual where horaInicio >= @fecFrom and  horaFin <= @fecTo) as Porcentaje
from PrestamoAudiovisual
where horaInicio >= @fecFrom and  horaFin <= @fecTo
group by departamento
end



--
--
--
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_DEPARTAMENTO_FROM_TO_PE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_DEPARTAMENTO_FROM_TO_PE] (@fecFrom date, @fecTo date)
as
begin
select departamento AS Departamento, COUNT(departamento) as Cantidad, count(departamento)*100/ (select count(*) from PrestamoEquipo where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo) as Porcentaje
from PrestamoEquipo
where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo
group by departamento
end



--
--
--
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_DEPARTAMENTO_INGRESO_PA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_DEPARTAMENTO_INGRESO_PA] (@fecFrom date, @fecTo date)
as 
begin
select departamento, COUNT(departamento) as Cantidad, count(departamento)*100/ (select count(*) from PrestamoAudiovisual where horaInicio between @fecFrom and @fecTo) as porcentaje
from PrestamoAudiovisual 
where horaInicio between @fecFrom and @fecTo
group by departamento
end


/* Proceimiento que devuelve la cantida de reportes por tipo de usuario y su porcentaje en un rango de fechas de respuesta al sistema, las cuales son pasadas como parametros desde el sistema
para el formulario*/
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_DEPARTAMENTO_INGRESO_PE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_DEPARTAMENTO_INGRESO_PE] (@fecFrom date, @fecTo date)
as 
begin
select departamento, COUNT(departamento) as Cantidad, count(departamento)*100/ (select count(*) from PrestamoEquipo where fechaIngreso between @fecFrom and @fecTo) as porcentaje
from PrestamoEquipo 
where fechaIngreso between @fecFrom and @fecTo
group by departamento
end


/* Proceimiento que devuelve la cantida de reportes por tipo de usuario y su porcentaje en un rango de fechas de respuesta al sistema, las cuales son pasadas como parametros desde el sistema
para el formulario*/
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_DEPARTAMENTO_Salida_PA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_DEPARTAMENTO_Salida_PA] (@fecFrom date, @fecTo date)
as 
begin
select departamento, COUNT(departamento) as Cantidad, count(departamento)*100/ (select count(*) from PrestamoAudiovisual where horaFin between @fecFrom and @fecTo) as porcentaje
from PrestamoAudiovisual 
where horaFin between @fecFrom and @fecTo
group by departamento
end



/* Procedimiento que devuelve la cantidad de registros de la tabla en un rango de fechas (Ingreso y respuesta) las cuales son pasadas como parametro 
desde el sistema, orenado por tipo de usuario, cantidad y su porcentaje relativo sobre el total de lineas que hay en la tabla*/
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_DEPARTAMENTO_SALIDA_PE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_DEPARTAMENTO_SALIDA_PE] (@fecFrom date, @fecTo date)
as 
begin
select departamento, COUNT(departamento) as Cantidad, count(departamento)*100/ (select count(*) from PrestamoEquipo where fechaRespuesta between @fecFrom and @fecTo) as porcentaje
from PrestamoEquipo 
where fechaRespuesta between @fecFrom and @fecTo
group by departamento
end



/* Procedimiento que devuelve la cantidad de registros de la tabla en un rango de fechas (Ingreso y respuesta) las cuales son pasadas como parametro 
desde el sistema, orenado por tipo de usuario, cantidad y su porcentaje relativo sobre el total de lineas que hay en la tabla*/
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_DESPACHO_INGRESO_PP]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_DESPACHO_INGRESO_PP] (@fecFrom date, @fecTo date)
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
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_FIN_PA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_GENERO_FIN_PA] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from PrestamoAudiovisual where horaFin between @fecFrom and @fecTo) as porcentaje
from PrestamoAudiovisual 
where horaFin between @fecFrom and @fecTo
group by generoSolicitante
END




--
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_FROM_TO_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_GENERO_FROM_TO_CIIE] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from FormularioCIIE where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo) as porcentaje
from FormularioCIIE 
where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo
group by generoSolicitante
END
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_FROM_TO_CONSULTA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_GENERO_FROM_TO_CONSULTA] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from Consulta where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo) as porcentaje
from Consulta 
where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo
group by generoSolicitante
END
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_FROM_TO_PA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_GENERO_FROM_TO_PA] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from PrestamoAudiovisual where horaInicio >= @fecFrom and  horaFin <= @fecTo) as porcentaje
from PrestamoAudiovisual 
where horaInicio >= @fecFrom and  horaFin <= @fecTo
group by generoSolicitante
END





--Reportes PE	
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_FROM_TO_PE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_GENERO_FROM_TO_PE] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicictante, COUNT(generoSolicictante) as Cantidad, count(generoSolicictante)*100/ (select count(*) from PrestamoEquipo where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo) as porcentaje
from PrestamoEquipo 
where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo
group by generoSolicictante
END
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_INGRESO_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_GENERO_INGRESO_CIIE] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from FormularioCIIE where fechaIngreso between @fecFrom and @fecTo) as porcentaje
from FormularioCIIE 
where fechaIngreso between @fecFrom and @fecTo
group by generoSolicitante
END

--
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_INGRESO_CONSULTA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_GENERO_INGRESO_CONSULTA] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from Consulta where fechaIngreso between @fecFrom and @fecTo) as porcentaje
from Consulta 
where fechaIngreso between @fecFrom and @fecTo
group by generoSolicitante
END

--
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_INGRESO_PA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_GENERO_INGRESO_PA] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from PrestamoAudiovisual where horaInicio between @fecFrom and @fecTo) as porcentaje
from PrestamoAudiovisual 
where horaInicio between @fecFrom and @fecTo
group by generoSolicitante
END

--
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_INGRESO_PE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_GENERO_INGRESO_PE] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicictante, COUNT(generoSolicictante) as Cantidad, count(generoSolicictante)*100/ (select count(*) from PrestamoEquipo where fechaIngreso between @fecFrom and @fecTo) as porcentaje
from PrestamoEquipo 
where fechaIngreso between @fecFrom and @fecTo
group by generoSolicictante
END

--
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_INGRESO_PP]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_GENERO_INGRESO_PP] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicictante, COUNT(generoSolicictante) as Cantidad, count(generoSolicictante)*100/ (select count(*) from PrestamoPermanente where fechaPrestamo between @fecFrom and @fecTo) as porcentaje
from PrestamoPermanente 
where fechaPrestamo between @fecFrom and @fecTo
group by generoSolicictante
END



--Reportes PA
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_RESPUESTA_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_GENERO_RESPUESTA_CIIE] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from FormularioCIIE where fechaRespuesta between @fecFrom and @fecTo) as porcentaje
from FormularioCIIE 
where fechaRespuesta between @fecFrom and @fecTo
group by generoSolicitante
END



--
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_RESPUESTA_CONSULTA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_GENERO_RESPUESTA_CONSULTA] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicitante, COUNT(generoSolicitante) as Cantidad, count(generoSolicitante)*100/ (select count(*) from Consulta where fechaRespuesta between @fecFrom and @fecTo) as porcentaje
from Consulta 
where fechaRespuesta between @fecFrom and @fecTo
group by generoSolicitante
END



--
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_GENERO_SALIDA_PE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_GENERO_SALIDA_PE] (@fecFrom date, @fecTo date)
as 
begin
select generoSolicictante, COUNT(generoSolicictante) as Cantidad, count(generoSolicictante)*100/ (select count(*) from PrestamoEquipo where fechaRespuesta between @fecFrom and @fecTo) as porcentaje
from PrestamoEquipo 
where fechaRespuesta between @fecFrom and @fecTo
group by generoSolicictante
END





--
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_METODO_INGRESO_CONSULTA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_METODO_INGRESO_CONSULTA] (@fecFrom date, @fecTo date)
as 
begin
select metodoIngreso, COUNT(metodoIngreso) as Cantidad, count(metodoIngreso)*100/ (select count(*) from Consulta where fechaIngreso between @fecFrom and @fecTo) as porcentaje
from Consulta 
where fechaIngreso between @fecFrom and @fecTo
group by metodoIngreso
end


/* Proceimiento que devuelve la cantida de reportes por tipo de usuario y su porcentaje en un rango de fechas de respuesta al sistema, las cuales son pasadas como parametros desde el sistema
para el formulario*/
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_METODO_INGRESO_CONSULTA_FROM_TO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_METODO_INGRESO_CONSULTA_FROM_TO] (@fecFrom date, @fecTo date)
as
begin
select metodoIngreso AS MetodoIngreso, COUNT(metodoIngreso) as Cantidad, count(metodoIngreso)*100/ (select count(*) from Consulta where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo) as Porcentaje
from Consulta
where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo
group by metodoIngreso
end
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_METODO_INGRESO_CONSULTA_RESPUESTA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CANTIDAD_METODO_INGRESO_CONSULTA_RESPUESTA] (@fecFrom date, @fecTo date)
as 
begin
select metodoIngreso, COUNT(metodoIngreso) as Cantidad, count(metodoIngreso)*100/ (select count(*) from Consulta where fechaRespuesta between @fecFrom and @fecTo) as porcentaje
from Consulta 
where fechaRespuesta between @fecFrom and @fecTo
group by metodoIngreso
end



/* Procedimiento que devuelve la cantidad de registros de la tabla en un rango de fechas (Ingreso y respuesta) las cuales son pasadas como parametro 
desde el sistema, orenado por tipo de usuario, cantidad y su porcentaje relativo sobre el total de lineas que hay en la tabla*/
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_RANGO_FECHAS_INGRESO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_RANGO_FECHAS_INGRESO] (@fecFrom date, @fecTo date)
as 
begin
SELECT COUNT(*) 
FROM FormularioCIIE
WHERE fechaIngreso between @fecFrom and @fecTo
end

 

--

GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_RANGO_FECHAS_RESPUESTA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_RANGO_FECHAS_RESPUESTA] (@fecFrom date, @fecTo date)
as 
begin
SELECT COUNT(*) 
FROM FormularioCIIE
WHERE fechaRespuesta between @fecFrom and @fecTo
end

 

--

GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_TIPO_USUARIO_FROM_TO_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_TIPO_USUARIO_FROM_TO_CIIE](@fecFrom date, @fecTo date)
as
begin
select tipoDespacho AS Tipo_Usuario, COUNT(tipoDespacho) as Cantidad, count(tipoDespacho)*100/ (select count(*) from FormularioCIIE) as Porcentaje
from FormularioCIIE
where fechaIngreso >= @fecFrom and  fechaRespuesta <= @fecTo
group by tipoDespacho
end
GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_TIPO_USUARIO_INGRESO_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_TIPO_USUARIO_INGRESO_CIIE] (@fecFrom date, @fecTo date)
as 
begin
select tipoDespacho, COUNT(tipoDespacho) as Cantidad, count(tipoDespacho)*100/ (select count(*) from FormularioCIIE) as Porcentaje
from FormularioCIIE 
where fechaIngreso between @fecFrom and @fecTo
group by tipoDespacho
end

 


--

GO
/****** Object:  StoredProcedure [dbo].[CANTIDAD_TIPO_USUARIO_RESPUESTA_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CANTIDAD_TIPO_USUARIO_RESPUESTA_CIIE] (@fecFrom date, @fecTo date)
as 
begin
select tipoDespacho, COUNT(tipoDespacho) as Cantidad, count(tipoDespacho)*100/ (select count(*) from FormularioCIIE) as Porcentaje
from FormularioCIIE 
where fechaRespuesta between @fecFrom and @fecTo
group by tipoDespacho
end



GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_AUDIOVISUAL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_AUDIOVISUAL]
(@nombreSolicitante varchar(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@telefono INTEGER ,@departamento VARCHAR(40),
@nombreActividad VARCHAR(50) ,@categoria VARCHAR(40) ,@especificacionCategoria VARCHAR(100),@ubicacion VARCHAR(100),@horaInicio DATETIME ,
@horaFin DATETIME ,@descripcion VARCHAR(500) ,@equipoRequerido VARCHAR(40) ,@aforo INTEGER ,@generoSolicitante VARCHAR(10) ,
@cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20)
)
AS
DECLARE
@codigoAudiovisual varchar(40),
@maxCode int;
set @maxCode = (select MAX (Consecutivo) from RefConsecutivoPA);
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
/****** Object:  StoredProcedure [dbo].[INSERTAR_BITACORA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[INSERTAR_BITACORA](
@CONTROLADOR nvarchar(100) , @METODO nvarchar(100), @MENSAJE nvarchar(Max), @USUARIO varchar (50), @TIPO int
)
AS 
BEGIN
INSERT INTO Bitacora (Controlador, Metodo, Mensaje, Usuario, Tipo, Fecha)
values
(@CONTROLADOR, @METODO, @MENSAJE, @USUARIO, @TIPO, getdate())
END
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_CEDIL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[INSERTAR_CEDIL]

 (@nombreSolicitante varchar(40), @apellidoSolicitante1 VARCHAR(20), @apellidoSolicitante2 VARCHAR(20), @telefono INTEGER, @procedencia VARCHAR(40), @ubicacion varchar(40),

 @tipoSolicitud varchar(30), @informacionRequerida VARCHAR(500), @usoInformacion VARCHAR(100), @generoSolicitante VARCHAR(10), @fechaIngreso DATE, @fechaRespuesta DATE,

 @estado VARCHAR(20), @cedulaUsuario varchar(20), @nombre VARCHAR(40), @apellido1 VARCHAR(20), @apellido2 VARCHAR(20))

 AS

 DECLARE

 @codigoCEDIL varchar(40),

 @maxCode int;

 set @maxCode = (select MAX (Consecutivo) from [dbo].[RefConsecutivoCEDIL]);

 if( @maxCode IS NULL)

 SET @codigoCEDIL= 'CEDIL-1'

 ELSE

 SET @codigoCEDIL = ('CEDIL-' + cast(@maxCode+1 as varchar));

 BEGIN

 INSERT INTO FormularioCEDIL (codigoCEDIL, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2,

 telefono, procedencia, ubicacion, tipoSolicitud, informacionRequerida, usoInformacion, generoSolicitante,

 fechaIngreso, fechaRespuesta, estado)

 VALUES

 (@codigoCEDIL, @nombreSolicitante, @apellidoSolicitante1, @apellidoSolicitante2 , @telefono, @procedencia , @ubicacion ,

 @tipoSolicitud, @informacionRequerida, @usoInformacion, @generoSolicitante, @fechaIngreso, @fechaRespuesta,

 @estado);



INSERT INTO [dbo].[Usuario_FormularioCEDIL] ([cedulaUsuario], [codigoCEDIL], nombre, apellido1, apellido2)

 values

 (@cedulaUsuario, @codigoCEDIL, @nombre, @apellido1, @apellido2)

 END





 ---SELECT TODO FROM CEDIL

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_CIIE] 
(@nombreSolicitante varchar(40), @apellidoSolicitante1 VARCHAR(20), @apellidoSolicitante2 VARCHAR(20), @telefono INTEGER,
@email VARCHAR(100), @tipoDespacho VARCHAR(40), @fraccion VARCHAR(10), @especificacionDespacho VARCHAR(50),
@tipoConsulta VARCHAR(20), @especificacionConsulta VARCHAR(50), @tema VARCHAR(50), @informacionRequerida VARCHAR(max), 
@usoInformacion VARCHAR(40), @generoSolicitante VARCHAR(10), @fechaIngreso DATE, @fechaRespuesta DATE, @estado VARCHAR(20),
@cedulaUsuario varchar(20), @nombre VARCHAR(40), @apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
AS
DECLARE
@codigoCIIE varchar(40),
@maxCode int;
set @maxCode = (select MAX (Consecutivo) from [dbo].[RefConsecutivoCIIE]);
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
GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_CONSULTA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INSERTAR_CONSULTA]
(@nombreSolicitante varchar(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@telefono INTEGER ,
@email VARCHAR(100) ,@asunto VARCHAR(50) ,@descripcion VARCHAR(500),@respuesta VARCHAR(max) ,@metodoIngreso VARCHAR(20) ,@generoSolicitante VARCHAR(10) ,
@fechaIngreso DATE ,@fechaRespuesta DATE ,@estado VARCHAR(20),@cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
AS
DECLARE
@codigoConsulta varchar(40),
@maxCode int;
set @maxCode = (select MAX (Consecutivo) from RefConsecutivoConsulta);
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
/****** Object:  StoredProcedure [dbo].[INSERTAR_FRACCION]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[INSERTAR_FRACCION]
(@NOMBRE VARCHAR(40), @DESCRIPCION VARCHAR(100))
AS
BEGIN
INSERT INTO Fraccion (nombre, descripcion) values 
(@NOMBRE, @DESCRIPCION);
END

 



GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PrestamoEquipo]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_PrestamoEquipo]
(
@nombreSolicitante VARCHAR(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@cedulaSolicitante VARCHAR(20) ,@departamento VARCHAR(40) ,
@tipoEquipo VARCHAR(20) ,@implementos VARCHAR(40),@especificacionImplementos VARCHAR(50),@generoSolicictante VARCHAR(10) ,
@fechaIngreso DATE ,@fechaRespuesta DATE ,@estado VARCHAR(20), @cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
as
declare
@codigoPrestamoEquipo varchar(40),
@maxCode int;
set @maxCode = (select MAX (Consecutivo) from RefConsecutivoPE);
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
/****** Object:  StoredProcedure [dbo].[INSERTAR_PrestamoPermanente]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_PrestamoPermanente]
(@nombreSolicitante VARCHAR(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@despacho VARCHAR(40) ,@telefono INTEGER ,
@extension VARCHAR(10),@informacionAdicional VARCHAR(max),@generoSolicictante VARCHAR(10) ,@fechaPrestamo DATE ,@estado VARCHAR(20),@cedulaUsuario varchar(20), @nombre VARCHAR(40),
@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
AS
DECLARE
@codigoPrestamoPermanente varchar(40),
@maxCode int;
set @maxCode = (select MAX (Consecutivo) from RefConsecutivoPP);
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
/****** Object:  StoredProcedure [dbo].[INSERTAR_USUARIO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_USUARIO] 
(@CEDULA varchar(20), @NOMBRE varchar(40), @APELLIDO1 varchar(20), @APELLIDO2 varchar(20),
@EMAIL varchar(100), @CLAVE varchar(40), @IDROL INT)
as
BEGIN
INSERT INTO Usuario (cedula, nombre, apellido1, apellido2, email, clave, IdRol) values
(@CEDULA, @NOMBRE, @APELLIDO1, @APELLIDO2, @EMAIL, @CLAVE, @IDROL);
END
GO
/****** Object:  StoredProcedure [dbo].[LOGIN_USUARIO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--PROCEDIMIENTO PARA LOGIN
/* Este procedure utiliza dos variable temporales @claveEncriptada y @claveDesencriptada,  en la primera se recupera el valor encriptado, y en la segunda usando la llave se desencripta el valor*/
CREATE PROC [dbo].[LOGIN_USUARIO]
@Correo as varchar(100),
@Clave as varchar(50)
AS
BEGIN
	SELECT * from Usuario where email=@Correo and clave=@Clave
END



---seleccionar todos los usuario
GO
/****** Object:  StoredProcedure [dbo].[RESTAURAR_AUDIOVISUAL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[RESTAURAR_AUDIOVISUAL]
 (@codigoAudiovisual varchar(40), @nombreSolicitante varchar(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@telefono INTEGER ,@departamento VARCHAR(40),
 @nombreActividad VARCHAR(50) ,@categoria VARCHAR(40) ,@especificacionCategoria VARCHAR(100),@ubicacion VARCHAR(100),@horaInicio DATETIME ,
 @horaFin DATETIME ,@descripcion VARCHAR(500) ,@equipoRequerido VARCHAR(40) ,@aforo INTEGER ,@generoSolicitante VARCHAR(10) ,
 @cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
 AS
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



DELETE FROM AuditoriaPrestamoAudiovisual WHERE @codigoAudiovisual=codigoPrestamoAudiovisual;



end
GO
/****** Object:  StoredProcedure [dbo].[RESTAURAR_CEDIL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RESTAURAR_CEDIL]
(@codigoCEDIL varchar(40), @nombreSolicitante varchar(40), @apellidoSolicitante1 VARCHAR(20), @apellidoSolicitante2 VARCHAR(20), @telefono INTEGER, @procedencia VARCHAR(40), @ubicacion varchar(40), 
@tipoSolicitud varchar(30), @informacionRequerida VARCHAR(500), @usoInformacion VARCHAR(100), @generoSolicitante VARCHAR(10), @fechaIngreso DATE, @fechaRespuesta DATE, 
@estado VARCHAR(20), @cedulaUsuario varchar(20), @nombre VARCHAR(40), @apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
AS
BEGIN
INSERT INTO FormularioCEDIL (codigoCEDIL, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2, 
telefono, procedencia, ubicacion, tipoSolicitud, informacionRequerida, usoInformacion, generoSolicitante, 
fechaIngreso, fechaRespuesta, estado)
VALUES
(@codigoCEDIL, @nombreSolicitante, @apellidoSolicitante1, @apellidoSolicitante2 , @telefono, @procedencia , @ubicacion , 
@tipoSolicitud, @informacionRequerida, @usoInformacion, @generoSolicitante, @fechaIngreso, @fechaRespuesta, 
@estado);

INSERT INTO [dbo].[Usuario_FormularioCEDIL] ([cedulaUsuario], [codigoCEDIL], nombre, apellido1, apellido2)
values
(@cedulaUsuario, @codigoCEDIL, @nombre, @apellido1, @apellido2);

DELETE FROM AuditoriaFormularioCEDIL WHERE @codigoCEDIL= codigoCEDIL;
END
GO
/****** Object:  StoredProcedure [dbo].[RESTAURAR_CONSULTA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[RESTAURAR_CONSULTA]
 (@codigoConsulta varchar(40), @nombreSolicitante varchar(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@telefono INTEGER ,
 @email VARCHAR(100) ,@asunto VARCHAR(50) ,@descripcion VARCHAR(500),@respuesta VARCHAR(max) ,@metodoIngreso VARCHAR(20) ,@generoSolicitante VARCHAR(10) ,
 @fechaIngreso DATE ,@fechaRespuesta DATE ,@estado VARCHAR(20),@cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
 AS
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
 delete from AuditoriaConsulta where @codigoConsulta=codigoConsulta;
 END
GO
/****** Object:  StoredProcedure [dbo].[RESTAURAR_INSERTAR_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[RESTAURAR_INSERTAR_CIIE]
 (@codigoCIIE varchar(40), @nombreSolicitante varchar(40), @apellidoSolicitante1 VARCHAR(20), @apellidoSolicitante2 VARCHAR(20), @telefono INTEGER,
 @email VARCHAR(100), @tipoDespacho VARCHAR(40), @fraccion VARCHAR(10), @especificacionDespacho VARCHAR(50),
 @tipoConsulta VARCHAR(20), @especificacionConsulta VARCHAR(50), @tema VARCHAR(50), @informacionRequerida VARCHAR(max),
 @usoInformacion VARCHAR(40), @generoSolicitante VARCHAR(10), @fechaIngreso DATE, @fechaRespuesta DATE, @estado VARCHAR(20),
 @cedulaUsuario varchar(20), @nombre VARCHAR(40), @apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
 AS
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



delete from AuditoriaFormularioCIIE where @codigoCIIE = codigoCIIE
END
GO
/****** Object:  StoredProcedure [dbo].[RESTAURAR_PrestamoEquipo]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[RESTAURAR_PrestamoEquipo]
(@codigoPrestamoEquipo varchar(40), @nombreSolicitante VARCHAR(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@cedulaSolicitante VARCHAR(20) ,@departamento VARCHAR(40) ,
@tipoEquipo VARCHAR(20) ,@implementos VARCHAR(40),@especificacionImplementos VARCHAR(50),@generoSolicictante VARCHAR(10) ,
@fechaIngreso DATE ,@fechaRespuesta DATE ,@estado VARCHAR(20), @cedulaUsuario varchar(20), @nombre VARCHAR(40),@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
as
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

DELETE FROM AuditoriaPrestamoEquipo where @codigoPrestamoEquipo =  codigoPrestamoEquipo;
END
GO
/****** Object:  StoredProcedure [dbo].[RESTAURAR_PrestamoPermanente]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RESTAURAR_PrestamoPermanente]
(@codigoPrestamoPermanente varchar(40), @nombreSolicitante VARCHAR(40) ,@apellidoSolicitante1 VARCHAR(20) ,@apellidoSolicitante2 VARCHAR(20) ,@despacho VARCHAR(40) ,@telefono INTEGER ,
@extension VARCHAR(10),@informacionAdicional VARCHAR(max),@generoSolicictante VARCHAR(10) ,@fechaPrestamo DATE ,@estado VARCHAR(20),@cedulaUsuario varchar(20), @nombre VARCHAR(40),
@apellido1 VARCHAR(20), @apellido2 VARCHAR(20))
AS
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

DELETE FROM AuditoriaPrestamoPermanente where @codigoPrestamoPermanente = codigoPrestamoPermanente;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDIOVISUAL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECCIONAR_AUDIOVISUAL]
(@id int)
AS
BEGIN
SELECT
a.Id, a.codigoPrestamoAudiovisual, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2,
telefono, departamento, nombreActividad, categoria, especificacionCategoria, ubicacion, horaInicio,
horaFin, descripcion, equipoRequerido, aforo, generoSolicitante, cedulaUsuario,  
nombre, apellido1, apellido2
FROM PrestamoAudiovisual a, Usuario_PrestamoAudiovisual b
where a.Id=@id AND @id=b.Id
end

---UPDATE AUDIOVISUAL
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDIOVISUAL_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECCIONAR_AUDIOVISUAL_TODO]
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
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_AUDIOVISUAL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_AUDIOVISUAL]
(@ID int)
AS
BEGIN
select * from AuditoriaPrestamoAudiovisual where Id=@ID;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_AUDIOVISUAL_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_AUDIOVISUAL_TODO]
AS
BEGIN
SELECT * FROM AuditoriaPrestamoAudiovisual;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_CEDIL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_CEDIL]
(@ID int)
AS
BEGIN
select * from AuditoriaFormularioCEDIL where Id=@ID;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_CEDIL_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_CEDIL_TODO]
AS
BEGIN
SELECT * FROM AuditoriaFormularioCEDIL;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_CIIE]
(@ID int)
AS
BEGIN
select * from AuditoriaFormularioCIIE where Id=@ID;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_CIIE_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_CIIE_TODO]
AS
BEGIN
SELECT * FROM AuditoriaFormularioCIIE;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_Consulta]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_Consulta]
(@ID int)
AS
BEGIN
select * from AuditoriaConsulta where Id=@ID;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_Consulta_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_Consulta_TODO]
AS
BEGIN
SELECT * FROM AuditoriaConsulta;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_PrestamoEquipo]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_PrestamoEquipo]
(@ID int)
AS
BEGIN
select * from AuditoriaPrestamoEquipo where Id=@ID;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_PrestamoEquipo_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_PrestamoEquipo_TODO]
AS
BEGIN
SELECT * FROM AuditoriaPrestamoEquipo;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_PrestamoPermanente]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_PrestamoPermanente]
(@ID int)
AS
BEGIN
select * from AuditoriaPrestamoPermanente where Id=@ID;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_AUDITORIA_PrestamoPermanente_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_AUDITORIA_PrestamoPermanente_TODO]
AS
BEGIN
SELECT * FROM AuditoriaPrestamoPermanente;
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_BITACORAS]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_BITACORAS]
AS
BEGIN
select * from Bitacora
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_CEDIL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROC [dbo].[SELECCIONAR_CEDIL]

 (@ID INT)

 as

 declare @TEXTO varchar(50)

 BEGIN

 if (select count(*) from FormularioCEDIL where Id = @ID) = 0

 select @TEXTO = 'No existente un formulario con la misma especificacion'

 else

 SELECT a.Id, a.codigoCEDIL, a.nombreSolicitante, a.apellidoSolicitante1, a.apellidoSolicitante2,

 a.telefono, a.procedencia, a.ubicacion, a.tipoSolicitud, a.informacionRequerida, a.usoInformacion, a.generoSolicitante,

 a.fechaIngreso, a.fechaRespuesta, a.estado, b.cedulaUsuario, b.codigoCEDIL, b.nombre, b.apellido1, b.apellido2

 FROM Usuario_FormularioCEDIL b, FormularioCEDIL a

 where @ID=a.Id and @ID=b.Id

 END



-- DELETE FROM CEDIL

GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_CEDIL_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROC [dbo].[SELECCIONAR_CEDIL_TODO]

 AS

 BEGIN

 SELECT a.Id, a.codigoCEDIL, a.nombreSolicitante, a.apellidoSolicitante1, a.apellidoSolicitante2,

 a.telefono, a.procedencia, a.ubicacion, a.tipoSolicitud, a.informacionRequerida, a.usoInformacion, a.generoSolicitante,

 a.fechaIngreso, a.fechaRespuesta, a.estado, b.cedulaUsuario, b.codigoCEDIL, b.nombre, b.apellido1, b.apellido2

 FROM Usuario_FormularioCEDIL b, FormularioCEDIL a

 where a.codigoCEDIL = b.codigoCEDIL

 END





 ---SELECT FROM CEDIL

GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_CIIE]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_CIIE]
(@id int)
as
 declare @TEXTO varchar(50) 
BEGIN
if (select count(*) from FormularioCIIE where Id = @id)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion'
else 
SELECT a.Id, a.codigoCIIE, a.nombreSolicitante, a.apellidoSolicitante1, a.apellidoSolicitante2, 
a.telefono, a.email, a.tipoDespacho, a.fraccion, a.especificacionDespacho, a.tipoConsulta, 
a.especificacionConsulta, a.tema, a.informacionRequerida, a.usoInformacion, a.generoSolicitante, 
a.fechaIngreso, a.fechaRespuesta, a.estado, b.cedulaUsuario, b.codigoCIIE, b.nombre, b.apellido1, b.apellido2
	FROM Usuario_FormularioCIIE b, FormularioCIIE a
	where  @id=a.Id and @id=b.Id
END
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_CIIE_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_CIIE_TODO]
AS
BEGIN
	SELECT a.Id, a.codigoCIIE, a.nombreSolicitante, a.apellidoSolicitante1, a.apellidoSolicitante2, 
a.telefono, a.email, a.tipoDespacho, a.fraccion, a.especificacionDespacho, a.tipoConsulta, 
a.especificacionConsulta, a.tema, a.informacionRequerida, a.usoInformacion, a.generoSolicitante, 
a.fechaIngreso, a.fechaRespuesta, a.estado, b.cedulaUsuario, b.codigoCIIE, b.nombre, b.apellido1, b.apellido2
	FROM Usuario_FormularioCIIE b, FormularioCIIE a
	where a.Id = b.Id
END

--SELECT FROM CIIE
/* select en base al campo unico @codigoCIIE*/
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_CONSULTA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_CONSULTA]
(@id int)
AS 
declare  @TEXTO varchar(50)
BEGIN
if (select count(*) from Consulta where Id = @id)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion'
else 
SELECT
a.Id, a.codigoConsulta, nombreSolicitante, apellidoSolicitante1, apellidoSolicitante2,
telefono, email, asunto, descripcion, respuesta, metodoIngreso, generoSolicitante, fechaIngreso,
fechaRespuesta, estado, cedulaUsuario, nombre, apellido1, apellido2
FROM Consulta a, Usuario_Consulta b
where b.Id=@id and @id=a.Id
END

--UPDATE CONSULTA
/* se setea un update en base al campo unico codigo*/
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_CONSULTA_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_CONSULTA_TODO]
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
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_FRACCION]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_FRACCION]
(@ID int)
as
BEGIN
select * from Fraccion where Id=@ID;
END

 


GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_FRACCION_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_FRACCION_TODO]
AS
BEGIN
    SELECT * FROM Fraccion;
END

 



GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_PrestamoEquipo]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_PrestamoEquipo]
(@id int)
as
declare  @TEXTO varchar(50) 
BEGIN
if (select count(*) from PrestamoEquipo where Id = @id)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion'
else 
SELECT  a.Id, a.codigoPrestamoEquipo,a.nombreSolicitante,a.apellidoSolicitante1,a.apellidoSolicitante2,a.cedulaSolicitante,
a.departamento,a.tipoEquipo,a.implementos,a.especificacionImplementos,a.generoSolicictante,a.fechaIngreso,
a.fechaRespuesta,a.estado,b.cedulaUsuario, b.nombre, b.apellido1, b.apellido2
FROM Usuario_PrestamoEquipo b, PrestamoEquipo a
WHERE a.Id=@id and b.Id=@id 
end

---ACTULIZAR PRESTAMO EQUIPO
/* se setea un update en base al campo unico codigo*/
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_PrestamoEquipo_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_PrestamoEquipo_TODO]
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
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_PrestamoPermanente]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECCIONAR_PrestamoPermanente]
(@id int)
AS 
declare  @TEXTO varchar(50) 
BEGIN
if (select count(*) from PrestamoPermanente where id = @id)  = 0
select @TEXTO = 'No existente un formulario con la misma especificacion'
else 
Select
a.Id,a.codigoPrestamoPermanente,a.nombreSolicitante,a.apellidoSolicitante1,a.apellidoSolicitante2,
a.despacho,a.telefono,a.extension,a.informacionAdicional,a.generoSolicictante,a.fechaPrestamo,
a.estado,b.cedulaUsuario, b.nombre, b.apellido1, b.apellido2
FROM Usuario_PrestamoPermanente b, PrestamoPermanente a
WHERE b.Id=@id and @id=a.Id
END

--ACTUALIZAR PRESTAMO PERMANENTE
/* se setea un update en base al campo unico codigo*/
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_PrestamoPermanente_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECCIONAR_PrestamoPermanente_TODO]
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
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_REFERENCIA]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[SELECCIONAR_REFERENCIA]
(@ID int)
as 
BEGIN
select * from Referencia where Id=@ID;
END

--TRIGGERS
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_REFERENCIA_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SELECCIONAR_REFERENCIA_TODO]
AS 
BEGIN
SELECT * FROM Referencia;
end


---SELECCIONAR EN REFERENCIA
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_ROL]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_ROL]
(@Id int)
AS
begin
SELECT * from InformacionRol WHERE Id = @Id
END



--PROCEDIMIENTO A LA HORA DE INSERTAR
/*este procedimiento permite insertar un usuario a la tabla usuario, declarando variables por parametro para obtener los datos desde la aplicacion. 
Se us una variable temporal que permite imprimir un mensaje de validacion para la existencia del usuario. Esta validacion se hace por medio del IF, haciendo conteo de la
fila cedula para buscar si hay algo igual  */
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_ROL_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_ROL_TODO]
AS
BEGIN
	SELECT * FROM InformacionRol;
END

GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_USUARIO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_USUARIO] 
(@ID int)
as 
BEGIN
select * from Usuario where Id=@ID;
END



---UPDATE USER
/* se setea un update en base al campo unico cedula*/
GO
/****** Object:  StoredProcedure [dbo].[SELECCIONAR_USUARIO_TODO]    Script Date: 16/11/2020 22:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SELECCIONAR_USUARIO_TODO]
AS
BEGIN
	SELECT * FROM Usuario;
END


---Seleccionar un solo user
/* select en base al campo unico id*/

GO
USE [master]
GO
ALTER DATABASE [ARE_Biblioteca_Legislativa] SET  READ_WRITE 
GO
