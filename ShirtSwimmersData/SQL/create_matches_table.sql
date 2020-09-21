USE [Shirtswimmers]
GO

/****** Object:  Table [dbo].[Matches]    Script Date: 2020-09-21 12:41:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Matches](
	[match_id] [bigint] NOT NULL,
	[dire_score] [int] NULL,
	[radiant_score] [int] NULL,
	[duration] [int] NULL,
	[game_mode] [int] NULL,
	[lobby_type] [int] NULL,
	[skill] [int] NULL,
	[start_time] [int] NULL,
	[tower_status_dire] [int] NULL,
	[tower_status_radiant] [int] NULL,
	[radiant_win] [bit] NULL,
	[patch] [int] NULL,
	[region] [int] NULL,
 CONSTRAINT [PK_Matches] PRIMARY KEY CLUSTERED 
(
	[match_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


