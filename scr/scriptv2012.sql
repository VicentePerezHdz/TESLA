USE [master]
GO
/****** Object:  Database [ProductoTesla]    Script Date: 22/05/2020 8:05:14 ******/
CREATE DATABASE [ProductoTesla]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductoTesla', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER2014\MSSQL\DATA\ProductoTesla.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProductoTesla_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER2014\MSSQL\DATA\ProductoTesla_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductoTesla].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductoTesla] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductoTesla] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductoTesla] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductoTesla] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductoTesla] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductoTesla] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductoTesla] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductoTesla] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductoTesla] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductoTesla] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductoTesla] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductoTesla] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductoTesla] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductoTesla] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductoTesla] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProductoTesla] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductoTesla] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductoTesla] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductoTesla] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductoTesla] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductoTesla] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductoTesla] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductoTesla] SET RECOVERY FULL 
GO
ALTER DATABASE [ProductoTesla] SET  MULTI_USER 
GO
ALTER DATABASE [ProductoTesla] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductoTesla] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductoTesla] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductoTesla] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProductoTesla', N'ON'
GO
USE [ProductoTesla]
GO
/****** Object:  Table [dbo].[Almacen]    Script Date: 22/05/2020 8:05:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Almacen](
	[IdAlmacen] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Fecha_Ingreso] [datetime] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Cantidad] [int] NULL,
	[PrecioUnidad] [float] NULL,
	[Activo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlmacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 22/05/2020 8:05:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id_Personal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[Domicilio] [varchar](50) NULL,
	[Colonia] [varchar](50) NULL,
	[Sexo] [varchar](10) NULL,
	[Telefono] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Salario] [float] NULL,
	[IdAlmacen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Personal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblusuario]    Script Date: 22/05/2020 8:05:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblusuario](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioRolID] [int] NULL,
	[Usuario] [varchar](50) NULL,
	[Contrasenia] [varchar](50) NULL,
	[Correo] [varchar](150) NULL,
	[Activo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblusuariorol]    Script Date: 22/05/2020 8:05:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblusuariorol](
	[UsuarioRolID] [int] IDENTITY(1,1) NOT NULL,
	[NombreModelo] [varchar](50) NULL,
	[Administrable] [int] NULL,
	[FechaRegistro] [date] NULL,
	[Activo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioRolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[tblusuario]  WITH CHECK ADD FOREIGN KEY([UsuarioRolID])
REFERENCES [dbo].[tblusuariorol] ([UsuarioRolID])
GO
USE [master]
GO
ALTER DATABASE [ProductoTesla] SET  READ_WRITE 
GO
