create PROCEDURE [dbo].[ActividadActualizar]
@idActividad int,
@Descripcion nvarchar(30),
@Tarifa float,
@HorarioInicio time,
@HorarioFin time,
@Dia nvarchar(10),
@idSala int

AS

UPDATE ACTIVIDAD
SET 
idActividad=@idActividad ,
Descripcion=@Descripcion ,
Tarifa=@Tarifa,
HorarioInicio=@HorarioInicio,
HorarioFin=@HorarioFin,
Dia=@Dia 


UPDATE [dbo].[ACTIVIDADSALA]
SET idActividad=@idActividad
WHERE idSala=@idSala 

RETURN SCOPE_IDENTITY()

CREATE PROCEDURE [dbo].[ActividadAlta]
@idActividad int,
@Descripcion nvarchar(30),
@Tarifa float,
@HorarioInicio time,
@HorarioFin time,
@Dia nvarchar(10),
@idSala int,
@idEmpleado int

AS

INSERT INTO ACTIVIDAD
(
idActividad ,
Descripcion ,
Tarifa,
HorarioInicio,
HorarioFin,
Dia 
)
VALUES
(
@idActividad ,
@Descripcion ,
@Tarifa,
@HorarioInicio,
@HorarioFin,
@Dia 
);


INSERT INTO [dbo].[ACTIVIDADSALA]
(
idActividad ,
idSala
)
VALUES
(
@idActividad ,
@idSala
);

INSERT INTO [dbo].[EMPLEADOACTIVIDAD]
(
idActividad ,
idEmpleado 
)
VALUES
(
@idActividad ,
@idEmpleado 
);

RETURN SCOPE_IDENTITY()

create PROCEDURE [dbo].[ActividadBaja]
@idActividad int

AS


declare @idSala int ;
set @idSala = (select idSala from ACTIVIDADSALA where idActividad= @idActividad);


DELETE 
FROM [dbo].[ACTIVIDAD]
WHERE idActividad=@idActividad;


DELETE 
FROM [dbo].[ACTIVIDADSALA]
WHERE idSala=@idSala ;


RETURN SCOPE_IDENTITY()

CREATE PROCEDURE [dbo].[EmpleadoActualizarTodo]
@Dni nvarchar(30),
@Nombre nvarchar(30),
@Apellido nvarchar(30),
@Telefono nvarchar(50),
@Email nvarchar(100),
@Password nvarchar(100),
@FechaNacimiento date,
@Sexo nchar(1),
@TipoPersona nchar(1),
--@FechaRegistracion datetime,
--@FechaActualizacion datetime,
@TipoEmpleado int,
@fechaDeIngreso date,
@fechaDeEgreso date

AS

DECLARE @id nvarchar(100);

SET @id = (SELECT idPersona FROM PERSONA WHERE Email=@Email);

UPDATE PERSONA
SET 
	Dni=@Dni,
	Telefono=@Telefono,
	Nombre=@Nombre,
	Apellido=@Apellido,
	Email=@Email,
	Password=@Password,
	FechaNacimiento=@FechaNacimiento,
	Sexo=@Sexo,
	TipoPersona=@TipoPersona,
	--FechaRegistracion=@FechaRegistracion,
	FechaActualizacion=CURRENT_TIMESTAMP
WHERE PERSONA.idPersona= @id

UPDATE EMPLEADO
SET 
	TipoEmpleado=@TipoEmpleado,
	fechaDeIngreso=@fechaDeIngreso,
	fechaDeEgreso=@fechaDeEgreso
WHERE EMPLEADO.idPersona= @id

RETURN SCOPE_IDENTITY()

--
create PROCEDURE [dbo].[EmpleadoBuscarPorId]

@idPersona int


AS

	SELECT * 
	FROM PERSONA
	inner join EMPLEADO on PERSONA.idPersona=EMPLEADO.idPersona
	where PERSONA.idPersona=@idPersona

CREATE PROCEDURE [dbo].[EmpleadoInsert]
@Dni nvarchar(30),
@Nombre nvarchar(30),
@Apellido nvarchar(30),
@Telefono nvarchar(50),
@Email nvarchar(100),
@Password nvarchar(100),
@FechaNacimiento date,
@Sexo nchar(1),
@TipoPersona nchar(1),
@FechaRegistracion datetime,
--@FechaActualizacion datetime,
@TipoEmpleado int,
@fechaDeIngreso date,
@fechaDeEgreso date

