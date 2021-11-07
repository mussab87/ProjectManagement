USE [master]
GO
/****** Object:  Database [ProjectManagementDB]    Script Date: 11/8/2021 12:44:29 AM ******/
CREATE DATABASE [ProjectManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ProjectManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ProjectManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProjectManagementDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectManagementDB] SET QUERY_STORE = OFF
GO
USE [ProjectManagementDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/8/2021 12:44:29 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11/8/2021 12:44:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/8/2021 12:44:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/8/2021 12:44:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/8/2021 12:44:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/8/2021 12:44:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/8/2021 12:44:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11/8/2021 12:44:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectPhaseLevelEvalTbl]    Script Date: 11/8/2021 12:44:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectPhaseLevelEvalTbl](
	[ProjectPhaseLevelEvalId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectPhaseLevelId] [int] NOT NULL,
	[ProjectPhaseLevelEvaluation] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[UpdatedBy] [nvarchar](200) NULL,
 CONSTRAINT [PK_ProjectPhaseLevelEvalTbl] PRIMARY KEY CLUSTERED 
(
	[ProjectPhaseLevelEvalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectPhaseLevelTbl]    Script Date: 11/8/2021 12:44:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectPhaseLevelTbl](
	[ProjectPhaseLevelId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectPhaseId] [int] NOT NULL,
	[ProjectPhaseLevelNameArabic] [nvarchar](200) NULL,
	[ProjectPhaseLevelNameEnglish] [nvarchar](200) NULL,
	[ProjectPhaseLevelStartDate] [datetime] NULL,
	[ProjectPhaseLevelEndDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[UpdatedBy] [nvarchar](200) NULL,
 CONSTRAINT [PK_ProjectPhaseLevelTbl] PRIMARY KEY CLUSTERED 
(
	[ProjectPhaseLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectPhaseTbl]    Script Date: 11/8/2021 12:44:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectPhaseTbl](
	[ProjectPhaseId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ProjectPhaseNameArabic] [nvarchar](500) NULL,
	[ProjectPhaseNameEnglish] [nvarchar](500) NULL,
	[ProjectPhaseStartDate] [datetime] NULL,
	[ProjectPhaseEndDate] [datetime] NULL,
	[ProjectPhaseCreatedDate] [datetime] NULL,
	[ProjectPhaseUpdatedDate] [datetime] NULL,
	[ProjectPhaseCreatedBy] [nvarchar](200) NULL,
	[ProjectPhaseUpdatedBy] [nvarchar](200) NULL,
 CONSTRAINT [PK_ProjectPhaseTbl] PRIMARY KEY CLUSTERED 
(
	[ProjectPhaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTbl]    Script Date: 11/8/2021 12:44:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTbl](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectNameEnglish] [nvarchar](500) NULL,
	[ProjectNameArabic] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[UpdatedBy] [nvarchar](200) NULL,
 CONSTRAINT [PK_ProjectTbl] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210809185052_InitialMigration', N'5.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210901193530_Extend', N'5.0.8')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'04e52732-49f9-476f-8642-195c908bdc92', N'Admin', N'ADMIN', N'95942f93-6bd8-4d91-85dc-05b9e15eab98')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'305962d4-4f28-443a-850a-a3686d90e5f5', N'User', N'USER', N'9b4fb400-bcc2-4f8f-af81-aa16e386b5c0')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 

INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (7, N'3ec322df-ec5e-4e65-b68c-799200fcba3c', N'Create Role', N'Create Role')
INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (8, N'3ec322df-ec5e-4e65-b68c-799200fcba3c', N'Edit Role', N'Edit Role')
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3ec322df-ec5e-4e65-b68c-799200fcba3c', N'04e52732-49f9-476f-8642-195c908bdc92')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd39fd195-6bfa-4370-acf4-e407b2fe6f8b', N'04e52732-49f9-476f-8642-195c908bdc92')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3ec322df-ec5e-4e65-b68c-799200fcba3c', N'305962d4-4f28-443a-850a-a3686d90e5f5')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd39fd195-6bfa-4370-acf4-e407b2fe6f8b', N'305962d4-4f28-443a-850a-a3686d90e5f5')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e535de90-e9ad-4ebc-bae2-122c2450f1f1', N'305962d4-4f28-443a-850a-a3686d90e5f5')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3ec322df-ec5e-4e65-b68c-799200fcba3c', N'admin', N'ADMIN', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEC9hr9Nu1bwaiBB5KG6ergA4kE2uWaq9oGcv3hNMcYZ06esezJmm4aA9kszWaPHDHw==', N'67ZLXIGXY7KR4I7I7V7RRMBJEPKTSD2I', N'3a90d7b7-ddc6-4350-b982-86da756a647a', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd39fd195-6bfa-4370-acf4-e407b2fe6f8b', N'test', N'TEST', N'test', N'TEST', 0, N'AQAAAAEAACcQAAAAEPIdDccnRemrGib99C7R3reqHUwPoQ1p/rOJD3XxYctxiTgE3jjjjfff31zCeh33wQ==', N'FCR3B7OQGQN7MS6I5LJGP6BV6TTEPAAK', N'bdcacc75-d7f7-4ba9-b489-e1ecdb3c28bf', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e535de90-e9ad-4ebc-bae2-122c2450f1f1', N'mussab', N'MUSSAB', N'mussab', N'MUSSAB', 0, N'AQAAAAEAACcQAAAAEEg451AwJ5uBxLcJW0eDQj1LnIx4zHZAfvwRc2F5kZoTxEo4txXMcak3VLM+6b+JwQ==', N'QXSITPFMAYLX5MHPIN32EMJFSZJXIP3J', N'8a7f3010-4d0e-41b3-b31d-c11b9e0c975d', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[ProjectPhaseLevelEvalTbl] ON 

INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (12, 12, 12, CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:42:20.563' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (13, 13, 5, CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:41:05.663' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (14, 14, 5, CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:40:31.607' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (15, 15, 0, CAST(N'2021-11-03T22:27:47.510' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (16, 16, 5, CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:40:00.347' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (17, 17, 0, CAST(N'2021-11-03T22:27:47.513' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (18, 18, 0, CAST(N'2021-11-03T22:27:47.517' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (19, 19, 0, CAST(N'2021-11-03T22:27:47.520' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (20, 20, 0, CAST(N'2021-11-03T22:27:47.520' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (21, 21, 0, CAST(N'2021-11-03T22:27:47.520' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (22, 22, 0, CAST(N'2021-11-03T22:27:47.523' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (23, 23, 0, CAST(N'2021-11-08T00:09:47.303' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (24, 24, 0, CAST(N'2021-11-08T00:09:47.313' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (25, 25, 0, CAST(N'2021-11-08T00:09:47.320' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (26, 26, 0, CAST(N'2021-11-08T00:09:47.320' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (27, 27, 0, CAST(N'2021-11-08T00:09:47.323' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (28, 28, 0, CAST(N'2021-11-08T00:09:47.323' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (29, 29, 0, CAST(N'2021-11-08T00:09:47.327' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (30, 30, 0, CAST(N'2021-11-08T00:09:47.330' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (31, 31, 0, CAST(N'2021-11-08T00:09:47.330' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (32, 32, 0, CAST(N'2021-11-08T00:09:47.337' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelEvalTbl] ([ProjectPhaseLevelEvalId], [ProjectPhaseLevelId], [ProjectPhaseLevelEvaluation], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (33, 33, 0, CAST(N'2021-11-08T00:09:47.340' AS DateTime), NULL, N'admin', NULL)
SET IDENTITY_INSERT [dbo].[ProjectPhaseLevelEvalTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectPhaseLevelTbl] ON 

INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (12, 9, N'التحليل', N'Analysis', NULL, NULL, CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:42:20.557' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (13, 9, N'المراجعة', N'Review', NULL, NULL, CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:41:05.663' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (14, 10, N'تصميم الواجهات', N'Screens Prototype', NULL, NULL, CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:40:31.603' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (15, 11, N'تصميم الهيكلية وقاعدة البيانات', N'Archetucure Analysis', NULL, NULL, CAST(N'2021-11-03T22:27:47.493' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (16, 11, N'المراجعة للهيكلية', N'Archetucure Review', NULL, NULL, CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:39:59.800' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (17, 12, N'تصميم وبرمجة الواجهات', N'Front End Development', NULL, NULL, CAST(N'2021-11-03T22:27:47.497' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (18, 12, N'برمجة الكود', N'Back End Development', NULL, NULL, CAST(N'2021-11-03T22:27:47.497' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (19, 13, N'تصميم حالات الاختبار', N'Test Cases Design', NULL, NULL, CAST(N'2021-11-03T22:27:47.500' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (20, 13, N'تنفيذ الاختبار', N'Test Execution', NULL, NULL, CAST(N'2021-11-03T22:27:47.500' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (21, 14, N'التطبيق والتنفيذ', N'Implementation and Execution', NULL, NULL, CAST(N'2021-11-03T22:27:47.503' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (22, 15, N'التسليم', N'Delivery', NULL, NULL, CAST(N'2021-11-03T22:27:47.503' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (23, 16, N'التحليل', N'Analysis', NULL, NULL, CAST(N'2021-11-08T00:09:47.270' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (24, 16, N'المراجعة', N'Review', NULL, NULL, CAST(N'2021-11-08T00:09:47.277' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (25, 17, N'تصميم الواجهات', N'Screens Prototype', NULL, NULL, CAST(N'2021-11-08T00:09:47.280' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (26, 18, N'تصميم الهيكلية وقاعدة البيانات', N'Archetucure Analysis', NULL, NULL, CAST(N'2021-11-08T00:09:47.280' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (27, 18, N'المراجعة للهيكلية', N'Archetucure Review', NULL, NULL, CAST(N'2021-11-08T00:09:47.283' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (28, 19, N'تصميم وبرمجة الواجهات', N'Front End Development', NULL, NULL, CAST(N'2021-11-08T00:09:47.287' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (29, 19, N'برمجة الكود', N'Back End Development', NULL, NULL, CAST(N'2021-11-08T00:09:47.290' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (30, 20, N'تصميم حالات الاختبار', N'Test Cases Design', NULL, NULL, CAST(N'2021-11-08T00:09:47.290' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (31, 20, N'تنفيذ الاختبار', N'Test Execution', NULL, NULL, CAST(N'2021-11-08T00:09:47.293' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (32, 21, N'التطبيق والتنفيذ', N'Implementation and Execution', NULL, NULL, CAST(N'2021-11-08T00:09:47.293' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId], [ProjectPhaseId], [ProjectPhaseLevelNameArabic], [ProjectPhaseLevelNameEnglish], [ProjectPhaseLevelStartDate], [ProjectPhaseLevelEndDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (33, 22, N'التسليم', N'Delivery', NULL, NULL, CAST(N'2021-11-08T00:09:47.297' AS DateTime), NULL, N'admin', NULL)
SET IDENTITY_INSERT [dbo].[ProjectPhaseLevelTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectPhaseTbl] ON 

INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (9, 4, N'مرحلة التحليل', N'Analysis Phase', CAST(N'2021-11-01T00:00:00.000' AS DateTime), CAST(N'2021-11-07T00:00:00.000' AS DateTime), CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:42:20.550' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (10, 4, N'مرحلة الواجهات', N'Prototype Phase', NULL, NULL, CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:40:31.597' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (11, 4, N'مرحلة البنية الهيكلية وتصميم قاعدة البيانات', N'Sofware Archetucure and DB Design Phase', NULL, NULL, CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:39:59.227' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (12, 4, N'مرحلة البرمجة والتطوير', N'Development Phase', NULL, NULL, CAST(N'2021-11-03T22:27:47.483' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (13, 4, N'مرحلة الاختبار', N'Testing Phase', NULL, NULL, CAST(N'2021-11-03T22:27:47.487' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (14, 4, N'مرحلة التنفيذ', N'Execution Phase', NULL, NULL, CAST(N'2021-11-03T22:27:47.487' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (15, 4, N'مرحلة التسليم', N'Delivery Phase', NULL, NULL, CAST(N'2021-11-03T22:27:47.487' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (16, 5, N'مرحلة التحليل', N'Analysis Phase', NULL, NULL, CAST(N'2021-11-08T00:09:47.137' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (17, 5, N'مرحلة الواجهات', N'Prototype Phase', NULL, NULL, CAST(N'2021-11-08T00:09:47.253' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (18, 5, N'مرحلة البنية الهيكلية وتصميم قاعدة البيانات', N'Sofware Archetucure and DB Design Phase', NULL, NULL, CAST(N'2021-11-08T00:09:47.260' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (19, 5, N'مرحلة البرمجة والتطوير', N'Development Phase', NULL, NULL, CAST(N'2021-11-08T00:09:47.260' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (20, 5, N'مرحلة الاختبار', N'Testing Phase', NULL, NULL, CAST(N'2021-11-08T00:09:47.263' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (21, 5, N'مرحلة التنفيذ', N'Execution Phase', NULL, NULL, CAST(N'2021-11-08T00:09:47.263' AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[ProjectPhaseTbl] ([ProjectPhaseId], [ProjectId], [ProjectPhaseNameArabic], [ProjectPhaseNameEnglish], [ProjectPhaseStartDate], [ProjectPhaseEndDate], [ProjectPhaseCreatedDate], [ProjectPhaseUpdatedDate], [ProjectPhaseCreatedBy], [ProjectPhaseUpdatedBy]) VALUES (22, 5, N'مرحلة التسليم', N'Delivery Phase', NULL, NULL, CAST(N'2021-11-08T00:09:47.267' AS DateTime), NULL, N'admin', NULL)
SET IDENTITY_INSERT [dbo].[ProjectPhaseTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectTbl] ON 

INSERT [dbo].[ProjectTbl] ([ProjectId], [ProjectNameEnglish], [ProjectNameArabic], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (4, N'English Path', N'مشروع الترجمة', CAST(N'2021-11-03T22:27:47.000' AS DateTime), CAST(N'2021-11-07T20:42:16.523' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ProjectTbl] ([ProjectId], [ProjectNameEnglish], [ProjectNameArabic], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (5, N'test', N'اختبار', CAST(N'2021-11-02T22:51:34.860' AS DateTime), NULL, N'admin', NULL)
SET IDENTITY_INSERT [dbo].[ProjectTbl] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 11/8/2021 12:44:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11/8/2021 12:44:29 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 11/8/2021 12:44:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 11/8/2021 12:44:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 11/8/2021 12:44:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 11/8/2021 12:44:29 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 11/8/2021 12:44:29 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ProjectPhaseLevelEvalTbl]  WITH CHECK ADD  CONSTRAINT [FK_ProjectPhaseLevelEvalTbl_ProjectPhaseLevelTbl] FOREIGN KEY([ProjectPhaseLevelId])
REFERENCES [dbo].[ProjectPhaseLevelTbl] ([ProjectPhaseLevelId])
GO
ALTER TABLE [dbo].[ProjectPhaseLevelEvalTbl] CHECK CONSTRAINT [FK_ProjectPhaseLevelEvalTbl_ProjectPhaseLevelTbl]
GO
ALTER TABLE [dbo].[ProjectPhaseLevelTbl]  WITH CHECK ADD  CONSTRAINT [FK_ProjectPhaseLevelTbl_ProjectPhaseTbl] FOREIGN KEY([ProjectPhaseId])
REFERENCES [dbo].[ProjectPhaseTbl] ([ProjectPhaseId])
GO
ALTER TABLE [dbo].[ProjectPhaseLevelTbl] CHECK CONSTRAINT [FK_ProjectPhaseLevelTbl_ProjectPhaseTbl]
GO
ALTER TABLE [dbo].[ProjectPhaseTbl]  WITH CHECK ADD  CONSTRAINT [FK_ProjectPhaseTbl_ProjectTbl] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[ProjectTbl] ([ProjectId])
GO
ALTER TABLE [dbo].[ProjectPhaseTbl] CHECK CONSTRAINT [FK_ProjectPhaseTbl_ProjectTbl]
GO
USE [master]
GO
ALTER DATABASE [ProjectManagementDB] SET  READ_WRITE 
GO
