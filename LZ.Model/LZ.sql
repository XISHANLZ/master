USE [LZ]
GO
/****** Object:  Table [dbo].[Wage]    Script Date: 01/13/2020 20:21:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Wage](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[UserName] [bigint] NULL,
	[Month] [datetime] NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Total] [decimal](18, 2) NULL,
	[Base] [decimal](18, 2) NULL,
	[Achievements] [decimal](18, 2) NULL,
	[AgeWage] [decimal](18, 2) NULL,
	[Other] [decimal](18, 2) NULL,
	[MaternityInsurancePrivate] [decimal](18, 2) NULL,
	[EndowmentInsurancePrivate] [decimal](18, 2) NULL,
	[MedicalInsurancePrivate] [decimal](18, 2) NULL,
	[UnemploymentInsurancePrivate] [decimal](18, 2) NULL,
	[EmploymentInjuryInsurancePrivate] [decimal](18, 2) NULL,
	[AccumulationFundPrivate] [decimal](18, 2) NULL,
	[AccumulationFundCompany] [decimal](18, 2) NULL,
	[MaternityInsuranceCompany] [decimal](18, 2) NULL,
	[EndowmentInsuranceCompany] [decimal](18, 2) NULL,
	[MedicalInsuranceCompany] [decimal](18, 2) NULL,
	[UnemploymentInsurance1] [decimal](18, 2) NULL,
	[EmploymentInjuryInsurance1] [decimal](18, 2) NULL,
	[TotalReduction] [decimal](18, 2) NULL,
	[ToTalCompany] [decimal](18, 2) NULL,
	[ActualPayment] [decimal](18, 2) NULL,
	[UpdateTime] [datetime] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUserID] [bigint] NOT NULL,
	[CreateUserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Wage] PRIMARY KEY CLUSTERED 
(
	[UpdateTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'绩效工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'Achievements'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年龄工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'AgeWage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生育保险' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'MaternityInsurancePrivate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'养老保险' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'EndowmentInsurancePrivate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'医疗保险' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'MedicalInsurancePrivate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'失业保险' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'UnemploymentInsurancePrivate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工伤保险' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'EmploymentInjuryInsurancePrivate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公积金-私人部分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'AccumulationFundPrivate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公积金-公司部分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'AccumulationFundCompany'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生育保险-公司部分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'MaternityInsuranceCompany'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'养老保险-公司部分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'EndowmentInsuranceCompany'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'医疗保险-公司部分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'MedicalInsuranceCompany'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'失业保险-公司部分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'UnemploymentInsurance1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工伤保险-公司部分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'EmploymentInjuryInsurance1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总共减少（五险一金私人部分相加）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'TotalReduction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司总缴' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'ToTalCompany'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际发放给员工工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wage', @level2type=N'COLUMN',@level2name=N'ActualPayment'
GO
/****** Object:  Table [dbo].[User_Role_Relation]    Script Date: 01/13/2020 20:21:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Role_Relation](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[UserId] [bigint] NULL,
	[RoleId] [bigint] NULL,
	[CreateUserId] [bigint] NULL,
 CONSTRAINT [PK_User_Role_Relation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User_Role_Relation] ON
INSERT [dbo].[User_Role_Relation] ([ID], [CreateTime], [UpdateTime], [UserId], [RoleId], [CreateUserId]) VALUES (1, CAST(0x0000AB3E009A0441 AS DateTime), CAST(0x0000AB3E009A0441 AS DateTime), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[User_Role_Relation] OFF
/****** Object:  Table [dbo].[User]    Script Date: 01/13/2020 20:21:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Account] [varchar](50) NOT NULL,
	[PassWord] [varchar](255) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[CreateUserId] [bigint] NULL,
	[CreateUserName] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([ID], [Name], [Account], [PassWord], [CreateTime], [UpdateTime], [CreateUserId], [CreateUserName]) VALUES (1, N'管理员', N'admin', N'admin', CAST(0x0000AB4100F5FB23 AS DateTime), CAST(0x0000AB4100F5FB23 AS DateTime), 1, N'管理员')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 01/13/2020 20:21:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[CreateUserId] [bigint] NOT NULL,
	[CreateUserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login_Log]    Script Date: 01/13/2020 20:21:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login_Log](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[LoginTime] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Login_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Login_Log', @level2type=N'COLUMN',@level2name=N'LoginTime'
GO
/****** Object:  Table [dbo].[Login_Info]    Script Date: 01/13/2020 20:21:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login_Info](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[UserRole] [varchar](2000) NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NULL,
	[LastLoginTime] [datetime] NULL,
 CONSTRAINT [PK_Login_Info] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Login_Info_CreateTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[Login_Info] ADD  CONSTRAINT [DF_Login_Info_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_Login_Info_UpdateTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[Login_Info] ADD  CONSTRAINT [DF_Login_Info_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
/****** Object:  Default [DF_Login_Info_LastLoginTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[Login_Info] ADD  CONSTRAINT [DF_Login_Info_LastLoginTime]  DEFAULT (getdate()) FOR [LastLoginTime]
GO
/****** Object:  Default [DF_Login_Log_LoginTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[Login_Log] ADD  CONSTRAINT [DF_Login_Log_LoginTime]  DEFAULT (getdate()) FOR [LoginTime]
GO
/****** Object:  Default [DF_Role_CreateTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_Role_UpdateTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
/****** Object:  Default [DF_User_CreateTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_User_UpdateTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
/****** Object:  Default [DF_User_Role_Relation_CreateTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[User_Role_Relation] ADD  CONSTRAINT [DF_User_Role_Relation_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_User_Role_Relation_UpdateTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[User_Role_Relation] ADD  CONSTRAINT [DF_User_Role_Relation_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
/****** Object:  Default [DF_Wage_UpdateTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[Wage] ADD  CONSTRAINT [DF_Wage_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
/****** Object:  Default [DF_Wage_CreateTime]    Script Date: 01/13/2020 20:21:02 ******/
ALTER TABLE [dbo].[Wage] ADD  CONSTRAINT [DF_Wage_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