AS

INSERT INTO PERSONA
(
Dni,
Telefono,
Nombre,
Apellido,
Email,
Password,
FechaNacimiento,
Sexo,
TipoPersona,
FechaRegistracion,
FechaActualizacion
)
VALUES
(
@Dni,
@Telefono,
@Nombre,
@Apellido,
@Email,
@Password,
@FechaNacimiento,
@Sexo,
@TipoPersona,
@FechaRegistracion,
NULL--@FechaActualizacion
);

DECLARE @id nvarchar(100);

SET @id = (SELECT idPersona FROM PERSONA WHERE Email=@Email);

INSERT INTO EMPLEADO
(
TipoEmpleado,
fechaDeIngreso,
fechaDeEgreso
)
VALUES
(
@TipoEmpleado,
@fechaDeIngreso,
@fechaDeEgreso
);
 

RETURN SCOPE_IDENTITY()

create PROCEDURE [dbo].[EmpleadoTraerTodos]

AS

	SELECT * 
	FROM PERSONA
	inner join EMPLEADO on PERSONA.idPersona=EMPLEADO.idPersona

create PROCEDURE [dbo].[PersonaActualizarFoto]

@idPersona smallint,
@foto nvarchar(100)

AS

UPDATE	PERSONA
SET		foto = @foto
WHERE	idPersona = @idPersona

CREATE PROCEDURE [dbo].[PersonaBuscarPorEmailPassword]

@Email nvarchar(100),
@Password nvarchar(100)

AS

SELECT	*
FROM	PERSONA
WHERE	Email = @Email AND
		Password = @Password

create PROCEDURE [dbo].[PersonaExisteEmail]

@Email nvarchar(100)

AS

IF EXISTS (SELECT * FROM PERSONA WHERE Email = @Email)
	SELECT 1

ELSE
	SELECT 0

create PROCEDURE [dbo].[PersonaTraerTodos]

AS

	SELECT * 
	FROM PERSONA

CREATE PROCEDURE [dbo].[ProfesorActualizarTodo]
@Dni nvarchar(30),
@Nombre nvarchar(30),
@Apellido nvarchar(30),
@Telefono nvarchar(50),
@Email nvarchar(100),
@Password nvarchar(100),
@FechaNacimiento date,
@Sexo nchar(1),
@TipoPersona nchar(1),
@FechaRegistracion datetime,
@FechaActualizacion datetime,
@TipoEmpleado nchar(10),
@fechaDeIngreso date,
@fechaDeEgreso date


AS

DECLARE @id nvarchar(100);

SET @id = (SELECT idPersona FROM PERSONA WHERE Email=@Email);

UPDATE PERSONA
SET Dni=@Dni,
Telefono=@Telefono,
Nombre=@Nombre,
Apellido=@Apellido,
Email=@Email,
Password=@Password,
FechaNacimiento=@FechaNacimiento,
Sexo=@Sexo,
TipoPersona=@TipoPersona,
FechaRegistracion=@FechaRegistracion,
FechaActualizacion=@FechaActualizacion
WHERE PERSONA.idPersona= @id

UPDATE EMPLEADO
SET 

TipoEmpleado=@TipoEmpleado,
fechaDeIngreso=@fechaDeIngreso,
fechaDeEgreso=@fechaDeEgreso

WHERE EMPLEADO.idPersona= @id


RETURN SCOPE_IDENTITY()

CREATE PROCEDURE [dbo].[ProfesorInsert]
@Dni nvarchar(30),
@Nombre nvarchar(30),
@Apellido nvarchar(30),
@Telefono nvarchar(50),
@Email nvarchar(100),
@Password nvarchar(100),
@FechaNacimiento date,
@Sexo nchar(1),
@TipoPersona nchar(1),
@FechaRegistracion datetime,
@FechaActualizacion datetime,
@TipoEmpleado nchar(10),
@fechaDeIngreso date,
@fechaDeEgreso date

AS

INSERT INTO PERSONA
(
Dni,
Nombre,
Apellido,
Telefono,
Email,
Password,
FechaNacimiento,
Sexo,
TipoPersona,
FechaRegistracion,
FechaActualizacion
)
VALUES
(
@Dni,
@Nombre,
@Apellido,
@Telefono,
@Email,
@Password,
@FechaNacimiento,
@Sexo,
@TipoPersona,
@FechaRegistracion,
@FechaActualizacion
);

