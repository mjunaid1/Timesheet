USE [TimesheetDatabase]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/9/2018 4:48:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[role] [int] NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company_Tbl]    Script Date: 3/9/2018 4:48:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_Tbl](
	[CompanyId] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[Created] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_Company_Tbl] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyEmployees]    Script Date: 3/9/2018 4:48:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyEmployees](
	[CompanyId] [bigint] NULL,
	[EmployeeId] [nvarchar](128) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project_Tbl]    Script Date: 3/9/2018 4:48:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project_Tbl](
	[ProjectId] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyId] [bigint] NULL,
	[ProjectName] [nvarchar](255) NULL,
	[Created] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_Project_Tbl] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [role]) VALUES (N'a087d45c-9e30-4e6f-a613-34db3b9bd0e5', N'umais20@yahoo.com', 0, N'ANxS/a44SgZYK47uWnB9Vd3fFBELKIuZYC7e7RsjxY7kLu5d2aJrGVQCOJ2oTp7LsQ==', N'738a40f1-c25c-4d9b-aad4-d625721fb288', NULL, 0, 0, NULL, 1, 0, N'umais20@yahoo.com', 1)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [role]) VALUES (N'ab92901d-2720-4aeb-91ba-73d1c8dc717f', N'yasir@gmail.com', 0, N'ABm+RWq7qTgpo1BJG2PZ/bXBBSh6ndtI+GV4GI4NgtfBDxVVaNlXUWsqmY2IkSzEAQ==', N'70b7f479-bd0b-40a3-95a8-70ae5d00e04c', NULL, 0, 0, NULL, 1, 0, N'yasir@gmail.com', 2)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [role]) VALUES (N'e73c7dad-b3aa-4e51-8803-239be3f4420c', N'hassaan03@gmail.com', 0, N'AMo99jqEAfWljC0Fu/iWWHaT1p3rb719nAXiVezN7Q2qgwoCHhIEuP9kWXPlIT43oQ==', N'd517ee14-85bb-4656-8b88-251b6ed16267', NULL, 0, 0, NULL, 1, 0, N'hassaan03@gmail.com', 2)
SET IDENTITY_INSERT [dbo].[Company_Tbl] ON 

INSERT [dbo].[Company_Tbl] ([CompanyId], [CompanyName], [Created], [CreatedBy]) VALUES (1, N'dsfsd', CAST(N'2018-03-09T09:50:31.000' AS DateTime), 1)
INSERT [dbo].[Company_Tbl] ([CompanyId], [CompanyName], [Created], [CreatedBy]) VALUES (2, N'sfgsdg', CAST(N'2018-03-09T09:51:17.000' AS DateTime), 1)
INSERT [dbo].[Company_Tbl] ([CompanyId], [CompanyName], [Created], [CreatedBy]) VALUES (3, N'ghfgh', CAST(N'2018-03-09T09:53:04.000' AS DateTime), 1)
INSERT [dbo].[Company_Tbl] ([CompanyId], [CompanyName], [Created], [CreatedBy]) VALUES (4, N'sffs', CAST(N'2018-03-09T10:52:32.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Company_Tbl] OFF
INSERT [dbo].[CompanyEmployees] ([CompanyId], [EmployeeId]) VALUES (2, N'e73c7dad-b3aa-4e51-8803-239be3f4420c')
INSERT [dbo].[CompanyEmployees] ([CompanyId], [EmployeeId]) VALUES (3, N'ab92901d-2720-4aeb-91ba-73d1c8dc717f')
INSERT [dbo].[CompanyEmployees] ([CompanyId], [EmployeeId]) VALUES (3, N'e73c7dad-b3aa-4e51-8803-239be3f4420c')
INSERT [dbo].[CompanyEmployees] ([CompanyId], [EmployeeId]) VALUES (3, N'ab92901d-2720-4aeb-91ba-73d1c8dc717f')
INSERT [dbo].[CompanyEmployees] ([CompanyId], [EmployeeId]) VALUES (3, N'e73c7dad-b3aa-4e51-8803-239be3f4420c')
SET IDENTITY_INSERT [dbo].[Project_Tbl] ON 

INSERT [dbo].[Project_Tbl] ([ProjectId], [CompanyId], [ProjectName], [Created], [CreatedBy]) VALUES (1, 1, N'course', NULL, NULL)
INSERT [dbo].[Project_Tbl] ([ProjectId], [CompanyId], [ProjectName], [Created], [CreatedBy]) VALUES (2, 4, N'TimeSheet', CAST(N'2018-03-09T16:41:59.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Project_Tbl] OFF
ALTER TABLE [dbo].[CompanyEmployees]  WITH CHECK ADD  CONSTRAINT [FK_CompanyEmployees_AspNetUsers] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[CompanyEmployees] CHECK CONSTRAINT [FK_CompanyEmployees_AspNetUsers]
GO
ALTER TABLE [dbo].[CompanyEmployees]  WITH CHECK ADD  CONSTRAINT [FK_CompanyEmployees_Company_Tbl] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company_Tbl] ([CompanyId])
GO
ALTER TABLE [dbo].[CompanyEmployees] CHECK CONSTRAINT [FK_CompanyEmployees_Company_Tbl]
GO
ALTER TABLE [dbo].[Project_Tbl]  WITH CHECK ADD  CONSTRAINT [FK_Project_Tbl_Company_Tbl] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company_Tbl] ([CompanyId])
GO
ALTER TABLE [dbo].[Project_Tbl] CHECK CONSTRAINT [FK_Project_Tbl_Company_Tbl]
GO
