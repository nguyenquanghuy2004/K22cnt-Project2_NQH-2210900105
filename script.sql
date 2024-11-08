USE [master]
GO
/****** Object:  Database [webcuahangthethao]    Script Date: 03/11/2024 11:54:47 CH ******/
CREATE DATABASE [webcuahangthethao]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'webcuahangthethao', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQL123\MSSQL\DATA\webcuahangthethao.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'webcuahangthethao_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQL123\MSSQL\DATA\webcuahangthethao_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [webcuahangthethao] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [webcuahangthethao].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [webcuahangthethao] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [webcuahangthethao] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [webcuahangthethao] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [webcuahangthethao] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [webcuahangthethao] SET ARITHABORT OFF 
GO
ALTER DATABASE [webcuahangthethao] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [webcuahangthethao] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [webcuahangthethao] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [webcuahangthethao] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [webcuahangthethao] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [webcuahangthethao] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [webcuahangthethao] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [webcuahangthethao] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [webcuahangthethao] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [webcuahangthethao] SET  DISABLE_BROKER 
GO
ALTER DATABASE [webcuahangthethao] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [webcuahangthethao] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [webcuahangthethao] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [webcuahangthethao] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [webcuahangthethao] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [webcuahangthethao] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [webcuahangthethao] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [webcuahangthethao] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [webcuahangthethao] SET  MULTI_USER 
GO
ALTER DATABASE [webcuahangthethao] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [webcuahangthethao] SET DB_CHAINING OFF 
GO
ALTER DATABASE [webcuahangthethao] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [webcuahangthethao] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [webcuahangthethao] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [webcuahangthethao] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [webcuahangthethao] SET QUERY_STORE = ON
GO
ALTER DATABASE [webcuahangthethao] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [webcuahangthethao]
GO
/****** Object:  Table [dbo].[MEMBER]    Script Date: 03/11/2024 11:54:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MEMBER](
	[member_id] [int] IDENTITY(1,1) NOT NULL,
	[member_name] [nvarchar](100) NULL,
	[member_username] [nvarchar](50) NOT NULL,
	[member_pass] [nvarchar](32) NULL,
	[dia_chi] [nvarchar](50) NULL,
	[member_phone] [nvarchar](30) NULL,
	[member_email] [nvarchar](50) NOT NULL,
	[ngay_sinh] [datetime] NULL,
	[ngay_cap_nhap] [datetime] NULL,
	[gioi_tinh] [tinyint] NULL,
	[tich_diem] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[member_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[member_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDER_DETAIL]    Script Date: 03/11/2024 11:54:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDER_DETAIL](
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[product_price] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDERS]    Script Date: 03/11/2024 11:54:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDERS](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[order_date] [date] NOT NULL,
	[order_status] [tinyint] NOT NULL,
	[product_price] [decimal](10, 2) NOT NULL,
	[total_price] [decimal](10, 2) NOT NULL,
	[member_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT]    Script Date: 03/11/2024 11:54:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [nvarchar](255) NOT NULL,
	[product_price] [decimal](10, 2) NOT NULL,
	[product_size] [nvarchar](50) NULL,
	[product_color] [nvarchar](50) NULL,
	[product_quantity] [int] NOT NULL,
	[description] [nvarchar](250) NULL,
	[product_image] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUAN_TRI]    Script Date: 03/11/2024 11:54:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUAN_TRI](
	[admin_username] [nvarchar](100) NOT NULL,
	[admin_pass] [nvarchar](255) NOT NULL,
	[admin_status] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[admin_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REVIEW]    Script Date: 03/11/2024 11:54:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REVIEW](
	[review_id] [int] IDENTITY(1,1) NOT NULL,
	[rating] [tinyint] NOT NULL,
	[comment] [nvarchar](250) NULL,
	[member_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[review_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MEMBER] ADD  DEFAULT (getdate()) FOR [ngay_cap_nhap]
GO
ALTER TABLE [dbo].[MEMBER] ADD  DEFAULT ((0)) FOR [tich_diem]
GO
ALTER TABLE [dbo].[ORDER_DETAIL]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[ORDERS] ([order_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ORDER_DETAIL]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[PRODUCT] ([product_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD FOREIGN KEY([member_id])
REFERENCES [dbo].[MEMBER] ([member_id])
GO
ALTER TABLE [dbo].[REVIEW]  WITH CHECK ADD FOREIGN KEY([member_id])
REFERENCES [dbo].[MEMBER] ([member_id])
GO
ALTER TABLE [dbo].[REVIEW]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[PRODUCT] ([product_id])
GO
ALTER TABLE [dbo].[REVIEW]  WITH CHECK ADD CHECK  (([rating]>=(1) AND [rating]<=(5)))
GO
USE [master]
GO
ALTER DATABASE [webcuahangthethao] SET  READ_WRITE 
GO
