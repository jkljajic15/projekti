USE [master]
GO

/****** Object:  Database [EntityDB]    Script Date: 27-May-18 00:18:28 ******/
CREATE DATABASE [EntityDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EntityDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\EntityDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EntityDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\EntityDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [EntityDB] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EntityDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [EntityDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EntityDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EntityDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EntityDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EntityDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [EntityDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [EntityDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EntityDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EntityDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EntityDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EntityDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EntityDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EntityDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EntityDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EntityDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [EntityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EntityDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EntityDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EntityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EntityDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EntityDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [EntityDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EntityDB] SET RECOVERY FULL 
GO

ALTER DATABASE [EntityDB] SET  MULTI_USER 
GO

ALTER DATABASE [EntityDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EntityDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [EntityDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [EntityDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [EntityDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [EntityDB] SET QUERY_STORE = OFF
GO

USE [EntityDB]
GO

ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [EntityDB] SET  READ_WRITE 
GO


USE [EntityDB]
GO

/****** Object:  Table [dbo].[Predmet]    Script Date: 27-May-18 00:19:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Predmet](
	[PredmetID] [int] NOT NULL,
	[NaizvPredmeta] [nvarchar](50) NOT NULL,
	[SmerID] [int] NOT NULL,
 CONSTRAINT [PK_Predmet] PRIMARY KEY CLUSTERED 
(
	[PredmetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Predmet]  WITH CHECK ADD  CONSTRAINT [FK_Predmet_Smer] FOREIGN KEY([SmerID])
REFERENCES [dbo].[Smer] ([SmerID])
GO

ALTER TABLE [dbo].[Predmet] CHECK CONSTRAINT [FK_Predmet_Smer]
GO

/****** Object:  Table [dbo].[Smer]    Script Date: 27-May-18 00:20:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Smer](
	[SmerID] [int] NOT NULL,
	[NazivSmera] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Smer] PRIMARY KEY CLUSTERED 
(
	[SmerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Student]    Script Date: 27-May-18 00:20:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student](
	[StudentID] [int] NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[SmerID] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Smer] FOREIGN KEY([SmerID])
REFERENCES [dbo].[Smer] ([SmerID])
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Smer]
GO


