USE [GDD]
GO
/****** Object:  Table [dbo].[Action]    Script Date: 30/11/2021 11:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Action](
	[ActionID] [int] IDENTITY(1,1) NOT NULL,
	[ActionName] [nvarchar](30) NOT NULL,
	[ActionIcon] [nvarchar](100) NULL,
 CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Summary]    Script Date: 30/11/2021 11:21:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Summary](
	[SummaryID] [int] IDENTITY(1,1) NOT NULL,
	[SummaryDateGenerated] [datetime] NOT NULL,
	[SummaryDateWST] [datetime] NOT NULL,
	[SummaryDateString] [nchar](8) NOT NULL,
	[SummaryMaxTemp] [decimal](2, 0) NULL,
	[SummaryMinTemp] [decimal](2, 0) NULL,
	[SummaryGDDTotal] [decimal](2, 0) NULL,
	[SummaryApplication] [bit] NULL,
	[SummaryAction] [int] NULL,
 CONSTRAINT [PK_Summary] PRIMARY KEY CLUSTERED 
(
	[SummaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ActionSummary]    Script Date: 30/11/2021 11:21:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ActionSummary]
AS
select ActionID, ActionName, ActionIcon,
(SELECT TOP 1 SummaryDateWST FROM Summary WHERE SummaryAction = ActionID ORDER BY SummaryDateWST DESC) as ActionLastDate, 
DATEDIFF(DAY,(SELECT TOP 1 SummaryDateWST FROM Summary WHERE SummaryAction = ActionID ORDER BY SummaryDateWST DESC), GETDATE()) as ActionDaysAgo 
from Action
GO
/****** Object:  Table [dbo].[Temperatures]    Script Date: 30/11/2021 11:21:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temperatures](
	[ReadingKey] [int] IDENTITY(1,1) NOT NULL,
	[ReadingDateString] [nchar](8) NOT NULL,
	[ReadingDateTimeWST] [datetime] NOT NULL,
	[ReadingValue] [decimal](2, 0) NOT NULL,
 CONSTRAINT [PK_Temps] PRIMARY KEY CLUSTERED 
(
	[ReadingKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 30/11/2021 11:21:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Action] ON 
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionIcon]) VALUES (1, N'PGR Applied', N'images/pgr.png')
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionIcon]) VALUES (2, N'Mow', N'images/mow.png')
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionIcon]) VALUES (3, N'Fertilized', N'images/fert.png')
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionIcon]) VALUES (4, N'Soil Wetter', N'images/wetter.png')
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionIcon]) VALUES (5, N'Seaweed Secrets', N'images/seaweed.png')
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionIcon]) VALUES (6, N'Iron Chelate', N'images/iron.png')
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionIcon]) VALUES (7, N'Barricade', N'images/barricade.png')
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionIcon]) VALUES (8, N'Knife+', N'images/knife.png')
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionIcon]) VALUES (9, N'Protesyn', N'images/protesyn.png')
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionIcon]) VALUES (10, N'Baythroid', N'images/baythroid.png')
GO
INSERT [dbo].[Action] ([ActionID], [ActionName], [ActionIcon]) VALUES (11, N'Bifenthrin', N'images/bifenthrin.png')
GO
SET IDENTITY_INSERT [dbo].[Action] OFF
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON 
GO
INSERT [dbo].[UserInfo] ([UserId], [FirstName], [LastName], [UserName], [Email], [Password], [CreatedDate]) VALUES (1, N'Demo', N'User', N'DemoUser', N'demo@email.domain', N'demopassword', CAST(N'2020-09-15T02:48:52.640' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
GO
ALTER TABLE [dbo].[UserInfo] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
