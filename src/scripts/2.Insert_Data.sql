USE [UniDatabase]
GO
SET IDENTITY_INSERT [dbo].[Asignatura] ON 

INSERT [dbo].[Asignatura] ([Id], [Nombre], [Codigo], [CantidadCreditosNecesarios]) VALUES (1, N'Investigación de Operaciones', N'AA001', 3)
INSERT [dbo].[Asignatura] ([Id], [Nombre], [Codigo], [CantidadCreditosNecesarios]) VALUES (2, N'Prácticas', N'AA002', 3)
INSERT [dbo].[Asignatura] ([Id], [Nombre], [Codigo], [CantidadCreditosNecesarios]) VALUES (3, N'Business Intelligence', N'AA003', 3)
INSERT [dbo].[Asignatura] ([Id], [Nombre], [Codigo], [CantidadCreditosNecesarios]) VALUES (4, N'Administración de Bases de Datos', N'AA004', 3)
INSERT [dbo].[Asignatura] ([Id], [Nombre], [Codigo], [CantidadCreditosNecesarios]) VALUES (5, N'Seguridad Informática', N'AA005', 3)
INSERT [dbo].[Asignatura] ([Id], [Nombre], [Codigo], [CantidadCreditosNecesarios]) VALUES (6, N'Legislación en la Informática', N'AA006', 3)
INSERT [dbo].[Asignatura] ([Id], [Nombre], [Codigo], [CantidadCreditosNecesarios]) VALUES (7, N'Informática Forense', N'AA007', 3)
INSERT [dbo].[Asignatura] ([Id], [Nombre], [Codigo], [CantidadCreditosNecesarios]) VALUES (8, N'Matemáticas Discretas', N'AA008', 3)
INSERT [dbo].[Asignatura] ([Id], [Nombre], [Codigo], [CantidadCreditosNecesarios]) VALUES (9, N'Optativa II', N'AA009', 3)
INSERT [dbo].[Asignatura] ([Id], [Nombre], [Codigo], [CantidadCreditosNecesarios]) VALUES (10, N'Optativa III', N'AA010', 3)
SET IDENTITY_INSERT [dbo].[Asignatura] OFF
GO
SET IDENTITY_INSERT [dbo].[PeriodoAcademico] ON 

INSERT [dbo].[PeriodoAcademico] ([Id], [Periodo], [Activo]) VALUES (1, N'2025 - 01', 1)
SET IDENTITY_INSERT [dbo].[PeriodoAcademico] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Nombre], [Documento]) VALUES (1, N'Juan David Mojica', N'1021321123')
INSERT [dbo].[Usuario] ([Id], [Nombre], [Documento]) VALUES (2, N'Nicolas Ospina', N'56321123')
INSERT [dbo].[Usuario] ([Id], [Nombre], [Documento]) VALUES (3, N'Gina Savino', N'72321123')
INSERT [dbo].[Usuario] ([Id], [Nombre], [Documento]) VALUES (4, N'Daniel Suavita', N'1010123321')
INSERT [dbo].[Usuario] ([Id], [Nombre], [Documento]) VALUES (5, N'Juan Andrés Ospina', N'56312213')
INSERT [dbo].[Usuario] ([Id], [Nombre], [Documento]) VALUES (6, N'Esteban Ibarra Villota', N'1011221223')
INSERT [dbo].[Usuario] ([Id], [Nombre], [Documento]) VALUES (9, N'Dana Saravena', N'1010456654')
INSERT [dbo].[Usuario] ([Id], [Nombre], [Documento]) VALUES (10, N'Romina Smith', N'1010987789')
INSERT [dbo].[Usuario] ([Id], [Nombre], [Documento]) VALUES (11, N'Adam Vespucio', N'1010963369')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Matricula] ON 

INSERT [dbo].[Matricula] ([Id], [CreditosInscritos], [IdEstudiante], [IdPeriodoAcademico]) VALUES (5, 9, 4, 1)
INSERT [dbo].[Matricula] ([Id], [CreditosInscritos], [IdEstudiante], [IdPeriodoAcademico]) VALUES (6, 6, 9, 1)
INSERT [dbo].[Matricula] ([Id], [CreditosInscritos], [IdEstudiante], [IdPeriodoAcademico]) VALUES (7, 3, 10, 1)
SET IDENTITY_INSERT [dbo].[Matricula] OFF
GO
SET IDENTITY_INSERT [dbo].[AsignaturasMatricula] ON 

