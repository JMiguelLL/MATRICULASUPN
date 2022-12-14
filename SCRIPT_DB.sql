USE [master]
GO
/****** Object:  Database [matriculasupn2]    Script Date: 31/10/2022 11:58:15 ******/
CREATE DATABASE [matriculasupn2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'matriculasupn2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\matriculasupn2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'matriculasupn2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\matriculasupn2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [matriculasupn2] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [matriculasupn2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [matriculasupn2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [matriculasupn2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [matriculasupn2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [matriculasupn2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [matriculasupn2] SET ARITHABORT OFF 
GO
ALTER DATABASE [matriculasupn2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [matriculasupn2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [matriculasupn2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [matriculasupn2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [matriculasupn2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [matriculasupn2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [matriculasupn2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [matriculasupn2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [matriculasupn2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [matriculasupn2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [matriculasupn2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [matriculasupn2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [matriculasupn2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [matriculasupn2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [matriculasupn2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [matriculasupn2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [matriculasupn2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [matriculasupn2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [matriculasupn2] SET  MULTI_USER 
GO
ALTER DATABASE [matriculasupn2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [matriculasupn2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [matriculasupn2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [matriculasupn2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [matriculasupn2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [matriculasupn2] SET QUERY_STORE = OFF
GO
USE [matriculasupn2]
GO
/****** Object:  Table [dbo].[Aula]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aula](
	[idAula] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](10) NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idAula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[idCarrera] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](40) NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCarrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clase]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clase](
	[idClase] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](10) NULL,
	[nombre] [nvarchar](30) NULL,
	[horaInicio] [datetime] NULL,
	[horaFin] [datetime] NULL,
	[status] [int] NOT NULL,
	[idCurso] [int] NOT NULL,
	[idAula] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idClase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[idCurso] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](40) NULL,
	[creditos] [int] NULL,
	[status] [int] NOT NULL,
	[idCarrera] [int] NOT NULL,
	[idPeriodo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[idEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [nvarchar](10) NULL,
	[nombre] [nvarchar](30) NULL,
	[apellidoPaterno] [nvarchar](15) NULL,
	[apellidoMaterno] [nvarchar](15) NULL,
	[telefono] [nvarchar](9) NULL,
	[status] [int] NOT NULL,
	[idCarrera] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogsMatriculaDetalle]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogsMatriculaDetalle](
	[idLogsMatriculaDetalle] [int] IDENTITY(1,1) NOT NULL,
	[fechaRegistro] [datetime] NULL,
	[accion] [int] NULL,
	[idMatriculaDetalle] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idLogsMatriculaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogsUsuario]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogsUsuario](
	[idLogsUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[fechaIngreso] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idLogsUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[idMatricula] [int] IDENTITY(1,1) NOT NULL,
	[fechaMatricula] [datetime] NULL,
	[status] [int] NOT NULL,
	[idEstudiante] [int] NOT NULL,
	[idPeriodo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idMatricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatriculaDetalle]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatriculaDetalle](
	[idMatriculaDetalle] [int] IDENTITY(1,1) NOT NULL,
	[idMatricula] [int] NOT NULL,
	[idClase] [int] NOT NULL,
	[status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idMatriculaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periodo]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periodo](
	[idPeriodo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](10) NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPeriodo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NULL,
	[nombre] [nvarchar](30) NULL,
	[apellidoPaterno] [nvarchar](15) NULL,
	[apellidoMaterno] [nvarchar](15) NULL,
	[intentos] [int] NULL,
	[status] [bit] NULL,
	[password] [nvarchar](30) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Aula] ON 

INSERT [dbo].[Aula] ([idAula], [codigo], [status]) VALUES (1, N'A-201', 1)
INSERT [dbo].[Aula] ([idAula], [codigo], [status]) VALUES (2, N'A-202', 1)
INSERT [dbo].[Aula] ([idAula], [codigo], [status]) VALUES (3, N'A-203', 1)
INSERT [dbo].[Aula] ([idAula], [codigo], [status]) VALUES (4, N'A-204', 1)
INSERT [dbo].[Aula] ([idAula], [codigo], [status]) VALUES (5, N'A-301', 1)
INSERT [dbo].[Aula] ([idAula], [codigo], [status]) VALUES (6, N'A-302', 1)
INSERT [dbo].[Aula] ([idAula], [codigo], [status]) VALUES (7, N'A-303', 1)
INSERT [dbo].[Aula] ([idAula], [codigo], [status]) VALUES (8, N'B-201', 1)
INSERT [dbo].[Aula] ([idAula], [codigo], [status]) VALUES (9, N'B-202', 1)
INSERT [dbo].[Aula] ([idAula], [codigo], [status]) VALUES (10, N'B-203', 1)
INSERT [dbo].[Aula] ([idAula], [codigo], [status]) VALUES (11, N'B-204', 1)
SET IDENTITY_INSERT [dbo].[Aula] OFF
GO
SET IDENTITY_INSERT [dbo].[Carrera] ON 

INSERT [dbo].[Carrera] ([idCarrera], [nombre], [status]) VALUES (1, N'Ingeniería de Sistemas Computacionales', 1)
INSERT [dbo].[Carrera] ([idCarrera], [nombre], [status]) VALUES (2, N'Ingeniería Industrial', 1)
SET IDENTITY_INSERT [dbo].[Carrera] OFF
GO
SET IDENTITY_INSERT [dbo].[Clase] ON 

INSERT [dbo].[Clase] ([idClase], [codigo], [nombre], [horaInicio], [horaFin], [status], [idCurso], [idAula]) VALUES (1, N'5523', N'INSC', CAST(N'2023-04-01T09:10:00.000' AS DateTime), CAST(N'2023-04-01T10:40:00.000' AS DateTime), 1, 1, 1)
INSERT [dbo].[Clase] ([idClase], [codigo], [nombre], [horaInicio], [horaFin], [status], [idCurso], [idAula]) VALUES (2, N'5524', N'INSC', CAST(N'2023-04-03T12:30:00.000' AS DateTime), CAST(N'2023-04-03T14:00:00.000' AS DateTime), 1, 1, 2)
INSERT [dbo].[Clase] ([idClase], [codigo], [nombre], [horaInicio], [horaFin], [status], [idCurso], [idAula]) VALUES (3, N'6226', N'LGN', CAST(N'2023-04-02T14:30:00.000' AS DateTime), CAST(N'2023-04-02T16:00:00.000' AS DateTime), 1, 2, 1)
INSERT [dbo].[Clase] ([idClase], [codigo], [nombre], [horaInicio], [horaFin], [status], [idCurso], [idAula]) VALUES (4, N'6227', N'LGN', CAST(N'2023-04-02T14:30:00.000' AS DateTime), CAST(N'2023-04-02T16:00:00.000' AS DateTime), 1, 2, 2)
INSERT [dbo].[Clase] ([idClase], [codigo], [nombre], [horaInicio], [horaFin], [status], [idCurso], [idAula]) VALUES (5, N'9894', N'MAB', CAST(N'2023-04-04T09:10:00.000' AS DateTime), CAST(N'2023-04-04T12:30:00.000' AS DateTime), 1, 3, 5)
INSERT [dbo].[Clase] ([idClase], [codigo], [nombre], [horaInicio], [horaFin], [status], [idCurso], [idAula]) VALUES (6, N'9895', N'MAB', CAST(N'2023-04-05T07:30:00.000' AS DateTime), CAST(N'2023-04-05T10:40:00.000' AS DateTime), 1, 3, 6)
INSERT [dbo].[Clase] ([idClase], [codigo], [nombre], [horaInicio], [horaFin], [status], [idCurso], [idAula]) VALUES (7, N'6277', N'ININD', CAST(N'2023-04-05T12:30:00.000' AS DateTime), CAST(N'2023-04-05T14:00:00.000' AS DateTime), 1, 4, 3)
INSERT [dbo].[Clase] ([idClase], [codigo], [nombre], [horaInicio], [horaFin], [status], [idCurso], [idAula]) VALUES (8, N'6278', N'ININD', CAST(N'2023-04-02T14:30:00.000' AS DateTime), CAST(N'2023-04-02T16:00:00.000' AS DateTime), 1, 4, 4)
SET IDENTITY_INSERT [dbo].[Clase] OFF
GO
SET IDENTITY_INSERT [dbo].[Curso] ON 

INSERT [dbo].[Curso] ([idCurso], [nombre], [creditos], [status], [idCarrera], [idPeriodo]) VALUES (1, N'Introduccion a Ingeniería de Sistemas', 3, 1, 1, 1)
INSERT [dbo].[Curso] ([idCurso], [nombre], [creditos], [status], [idCarrera], [idPeriodo]) VALUES (2, N'Lengua I', 4, 1, 1, 1)
INSERT [dbo].[Curso] ([idCurso], [nombre], [creditos], [status], [idCarrera], [idPeriodo]) VALUES (3, N'Matemática Básica', 4, 1, 1, 2)
INSERT [dbo].[Curso] ([idCurso], [nombre], [creditos], [status], [idCarrera], [idPeriodo]) VALUES (4, N'Introducción a la ingeniería industrial', 3, 1, 2, 1)
INSERT [dbo].[Curso] ([idCurso], [nombre], [creditos], [status], [idCarrera], [idPeriodo]) VALUES (5, N'Lengua I', 4, 1, 2, 2)
INSERT [dbo].[Curso] ([idCurso], [nombre], [creditos], [status], [idCarrera], [idPeriodo]) VALUES (6, N'Cálculo I', 3, 1, 1, 2)
INSERT [dbo].[Curso] ([idCurso], [nombre], [creditos], [status], [idCarrera], [idPeriodo]) VALUES (7, N'Física I', 4, 1, 2, 2)
INSERT [dbo].[Curso] ([idCurso], [nombre], [creditos], [status], [idCarrera], [idPeriodo]) VALUES (8, N'Física II', 5, 1, 2, 2)
SET IDENTITY_INSERT [dbo].[Curso] OFF
GO
SET IDENTITY_INSERT [dbo].[Estudiante] ON 

INSERT [dbo].[Estudiante] ([idEstudiante], [codigo], [nombre], [apellidoPaterno], [apellidoMaterno], [telefono], [status], [idCarrera]) VALUES (1, N'N00079851', N'Miguel', N'Leython', N'Lías', N'953582742', 1, 1)
INSERT [dbo].[Estudiante] ([idEstudiante], [codigo], [nombre], [apellidoPaterno], [apellidoMaterno], [telefono], [status], [idCarrera]) VALUES (2, N'N00053863', N'Luis', N'Zapata', N'Gomez', N'953582742', 1, 2)
INSERT [dbo].[Estudiante] ([idEstudiante], [codigo], [nombre], [apellidoPaterno], [apellidoMaterno], [telefono], [status], [idCarrera]) VALUES (3, N'N00014444', N'María', N'Rodriguez', N'Ruiz', N'953582742', 1, 1)
INSERT [dbo].[Estudiante] ([idEstudiante], [codigo], [nombre], [apellidoPaterno], [apellidoMaterno], [telefono], [status], [idCarrera]) VALUES (4, N'N00046773', N'Enrique', N'Chavarri', N'Vera', N'953582742', 1, 1)
INSERT [dbo].[Estudiante] ([idEstudiante], [codigo], [nombre], [apellidoPaterno], [apellidoMaterno], [telefono], [status], [idCarrera]) VALUES (5, N'N03458447', N'Sandra', N'Romero', N'Chunga', N'953582742', 1, 1)
INSERT [dbo].[Estudiante] ([idEstudiante], [codigo], [nombre], [apellidoPaterno], [apellidoMaterno], [telefono], [status], [idCarrera]) VALUES (6, N'N00048357', N'Jennie', N'Cornejo', N'Saavedra', N'953582742', 1, 2)
INSERT [dbo].[Estudiante] ([idEstudiante], [codigo], [nombre], [apellidoPaterno], [apellidoMaterno], [telefono], [status], [idCarrera]) VALUES (7, N'N00326773', N'Juan', N'Martinez', N'Lobaton', N'953582742', 1, 2)
INSERT [dbo].[Estudiante] ([idEstudiante], [codigo], [nombre], [apellidoPaterno], [apellidoMaterno], [telefono], [status], [idCarrera]) VALUES (8, N'N00226645', N'David', N'Rodriguez', N'Salgado', N'953582742', 1, 2)
INSERT [dbo].[Estudiante] ([idEstudiante], [codigo], [nombre], [apellidoPaterno], [apellidoMaterno], [telefono], [status], [idCarrera]) VALUES (9, N'N00935882', N'Dany', N'Reyna', N'Espinoza', N'953582742', 1, 1)
SET IDENTITY_INSERT [dbo].[Estudiante] OFF
GO
SET IDENTITY_INSERT [dbo].[LogsMatriculaDetalle] ON 

INSERT [dbo].[LogsMatriculaDetalle] ([idLogsMatriculaDetalle], [fechaRegistro], [accion], [idMatriculaDetalle], [idUsuario]) VALUES (1, CAST(N'2022-10-31T02:51:32.903' AS DateTime), 1, 1, 1)
INSERT [dbo].[LogsMatriculaDetalle] ([idLogsMatriculaDetalle], [fechaRegistro], [accion], [idMatriculaDetalle], [idUsuario]) VALUES (2, CAST(N'2022-10-31T03:01:02.833' AS DateTime), 1, 2, 1)
INSERT [dbo].[LogsMatriculaDetalle] ([idLogsMatriculaDetalle], [fechaRegistro], [accion], [idMatriculaDetalle], [idUsuario]) VALUES (3, CAST(N'2022-10-31T03:01:20.170' AS DateTime), 2, 1, 1)
INSERT [dbo].[LogsMatriculaDetalle] ([idLogsMatriculaDetalle], [fechaRegistro], [accion], [idMatriculaDetalle], [idUsuario]) VALUES (4, CAST(N'2022-10-31T03:01:45.870' AS DateTime), 1, 3, 1)
INSERT [dbo].[LogsMatriculaDetalle] ([idLogsMatriculaDetalle], [fechaRegistro], [accion], [idMatriculaDetalle], [idUsuario]) VALUES (5, CAST(N'2022-10-31T03:03:09.557' AS DateTime), 1, 4, 1)
INSERT [dbo].[LogsMatriculaDetalle] ([idLogsMatriculaDetalle], [fechaRegistro], [accion], [idMatriculaDetalle], [idUsuario]) VALUES (6, CAST(N'2022-10-31T03:03:28.700' AS DateTime), 1, 5, 1)
SET IDENTITY_INSERT [dbo].[LogsMatriculaDetalle] OFF
GO
SET IDENTITY_INSERT [dbo].[LogsUsuario] ON 

INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (1, 1, CAST(N'2022-10-31T02:43:43.330' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (2, 1, CAST(N'2022-10-31T02:47:15.280' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (3, 1, CAST(N'2022-10-31T02:50:51.670' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (4, 1, CAST(N'2022-10-31T02:52:52.147' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (5, 1, CAST(N'2022-10-31T02:55:42.727' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (6, 1, CAST(N'2022-10-31T02:57:27.290' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (7, 1, CAST(N'2022-10-31T02:58:00.043' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (8, 1, CAST(N'2022-10-31T02:59:22.683' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (9, 1, CAST(N'2022-10-31T03:02:59.497' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (10, 1, CAST(N'2022-10-31T03:04:43.343' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (11, 1, CAST(N'2022-10-31T03:05:49.287' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (12, 1, CAST(N'2022-10-31T03:09:10.800' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (13, 1, CAST(N'2022-10-31T03:14:41.020' AS DateTime))
INSERT [dbo].[LogsUsuario] ([idLogsUsuario], [idUsuario], [fechaIngreso]) VALUES (14, 1, CAST(N'2022-10-31T03:17:43.127' AS DateTime))
SET IDENTITY_INSERT [dbo].[LogsUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Matricula] ON 

INSERT [dbo].[Matricula] ([idMatricula], [fechaMatricula], [status], [idEstudiante], [idPeriodo]) VALUES (1, CAST(N'2022-10-31T02:51:32.897' AS DateTime), 2, 1, 1)
INSERT [dbo].[Matricula] ([idMatricula], [fechaMatricula], [status], [idEstudiante], [idPeriodo]) VALUES (2, CAST(N'2022-10-31T03:03:09.550' AS DateTime), 2, 9, 1)
INSERT [dbo].[Matricula] ([idMatricula], [fechaMatricula], [status], [idEstudiante], [idPeriodo]) VALUES (3, CAST(N'2022-10-31T03:03:28.700' AS DateTime), 2, 5, 1)
SET IDENTITY_INSERT [dbo].[Matricula] OFF
GO
SET IDENTITY_INSERT [dbo].[MatriculaDetalle] ON 

INSERT [dbo].[MatriculaDetalle] ([idMatriculaDetalle], [idMatricula], [idClase], [status]) VALUES (1, 1, 2, 0)
INSERT [dbo].[MatriculaDetalle] ([idMatriculaDetalle], [idMatricula], [idClase], [status]) VALUES (2, 1, 4, 1)
INSERT [dbo].[MatriculaDetalle] ([idMatriculaDetalle], [idMatricula], [idClase], [status]) VALUES (3, 1, 1, 1)
INSERT [dbo].[MatriculaDetalle] ([idMatriculaDetalle], [idMatricula], [idClase], [status]) VALUES (4, 2, 4, 1)
INSERT [dbo].[MatriculaDetalle] ([idMatriculaDetalle], [idMatricula], [idClase], [status]) VALUES (5, 3, 3, 1)
SET IDENTITY_INSERT [dbo].[MatriculaDetalle] OFF
GO
SET IDENTITY_INSERT [dbo].[Periodo] ON 

INSERT [dbo].[Periodo] ([idPeriodo], [nombre], [status]) VALUES (1, N'2022-2', 2)
INSERT [dbo].[Periodo] ([idPeriodo], [nombre], [status]) VALUES (2, N'2023-0', 1)
INSERT [dbo].[Periodo] ([idPeriodo], [nombre], [status]) VALUES (3, N'2023-1', 0)
SET IDENTITY_INSERT [dbo].[Periodo] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idUsuario], [email], [nombre], [apellidoPaterno], [apellidoMaterno], [intentos], [status], [password]) VALUES (1, N'mzapata@upn.pe', N'Manuel', N'Zapata', N'Chavarri', 0, 1, N'xyz123')
INSERT [dbo].[Usuario] ([idUsuario], [email], [nombre], [apellidoPaterno], [apellidoMaterno], [intentos], [status], [password]) VALUES (2, N'ljimenez@gmail.com', N'Liliana', N'Jimenez', N'Romero', 0, 1, N'qwerty')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Aula] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Carrera] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Clase] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Curso] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Estudiante] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Matricula] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[MatriculaDetalle] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Periodo] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD FOREIGN KEY([idAula])
REFERENCES [dbo].[Aula] ([idAula])
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD FOREIGN KEY([idCurso])
REFERENCES [dbo].[Curso] ([idCurso])
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD FOREIGN KEY([idCarrera])
REFERENCES [dbo].[Carrera] ([idCarrera])
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD FOREIGN KEY([idPeriodo])
REFERENCES [dbo].[Periodo] ([idPeriodo])
GO
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD FOREIGN KEY([idCarrera])
REFERENCES [dbo].[Carrera] ([idCarrera])
GO
ALTER TABLE [dbo].[LogsMatriculaDetalle]  WITH CHECK ADD FOREIGN KEY([idMatriculaDetalle])
REFERENCES [dbo].[MatriculaDetalle] ([idMatriculaDetalle])
GO
ALTER TABLE [dbo].[LogsMatriculaDetalle]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[LogsUsuario]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[Estudiante] ([idEstudiante])
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD FOREIGN KEY([idPeriodo])
REFERENCES [dbo].[Periodo] ([idPeriodo])
GO
ALTER TABLE [dbo].[MatriculaDetalle]  WITH CHECK ADD FOREIGN KEY([idClase])
REFERENCES [dbo].[Clase] ([idClase])
GO
ALTER TABLE [dbo].[MatriculaDetalle]  WITH CHECK ADD FOREIGN KEY([idMatricula])
REFERENCES [dbo].[Matricula] ([idMatricula])
GO
/****** Object:  StoredProcedure [dbo].[bloquearAcceso]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[bloquearAcceso]
(@paramEmail nvarchar(50))
as
begin
UPDATE Usuario 
set 
status = 2
where email = @paramEmail
end
GO
/****** Object:  StoredProcedure [dbo].[buscarClase]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarClase]
(@paramIdClase int)
as
begin
SELECT *
FROM Clase 
WHERE idClase = @paramIdClase
end
GO
/****** Object:  StoredProcedure [dbo].[buscarCurso]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarCurso]
(@paramIdCurso int)
as
begin
SELECT *
FROM Curso 
WHERE idCurso = @paramIdCurso
end
GO
/****** Object:  StoredProcedure [dbo].[buscarCursoAnterior]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarCursoAnterior]
(@paramIdCurso int, @paramIdEstudiante int)
as
begin
SELECT cu.idCurso
FROM Curso cu
inner join Clase cl on cu.idCurso = cl.idCurso
inner join MatriculaDetalle md on cl.idClase = md.idClase
inner join Matricula ma on md.idMatricula = ma.idMatricula
inner join Estudiante es on ma.idEstudiante = es.idEstudiante
where cu.idCurso = @paramIdCurso AND es.idEstudiante = @paramIdEstudiante AND md.status = 1 AND ma.status = 2
end
GO
/****** Object:  StoredProcedure [dbo].[buscarCursoMatricula]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarCursoMatricula]
(@paramIdMatricula int, @paramIdCurso int)
as
begin
SELECT cu.idCurso
FROM MatriculaDetalle md
inner join Clase cl on md.idClase = cl.idClase
inner join Curso cu on cl.idCurso = cu.idCurso
where md.idMatricula = @paramIdMatricula AND md.status = 1 AND cu.idCurso = @paramIdCurso
end
GO
/****** Object:  StoredProcedure [dbo].[buscarDetalleClase]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarDetalleClase]
(@paramIdMatricula int, @paramIdClase int)
as
begin
SELECT idMatriculaDetalle
FROM MatriculaDetalle
where idMatricula = @paramIdMatricula AND idClase = @paramIdClase AND status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[buscarEstudiante]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarEstudiante]
(@paramIdEstudiante int)
as
begin
SELECT idEstudiante, codigo, nombre, apellidoPaterno, apellidoMaterno,status
FROM Estudiante 
WHERE idEstudiante = @paramIdEstudiante and status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[buscarEstudianteCarrera]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarEstudianteCarrera]
(@paramIdEstudiante int)
as
begin
SELECT idEstudiante, codigo, nombre, apellidoPaterno, apellidoMaterno,status, idCarrera
FROM Estudiante 
WHERE idEstudiante = @paramIdEstudiante and status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[buscarMatriculaActivaEstudiante]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarMatriculaActivaEstudiante]
(@paramIdEstudiante int)
as
begin
SELECT idMatricula, fechaMatricula, status
FROM Matricula
where idEstudiante = @paramIdEstudiante AND status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[buscarMatriculaEstudiante]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[buscarMatriculaEstudiante]
(@paramIdEstudiante int, @paramIdPeriodo int)
as
begin
SELECT idMatricula, fechaMatricula, status
FROM Matricula
where idEstudiante = @paramIdEstudiante AND idPeriodo = @paramIdPeriodo AND status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[buscarPeriodo]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarPeriodo]
(@paramIdPeriodo int)
as
begin
SELECT *
FROM Periodo 
WHERE idPeriodo = @paramIdPeriodo and status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[buscarUsuario]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarUsuario]
(@paramEmail nvarchar(50))
as
begin
SELECT idUsuario
FROM Usuario
where email = @paramEmail
end
GO
/****** Object:  StoredProcedure [dbo].[cursosMatriculados]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cursosMatriculados]
(@paramIdMatricula int)
as
begin
SELECT cl.idClase, cl.codigo, cl.nombre, cl.horaInicio, cl.horaFin,
cu.idCurso, cu.nombre as nombreCurso, cu.creditos,
a.codigo as codigoAula
FROM Matricula m
inner join MatriculaDetalle md on m.idMatricula = md.idMatricula
inner join Clase cl on md.idClase = cl.idClase
inner join Curso cu on cl.idCurso = cu.idCurso
inner join Aula a on cl.idAula = a.idAula
where m.idMatricula = @paramIdMatricula AND md.status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[eliminarCursoMatriculado]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminarCursoMatriculado]
(@paramIdMatriculaDetalle int)
as
begin
update MatriculaDetalle
set status = 0
where idMatriculaDetalle = @paramIdMatriculaDetalle
end
GO
/****** Object:  StoredProcedure [dbo].[listaClasesCurso]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[listaClasesCurso]
(@paramIdCurso int)
as
begin
SELECT c.idClase, c.codigo, c.nombre, c.horaInicio, c.horaFin, c.status,
a.idAula, a.codigo as codigoAula, a.status as statusAula
FROM Clase c
inner join Aula a on c.idAula = a.idAula
WHERE idCurso = @paramIdCurso AND c.status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[listaEstudiantes]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listaEstudiantes]
as
begin
SELECT e.idEstudiante, e.codigo, e.nombre, e.apellidoPaterno, e.apellidoMaterno,e.status, c.idCarrera, c.nombre as nombreCarrera, c.status as statusCarrera
FROM Estudiante e
inner join Carrera c on e.idCarrera = c.idCarrera
end
GO
/****** Object:  StoredProcedure [dbo].[listaPeriodosActivos]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listaPeriodosActivos]
as
begin
SELECT *
FROM Periodo 
WHERE status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[listCursosCarreraPeriodo]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[listCursosCarreraPeriodo]
(@paramIdCarrera int, @paramIdPeriodo int)
as
begin
SELECT *
FROM Curso 
where idCarrera = @paramIdCarrera and idPeriodo = @paramIdPeriodo
end
GO
/****** Object:  StoredProcedure [dbo].[nuevaMatricula]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[nuevaMatricula]
(@paramFechaMatricula datetime, @paramIdEstudiante int, @paramIdPeriodo int, @paramStatus int)
as
begin
INSERT INTO Matricula (fechaMatricula, idEstudiante, idPeriodo, status)
VALUES (@paramFechaMatricula, @paramIdEstudiante,@paramIdPeriodo,@paramStatus)
SELECT idMatricula
FROM Matricula
where idEstudiante = @paramIdEstudiante AND idPeriodo = @paramIdPeriodo AND status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[nuevaMatriculaDetalle]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[nuevaMatriculaDetalle]
(@paramIdClase int, @paramIdMatricula int, @paramStatus int)
as
begin
INSERT INTO MatriculaDetalle ( idClase, idMatricula, status)
VALUES (@paramIdClase, @paramIdMatricula, @paramStatus)
SELECT idMatriculaDetalle
FROM MatriculaDetalle
where idClase = @paramIdClase AND idMatricula = @paramIdMatricula AND status = 1
end
GO
/****** Object:  StoredProcedure [dbo].[nuevoLogMatriculaDetalle]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[nuevoLogMatriculaDetalle]
(@paramFechaRegistro datetime, @paramAccion int, @paramIdMatriculaDetalle int, @paramIdUsuario int)
as
begin
INSERT INTO LogsMatriculaDetalle ( fechaRegistro, accion, idMatriculaDetalle, idUsuario)
VALUES (@paramFechaRegistro, @paramAccion, @paramIdMatriculaDetalle,@paramIdUsuario )
end
GO
/****** Object:  StoredProcedure [dbo].[nuevoLogUsuario]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[nuevoLogUsuario]
(@paramIdUsuario int, @paramFechaIngreso datetime)
as
begin
INSERT INTO LogsUsuario (idUsuario, fechaIngreso)
VALUES (@paramIdUsuario, @paramFechaIngreso)

end
GO
/****** Object:  StoredProcedure [dbo].[obtenerIntentos]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerIntentos]
(@paramEmail nvarchar(50))
as
begin
SELECT intentos, status
FROM Usuario
where email = @paramEmail
end
GO
/****** Object:  StoredProcedure [dbo].[reiniciarNumeroIntentos]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[reiniciarNumeroIntentos]
(@paramEmail nvarchar(50))
as
begin
UPDATE Usuario 
set 
intentos = 0
where email = @paramEmail
end
GO
/****** Object:  StoredProcedure [dbo].[reporteMatriculas]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[reporteMatriculas]
as
begin
SELECT ma.idMatricula, es.codigo, es.nombre, es.apellidoPaterno, es.apellidoMaterno,
pe.nombre as nombrePeriodo, count(cu.idCurso) as cursosMatriculados,
count(lmd.idLogsMatriculaDetalle) as cantidadAgregados, 
count(lmd2.idLogsMatriculaDetalle) as cantidadEliminados
FROM Matricula ma
inner join Estudiante es on ma.idEstudiante = es.idEstudiante
inner join Periodo pe on ma.idPeriodo = pe.idPeriodo
inner join MatriculaDetalle md on  ma.idMatricula = md.idMatricula
inner join Clase cl on md.idClase = cl.idClase 
left join Curso cu on cl.idCurso = cu.idCurso AND md.status = 1
left join LogsMatriculaDetalle lmd on md.idMatriculaDetalle = lmd.idMatriculaDetalle AND lmd.accion = 1
left join LogsMatriculaDetalle lmd2 on md.idMatriculaDetalle = lmd2.idMatriculaDetalle AND lmd2.accion = 2
where ma.status = 1
group by ma.idMatricula,es.codigo, es.nombre, es.apellidoPaterno, es.apellidoMaterno,pe.nombre 
end
GO
/****** Object:  StoredProcedure [dbo].[sumarIntento]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sumarIntento]
(@paramEmail nvarchar(50))
as
begin
UPDATE Usuario 
set 
intentos = intentos + 1
where email = @paramEmail
end
GO
/****** Object:  StoredProcedure [dbo].[validarLogin]    Script Date: 31/10/2022 11:58:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[validarLogin]
(@paramEmail nvarchar(50), @paramPassword nvarchar(30))
as
begin
SELECT idUsuario, email, nombre, apellidoPaterno, intentos
FROM Usuario
where email = @paramEmail AND password = @paramPassword AND status = 1
end
GO
USE [master]
GO
ALTER DATABASE [matriculasupn2] SET  READ_WRITE 
GO
