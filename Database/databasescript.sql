USE [master]
GO
/****** Object:  Database [ExpenseManagement]    Script Date: 10-05-2022 21:02:22 ******/
CREATE DATABASE [ExpenseManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExpenseManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ExpenseManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExpenseManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ExpenseManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ExpenseManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExpenseManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExpenseManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExpenseManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExpenseManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExpenseManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExpenseManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExpenseManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExpenseManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExpenseManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExpenseManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExpenseManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExpenseManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExpenseManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExpenseManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExpenseManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExpenseManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ExpenseManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExpenseManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExpenseManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExpenseManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExpenseManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExpenseManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExpenseManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExpenseManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ExpenseManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ExpenseManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExpenseManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExpenseManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExpenseManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExpenseManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ExpenseManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ExpenseManagement] SET QUERY_STORE = OFF
GO
USE [ExpenseManagement]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 10-05-2022 21:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[UserId] [numeric](18, 0) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserEmail] [varchar](50) NOT NULL,
	[UserPassword] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expense]    Script Date: 10-05-2022 21:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expense](
	[ExpenseId] [numeric](18, 0) NOT NULL,
	[ExpenseName] [varchar](50) NOT NULL,
	[ExpenseDate] [date] NOT NULL,
	[ExpenseAmount] [numeric](18, 0) NOT NULL,
	[UserId] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED 
(
	[ExpenseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Income]    Script Date: 10-05-2022 21:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Income](
	[IncomeId] [numeric](18, 0) NOT NULL,
	[IncomeName] [varchar](50) NOT NULL,
	[IncomeAmount] [numeric](18, 0) NOT NULL,
	[IncomeDate] [date] NOT NULL,
	[UserId] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Income] PRIMARY KEY CLUSTERED 
(
	[IncomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Client] FOREIGN KEY([UserId])
REFERENCES [dbo].[Client] ([UserId])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Client]
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_Client] FOREIGN KEY([ExpenseId])
REFERENCES [dbo].[Client] ([UserId])
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_Client]
GO
ALTER TABLE [dbo].[Income]  WITH CHECK ADD  CONSTRAINT [FK_Income_Client] FOREIGN KEY([UserId])
REFERENCES [dbo].[Client] ([UserId])
GO
ALTER TABLE [dbo].[Income] CHECK CONSTRAINT [FK_Income_Client]
GO
USE [master]
GO
ALTER DATABASE [ExpenseManagement] SET  READ_WRITE 
GO
