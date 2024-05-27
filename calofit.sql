USE [master]
GO
/****** Object:  Database [Calofit_DB]    Script Date: 27-May-24 9:20:32 PM ******/
CREATE DATABASE [Calofit_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Calofit_DB', FILENAME = N'D:\SQL_Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Calofit_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Calofit_DB_log', FILENAME = N'D:\SQL_Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Calofit_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Calofit_DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Calofit_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Calofit_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Calofit_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Calofit_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Calofit_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Calofit_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Calofit_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Calofit_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Calofit_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Calofit_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Calofit_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Calofit_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Calofit_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Calofit_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Calofit_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Calofit_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Calofit_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Calofit_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Calofit_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Calofit_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Calofit_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Calofit_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Calofit_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Calofit_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Calofit_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Calofit_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Calofit_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Calofit_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Calofit_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Calofit_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Calofit_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Calofit_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [Calofit_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Calofit_DB]
GO
/****** Object:  Table [dbo].[Diet]    Script Date: 27-May-24 9:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[diet_name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Diet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 27-May-24 9:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[image_filename] [nvarchar](255) NULL,
	[image_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[image_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingredient_serving_sizes]    Script Date: 27-May-24 9:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingredient_serving_sizes](
	[serving_size_id] [int] IDENTITY(1,1) NOT NULL,
	[ingredient_id] [int] NOT NULL,
	[qty] [float] NOT NULL,
	[scale] [float] NOT NULL,
	[units] [nvarchar](50) NOT NULL,
	[grams] [float] NOT NULL,
	[description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[serving_size_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingredients]    Script Date: 27-May-24 9:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingredients](
	[ingredient_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[image_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ingredient_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 27-May-24 9:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[menu_name] [nvarchar](50) NOT NULL,
	[diet_id] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nutritions]    Script Date: 27-May-24 9:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nutritions](
	[ingredient_id] [int] NOT NULL,
	[calories] [float] NOT NULL,
	[fat] [float] NOT NULL,
	[sugar] [float] NOT NULL,
	[carbohydrates] [float] NOT NULL,
	[protein] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ingredient_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recipe_ingredients]    Script Date: 27-May-24 9:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recipe_ingredients](
	[recipe_ingredient_id] [int] IDENTITY(1,1) NOT NULL,
	[recipe_id] [int] NOT NULL,
	[ingredient_id] [int] NOT NULL,
	[serving_size_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[recipe_ingredient_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recipes]    Script Date: 27-May-24 9:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recipes](
	[recipe_id] [int] IDENTITY(1,1) NOT NULL,
	[recipe_name] [nvarchar](255) NOT NULL,
	[servings] [int] NOT NULL,
	[cook_time] [int] NOT NULL,
	[prep_time] [int] NOT NULL,
	[description] [nvarchar](max) NULL,
	[image_id] [int] NULL,
	[menu_id] [int] NOT NULL,
 CONSTRAINT [PK__recipes__3571ED9B587E0D9E] PRIMARY KEY CLUSTERED 
(
	[recipe_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[steps]    Script Date: 27-May-24 9:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[steps](
	[step_id] [int] IDENTITY(1,1) NOT NULL,
	[recipe_id] [int] NOT NULL,
	[step_number] [int] NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[image_filename] [nvarchar](255) NULL,
	[image_type] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[step_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ingredient_serving_sizes]  WITH CHECK ADD FOREIGN KEY([ingredient_id])
REFERENCES [dbo].[ingredients] ([ingredient_id])
GO
ALTER TABLE [dbo].[ingredients]  WITH CHECK ADD FOREIGN KEY([image_id])
REFERENCES [dbo].[Images] ([image_id])
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Diet] FOREIGN KEY([diet_id])
REFERENCES [dbo].[Diet] ([id])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Diet]
GO
ALTER TABLE [dbo].[Nutritions]  WITH CHECK ADD FOREIGN KEY([ingredient_id])
REFERENCES [dbo].[ingredients] ([ingredient_id])
GO
ALTER TABLE [dbo].[recipe_ingredients]  WITH CHECK ADD FOREIGN KEY([ingredient_id])
REFERENCES [dbo].[ingredients] ([ingredient_id])
GO
ALTER TABLE [dbo].[recipe_ingredients]  WITH CHECK ADD  CONSTRAINT [FK__recipe_in__recip__5441852A] FOREIGN KEY([recipe_id])
REFERENCES [dbo].[recipes] ([recipe_id])
GO
ALTER TABLE [dbo].[recipe_ingredients] CHECK CONSTRAINT [FK__recipe_in__recip__5441852A]
GO
ALTER TABLE [dbo].[recipe_ingredients]  WITH CHECK ADD FOREIGN KEY([serving_size_id])
REFERENCES [dbo].[ingredient_serving_sizes] ([serving_size_id])
GO
ALTER TABLE [dbo].[recipes]  WITH CHECK ADD  CONSTRAINT [FK_recipes_Images] FOREIGN KEY([image_id])
REFERENCES [dbo].[Images] ([image_id])
GO
ALTER TABLE [dbo].[recipes] CHECK CONSTRAINT [FK_recipes_Images]
GO
ALTER TABLE [dbo].[recipes]  WITH CHECK ADD  CONSTRAINT [FK_recipes_Menu] FOREIGN KEY([menu_id])
REFERENCES [dbo].[Menu] ([id])
GO
ALTER TABLE [dbo].[recipes] CHECK CONSTRAINT [FK_recipes_Menu]
GO
ALTER TABLE [dbo].[steps]  WITH CHECK ADD  CONSTRAINT [FK__steps__recipe_id__59063A47] FOREIGN KEY([recipe_id])
REFERENCES [dbo].[recipes] ([recipe_id])
GO
ALTER TABLE [dbo].[steps] CHECK CONSTRAINT [FK__steps__recipe_id__59063A47]
GO
USE [master]
GO
ALTER DATABASE [Calofit_DB] SET  READ_WRITE 
GO
