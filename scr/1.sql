--Necesito un sistema de ventas muy simple con inicio de sesión  y con conexión a base de datos y que también tenga un instalador.
--Con las tablas: tesla(Osea Productos),Empleados,Ventas,usuarios y almacenes.
--En la tabla de Tesla debe haber: Agregar nuevo tesla,modelo,Precio del tesla,Ventas del tesla,y el almacén en donde se encuentra,que también me permita agregar una imagen del producto.
--
--
--En la tabla de Empleados debe haber: Nombre y apellido del empleado,salario,almacén donde trabaja y agregar nuevo empleado.
--En la tabla de Ventas debe haber :Numero de ventas por modelo,Almacén de donde están los modelos y agregar nuevas ventas.
--En la tabla de usuarios debe haber:Registrar nuevo empleado
--En la tabla de almacenes debe haber: nombre del almacén, cantidad de teslas que alberga en el almacén y empleados que trabajan hay.


CREATE TABLE [dbo].[Almacen](
	[IdAlmacen] int  IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Codigo] [varchar](50) NOT NULL,
	[Fecha_Ingreso] [datetime] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](50),
	Cantidad     INT,
	PrecioUnidad float,

)

CREATE TABLE [dbo].[Empleado](
	[Id_Personal] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Nombre] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[Domicilio] [varchar](50)  NULL,
	[Colonia] [varchar](50)  NULL,
	[Sexo] [varchar](10)  NULL,
	[Telefono] [varchar](50)  NULL,
	[Email] [varchar](50)  NULL,
	[Salario][FLOAT],
	FOREIGN KEY (IdAlmacen) REFERENCES Almacen(IdAlmacen)
 ) 
 
 CREATE TABLE [dbo].[tblusuario](
  [UsuarioID]	 int(11) IDENTITY(1,1) NOT NULL PRIMARY KEY ,
  [UsuarioRolID] 	int(11)  NULL,
  [Usuario] 		varchar(50)  NULL,
  [Contrasenia]		 varchar(50)  NULL,
  [Correo] 				varchar(150)  NULL,
  [Activo] 			int(11)  NULL,
)

CREATE  TABLE [dbo]. [tblusuariorol] (
  [UsuarioRolID] int(11)  IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [NombreModelo] varchar(50)  NULL,
  [Administrable] int(11)  NULL,
  [FechaRegistro] date  NULL,
  [Activo] int(11)  NULL,

) 

