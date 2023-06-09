USE [master]
GO
/****** Object:  Database [GestorUsuarios]    Script Date: 26/05/2023 10:13:44 a. m. ******/
CREATE DATABASE [GestorUsuarios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GestorUsuarios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GestorUsuarios.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GestorUsuarios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GestorUsuarios_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GestorUsuarios] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestorUsuarios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestorUsuarios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestorUsuarios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestorUsuarios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestorUsuarios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestorUsuarios] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestorUsuarios] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GestorUsuarios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestorUsuarios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestorUsuarios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestorUsuarios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestorUsuarios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestorUsuarios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestorUsuarios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestorUsuarios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestorUsuarios] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GestorUsuarios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestorUsuarios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestorUsuarios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestorUsuarios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestorUsuarios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestorUsuarios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestorUsuarios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestorUsuarios] SET RECOVERY FULL 
GO
ALTER DATABASE [GestorUsuarios] SET  MULTI_USER 
GO
ALTER DATABASE [GestorUsuarios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestorUsuarios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestorUsuarios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestorUsuarios] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestorUsuarios] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GestorUsuarios] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GestorUsuarios', N'ON'
GO
ALTER DATABASE [GestorUsuarios] SET QUERY_STORE = OFF
GO
USE [GestorUsuarios]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 26/05/2023 10:13:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Sexo] [char](1) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nombre], [FechaNacimiento], [Sexo]) VALUES (24, N'Adrian', CAST(N'2015-08-06' AS Date), N'M')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [FechaNacimiento], [Sexo]) VALUES (25, N'Yulieth', CAST(N'1992-10-02' AS Date), N'F')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [FechaNacimiento], [Sexo]) VALUES (26, N'Dani', CAST(N'2015-10-02' AS Date), N'M')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [FechaNacimiento], [Sexo]) VALUES (27, N'Andres C', CAST(N'2023-05-26' AS Date), N'F')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [FechaNacimiento], [Sexo]) VALUES (28, N'64', CAST(N'2023-05-26' AS Date), N'M')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  StoredProcedure [dbo].[UsuariosAdd]    Script Date: 26/05/2023 10:13:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsuariosAdd]
(
	@Nombre	varchar(150),
	@FechaNacimiento date,
	@Sexo char(1)
)

as
begin
set nocount on


	/*
	if (select count(*) from Producto where Sku = @Sku) >0 
	begin
		raiserror('El Sku ya existe',16,1);
		return -1
	end
	*/

	insert into	Usuarios(
				Nombre,
				FechaNacimiento,
				Sexo
				)
	values		(
				@Nombre,
				@FechaNacimiento,--getdate(),--@FechaNacimiento,				
				@Sexo
				)
end;
GO
/****** Object:  StoredProcedure [dbo].[UsuariosDelete]    Script Date: 26/05/2023 10:13:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[UsuariosDelete]
(
	@id int
)
as
begin
set nocount on

	Delete
	from	Usuarios
	where	Id = @id

end;
GO
/****** Object:  StoredProcedure [dbo].[UsuariosGet]    Script Date: 26/05/2023 10:13:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UsuariosGet]


as
begin
--set nocount on
	select	Id,
			Nombre,
			FechaNacimiento,
			Sexo
	from	Usuarios	

end;
GO
/****** Object:  StoredProcedure [dbo].[UsuariosGetxId]    Script Date: 26/05/2023 10:13:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[UsuariosGetxId]
(
	@id int
)
as
begin
set nocount on

	select	Id,
			Nombre,
			FechaNacimiento,			
			Sexo
	from	Usuarios
	where	Id = @id

end;
GO
/****** Object:  StoredProcedure [dbo].[UsuariosUpdate]    Script Date: 26/05/2023 10:13:45 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[UsuariosUpdate]
(
	@Id int,
	@Nombre	varchar(100),
	@FechaNacimiento date,
	@Sexo char(1)
)
as
Begin
	
	update	Usuarios
	set		Nombre = @Nombre,
			FechaNacimiento = @FechaNacimiento,--GETDATE(),
			Sexo = @Sexo
	where	Id = @Id

End;
GO
USE [master]
GO
ALTER DATABASE [GestorUsuarios] SET  READ_WRITE 
GO
