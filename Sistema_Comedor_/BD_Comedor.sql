--Base de datos --------------------------
---Sistema Comedor------------------------
---Programador: Emerson Humberto Carpaño--
---6/12/22--------------------------------

Create database Sistema_Comedor

Use Sistema_Comedor

--Creamos una base de datos Personal
Create table Personal(
Id Int identity(1,1),
Usuario Varchar(50),
Contraseña Varchar(50),
)

--Creamos un procedimiento almacenado registrarse
Create procedure sp_Registrarse(
@Usuario Varchar(50),
@Contraseña Varchar(50),
@Registrado bit output,
@Mensaje Varchar(100) output
)
as begin
 if(not exists(Select * from Personal Where Usuario = @Usuario))
 begin
   Insert into Personal(Usuario,Contraseña)Values(@Usuario,@Contraseña)
   Set @Registrado = 1
   Set @Mensaje = 'Usuario Registrado correctamente!!'
 end
   else
    begin
	  Set @Registrado = 0
	  Set @Mensaje = 'El usuario ya existe!!'
	end
end
go

Create Procedure sp_Validar(
@Usuario Varchar(50),
@Contraseña Varchar(50)
)
As begin
 if(exists(Select * from Personal Where Usuario = @Usuario  And Contraseña = @Contraseña))
   select Id From Personal Where Usuario = @Usuario And Contraseña = @Contraseña
  else
    select '0'
end
go
--Creamos la tabla desayunos
Create table Desayunos(
Id Int identity(1,1)primary key,
Nombre_Plato Varchar(50),
Precio varchar(50),
)
drop table Desayunos
--Creamos la tabla almuerzo
Create table Almuerzo(
Id Int identity(1,1)primary key,
Nombre_Plato Varchar(50),
Precio varchar(50),
)
--Creamos la tabla Cena
Create table Cena(
Id Int identity(1,1)primary key,
Nombre_Plato Varchar(50),
Precio varchar(50),
)

--Procedimientos almacenados
--Agregar desayunos
Create procedure sp_AgregarDesayuno(
@Nombre_Plato Varchar(50),
@Precio Varchar(50)
)
As begin
 Insert into Desayunos(Nombre_Plato,Precio)
 Values(@Nombre_Plato,@Precio)
End
--Actualizar desayunos
Create procedure sp_ActualizarDesayuno(
@Id Int,
@Nombre_Plato Varchar(50),
@Precio Varchar(50)
)
As begin
Update Desayunos set Nombre_Plato = @Nombre_Plato , Precio = @Precio
Where Id =  @Id
End
--Agregar desayunos
Create procedure sp_EliminarDesayuno(
@Id Int
)
As begin
Delete From Desayunos Where Id = @Id
End

Insert into Desayunos Values('Desayunos tipicos','$5.00')
Insert into Almuerzo Values('Ensalada','$5.00')
Insert into Cena Values('Sandwich','$3.00')

Select * from Desayunos

--Procedimiento almacenado Almuerzo
--Agregar
Create procedure sp_AgregarAlumerzo(
@Nombre_Plato Varchar(50),
@Precio Varchar(50)
)
As begin
 Insert into Almuerzo(Nombre_Plato,Precio)
 Values(@Nombre_Plato,@Precio)
End
--Modificar
Create procedure sp_ActualizarAlmuerzo(
@Id Int,
@Nombre_Plato Varchar(50),
@Precio Varchar(50)
)
As begin
Update Almuerzo set Nombre_Plato = @Nombre_Plato , Precio = @Precio
Where Id =  @Id
End
--Eliminar
Create procedure sp_EliminarAlmuerzo(
@Id Int
)
As begin
Delete From Almuerzo Where Id = @Id
End	
--Procedimiento almacenado de la cena
--Agregar
Create procedure sp_AgregarCena(
@Nombre_Plato Varchar(50),
@Precio Varchar(50)
)
As begin
 Insert into Cena(Nombre_Plato,Precio)
 Values(@Nombre_Plato,@Precio)
End
--Modififcar
Create procedure sp_ActualizarCena(
@Id Int,
@Nombre_Plato Varchar(50),
@Precio Varchar(50)
)
As begin
Update Cena set Nombre_Plato = @Nombre_Plato , Precio = @Precio
Where Id =  @Id
End
--Eliminar
Create procedure sp_EliminarCena(
@Id Int
)
As begin
Delete From Cena Where Id = @Id
End	

drop procedure sp_EliminarCena