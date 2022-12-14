USE [master]
GO
/****** Object:  Database [StrukovCharitableFoundation]    Script Date: 12.02.2021 23:57:27 ******/
CREATE DATABASE [StrukovCharitableFoundation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StrukovCharitableFoundation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StrukovCharitableFoundation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StrukovCharitableFoundation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StrukovCharitableFoundation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [StrukovCharitableFoundation] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StrukovCharitableFoundation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StrukovCharitableFoundation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET ARITHABORT OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET  MULTI_USER 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StrukovCharitableFoundation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StrukovCharitableFoundation] SET QUERY_STORE = OFF
GO
USE [StrukovCharitableFoundation]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 12.02.2021 23:57:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[id] [int] NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[question] [nvarchar](150) NOT NULL,
	[answer] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[USER] ([id], [login], [password], [question], [answer]) VALUES (1, N'admin', N'admin', N'admin?', N'admin!')
INSERT [dbo].[USER] ([id], [login], [password], [question], [answer]) VALUES (2, N'aa', N'bb', N'aa?', N'aa!')
INSERT [dbo].[USER] ([id], [login], [password], [question], [answer]) VALUES (3, N'gg', N'gg', N'gg?', N'gg!')
INSERT [dbo].[USER] ([id], [login], [password], [question], [answer]) VALUES (4, N'ff', N'ff', N'ff?', N'ff!')
INSERT [dbo].[USER] ([id], [login], [password], [question], [answer]) VALUES (5, N'test', N'test111', N'testtt?', N'test!')
GO
USE [master]
GO
ALTER DATABASE [StrukovCharitableFoundation] SET  READ_WRITE 
GO
