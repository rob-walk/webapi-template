CREATE TABLE [dbo].[Eventlog]
(
	[EventlogId] BIGINT IDENTITY(1,1) NOT NULL,
    [Timestamp] [datetime] NOT NULL,
    [Level] [varchar](50) NOT NULL,
    [Logger] [varchar](255) NOT NULL,
    [Message] [varchar](max) NOT NULL,
    [Exception] [varchar](max) NULL,
	[Username] [varchar](255) NULL,
    [HostName] [varchar](255) NULL,
    
    CONSTRAINT [PK_Eventlog] PRIMARY KEY ([EventlogId]),
)

GO

CREATE INDEX [IX_Eventlog_TimeStamp] ON [dbo].[Eventlog] ([Timestamp])
