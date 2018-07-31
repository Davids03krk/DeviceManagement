CREATE TABLE [dbo].[GATEWAY] (
    [IdDevice] INT           NOT NULL,
    [Ip]       NVARCHAR (15) NOT NULL,
    [Port]     NVARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([IdDevice] ASC),
    CONSTRAINT [FK_GATEWAY_DEVICE] FOREIGN KEY ([IdDevice]) REFERENCES [dbo].[DEVICE] ([IdDevice])
);

