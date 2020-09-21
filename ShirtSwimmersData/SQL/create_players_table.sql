USE [Shirtswimmers]
GO

/****** Object:  Table [dbo].[Players]    Script Date: 2020-09-21 12:42:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Players](
	[match_id] [bigint] NOT NULL,
	[player_slot] [int] NULL,
	[account_id] [bigint] NULL,
	[kills] [int] NULL,
	[deaths] [int] NULL,
	[assists] [int] NULL,
	[last_hits] [int] NULL,
	[denies] [int] NULL,
	[gold] [int] NULL,
	[gold_per_min] [int] NULL,
	[gold_spent] [int] NULL,
	[hero_damage] [int] NULL,
	[hero_healing] [int] NULL,
	[tower_damage] [int] NULL,
	[xp_per_min] [int] NULL,
	[personaname] [varchar](max) NULL,
	[isRadiant] [bit] NULL,
	[win] [int] NULL,
	[lose] [int] NULL,
	[total_gold] [int] NULL,
	[total_xp] [int] NULL,
	[kda] [int] NULL,
	[abandons] [int] NULL,
	[hero_id] [int] NULL,
	[item_0] [int] NULL,
	[item_1] [int] NULL,
	[item_2] [int] NULL,
	[item_3] [int] NULL,
	[item_4] [int] NULL,
	[item_5] [int] NULL,
	[item_neutral] [int] NULL,
	[backpack_0] [int] NULL,
	[backpack_1] [int] NULL,
	[backpack_2] [int] NULL,
	[party_size] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


