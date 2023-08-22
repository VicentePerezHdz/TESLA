"insert into  (Nombre,Apellidos,Edad,Domicilio,Colonia,Sexo,Telefono,Email,Salario,IdAlmacen) Empleado VALUES (@Nombre,@Apellidos,@Edad,@Domicilio,@Colonia,@Sexo,@Telefono,@Email,@Salario,@IdAlmacen)"


		"insert into  (Codigo ,Fecha_Ingreso ,Nombre ,Descripcion,Cantidad,PrecioUnidad)Almacen
		Values(@Codigo ,@Fecha_Ingreso ,@Nombre ,@Descripcion,@Cantidad,@PrecioUnidad)"
	   
	   
	   SELECT  *FROM  Almacen 
	   SELECT  *FROM  Empleado
	   SELECT  *FROM  tblusuario
	 
	   	"insert into  (UsuarioRolID,Usuario,Contrasenia ,Correo,Activo) tblusuarioVALUES(@UsuarioRolID,@Usuario,@Contrasenia ,@Correo,@Activo)"