DECLARE @id nvarchar(100);

SET @id = (SELECT idPersona FROM PERSONA WHERE Email=@Email);

INSERT INTO EMPLEADO
(
idPersona,
TipoEmpleado,
fechaDeIngreso,
fechaDeEgreso
)
VALUES
(
@id,
@TipoEmpleado,
@fechaDeIngreso,
@fechaDeEgreso
);
 

RETURN SCOPE_IDENTITY()

CREATE PROCEDURE [dbo].[SocioActualizarEstado]

@idPersona int,
@idEstado int

AS

UPDATE	SOCIO
SET		 idEstado= @idEstado
WHERE	idPersona = @idPersona

CREATE PROCEDURE [dbo].[SocioActualizarTodo]
@Dni nvarchar(30),
@Nombre nvarchar(30),
@Apellido nvarchar(30),
@Telefono nvarchar(50),
@Email nvarchar(100),
@Password nvarchar(100),
@FechaNacimiento date,
@Sexo nchar(1),
@TipoPersona nchar(1),
@FechaRegistracion datetime,
@FechaActualizacion datetime,
@NroTarjetaIdentificacion nchar(10),
@idEstado nchar(10)

AS

DECLARE @id nvarchar(100);

SET @id = (SELECT idPersona FROM PERSONA WHERE Email=@Email);

UPDATE PERSONA
SET Dni=@Dni,
Telefono=@Telefono,
Nombre=@Nombre,
Apellido=@Apellido,
Email=@Email,
Password=@Password,
FechaNacimiento=@FechaNacimiento,
Sexo=@Sexo,
TipoPersona=@TipoPersona,
FechaRegistracion=@FechaRegistracion,
FechaActualizacion=@FechaActualizacion
WHERE PERSONA.idPersona= @id

UPDATE SOCIO
SET 
NroTarjetaIdentificacion=@NroTarjetaIdentificacion,
idEstado=@idEstado
WHERE SOCIO.idPersona= @id


RETURN SCOPE_IDENTITY()

CREATE PROCEDURE [dbo].[SocioBuscarPorId]

@idPersona int


AS

	SELECT * 
	FROM PERSONA
	inner join SOCIO on PERSONA.idPersona=SOCIO.idPersona
	where PERSONA.idPersona=@idPersona

create PROCEDURE [dbo].[SocioBuscarPorMailPassword]

@Email nvarchar(100),
@Password nvarchar(100)

AS

SELECT	*
FROM	PERSONA
inner join SOCIO on PERSONA.idPersona=SOCIO.idPersona
WHERE	Email = @Email AND
		Password = @Password

CREATE PROCEDURE [dbo].[SocioInsert]
@Dni nvarchar(30),
@Nombre nvarchar(30),
@Apellido nvarchar(30),
@Telefono nvarchar(50),
@Email nvarchar(100),
@Password nvarchar(100),
@FechaNacimiento date,
@Sexo nchar(1),
@TipoPersona nchar(1),
@FechaRegistracion datetime,
--@FechaActualizacion datetime,
@NroTarjetaIdentificacion nchar(10),
@idEstado nchar(10)

AS

INSERT INTO PERSONA
(
Dni,
Telefono,
Nombre,
Apellido,
Email,
Password,
FechaNacimiento,
Sexo,
TipoPersona,
FechaRegistracion,
FechaActualizacion
)
VALUES
(
@Dni,
@Telefono,
@Nombre,
@Apellido,
@Email,
@Password,
@FechaNacimiento,
@Sexo,
@TipoPersona,
@FechaRegistracion,
NULL--@FechaActualizacion
);

DECLARE @id nvarchar(100);

SET @id = (SELECT idPersona FROM PERSONA WHERE Email=@Email);

INSERT INTO SOCIO
(
idPersona,
NroTarjetaIdentificacion,
idEstado
)
VALUES
(
@id,
@NroTarjetaIdentificacion,
@idEstado
);
 

RETURN @id

create PROCEDURE [dbo].[SocioTraerTodos]

AS

	SELECT * 
	FROM PERSONA
	inner join SOCIO on PERSONA.idPersona=SOCIO.idPersona