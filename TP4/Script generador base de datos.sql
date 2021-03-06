USE [master]
GO
/****** Object:  Database [Lacteos2]    Script Date: 25/7/2021 04:08:59 ******/
CREATE DATABASE [Lacteos2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Lacteos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Lacteos2.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Lacteos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Lacteos2_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Lacteos2] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Lacteos2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Lacteos2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Lacteos2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Lacteos2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Lacteos2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Lacteos2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Lacteos2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Lacteos2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Lacteos2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Lacteos2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Lacteos2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Lacteos2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Lacteos2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Lacteos2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Lacteos2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Lacteos2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Lacteos2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Lacteos2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Lacteos2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Lacteos2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Lacteos2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Lacteos2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Lacteos2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Lacteos2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Lacteos2] SET  MULTI_USER 
GO
ALTER DATABASE [Lacteos2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Lacteos2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Lacteos2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Lacteos2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Lacteos2] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Lacteos2]
GO
/****** Object:  Table [dbo].[Aditivo]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aditivo](
	[idAditivo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Aditivo] PRIMARY KEY CLUSTERED 
(
	[idAditivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
insert into Aditivo
values('Aditivo 1')
GO
insert into Aditivo
values('Aditivo 2')
GO
insert into Aditivo
values('Aditivo 3')
GO
insert into Aditivo
values('Aditivo 4')

GO
/****** Object:  Table [dbo].[Aditivos_lacteos]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aditivos_lacteos](
	[idAditivo] [int] NOT NULL,
	[cantidad] [numeric](4, 2) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[id_lacteo] [int] NOT NULL,
 CONSTRAINT [PK_Aditivos_lacteos] PRIMARY KEY CLUSTERED 
(
	[idAditivo] ASC,
	[cantidad] ASC,
	[tipo] ASC,
	[id_lacteo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InformeEnvasado]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InformeEnvasado](
	[legajoTecnico] [int] NOT NULL,
	[TipoEnvase] [varchar](50) NOT NULL,
	[TemperaturaRefigeracion] [numeric](4, 2) NOT NULL,
	[EtiquetaGenerada] [bit] NOT NULL,
	[ProductoAutorizado] [bit] NOT NULL,
	[InformeAutorizado] [bit] NOT NULL,
	[NroAutorizacion] [int] NOT NULL,
	[idInforme] [int] IDENTITY(1,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL CONSTRAINT [DF_InformeEnvasado_fechaCreacion]  DEFAULT (getdate()),
	[fechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_InformeEnvasado] PRIMARY KEY CLUSTERED 
(
	[idInforme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InformeEstandarizacion]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformeEstandarizacion](
	[idTamizador] [int] NOT NULL,
	[legajoTecnico] [int] NOT NULL,
	[TemperaturaCalentamiento] [numeric](4, 2) NOT NULL,
	[PorcentajeTenorGraso] [numeric](4, 2) NOT NULL,
	[PorcentajeSolidos] [numeric](4, 2) NOT NULL,
	[TemperaturaAutorizada] [bit] NOT NULL,
	[GrasaAutorizada] [bit] NOT NULL,
	[SolidosAutorizados] [bit] NOT NULL,
	[InformeAutorizado] [bit] NOT NULL,
	[idInforme] [int] IDENTITY(1,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL CONSTRAINT [DF_InformeEstandarizacion_fechaCreacion]  DEFAULT (getdate()),
	[fechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_InformeEstandarizacion] PRIMARY KEY CLUSTERED 
(
	[idInforme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InformeIncubacionYMezclado]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformeIncubacionYMezclado](
	[legajoTecnico] [int] NOT NULL,
	[idTanqueIncubacion] [int] NOT NULL,
	[TemperaturaCalentamiento] [numeric](4, 2) NOT NULL,
	[tiempoCalentamiento] [int] NOT NULL,
	[PH] [numeric](4, 2) NOT NULL,
	[Hidrogeno] [numeric](4, 2) NOT NULL,
	[Acidez] [numeric](4, 2) NOT NULL,
	[TemperaturaMezclado] [numeric](4, 2) NOT NULL,
	[calentado] [bit] NOT NULL,
	[inoculado] [bit] NOT NULL,
	[InformeAutorizado] [bit] NOT NULL,
	[mezclado] [bit] NOT NULL,
	[idInforme] [int] IDENTITY(1,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL CONSTRAINT [DF_InformeIncubacionYMezclado_fechaCreacion]  DEFAULT (getdate()),
	[fechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_InformeIncubacionYMezclado] PRIMARY KEY CLUSTERED 
(
	[idInforme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InformeInoculacion]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformeInoculacion](
	[legajoTecnico] [int] NOT NULL,
	[TemperaturaCalentamiento] [numeric](4, 2) NOT NULL,
	[TemperaturaCalentamientoAutorizada] [bit] NOT NULL,
	[TemperaturaEnfriamiento] [numeric](4, 2) NOT NULL,
	[TemperaturaEnfriamientoAutorizada] [bit] NOT NULL,
	[InformeAutorizado] [bit] NOT NULL,
	[MezcladoAutorizado] [bit] NOT NULL,
	[idInforme] [int] IDENTITY(1,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL CONSTRAINT [DF_InformeInoculacion_fechaCreacion]  DEFAULT (getdate()),
	[fechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_InformeInoculacion] PRIMARY KEY CLUSTERED 
(
	[idInforme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InformePasteurizado]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InformePasteurizado](
	[legajoTecnico] [int] NOT NULL,
	[TemperaturaCalentamiento] [numeric](4, 2) NOT NULL,
	[PasteurizacionAutorizada] [bit] NOT NULL,
	[TemperaturaEnfriamiento] [numeric](4, 2) NOT NULL,
	[TemperaturaEnfriamientoAutorizada] [bit] NOT NULL,
	[InformeAutorizado] [bit] NOT NULL,
	[MetodoPasteurizacion] [varchar](50) NULL,
	[idInforme] [int] IDENTITY(1,1) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL CONSTRAINT [DF_InformePasteurizado_fechaCreacion]  DEFAULT (getdate()),
	[fechaModificacion] [datetime] NULL,
	[IdOllaPasteurizacion] [int] NOT NULL CONSTRAINT [DF_InformePasteurizado_IdOllaPasteurizacion]  DEFAULT ((1)),
 CONSTRAINT [PK_InformePasteurizado] PRIMARY KEY CLUSTERED 
(
	[idInforme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lacteo]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lacteo](
	[TipoProducto] [varchar](100) NOT NULL,
	[IdMateriaPrima] [int] NOT NULL,
	[IdLacteo] [int] IDENTITY(1,1) NOT NULL,
	[estandarizado] [bit] NOT NULL CONSTRAINT [DF_Lacteo_estandarizado]  DEFAULT ((0)),
	[idInformeEstandarizado] [int] NULL,
	[inoculado] [bit] NOT NULL CONSTRAINT [DF_Lacteo_inoculado]  DEFAULT ((0)),
	[idInformeInoculacion] [int] NULL,
	[pasteurizado] [bit] NOT NULL CONSTRAINT [DF_Lacteo_pasteurizado]  DEFAULT ((0)),
	[IdInformePasteurizacion] [int] NULL,
	[incubadoyMezclado] [bit] NOT NULL CONSTRAINT [DF_Lacteo_incubadoyMezclado]  DEFAULT ((0)),
	[IdInformeIncubadoYMezclado] [int] NULL,
	[envasado] [bit] NOT NULL CONSTRAINT [DF_Lacteo_envasado]  DEFAULT ((0)),
	[IdInformeEnvasado] [int] NULL,
	[fechaCreacion] [datetime] NOT NULL CONSTRAINT [DF_Lacteo_fechaCreacion]  DEFAULT (getdate()),
	[fechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Lacteo] PRIMARY KEY CLUSTERED 
(
	[IdLacteo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MateriaPrima]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MateriaPrima](
	[idMateriaPrima] [int] IDENTITY(1,1) NOT NULL,
	[idTanque] [int] NOT NULL,
	[IdTampo] [int] NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[IndiceAcidez] [int] NOT NULL,
	[legajoTecnicoHab] [int] NOT NULL,
	[habilitadoFabrica] [bit] NOT NULL,
	[idCertificado] [int] NULL,
 CONSTRAINT [PK_MateriaPrima] PRIMARY KEY CLUSTERED 
(
	[idMateriaPrima] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personal](
	[legajo] [int] NOT NULL,
	[dni] [int] NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[apellido] [nvarchar](100) NOT NULL,
	[cargo] [nvarchar](100) NOT NULL,
	[genero] [char](1) NOT NULL,
	[esTecnico] [bit] NOT NULL CONSTRAINT [DF_Personal_esTecnico]  DEFAULT ((0)),
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tambo]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tambo](
	[idTambo] [int] NOT NULL,
	[descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Tambo] PRIMARY KEY CLUSTERED 
(
	[idTambo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tamizador]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tamizador](
	[idTamizador] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Tamizadores] PRIMARY KEY CLUSTERED 
(
	[idTamizador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tanque]    Script Date: 25/7/2021 04:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tanque](
	[idTanque] [int] NOT NULL,
	[descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Tanque] PRIMARY KEY CLUSTERED 
(
	[idTanque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Aditivos_lacteos]  WITH CHECK ADD  CONSTRAINT [FK_Aditivos_lacteos_Aditivo] FOREIGN KEY([idAditivo])
REFERENCES [dbo].[Aditivo] ([idAditivo])
GO
ALTER TABLE [dbo].[Aditivos_lacteos] CHECK CONSTRAINT [FK_Aditivos_lacteos_Aditivo]
GO
ALTER TABLE [dbo].[Aditivos_lacteos]  WITH CHECK ADD  CONSTRAINT [FK_Aditivos_lacteos_Lacteo] FOREIGN KEY([id_lacteo])
REFERENCES [dbo].[Lacteo] ([IdLacteo])
GO
ALTER TABLE [dbo].[Aditivos_lacteos] CHECK CONSTRAINT [FK_Aditivos_lacteos_Lacteo]
GO
ALTER TABLE [dbo].[InformeEnvasado]  WITH CHECK ADD  CONSTRAINT [FK_InformeEnvasado_Personal] FOREIGN KEY([legajoTecnico])
REFERENCES [dbo].[Personal] ([legajo])
GO
ALTER TABLE [dbo].[InformeEnvasado] CHECK CONSTRAINT [FK_InformeEnvasado_Personal]
GO
ALTER TABLE [dbo].[InformeEstandarizacion]  WITH CHECK ADD  CONSTRAINT [FK_InformeEstandarizacion_Personal] FOREIGN KEY([legajoTecnico])
REFERENCES [dbo].[Personal] ([legajo])
GO
ALTER TABLE [dbo].[InformeEstandarizacion] CHECK CONSTRAINT [FK_InformeEstandarizacion_Personal]
GO
ALTER TABLE [dbo].[InformeEstandarizacion]  WITH CHECK ADD  CONSTRAINT [FK_InformeEstandarizacion_Tamizador] FOREIGN KEY([idTamizador])
REFERENCES [dbo].[Tamizador] ([idTamizador])
GO
ALTER TABLE [dbo].[InformeEstandarizacion] CHECK CONSTRAINT [FK_InformeEstandarizacion_Tamizador]
GO
ALTER TABLE [dbo].[InformeIncubacionYMezclado]  WITH CHECK ADD  CONSTRAINT [FK_InformeIncubacionYMezclado_Personal] FOREIGN KEY([legajoTecnico])
REFERENCES [dbo].[Personal] ([legajo])
GO
ALTER TABLE [dbo].[InformeIncubacionYMezclado] CHECK CONSTRAINT [FK_InformeIncubacionYMezclado_Personal]
GO
ALTER TABLE [dbo].[InformeInoculacion]  WITH CHECK ADD  CONSTRAINT [FK_InformeInoculacion_Personal] FOREIGN KEY([legajoTecnico])
REFERENCES [dbo].[Personal] ([legajo])
GO
ALTER TABLE [dbo].[InformeInoculacion] CHECK CONSTRAINT [FK_InformeInoculacion_Personal]
GO
ALTER TABLE [dbo].[InformePasteurizado]  WITH CHECK ADD  CONSTRAINT [FK_InformePasteurizado_Personal] FOREIGN KEY([legajoTecnico])
REFERENCES [dbo].[Personal] ([legajo])
GO
ALTER TABLE [dbo].[InformePasteurizado] CHECK CONSTRAINT [FK_InformePasteurizado_Personal]
GO
Insert Tambo
values(1,'Tambo 1')
GO
Insert Tambo
values(2,'Tambo 2')
GO
Insert Tambo
values(3,'Tambo 3')
GO
Insert Tambo
values(4,'Tambo 4')
GO
Insert Tambo
values(5,'Tambo 5')
GO
Insert Tambo
values(6,'Tambo 6')
GO
Insert Tanque
values(1,'Tanque 1')
GO
Insert Tanque
values(2,'Tanque 2')
GO
Insert Tanque
values(3,'Tanque 3')
GO
Insert Tanque
values(4,'Tanque 4')
GO
Insert Tanque
values(5,'Tanque 5')
GO
Insert Tanque
values(6,'Tanque 6')
GO
INSERT INTO [dbo].[Tamizador] ([descripcion])
VALUES ('Tamizador 1')
GO
INSERT INTO [dbo].[Tamizador] ([descripcion])
VALUES ('Tamizador 2')
GO
INSERT INTO [dbo].[Tamizador] ([descripcion])
VALUES ('Tamizador 3')
GO
INSERT INTO [dbo].[Tamizador] ([descripcion])
VALUES ('Tamizador 4')
GO
INSERT INTO [dbo].[Tamizador] ([descripcion])
VALUES ('Tamizador 5')
GO
INSERT INTO [dbo].[Tamizador] ([descripcion])
VALUES ('Tamizador 6')
GO
USE [master]
GO
ALTER DATABASE [Lacteos2] SET  READ_WRITE 
GO