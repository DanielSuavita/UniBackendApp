USE [master]
GO
/****** Object:  Database [UniDatabase]    Script Date: 10/01/2025 21:43:01 ******/
CREATE DATABASE [UniDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniDatabase', FILENAME = N'C:\Users\Janus\UniDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UniDatabase_log', FILENAME = N'C:\Users\Janus\UniDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UniDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [UniDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UniDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UniDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [UniDatabase] SET QUERY_STORE = OFF
GO
USE [UniDatabase]
GO
/****** Object:  Table [dbo].[Asignatura]    Script Date: 10/01/2025 21:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignatura](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[Codigo] [varchar](50) NULL,
	[CantidadCreditosNecesarios] [int] NULL,
 CONSTRAINT [PK_Asignatura] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsignaturasMatricula]    Script Date: 10/01/2025 21:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignaturasMatricula](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdAsignatura] [bigint] NOT NULL,
	[IdMatricula] [bigint] NOT NULL,
	[IdProfesor] [bigint] NOT NULL,
 CONSTRAINT [PK_AsignaturasMatricula] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsignaturasProfesor]    Script Date: 10/01/2025 21:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignaturasProfesor](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdProfesor] [bigint] NOT NULL,
	[IdAsignatura] [bigint] NOT NULL,
 CONSTRAINT [PK_AsignaturasProfesor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Creditos]    Script Date: 10/01/2025 21:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Creditos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NULL,
	[IdUsuario] [bigint] NOT NULL,
 CONSTRAINT [PK_Creditos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 10/01/2025 21:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreditosInscritos] [int] NULL,
	[IdEstudiante] [bigint] NOT NULL,
	[IdPeriodoAcademico] [bigint] NOT NULL,
 CONSTRAINT [PK_Matricula] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeriodoAcademico]    Script Date: 10/01/2025 21:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeriodoAcademico](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Periodo] [varchar](100) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_PeriodoAcademico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 10/01/2025 21:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](100) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/01/2025 21:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[Documento] [varchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioRol]    Script Date: 10/01/2025 21:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRol](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
	[IdRol] [bigint] NOT NULL,
 CONSTRAINT [PK_UsuarioRol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PeriodoAcademico] ADD  DEFAULT ((0)) FOR [Activo]
GO
ALTER TABLE [dbo].[AsignaturasMatricula]  WITH CHECK ADD  CONSTRAINT [FK_Asignatura_TO_AsignaturasMatricula] FOREIGN KEY([IdAsignatura])
REFERENCES [dbo].[Asignatura] ([Id])
GO
ALTER TABLE [dbo].[AsignaturasMatricula] CHECK CONSTRAINT [FK_Asignatura_TO_AsignaturasMatricula]
GO
ALTER TABLE [dbo].[AsignaturasMatricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_TO_AsignaturasMatricula] FOREIGN KEY([IdMatricula])
REFERENCES [dbo].[Matricula] ([Id])
GO
ALTER TABLE [dbo].[AsignaturasMatricula] CHECK CONSTRAINT [FK_Matricula_TO_AsignaturasMatricula]
GO
ALTER TABLE [dbo].[AsignaturasMatricula]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TO_AsignaturasMatricula] FOREIGN KEY([IdProfesor])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[AsignaturasMatricula] CHECK CONSTRAINT [FK_Usuario_TO_AsignaturasMatricula]
GO
ALTER TABLE [dbo].[AsignaturasProfesor]  WITH CHECK ADD  CONSTRAINT [FK_Asignatura_TO_AsignaturasProfesor] FOREIGN KEY([IdAsignatura])
REFERENCES [dbo].[Asignatura] ([Id])
GO
ALTER TABLE [dbo].[AsignaturasProfesor] CHECK CONSTRAINT [FK_Asignatura_TO_AsignaturasProfesor]
GO
ALTER TABLE [dbo].[AsignaturasProfesor]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TO_AsignaturasProfesor] FOREIGN KEY([IdProfesor])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[AsignaturasProfesor] CHECK CONSTRAINT [FK_Usuario_TO_AsignaturasProfesor]
GO
ALTER TABLE [dbo].[Creditos]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TO_Creditos] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Creditos] CHECK CONSTRAINT [FK_Usuario_TO_Creditos]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_PeriodoAcademico_TO_Matricula] FOREIGN KEY([IdPeriodoAcademico])
REFERENCES [dbo].[PeriodoAcademico] ([Id])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_PeriodoAcademico_TO_Matricula]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TO_Matricula] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Usuario_TO_Matricula]
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_Rol_TO_UsuarioRol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[UsuarioRol] CHECK CONSTRAINT [FK_Rol_TO_UsuarioRol]
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TO_UsuarioRol] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsuarioRol] CHECK CONSTRAINT [FK_Usuario_TO_UsuarioRol]
GO
USE [master]
GO
ALTER DATABASE [UniDatabase] SET  READ_WRITE 
GO
