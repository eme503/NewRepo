--Base de datos --------------------------
---Sistema Comedor------------------------
---Programador: Emerson Humberto Carpa�o--
---6/12/22--------------------------------

Create database Sistema_Comedor

Use Sistema_Comedor

--Creamos una base de datos Personal
Create table Personal(
Id Int identity(1,1),
Usuario Varchar(50),
Contrase�a Varchar(50),
)

--Creamos un procedimiento almacenado registrarse
Create procedure sp_Registrarse(
@Usuario Varchar(50),
@Contrase�a Varchar(50),
@Registrado bit output,
@Mensaje Varchar(100) output
)
as begin
 if(not exists(Select * from Personal Where Usuario = @Usuario))
 begin
   Insert into Personal(Usuario,Contrase�a)Values(@Usuario,@Contrase�a)
   Set @Registrado = 1
   Set @Mensaje = 'Usuario Registrado correctamente!!'
 end
   else
    begin
	  Set @Registrado = 0
	  Set @Mensaje = 'El usuario ya existe!!'
	end
end

Create Procedure sp_Validar(
@Usuario Varchar(50),
@Contrase�a Varchar(50)
)
As begin
 if(exists(Select * from Personal Where Usuario = @Usuario  And Contrase�a = @Contrase�a))
   select Id From Personal Where Usuario = @Usuario And Contrase�a = @Contrase�a
  else
    select '0'
end