INSERT [dbo].[AsignaturasMatricula] ([Id], [IdAsignatura], [IdMatricula], [IdProfesor]) VALUES (10, 1, 5, 1)
INSERT [dbo].[AsignaturasMatricula] ([Id], [IdAsignatura], [IdMatricula], [IdProfesor]) VALUES (11, 4, 5, 2)
INSERT [dbo].[AsignaturasMatricula] ([Id], [IdAsignatura], [IdMatricula], [IdProfesor]) VALUES (12, 8, 5, 5)
INSERT [dbo].[AsignaturasMatricula] ([Id], [IdAsignatura], [IdMatricula], [IdProfesor]) VALUES (13, 1, 6, 1)
INSERT [dbo].[AsignaturasMatricula] ([Id], [IdAsignatura], [IdMatricula], [IdProfesor]) VALUES (14, 9, 6, 6)
INSERT [dbo].[AsignaturasMatricula] ([Id], [IdAsignatura], [IdMatricula], [IdProfesor]) VALUES (15, 1, 7, 1)
SET IDENTITY_INSERT [dbo].[AsignaturasMatricula] OFF
GO
SET IDENTITY_INSERT [dbo].[AsignaturasProfesor] ON 

INSERT [dbo].[AsignaturasProfesor] ([Id], [IdProfesor], [IdAsignatura]) VALUES (1, 1, 1)
INSERT [dbo].[AsignaturasProfesor] ([Id], [IdProfesor], [IdAsignatura]) VALUES (2, 1, 2)
INSERT [dbo].[AsignaturasProfesor] ([Id], [IdProfesor], [IdAsignatura]) VALUES (3, 2, 3)
INSERT [dbo].[AsignaturasProfesor] ([Id], [IdProfesor], [IdAsignatura]) VALUES (4, 2, 4)
INSERT [dbo].[AsignaturasProfesor] ([Id], [IdProfesor], [IdAsignatura]) VALUES (5, 3, 5)
INSERT [dbo].[AsignaturasProfesor] ([Id], [IdProfesor], [IdAsignatura]) VALUES (6, 3, 6)
INSERT [dbo].[AsignaturasProfesor] ([Id], [IdProfesor], [IdAsignatura]) VALUES (7, 5, 7)
INSERT [dbo].[AsignaturasProfesor] ([Id], [IdProfesor], [IdAsignatura]) VALUES (8, 5, 8)
INSERT [dbo].[AsignaturasProfesor] ([Id], [IdProfesor], [IdAsignatura]) VALUES (9, 6, 9)
INSERT [dbo].[AsignaturasProfesor] ([Id], [IdProfesor], [IdAsignatura]) VALUES (10, 6, 10)
SET IDENTITY_INSERT [dbo].[AsignaturasProfesor] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([Id], [Rol]) VALUES (1, N'Estudiante')
INSERT [dbo].[Rol] ([Id], [Rol]) VALUES (2, N'Profesor')
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioRol] ON 

INSERT [dbo].[UsuarioRol] ([Id], [IdUsuario], [IdRol]) VALUES (1, 1, 2)
INSERT [dbo].[UsuarioRol] ([Id], [IdUsuario], [IdRol]) VALUES (2, 2, 2)
INSERT [dbo].[UsuarioRol] ([Id], [IdUsuario], [IdRol]) VALUES (3, 3, 2)
INSERT [dbo].[UsuarioRol] ([Id], [IdUsuario], [IdRol]) VALUES (4, 4, 1)
INSERT [dbo].[UsuarioRol] ([Id], [IdUsuario], [IdRol]) VALUES (7, 9, 1)
INSERT [dbo].[UsuarioRol] ([Id], [IdUsuario], [IdRol]) VALUES (8, 10, 1)
INSERT [dbo].[UsuarioRol] ([Id], [IdUsuario], [IdRol]) VALUES (9, 11, 1)
SET IDENTITY_INSERT [dbo].[UsuarioRol] OFF
GO
SET IDENTITY_INSERT [dbo].[Creditos] ON 

INSERT [dbo].[Creditos] ([Id], [Cantidad], [IdUsuario]) VALUES (1, 0, 4)
INSERT [dbo].[Creditos] ([Id], [Cantidad], [IdUsuario]) VALUES (4, 3, 9)
INSERT [dbo].[Creditos] ([Id], [Cantidad], [IdUsuario]) VALUES (5, 6, 10)
INSERT [dbo].[Creditos] ([Id], [Cantidad], [IdUsuario]) VALUES (6, 9, 11)
SET IDENTITY_INSERT [dbo].[Creditos] OFF
GO
