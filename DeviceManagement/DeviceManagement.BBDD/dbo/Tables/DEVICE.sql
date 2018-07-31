CREATE TABLE [dbo].[DEVICE] (
    [IdDevice]     INT            NOT NULL,
    [SerialNumber] NVARCHAR (100) NOT NULL,
    [Brand]        NVARCHAR (100) NULL,
    [Model]        NVARCHAR (100) NULL,
    [IdDeviceType] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([IdDevice] ASC),
    CONSTRAINT [FK_DEVICE_DEVICETYPE] FOREIGN KEY ([IdDeviceType]) REFERENCES [dbo].[DEVICE_TYPE] ([IdDeviceType])
);



