USE [master]
GO
/****** Object:  Database [ProjectManagementSystem]    Script Date: 3/30/2021 2:08:53 PM ******/
CREATE DATABASE [ProjectManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectManagementSystem', FILENAME = N'E:\Program Files (x86)\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectManagementSystem_log', FILENAME = N'E:\Program Files (x86)\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjectManagementSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectManagementSystem', N'ON'
GO
ALTER DATABASE [ProjectManagementSystem] SET QUERY_STORE = OFF
GO
USE [ProjectManagementSystem]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 3/30/2021 2:08:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectCode] [varchar](50) NOT NULL,
	[Name] [varchar](50) NULL,
	[ProjectManager] [varchar](50) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 3/30/2021 2:08:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskID] [int] NOT NULL,
	[ProjectCode] [varchar](50) NOT NULL,
	[Assignee] [varchar](50) NULL,
	[Status] [int] NULL,
	[Progress] [decimal](18, 2) NULL,
	[Deadline] [datetime] NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC,
	[ProjectCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/30/2021 2:08:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Surname] [varchar](50) NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Users] FOREIGN KEY([ProjectManager])
REFERENCES [dbo].[Users] ([Username])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Users]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Project] FOREIGN KEY([ProjectCode])
REFERENCES [dbo].[Project] ([ProjectCode])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Project]
GO
USE [master]
GO
ALTER DATABASE [ProjectManagementSystem] SET  READ_WRITE 
GO
