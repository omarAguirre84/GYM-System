/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2014 (12.0.2000)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [DB_GYM]
GO
/****** Object:  Table [dbo].[ACTIVIDAD]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTIVIDAD](
	[idActividad] [int] NOT NULL,
	[descripcion] [varchar](30) NULL,
	[tarifa] [int] NULL,
	[horarioInicio] [datetime] NULL,
	[horarioFin] [datetime] NULL,
	[dia] [varchar](10) NOT NULL,
 CONSTRAINT [PK_ACTIVIDAD] PRIMARY KEY CLUSTERED 
(
	[idActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACTIVIDADSALA]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTIVIDADSALA](
	[idActividad] [int] NOT NULL,
	[idSala] [int] NOT NULL,
 CONSTRAINT [PK_ACTIVIDADSALA] PRIMARY KEY CLUSTERED 
(
	[idActividad] ASC,
	[idSala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLEADO]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLEADO](
	[idPersona] [int] NOT NULL,
	[tipoEmpleado] [int] NOT NULL,
	[fechaDeIngreso] [date] NULL,
	[fechaDeEgreso] [date] NULL,
 CONSTRAINT [PK_EMPLEADO] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLEADOACTIVIDAD]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLEADOACTIVIDAD](
	[IdEmpleado] [int] NOT NULL,
	[idActividad] [int] NOT NULL,
 CONSTRAINT [PK_EMPLEADODISCIPLINA] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC,
	[idActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESTADO]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTADO](
	[idEstado] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_ESTADO] PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONA]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONA](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[TipoPersona] [nchar](1) NOT NULL,
	[Telefono] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Dni] [varchar](50) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Sexo] [nchar](1) NOT NULL,
	[Foto] [nvarchar](100) NULL,
	[FechaRegistracion] [datetime] NOT NULL,
	[FechaActualizacion] [datetime] NULL,
 CONSTRAINT [PK_PERSONA_1] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SALA]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SALA](
	[idSala] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[numero] [varchar](50) NOT NULL,
	[capacidad] [int] NULL,
 CONSTRAINT [PK_SALA] PRIMARY KEY CLUSTERED 
(
	[idSala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOCIO]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOCIO](
	[idPersona] [int] NOT NULL,
	[nroTarjetaIdentificacion] [int] NOT NULL,
	[idEstado] [int] NOT NULL,
 CONSTRAINT [PK_SOCIO_1] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPOEMPLEADO]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPOEMPLEADO](
	[idTipoEmpleado] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TIPOEMPLEADO] PRIMARY KEY CLUSTERED 
(
	[idTipoEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ACTIVIDAD] ([idActividad], [descripcion], [tarifa], [horarioInicio], [horarioFin], [dia]) VALUES (1, N'PILATES', 100, CAST(N'1900-01-01T09:00:00.000' AS DateTime), CAST(N'1900-01-01T21:00:00.000' AS DateTime), N'LUNES')
INSERT [dbo].[ACTIVIDAD] ([idActividad], [descripcion], [tarifa], [horarioInicio], [horarioFin], [dia]) VALUES (2, N'SPINNING', 100, CAST(N'1900-01-01T09:00:00.000' AS DateTime), CAST(N'1900-01-01T21:00:00.000' AS DateTime), N'MARTES')
INSERT [dbo].[ACTIVIDAD] ([idActividad], [descripcion], [tarifa], [horarioInicio], [horarioFin], [dia]) VALUES (3, N'GAP', 100, CAST(N'1900-01-01T09:00:00.000' AS DateTime), CAST(N'1900-01-01T21:00:00.000' AS DateTime), N'MIERCOLES')
INSERT [dbo].[ACTIVIDAD] ([idActividad], [descripcion], [tarifa], [horarioInicio], [horarioFin], [dia]) VALUES (4, N'LOCALIZADA', 100, CAST(N'1900-01-01T09:00:00.000' AS DateTime), CAST(N'1900-01-01T21:00:00.000' AS DateTime), N'JUEVES')
INSERT [dbo].[ACTIVIDAD] ([idActividad], [descripcion], [tarifa], [horarioInicio], [horarioFin], [dia]) VALUES (5, N'DANZA', 100, CAST(N'1900-01-01T09:00:00.000' AS DateTime), CAST(N'1900-01-01T21:00:00.000' AS DateTime), N'VIERNES')
INSERT [dbo].[ACTIVIDADSALA] ([idActividad], [idSala]) VALUES (1, 100)
INSERT [dbo].[ACTIVIDADSALA] ([idActividad], [idSala]) VALUES (2, 200)
INSERT [dbo].[ACTIVIDADSALA] ([idActividad], [idSala]) VALUES (3, 300)
INSERT [dbo].[ACTIVIDADSALA] ([idActividad], [idSala]) VALUES (4, 400)
INSERT [dbo].[ACTIVIDADSALA] ([idActividad], [idSala]) VALUES (5, 100)
INSERT [dbo].[EMPLEADO] ([idPersona], [tipoEmpleado], [fechaDeIngreso], [fechaDeEgreso]) VALUES (2, 1, CAST(N'2017-10-10' AS Date), CAST(N'0001-01-01' AS Date))
INSERT [dbo].[EMPLEADO] ([idPersona], [tipoEmpleado], [fechaDeIngreso], [fechaDeEgreso]) VALUES (8, 2, CAST(N'2017-10-10' AS Date), CAST(N'0001-01-01' AS Date))
INSERT [dbo].[EMPLEADO] ([idPersona], [tipoEmpleado], [fechaDeIngreso], [fechaDeEgreso]) VALUES (10, 1, CAST(N'2017-10-10' AS Date), CAST(N'0001-01-01' AS Date))
INSERT [dbo].[EMPLEADO] ([idPersona], [tipoEmpleado], [fechaDeIngreso], [fechaDeEgreso]) VALUES (22, 1, CAST(N'2017-10-10' AS Date), CAST(N'0001-01-01' AS Date))
INSERT [dbo].[EMPLEADOACTIVIDAD] ([IdEmpleado], [idActividad]) VALUES (2, 1)
INSERT [dbo].[EMPLEADOACTIVIDAD] ([IdEmpleado], [idActividad]) VALUES (2, 2)
INSERT [dbo].[EMPLEADOACTIVIDAD] ([IdEmpleado], [idActividad]) VALUES (2, 3)
INSERT [dbo].[EMPLEADOACTIVIDAD] ([IdEmpleado], [idActividad]) VALUES (10, 4)
INSERT [dbo].[EMPLEADOACTIVIDAD] ([IdEmpleado], [idActividad]) VALUES (10, 5)
INSERT [dbo].[ESTADO] ([idEstado], [descripcion]) VALUES (1, N'ACTIVO')
INSERT [dbo].[ESTADO] ([idEstado], [descripcion]) VALUES (2, N'INACTIVO')
INSERT [dbo].[ESTADO] ([idEstado], [descripcion]) VALUES (3, N'BAJA')
SET IDENTITY_INSERT [dbo].[PERSONA] ON 

INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (2, N'p', 1, N'Omar', N'Aguirre', N'31000000', N'omar@omar.com', N'1234', CAST(N'1984-06-09' AS Date), N'm', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-07-07T18:09:20.223' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (8, N'E', 11111, N'blabla', N'blabla', N'123123', N'euge@euge.com', N'4444', CAST(N'1977-10-10' AS Date), N'f', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-07-07T18:09:20.223' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (9, N'E', 46940314, N'Mariano', N'Paciaroni', N'32000000', N'pacha@pacha.com', N'1234', CAST(N'1980-10-20' AS Date), N'M', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-07-07T18:09:20.223' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (10, N'E', 46940314, N'Pablo', N'Amurrio', N'32000000', N'pablo@pablo.com', N'1234', CAST(N'1980-10-20' AS Date), N'M', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-07-07T18:09:20.223' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (14, N'S', 11111, N'pepe', N'pepa', N'11111', N'solomeo@solomeo.com', N'123', CAST(N'1988-10-10' AS Date), N'M', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-12-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (15, N'E', 46940314, N'Elsa', N'Payero', N'32000000', N'elsa@elsa.com', N'1234', CAST(N'1980-10-20' AS Date), N'F', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-07-07T18:09:20.223' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (16, N'E', 46940314, N'Susana', N'Horia', N'32000000', N'susana@susana.com', N'1234', CAST(N'1980-10-20' AS Date), N'F', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-07-07T18:09:20.223' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (17, N's', 123456, N'bbbbbb', N'bbbbb', N'1234123', N'b@b.com', N'123', CAST(N'1986-10-10' AS Date), N'M', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-12-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (18, N'p', 12, N'd', N'd', N'412341234', N'd@d.com', N'd', CAST(N'1986-10-10' AS Date), N'f', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-12-20T04:05:20.160' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (19, N'E', 123, N'f', N'f', N'12341234', N'f@f.com', N'f', CAST(N'1986-10-10' AS Date), N'f', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-12-20T04:05:20.160' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (20, N'p', 123, N'g', N'g', N'12341', N'g@g.com', N'g', CAST(N'1986-10-10' AS Date), N'f', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-12-20T04:05:20.160' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (21, N'p', 123, N'h', N'h', N'2341234', N'h@h.com', N'12345', CAST(N'1980-10-10' AS Date), N'f', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-12-20T04:05:20.160' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (22, N'p', 123, N'i', N'i', N'12341234', N'i@i.com', N'i', CAST(N'1986-10-10' AS Date), N'f', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), CAST(N'2017-12-20T04:05:20.160' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (38, N'S', 12412341, N'susana', N'horia', N'12312312', N'susana@horia.com', N'asdasd', CAST(N'1810-06-09' AS Date), N'F', NULL, CAST(N'2017-12-18T02:30:40.710' AS DateTime), CAST(N'2017-12-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (39, N'E', 1123123, N'ijfijij', N'ojkijoj', N'123123123', N'dafsdf@asdf.com', N'123', CAST(N'1923-09-06' AS Date), N'M', NULL, CAST(N'2017-12-18T02:34:47.083' AS DateTime), CAST(N'2017-12-18T02:34:47.083' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (40, N'S', 12312333, N'jfhyjfu', N'jufjfu', N'123123123', N'dzfgsfdg@sdfsdf.com', N'123', CAST(N'1780-05-06' AS Date), N'M', NULL, CAST(N'2017-12-18T02:39:30.400' AS DateTime), CAST(N'2017-12-18T02:39:30.400' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (41, N'S', 12312333, N'jfhyjfu', N'jufjfu', N'123123123', N'dzfgsfssdg@sdfsdf.com', N'123', CAST(N'1780-05-06' AS Date), N'M', NULL, CAST(N'2017-12-18T02:41:05.780' AS DateTime), CAST(N'2017-12-18T02:41:05.780' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (42, N'S', 34234234, N'wthdgfh', N'dfgh', N'3423423', N'aa2345@adfa.com', N'123', CAST(N'1582-06-05' AS Date), N'M', NULL, CAST(N'2017-12-18T02:47:11.303' AS DateTime), CAST(N'2017-12-18T02:47:11.303' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (43, N'E', 123141, N'11111', N'ggggggg', N'123123123', N'sdfsd@asdf.com', N'asdasd', CAST(N'1965-05-06' AS Date), N'F', NULL, CAST(N'2017-12-18T02:48:34.660' AS DateTime), CAST(N'2017-12-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (44, N's', 1234234, N'abcdef1', N'ghijk', N'22222222', N'aaas2345@adfa.com', N'123', CAST(N'1485-02-05' AS Date), N'M', NULL, CAST(N'2017-12-18T02:49:14.270' AS DateTime), CAST(N'2017-12-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (45, N's', 12312312, N'kjisdjfg', N'ksjfdgk', N'23412345', N'osadf@asdf.com', N'123', CAST(N'1458-08-05' AS Date), N'M', NULL, CAST(N'2017-12-18T02:50:28.593' AS DateTime), CAST(N'2017-12-18T02:50:28.593' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (46, N's', 1234, N'abcdef', N'asdfgsd', N'2342342', N'nada@adfa.com', N'4444', CAST(N'1455-01-04' AS Date), N'M', NULL, CAST(N'2017-12-18T02:51:54.647' AS DateTime), CAST(N'2017-12-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (47, N's', 12123123, N'bbbbbb', N'bbbbb', N'123441234', N'oamsdar@onmar.com', N'123', CAST(N'1984-09-06' AS Date), N'F', NULL, CAST(N'2017-12-18T13:39:57.550' AS DateTime), CAST(N'2017-12-20T04:05:47.863' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (53, N's', 1122518060, N'Omar', N'Aguirre', N'3313222', N'omar.aguirre.1984@gmail.com', N'asdasd', CAST(N'1984-09-06' AS Date), N'M', NULL, CAST(N'2017-12-18T17:17:24.550' AS DateTime), CAST(N'2017-12-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PERSONA] ([idPersona], [TipoPersona], [Telefono], [Nombre], [Apellido], [Dni], [Email], [Password], [FechaNacimiento], [Sexo], [Foto], [FechaRegistracion], [FechaActualizacion]) VALUES (1026, N's', 12414123, N'Pepe1', N'Argento1', N'31201200', N'pepe1@pepe1.com', N'1234', CAST(N'1984-06-09' AS Date), N'm', NULL, CAST(N'2017-07-07T18:09:20.223' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[PERSONA] OFF
INSERT [dbo].[SALA] ([idSala], [nombre], [numero], [capacidad]) VALUES (100, N'PIRAMIDES', N'1', 100)
INSERT [dbo].[SALA] ([idSala], [nombre], [numero], [capacidad]) VALUES (200, N'CATARATAS', N'2', 50)
INSERT [dbo].[SALA] ([idSala], [nombre], [numero], [capacidad]) VALUES (300, N'COLISEO ROMANO', N'3', 20)
INSERT [dbo].[SALA] ([idSala], [nombre], [numero], [capacidad]) VALUES (400, N'TAJ MAHAL', N'4', 30)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (14, 11111, 2)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (15, 124, 1)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (16, 125, 2)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (17, 1, 1)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (38, 22967, 1)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (39, 76644, 1)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (40, 12707, 1)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (41, 44140, 1)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (42, 61134, 1)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (43, 46311, 1)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (44, 20739, 1)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (45, 19976, 1)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (46, 16715, 2)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (47, 7322, 1)
INSERT [dbo].[SOCIO] ([idPersona], [nroTarjetaIdentificacion], [idEstado]) VALUES (53, 14744, 1)
INSERT [dbo].[TIPOEMPLEADO] ([idTipoEmpleado], [descripcion]) VALUES (1, N'EMPLEADO')
INSERT [dbo].[TIPOEMPLEADO] ([idTipoEmpleado], [descripcion]) VALUES (2, N'PROFESOR')
ALTER TABLE [dbo].[ACTIVIDADSALA]  WITH CHECK ADD  CONSTRAINT [FK_ACTIVIDADSALA_ACTIVIDAD1] FOREIGN KEY([idActividad])
REFERENCES [dbo].[ACTIVIDAD] ([idActividad])
GO
ALTER TABLE [dbo].[ACTIVIDADSALA] CHECK CONSTRAINT [FK_ACTIVIDADSALA_ACTIVIDAD1]
GO
ALTER TABLE [dbo].[ACTIVIDADSALA]  WITH CHECK ADD  CONSTRAINT [FK_ACTIVIDADSALA_SALA] FOREIGN KEY([idSala])
REFERENCES [dbo].[SALA] ([idSala])
GO
ALTER TABLE [dbo].[ACTIVIDADSALA] CHECK CONSTRAINT [FK_ACTIVIDADSALA_SALA]
GO
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_PERSONA] FOREIGN KEY([idPersona])
REFERENCES [dbo].[PERSONA] ([idPersona])
GO
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_EMPLEADO_PERSONA]
GO
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_TIPOEMPLEADO] FOREIGN KEY([tipoEmpleado])
REFERENCES [dbo].[TIPOEMPLEADO] ([idTipoEmpleado])
GO
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_EMPLEADO_TIPOEMPLEADO]
GO
ALTER TABLE [dbo].[EMPLEADOACTIVIDAD]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADOACTIVIDAD_ACTIVIDAD] FOREIGN KEY([idActividad])
REFERENCES [dbo].[ACTIVIDAD] ([idActividad])
GO
ALTER TABLE [dbo].[EMPLEADOACTIVIDAD] CHECK CONSTRAINT [FK_EMPLEADOACTIVIDAD_ACTIVIDAD]
GO
ALTER TABLE [dbo].[EMPLEADOACTIVIDAD]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADOACTIVIDAD_EMPLEADO] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[EMPLEADO] ([idPersona])
GO
ALTER TABLE [dbo].[EMPLEADOACTIVIDAD] CHECK CONSTRAINT [FK_EMPLEADOACTIVIDAD_EMPLEADO]
GO
ALTER TABLE [dbo].[SOCIO]  WITH CHECK ADD  CONSTRAINT [FK_SOCIO_ESTADO] FOREIGN KEY([idEstado])
REFERENCES [dbo].[ESTADO] ([idEstado])
GO
ALTER TABLE [dbo].[SOCIO] CHECK CONSTRAINT [FK_SOCIO_ESTADO]
GO
ALTER TABLE [dbo].[SOCIO]  WITH CHECK ADD  CONSTRAINT [FK_SOCIO_PERSONA] FOREIGN KEY([idPersona])
REFERENCES [dbo].[PERSONA] ([idPersona])
GO
ALTER TABLE [dbo].[SOCIO] CHECK CONSTRAINT [FK_SOCIO_PERSONA]
GO
/****** Object:  StoredProcedure [dbo].[ActividadActualizar]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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


GO
/****** Object:  StoredProcedure [dbo].[ActividadAlta]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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


GO
/****** Object:  StoredProcedure [dbo].[ActividadBaja]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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


GO
/****** Object:  StoredProcedure [dbo].[ActividadSalaBuscarPorIdActividad]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[ActividadSalaBuscarPorIdActividad]

@idActividad int

AS

select * 
from ACTIVIDAD
	join ACTIVIDADSALA on ACTIVIDAD.idActividad = ACTIVIDADSALA.idActividad
	join SALA on SALA.idSala = ACTIVIDADSALA.idSala
where
ACTIVIDAD.idActividad = @idActividad;

RETURN SCOPE_IDENTITY()


GO
/****** Object:  StoredProcedure [dbo].[ActividadTraerTodos]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[ActividadTraerTodos]


AS

select * 
from ACTIVIDAD


RETURN SCOPE_IDENTITY()


GO
/****** Object:  StoredProcedure [dbo].[EmpleadoActualizarTodo]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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


GO
/****** Object:  StoredProcedure [dbo].[EmpleadoBuscarPorId]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmpleadoBuscarPorId]

@idPersona int
AS


select * 
from 
EMPLEADO 
	join PERSONA on PERSONA.idPersona= EMPLEADO.idPersona
	join EMPLEADOACTIVIDAD on EMPLEADO.idPersona = EMPLEADOACTIVIDAD.IdEmpleado
	 join ACTIVIDAD on EMPLEADOACTIVIDAD.idActividad= ACTIVIDAD.idActividad
where
PERSONA.TipoPersona like 'e' or 
PERSONA.TipoPersona like 'p' and
EMPLEADO.idPersona = @idPersona	
;

RETURN SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[EmpleadoInsert]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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


GO
/****** Object:  StoredProcedure [dbo].[EmpleadoTraerTodos]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmpleadoTraerTodos]

AS

select * 
from 
EMPLEADO 
	join PERSONA on PERSONA.idPersona= EMPLEADO.idPersona
	join EMPLEADOACTIVIDAD on EMPLEADO.idPersona = EMPLEADOACTIVIDAD.IdEmpleado
	join ACTIVIDAD on EMPLEADOACTIVIDAD.idActividad= ACTIVIDAD.idActividad

RETURN SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PersonaActualizarFoto]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PersonaActualizarFoto]

@idPersona smallint,
@foto nvarchar(100)

AS

UPDATE	PERSONA
SET		foto = @foto
WHERE	idPersona = @idPersona


GO
/****** Object:  StoredProcedure [dbo].[PersonaBuscarEmail]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PersonaBuscarEmail]

@Email nvarchar(100)

AS

IF EXISTS (SELECT * FROM PERSONA WHERE Email = @Email)
	SELECT SOCIO.idPersona AS ESSOCIO,EMPLEADO.idPersona AS ESEMPLEADO, PERSONA.* FROM PERSONA
left join SOCIO on PERSONA.idPersona=SOCIO.idPersona
left join EMPLEADO on PERSONA.idPersona=EMPLEADO.idPersona
WHERE PERSONA.Email= @Email

ELSE
	SELECT 0

GO
/****** Object:  StoredProcedure [dbo].[PersonaBuscarPorEmailPassword]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PersonaBuscarPorEmailPassword]

@Email nvarchar(100),
@Password nvarchar(100)

AS

SELECT	*
FROM	PERSONA
WHERE	Email = @Email AND
		Password = @Password


GO
/****** Object:  StoredProcedure [dbo].[PersonaTraerTodos]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[PersonaTraerTodos]

AS

select * 
from PERSONA
	
order by PERSONA.idPersona;

RETURN SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[SocioActualizarEstado]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SocioActualizarEstado]

@idPersona int,
@idEstado int

AS

UPDATE	SOCIO
SET		 idEstado= @idEstado
WHERE	idPersona = @idPersona


GO
/****** Object:  StoredProcedure [dbo].[SocioActualizarTodo]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SocioActualizarTodo]
@idPersona int,
@Dni nvarchar(30),
@Nombre nvarchar(30),
@Apellido nvarchar(30),
@Telefono nvarchar(50),
@Email nvarchar(100),
@Password nvarchar(100),
@FechaNacimiento date,
@Sexo nchar(1),
@TipoPersona nchar(1),
@FechaActualizacion datetime,
@NroTarjetaIdentificacion nchar(10),
@idEstado int

AS


UPDATE PERSONA
SET 
Dni=@Dni,
PERSONA.Telefono=@Telefono,
PERSONA.Nombre=@Nombre,
PERSONA.Apellido=@Apellido,
PERSONA.Email=@Email,
PERSONA.Password=@Password,
PERSONA.FechaNacimiento=@FechaNacimiento,
PERSONA.Sexo=@Sexo,
PERSONA.TipoPersona=@TipoPersona,
PERSONA.FechaActualizacion=@FechaActualizacion
WHERE 
PERSONA.idPersona= @idPersona

UPDATE SOCIO
SET 
SOCIO.NroTarjetaIdentificacion=@NroTarjetaIdentificacion,
SOCIO.idEstado=@idEstado
WHERE 
SOCIO.idPersona= @idPersona


RETURN SCOPE_IDENTITY()


GO
/****** Object:  StoredProcedure [dbo].[SocioBuscarId]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SocioBuscarId]
@idPersona int

as
SELECT * 
FROM PERSONA 
	JOIN SOCIO ON PERSONA.idPersona = SOCIO.idPersona 
	JOIN ESTADO ON ESTADO.idEstado = SOCIO.idEstado
WHERE 
PERSONA.TipoPersona LIKE 'S' and 
PERSONA.idPersona = @idPersona;

RETURN SCOPE_IDENTITY()


GO
/****** Object:  StoredProcedure [dbo].[SocioBuscarPorMailPassword]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SocioBuscarPorMailPassword]
@idPersona int,
@Password nvarchar(30)

AS

SELECT * 
FROM PERSONA 
	JOIN SOCIO ON PERSONA.idPersona = SOCIO.idPersona 
	JOIN ESTADO ON ESTADO.idEstado = SOCIO.idEstado
WHERE 
PERSONA.TipoPersona LIKE 'S' and
PERSONA.idPersona = @idPersona and
PERSONA.Password = @Password
ORDER BY PERSONA.idPersona;

RETURN SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[SocioInsert]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
@FechaActualizacion datetime,
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
@FechaActualizacion
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
 

RETURN SCOPE_IDENTITY()


GO
/****** Object:  StoredProcedure [dbo].[SocioTraerTodos]    Script Date: 20/12/2017 14:39:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SocioTraerTodos]

AS
SELECT * 
FROM PERSONA 
	JOIN SOCIO ON PERSONA.idPersona = SOCIO.idPersona 
	JOIN ESTADO ON ESTADO.idEstado = SOCIO.idEstado
WHERE PERSONA.TipoPersona LIKE 'S'	
ORDER BY PERSONA.idPersona;

RETURN SCOPE_IDENTITY()
GO
