USE [master]
GO
/****** Object:  Database [Lacteos]    Script Date: 12/7/2021 00:02:58 ******/
CREATE DATABASE [Lacteos]
GO
ALTER DATABASE [Lacteos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Lacteos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Lacteos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Lacteos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Lacteos] SET ARITHABORT OFF 
GO
ALTER DATABASE [Lacteos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Lacteos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Lacteos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Lacteos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Lacteos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Lacteos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Lacteos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Lacteos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Lacteos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Lacteos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Lacteos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Lacteos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Lacteos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Lacteos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Lacteos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Lacteos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Lacteos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Lacteos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Lacteos] SET  MULTI_USER 
GO
ALTER DATABASE [Lacteos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Lacteos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Lacteos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Lacteos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Lacteos] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Lacteos]
GO
/****** Object:  Table [dbo].[Aditivo]    Script Date: 12/7/2021 00:02:58 ******/
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
/****** Object:  Table [dbo].[Lacteo]    Script Date: 12/7/2021 00:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lacteo](
	[TipoProducto] [varchar](100) NOT NULL,
	[IdMateriaPrima] [int] NOT NULL,
	[IdLacteo] [int] NOT NULL,
	[idOllaPasteurizacion] [int] NOT NULL,
	[metodoPasteurizacion] [nvarchar](100) NOT NULL,
	[estandarizado] [bit] NOT NULL,
	[pasteurizado] [bit] NOT NULL,
	[enfriado] [bit] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MateriaPrima]    Script Date: 12/7/2021 00:02:58 ******/
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
/****** Object:  Table [dbo].[Tambo]    Script Date: 12/7/2021 00:02:58 ******/
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
/****** Object:  Table [dbo].[Tanque]    Script Date: 12/7/2021 00:02:58 ******/
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
USE [master]
GO
ALTER DATABASE [Lacteos] SET  READ_WRITE 
GO

