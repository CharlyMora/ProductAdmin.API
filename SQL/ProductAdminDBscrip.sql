USE [master]
GO
/****** Object:  Database [ProductAdminDB]    Script Date: 7/19/2021 9:49:39 AM ******/
CREATE DATABASE [ProductAdminDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductAdminDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProductAdminDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductAdminDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProductAdminDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProductAdminDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductAdminDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductAdminDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductAdminDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductAdminDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductAdminDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductAdminDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductAdminDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProductAdminDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductAdminDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductAdminDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductAdminDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductAdminDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductAdminDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductAdminDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductAdminDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductAdminDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProductAdminDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductAdminDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductAdminDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductAdminDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductAdminDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductAdminDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ProductAdminDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductAdminDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductAdminDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProductAdminDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductAdminDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductAdminDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductAdminDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductAdminDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductAdminDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProductAdminDB] SET QUERY_STORE = OFF
GO
USE [ProductAdminDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/19/2021 9:49:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/19/2021 9:49:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[ShortName] [nvarchar](60) NOT NULL,
	[Description] [nvarchar](1500) NOT NULL,
	[ProductType] [int] NOT NULL,
	[Value] [bigint] NOT NULL,
	[BuyDate] [datetime2](7) NOT NULL,
	[ProductStatus] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ProductAdminDB] SET  READ_WRITE 
GO
